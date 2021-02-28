using System;
using System.Collections.Generic;
using System.Linq;

namespace TrueStepTerminal
{
	/// <summary>
	/// TrueStep native serial protocol implementation
	/// </summary>
	public class Serial : SerialProtocolBase
	{
		enum PARSE_STATES
		{
			IDLE,
			PREAMBLE,
			LENGTH,
			MESSAGEID,
			PAYLOAD,
			CHECKSUM
		};

		PARSE_STATES parseState;
		Queue<byte> parseBuffer = new Queue<byte>();
		int pBytes;
		int msgLength;
		int seq;

		public Serial()
		{
			base.PacketReceived += Serial_PacketReceived;
		}

		private void Serial_PacketReceived(object sender, byte[] packet)
		{
			var msgId = (Messages.MESSAGE_IDS)packet[1];
			switch (msgId)
			{
				case Messages.MESSAGE_IDS.PARAM_KP:
					Int16 kp = BitConverter.ToInt16(packet, 2);
					base.NotifyNewMessageReceived(msgId, kp);
					break;

				case Messages.MESSAGE_IDS.PARAM_KI:
					Int16 ki = BitConverter.ToInt16(packet, 2);
					base.NotifyNewMessageReceived(msgId, ki);
					break;

				case Messages.MESSAGE_IDS.PARAM_KD:
					Int16 kd = BitConverter.ToInt16(packet, 2);
					base.NotifyNewMessageReceived(msgId, kd);
					break;

				case Messages.MESSAGE_IDS.PARAM_CURRENT:
					byte current = packet[2];
					var res = Math.Ceiling(current * 6.5);
					base.NotifyNewMessageReceived(msgId, res);
					break;

				case Messages.MESSAGE_IDS.PARAM_STEPSIZE:
					byte stepSize = packet[2];
					base.NotifyNewMessageReceived(msgId, stepSize);
					break;

				case Messages.MESSAGE_IDS.PARAM_ENDIR:
					byte endir = packet[2];
					base.NotifyNewMessageReceived(msgId, endir);
					break;

				case Messages.MESSAGE_IDS.PARAM_MOTORDIR:
					byte motordir = packet[2];
					base.NotifyNewMessageReceived(msgId, motordir);
					break;

				case Messages.MESSAGE_IDS.VALUE_ANGLE:
					{
						float angle = BitConverter.ToSingle(packet, 2);
						base.NotifyNewMessageReceived(msgId, angle);
						break;
					}

				case Messages.MESSAGE_IDS.VALUE_ANGLE_ERR:
					{
						float angleErr = BitConverter.ToSingle(packet, 2);
						base.NotifyNewMessageReceived(msgId, angleErr);
						break;
					}

				case Messages.MESSAGE_IDS.VALUE_TUNING_PID:
					{
						var arrAng = packet.Skip(2).Take(4).ToArray();
						var arrAngErr = packet.Skip(2 + 4).Take(4).ToArray();
						float angle = BitConverter.ToSingle(arrAng, 0);
						float angleErr = BitConverter.ToSingle(arrAngErr, 0);

						base.NotifyNewMessageReceived(msgId, angle);
						base.NotifyNewMessageReceived(msgId, angleErr);
						break;
					}
			}
		}

		void ResetParser()
		{
			parseState = PARSE_STATES.IDLE;
			parseBuffer.Clear();
		}

		public override void Parse(byte data)
		{
			switch (parseState)
			{
				case PARSE_STATES.IDLE:
					if (data == 0xFE)
						parseState = PARSE_STATES.PREAMBLE;
					break;

				case PARSE_STATES.PREAMBLE:
					parseBuffer.Enqueue(data);
					pBytes = data & 0x0F;
					msgLength = pBytes + 3;
					parseState = PARSE_STATES.LENGTH;
					break;

				case PARSE_STATES.LENGTH:
					parseBuffer.Enqueue(data);
					if (pBytes > 0)
						parseState = PARSE_STATES.MESSAGEID;
					else
						parseState = PARSE_STATES.PAYLOAD;
					break;

				case PARSE_STATES.MESSAGEID:
					parseBuffer.Enqueue(data);
					pBytes--;

					if (pBytes < 1)
						parseState = PARSE_STATES.PAYLOAD;
					break;

				case PARSE_STATES.PAYLOAD:
					parseBuffer.Enqueue(data);
					parseState = PARSE_STATES.IDLE;

					byte[] packetBytes = parseBuffer.ToArray();

					byte crc_calc = CalculateCRC8(packetBytes, 0, msgLength - 1);

					if (crc_calc == data)
					{
						NotifyNewPacketReceived(packetBytes);
					}
					else
					{
						// Some error
					}

					ResetParser();
					break;

				default:
					break;
			}
		}


		public override byte[] GeneratePacket(byte[] data)
		{
			byte[] newPacket = new byte[data.Length + 3];

			newPacket[0] = 0xFE;
			newPacket[1] = (byte)((data.Length - 1) & 0x0F);
			newPacket[1] |= (byte)((seq++ << 4) & 0xF0);

			for (int i = 0; i < data.Length; i++)
				newPacket[i + 2] = data[i];

			newPacket[data.Length + 2] = CalculateCRC8(newPacket, 1, data.Length + 2);

			return newPacket;
		}


		byte CalculateCRC8(byte[] data, int offset, int length)
		{
			byte crc = 0xff;
			int i, j;

			for (i = offset; i < length; i++)
			{
				crc ^= data[i];
				for (j = 0; j < 8; j++)
				{
					if ((crc & 0x80) != 0)
						crc = (byte)((crc << 1) ^ 0x31);
					else
						crc <<= 1;
				}
			}

			return crc;
		}

	}
}
