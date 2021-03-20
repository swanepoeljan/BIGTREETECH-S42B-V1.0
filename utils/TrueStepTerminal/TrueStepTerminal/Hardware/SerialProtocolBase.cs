using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrueStepTerminal
{
    /// <summary>
    /// Base class for all serial protocols
    /// </summary>
    public abstract class SerialProtocolBase
    {
        public delegate void PacketReceived_EventHandler(object sender, byte[] packet);
        public delegate void PacketError_EventHandler(object sender, string errMessage);
        public delegate void MessageReceived_EventHandler(object sender, Messages.MESSAGE_IDS msgId, object value);

        public event PacketReceived_EventHandler PacketReceived;
        public event PacketError_EventHandler PacketError;
        public event MessageReceived_EventHandler MessageReceived;

        public abstract byte[] GeneratePacket(byte[] data);

        public abstract void Parse(byte receivedByte);

        public void NotifyNewPacketReceived(byte[] data)
        {
			PacketReceived?.Invoke(this, data);
		}

        public void NotifyNewMessageReceived(Messages.MESSAGE_IDS id, object data)
        {
			MessageReceived?.Invoke(this, id, data);
		}

        public void NotifyNewPacketError(string errMessage)
        {
            PacketError_EventHandler handler = PacketError;
            if (handler != null)
                handler(this, errMessage);
        }
    }
}
