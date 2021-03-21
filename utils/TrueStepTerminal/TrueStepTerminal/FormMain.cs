using ScottPlot;
using System;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using TrueStepTerminal.Controls;
using TrueStepTerminal.Helper;

namespace TrueStepTerminal
{
	public partial class FormMain : Form
	{
		delegate void UpdateParametersCallBack(string name, string value);
		delegate void UpdateValuesCallBack(string name, double value);

		Settings AppSettings = new Settings();
		SerialPort sPort;
		SerialProtocolBase serialMessages;
		Byte[] buffer = new byte[100];
		private System.Threading.Timer timerRenderScottPlot;
		Parameters driverParameters;

		private readonly PidAutotuneCalc pidAutotuneClass;

		public FormMain()
		{
			InitializeComponent();

			pidAutotuneClass = new PidAutotuneCalc(2000);
			ScottPlotInit(formsPlot1, pidAutotuneClass.AngleDouble, pidAutotuneClass.AngleErrorDouble);
		}

		private void FrmMain_Load(object sender, EventArgs e)
		{
			AppSettings.LoadFromFile();

			sPort = new SerialPort
			{
				PortName = AppSettings.Connection.Port,
				BaudRate = AppSettings.Connection.Baud
			};
			sPort.DataReceived += SPort_DataReceived;

			driverParameters = new Parameters();

			//Bind list to dataGrid
			dataGridViewParameters.DataSource = driverParameters.Items;
			dataGridViewParameters.Columns[0].ReadOnly = true;
			dataGridViewParameters.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

			// Update GUI Settings
			cmbPortName.Text = AppSettings.Connection.Port;
			cmbPortBaud.Text = AppSettings.Connection.Baud.ToString();
			cmbPortBaud.Items.AddRange(new string[] { "9600", "19200", "38400", "57600", "115200" });

			// Create tooltips
			toolTips.SetToolTip(chkBTTProtocol, "Use original BTT protocol. Only works with original firmware!");
			toolTips.SetToolTip(chkWriteToFlash, "Write parameters to flash memory as opposed to RAM");

			UpdateEnableControls();
		}

		private void UpdateEnableControls()
		{
			var portOpened = sPort.IsOpen;
			grpControls.Enabled
				= grpOverview.Enabled
				= grpParameters.Enabled
				= portOpened;
			cmbPortName.Enabled
				= cmbPortBaud.Enabled
				= chkBTTProtocol.Enabled
				= !portOpened;
		}

		private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (chkTuningEnable.Enabled)
				chkTuningEnable.Enabled = false;

			if (sPort.IsOpen)
				sPort.Close();

			// Save previous session settings
			AppSettings.WriteToFile();
		}

		private void EnabledControlContents(Control panel, bool enabled)
		{
			foreach (Control ctrl in panel.Controls)
			{
				if (ctrl is Panel)
					EnabledControlContents(ctrl, enabled);
				else
					ctrl.Enabled = enabled;
			}
		}

		private void UpdateParameters(string name, string value)
		{
			if (InvokeRequired)
			{
				var d = new UpdateParametersCallBack(UpdateParameters);
				Invoke(d, name, value);
			}
			else
			{
				// If entry already exist then only update value
				if (driverParameters.Items.Any(o => o.Name == name))
					driverParameters.Items.First(o => o.Name == name).ValueStr = value;
				else
					// Add new entry 
					driverParameters.Items.Add(new Parameters.ParameterItem(name, value));

				dataGridViewParameters.Refresh();
			}
		}

		private void UpdateValues(string name, double value)
		{
			return;
			if (this.InvokeRequired)
			{
				var d = new UpdateValuesCallBack(UpdateValues);
				this.Invoke(d, name, value);
			}
			else
			{
				if (name == "angle")
				{
					// Logging needs to happen fast and GUI updates slows it down
					if (chkTuningEnable.Checked)
						LogToFile(value);
					else
						lblAngleValue.Text = value.ToString("F");

				}
				if (name == "angleErr")
					lblAngleError.Text = value.ToString("F");
			}
		}

		private void LogToFile(double val)
		{
			using (StreamWriter file =
			new StreamWriter(@"TuneLog.txt", true))
			{
				file.WriteLine(val.ToString());
			}
		}

		private void SerialMessages_MessageReceived(object sender, Messages.MESSAGE_IDS msgId, object value)
		{
			switch (msgId)
			{
				case Messages.MESSAGE_IDS.PARAM_KP:
					UpdateParameters("Kp", value.ToString());
					break;

				case Messages.MESSAGE_IDS.PARAM_KI:
					UpdateParameters("Ki", value.ToString());
					break;

				case Messages.MESSAGE_IDS.PARAM_KD:
					UpdateParameters("Kd", value.ToString());
					break;

				case Messages.MESSAGE_IDS.PARAM_CURRENT:
					UpdateParameters("Current", value.ToString());
					break;

				case Messages.MESSAGE_IDS.PARAM_STEPSIZE:
					UpdateParameters("Step Size", value.ToString());
					break;

				case Messages.MESSAGE_IDS.PARAM_ENDIR:
					UpdateParameters("EN Pin", value.ToString());
					break;

				case Messages.MESSAGE_IDS.PARAM_MOTORDIR:
					UpdateParameters("Motor Direction", value.ToString());
					break;

				case Messages.MESSAGE_IDS.VALUE_ANGLE:
					{
						UpdateValues("angle", (float)value);
						break;
					}

				case Messages.MESSAGE_IDS.VALUE_ANGLE_ERR:
					{
						UpdateValues("angleErr", (float)value);
						break;
					}
			}
		}

		private void SerialMessages_PacketError(object sender, string errMessage)
		{
			MessageBox.Show(errMessage, "Packet Error");
		}

		private void SPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
		{
			int bytesToRead = sPort.BytesToRead;
			byte[] receivedBytes = new byte[bytesToRead];

			sPort.Read(receivedBytes, 0, bytesToRead);

			for (int i = 0; i < bytesToRead; i++)
				serialMessages.Parse(receivedBytes[i]);
		}

		private void BtnConnect_Click(object sender, EventArgs e)
		{
			int baud;

			try
			{
				if (sPort.IsOpen)
				{
					sPort.Close();
					btnConnect.Text = "Connect";
				}
				else
				{
					// Update connection settings
					AppSettings.Connection.Port = cmbPortName.Text;
					if (int.TryParse(cmbPortBaud.Text, out baud))
						AppSettings.Connection.Baud = baud;
					else
						AppSettings.Connection.Baud = 115200;        // default incase there is an issue

					// Select which serial protocol to use
					if (chkBTTProtocol.Checked)
						serialMessages = new SerialBTT();
					else
						serialMessages = new Serial();

					serialMessages.PacketError += SerialMessages_PacketError;
					serialMessages.MessageReceived += SerialMessages_MessageReceived;

					sPort.PortName = AppSettings.Connection.Port;
					sPort.BaudRate = AppSettings.Connection.Baud;
					sPort.Open();
					btnConnect.Text = "Disconnect";
				}
				UpdateEnableControls();
			}
			catch
			{
				MessageBox.Show("Could not connect!", "Connection Problem");
			}
		}

		private void cmbPortName_DropDown(object sender, EventArgs e)
		{
			cmbPortName.Items.Clear();
			cmbPortName.Items.AddRange(SerialPort.GetPortNames());
		}

		private void btnControlStep_Click(object sender, EventArgs e)
		{
			// Check if serial protocol object exist
			if (serialMessages == null)
				return;

			Messages.Msg_Command cmdStep = new Messages.Msg_Command { command = Messages.COMMAND_TYPES.STEP };

			cmdStep.param1 = chkChangeDirection.Checked == true ? (byte)1 : (byte)0;

			byte[] msgStep = serialMessages.GeneratePacket(cmdStep.Serialize());

			if (sPort.IsOpen)
				sPort.Write(msgStep, 0, msgStep.Length);

			// Hierdie was vir die Fine Step, sal dit later weer gebruik
			/* 
			int loops = int.Parse(cmbStepLoop.Text);
			UInt16 stepSize = UInt16.Parse(cmbStepSize.Text); //1800;
			UInt16 current = UInt16.Parse(cmbStepCurrent.Text); //500;

			Messages.Msg_Command cmd;
			if (cmbStepDirection.Text == "CCW")
				cmd = new Messages.Msg_Command 
				{ 
					command = Messages.COMMAND_TYPES.STEP_FORWARD, 
					param1 = (byte)(stepSize >> 8), 
					param2 = (byte)(stepSize & 0x00FF),
					param3 = (byte)(current >> 8),
					param4 = (byte)(current & 0x00FF)
				};
			else
				cmd = new Messages.Msg_Command 
				{ 
					command = Messages.COMMAND_TYPES.STEP_BACK, 
					param1 = (byte)(stepSize >> 8), 
					param2 = (byte)(stepSize & 0x00FF),
					param3 = (byte)(current >> 8),
					param4 = (byte)(current & 0x00FF)
				};

			byte[] msg = serialMessages.GeneratePacket(cmd.Serialize());

			for (int i = 0; i < loops; i++)
			{
				if (sPort.IsOpen)
					sPort.Write(msg, 0, msg.Length);

				System.Threading.Thread.Sleep(10);
			}
			*/
		}

		private void btnControlGetAngle_Click(object sender, EventArgs e)
		{
			// Check if serial protocol object exist
			if (serialMessages == null)
				return;

			Messages.Msg_GetValue getAng = new Messages.Msg_GetValue { value = Messages.VALUE_TYPES.ANGLE };
			Messages.Msg_GetValue getAngErr = new Messages.Msg_GetValue { value = Messages.VALUE_TYPES.ANGERROR };


			byte[] msgAng = serialMessages.GeneratePacket(getAng.Serialize());
			byte[] msgAngErr = serialMessages.GeneratePacket(getAngErr.Serialize());


			if (sPort.IsOpen)
			{
				sPort.Write(msgAng, 0, msgAng.Length);
				sPort.Write(msgAngErr, 0, msgAngErr.Length);
			}
		}

		private void btnReadParameters_Click(object sender, EventArgs e)
		{
			// Check if serial protocol object exist
			if (serialMessages == null)
				return;

			Messages.Msg_GetParam getParamKp = new Messages.Msg_GetParam { param = Messages.PARAMETER_TYPES.KP };
			Messages.Msg_GetParam getParamKi = new Messages.Msg_GetParam { param = Messages.PARAMETER_TYPES.KI };
			Messages.Msg_GetParam getParamKd = new Messages.Msg_GetParam { param = Messages.PARAMETER_TYPES.KD };
			Messages.Msg_GetParam getParamCurrent = new Messages.Msg_GetParam { param = Messages.PARAMETER_TYPES.CURRENT };
			Messages.Msg_GetParam getParamStepSize = new Messages.Msg_GetParam { param = Messages.PARAMETER_TYPES.STEPSIZE };
			Messages.Msg_GetParam getParamENDir = new Messages.Msg_GetParam { param = Messages.PARAMETER_TYPES.ENDIR };
			Messages.Msg_GetParam getParamMotorDir = new Messages.Msg_GetParam { param = Messages.PARAMETER_TYPES.MOTORDIR };

			byte[] msgKp = serialMessages.GeneratePacket(getParamKp.Serialize());
			byte[] msgKi = serialMessages.GeneratePacket(getParamKi.Serialize());
			byte[] msgKd = serialMessages.GeneratePacket(getParamKd.Serialize());
			byte[] msgCurrent = serialMessages.GeneratePacket(getParamCurrent.Serialize());
			byte[] msgStepSize = serialMessages.GeneratePacket(getParamStepSize.Serialize());
			byte[] msgENDir = serialMessages.GeneratePacket(getParamENDir.Serialize());
			byte[] msgMotorDir = serialMessages.GeneratePacket(getParamMotorDir.Serialize());

			if (sPort.IsOpen)
			{
				// Short delays here are for compatibility with BTT serial protocol, which is rather slow
				sPort.Write(msgKp, 0, msgKp.Length);
				System.Threading.Thread.Sleep(50);

				sPort.Write(msgKi, 0, msgKi.Length);
				System.Threading.Thread.Sleep(50);

				sPort.Write(msgKd, 0, msgKd.Length);
				System.Threading.Thread.Sleep(50);

				sPort.Write(msgCurrent, 0, msgCurrent.Length);
				System.Threading.Thread.Sleep(50);

				sPort.Write(msgStepSize, 0, msgStepSize.Length);
				System.Threading.Thread.Sleep(50);

				sPort.Write(msgENDir, 0, msgENDir.Length);
				System.Threading.Thread.Sleep(50);

				sPort.Write(msgMotorDir, 0, msgMotorDir.Length);
				System.Threading.Thread.Sleep(50);
			}
		}

		private void btnWriteParameters_Click(object sender, EventArgs e)
		{
			// Check if serial protocol object exist
			if (serialMessages == null)
				return;

			try
			{
				Int16 valKp = Int16.Parse(driverParameters.Items.First(o => o.Name == "Kp").ValueStr);
				Int16 valKi = Int16.Parse(driverParameters.Items.First(o => o.Name == "Ki").ValueStr);
				Int16 valKd = Int16.Parse(driverParameters.Items.First(o => o.Name == "Kd").ValueStr);
				Int16 valCurrent = (Int16)Math.Ceiling(Int16.Parse(driverParameters.Items.First(o => o.Name == "Current").ValueStr) / 6.5);
				Int16 valStepSize = Int16.Parse(driverParameters.Items.First(o => o.Name == "Step Size").ValueStr);
				Int16 valENDir = Int16.Parse(driverParameters.Items.First(o => o.Name == "EN Pin").ValueStr);
				Int16 valMotorDir = Int16.Parse(driverParameters.Items.First(o => o.Name == "Motor Direction").ValueStr);

				Messages.Msg_SetParam setParamKp = new Messages.Msg_SetParam { param = Messages.PARAMETER_TYPES.KP, value = valKp };
				Messages.Msg_SetParam setParamKi = new Messages.Msg_SetParam { param = Messages.PARAMETER_TYPES.KI, value = valKi };
				Messages.Msg_SetParam setParamKd = new Messages.Msg_SetParam { param = Messages.PARAMETER_TYPES.KD, value = valKd };
				Messages.Msg_SetParam setParamCurrent = new Messages.Msg_SetParam { param = Messages.PARAMETER_TYPES.CURRENT, value = valCurrent };
				Messages.Msg_SetParam setParamStepSize = new Messages.Msg_SetParam { param = Messages.PARAMETER_TYPES.STEPSIZE, value = valStepSize };
				Messages.Msg_SetParam setParamENDir = new Messages.Msg_SetParam { param = Messages.PARAMETER_TYPES.ENDIR, value = valENDir };
				Messages.Msg_SetParam setParamMotorDir = new Messages.Msg_SetParam { param = Messages.PARAMETER_TYPES.MOTORDIR, value = valMotorDir };

				byte[] msgKp = serialMessages.GeneratePacket(setParamKp.Serialize());
				byte[] msgKi = serialMessages.GeneratePacket(setParamKi.Serialize());
				byte[] msgKd = serialMessages.GeneratePacket(setParamKd.Serialize());
				byte[] msgCurrent = serialMessages.GeneratePacket(setParamCurrent.Serialize());
				byte[] msgStepSize = serialMessages.GeneratePacket(setParamStepSize.Serialize());
				byte[] msgENDir = serialMessages.GeneratePacket(setParamENDir.Serialize());
				byte[] msgMotorDir = serialMessages.GeneratePacket(setParamMotorDir.Serialize());

				if (sPort.IsOpen)
				{
					// Short delays here are for compatibility with BTT serial protocol, which is rather slow
					sPort.Write(msgKp, 0, msgKp.Length);
					Thread.Sleep(100);

					sPort.Write(msgKi, 0, msgKi.Length);
					Thread.Sleep(100);

					sPort.Write(msgKd, 0, msgKd.Length);
					Thread.Sleep(100);

					sPort.Write(msgCurrent, 0, msgCurrent.Length);
					Thread.Sleep(100);

					sPort.Write(msgStepSize, 0, msgStepSize.Length);
					Thread.Sleep(100);

					sPort.Write(msgENDir, 0, msgENDir.Length);
					Thread.Sleep(100);

					sPort.Write(msgMotorDir, 0, msgMotorDir.Length);
					Thread.Sleep(100);

					if (chkWriteToFlash.Enabled & chkWriteToFlash.Checked)
					{
						Messages.Msg_Command cmdFlashSave = new Messages.Msg_Command { command = Messages.COMMAND_TYPES.STORAGE_SAVE };
						byte[] msgFlashSave = serialMessages.GeneratePacket(cmdFlashSave.Serialize());
						sPort.Write(msgFlashSave, 0, msgFlashSave.Length);
					}
				}
			}
			catch
			{
				MessageBox.Show("Something went wrong while trying to write parameters!", "Writing Error");
			}
		}


		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void rdOpenLoop_CheckedChanged(object sender, EventArgs e)
		{
			// Check if serial protocol object exist
			if (serialMessages == null)
				return;

			if (rdOpenLoop.Checked)
			{
				Messages.Msg_Command cmdModeOpen = new Messages.Msg_Command { command = Messages.COMMAND_TYPES.MODE_OPENLOOP };
				byte[] msgModeOpen = serialMessages.GeneratePacket(cmdModeOpen.Serialize());
				if (sPort.IsOpen)
					sPort.Write(msgModeOpen, 0, msgModeOpen.Length);
			}
		}

		private void rdClosedLoop_CheckedChanged(object sender, EventArgs e)
		{
			// Check if serial protocol object exist
			if (serialMessages == null)
				return;

			if (rdClosedLoop.Checked)
			{
				Messages.Msg_Command cmdModeClose = new Messages.Msg_Command { command = Messages.COMMAND_TYPES.MODE_CLOSELOOP };
				byte[] msgModeClose = serialMessages.GeneratePacket(cmdModeClose.Serialize());
				if (sPort.IsOpen)
					sPort.Write(msgModeClose, 0, msgModeClose.Length);
			}
		}

		private void chkEnable_CheckedChanged(object sender, EventArgs e)
		{
			// Check if serial protocol object exist
			if (serialMessages == null)
				return;

			if (chkEnable.Checked)
			{
				//Verify the mode before enabling
				rdOpenLoop_CheckedChanged(this, e);
				rdClosedLoop_CheckedChanged(this, e);

				// Seem unreliable to write while enabled
				btnWriteParameters.Enabled = false;

				Messages.Msg_Command cmdModeEnable = new Messages.Msg_Command { command = Messages.COMMAND_TYPES.MODE_ENABLE };
				byte[] msgModeEnable = serialMessages.GeneratePacket(cmdModeEnable.Serialize());
				if (sPort.IsOpen)
					sPort.Write(msgModeEnable, 0, msgModeEnable.Length);
			}
			else
			{
				btnWriteParameters.Enabled = true;

				Messages.Msg_Command cmdModeDisable = new Messages.Msg_Command { command = Messages.COMMAND_TYPES.MODE_DISABLE };
				byte[] msgModeDisable = serialMessages.GeneratePacket(cmdModeDisable.Serialize());
				if (sPort.IsOpen)
					sPort.Write(msgModeDisable, 0, msgModeDisable.Length);
			}
		}

		private void SoftMove(int steps, int direction)
		{
			// Check if serial protocol object exist
			if (serialMessages == null)
				return;

			// Check if serial protocol object exist
			if (serialMessages == null)
				return;

			Messages.Msg_Command cmdMove = new Messages.Msg_Command { command = Messages.COMMAND_TYPES.MOVE };
			cmdMove.param1 = (byte)(steps >> 8);
			cmdMove.param2 = (byte)(steps & 0x00FF);
			cmdMove.param3 = (byte)direction;

			byte[] msgMove = serialMessages.GeneratePacket(cmdMove.Serialize());

			if (sPort.IsOpen)
				sPort.Write(msgMove, 0, msgMove.Length);
		}

		private void btnMove_Click(object sender, EventArgs e)
		{
			SoftMove(1024, chkChangeDirection.Checked == true ? 1 : 0);
		}

		private void chkTuningEnable_CheckedChanged(object sender, EventArgs e)
		{
			if (!sPort.IsOpen)
				return;

			Messages.Msg_Command cmdStreamAngle;

			if (chkTuningEnable.Checked)
			{
				cmdStreamAngle = new Messages.Msg_Command { command = Messages.COMMAND_TYPES.STREAM_ANGLE, param1 = 1 };
				ThreadHelperClass.SetEnable(this, btnAutoTune, false);

				pidAutotuneClass.Clear();

				serialMessages.MessageReceived += SerialMessages_MessageReceived1;
				timerRenderScottPlot = new System.Threading.Timer(TimerRender, null, 5, 5);
			}
			else
			{
				cmdStreamAngle = new Messages.Msg_Command { command = Messages.COMMAND_TYPES.STREAM_ANGLE, param1 = 0 };

				serialMessages.MessageReceived -= SerialMessages_MessageReceived1;
				ThreadHelperClass.SetEnable(this, btnAutoTune, true);
				ThreadHelperClass.SetNumericUpDownValue(this, numMaxAngleError, (decimal)pidAutotuneClass.GetMaxAngleError);
				ThreadHelperClass.SetNumericUpDownValue(this, numAvgAngleError, (decimal)pidAutotuneClass.GetAvgAngleError);

				timerRenderScottPlot.Dispose();
				//timerRenderScottPlot.Change(Timeout.Infinite, Timeout.Infinite);
			}

			byte[] msgStreamAng = serialMessages.GeneratePacket(cmdStreamAngle.Serialize());

			if (sPort.IsOpen)
				sPort.Write(msgStreamAng, 0, msgStreamAng.Length);
		}

		private void TimerRender(object state)
		{
			Invoke(new MethodInvoker(() =>
			{
				//Disposed exception
				formsPlot1.Render(true, true);
			}));
		}

		void ScottPlotInit(FormsPlotMouseYTrack formsPlot, double[] angle, double[] angleError)
		{
			//formsPlot.Configuration.MiddleClickAutoAxisMarginX = 0;

			//// plot the data array only once and we can updates its values later
			var angleSignal = formsPlot.Plot.AddSignal(angle, 1, Color.Green, "Angle");
			var angleErrorSignal = formsPlot.Plot.AddSignal(angleError, 1, Color.Red, "Error");

			angleSignal.UseParallel = false;
			angleErrorSignal.UseParallel = false;

			formsPlot.Plot.AxisAuto();
			formsPlot.Plot.SetViewLimits(0, angle.Length, -5, 5);

			formsPlot.Plot.YLabel("Error (mm)");
			//formsPlot.Plot.XLabel("ms");
			formsPlot.Plot.AxisAutoX(margin: 0);
			formsPlot.Plot.AxisAutoY(margin: 0);

			formsPlot.YWarningLine = 0.5;
			//formsPlot.Plot.SetAxisLimits(yMin: -3, yMax: 3);

			//// plot a red vertical line and save it so we can move it later
			//var hline = formsPlot1.Plot.AddHorizontalLine(0, System.Drawing.Color.Red, 1);

			//// customize styling
			//formsPlot.Plot.Title("Electrocardiogram Strip Chart");
			//formsPlot.Plot.YLabel("Potential (mV)");
			//formsPlot.Plot.XLabel("Time (seconds)");


			//var plt = formsPlot.Plot;

			//Random rand = new Random(0);
			//int pointCount = (int)1e6;
			//int lineCount = 5;

			//for (int i = 0; i < lineCount; i++)
			//	plt.PlotSignal(DataGen.RandomWalk(rand, pointCount));

			//plt.Title("Signal Plot Quickstart (5 million points)");
			//plt.YLabel("Vertical Units");
			//plt.XLabel("Horizontal Units");

			//plt.SaveFig("Quickstart_Quickstart_Signal_5MillionPoints.png");
		}

		private void btnAutoTune_Click(object sender, EventArgs e)
		{
			if (serialMessages == null) return;

			btnAutoTune.Enabled = false;
			numMaxAngleError.Value = 0;

			pidAutotuneClass.Clear();

			serialMessages.MessageReceived += SerialMessages_MessageReceived1;

			var period = numericUpDownStepInterval.Value;
			var starter = new ThreadStart(() =>
			{
				for (int i = 0; i < 10; i++)
				{
					SoftMove(2048, i % 2);
					Thread.Sleep((int)period);
				}
				serialMessages.MessageReceived -= SerialMessages_MessageReceived1;
				ThreadHelperClass.SetEnable(this, btnAutoTune, true);
				ThreadHelperClass.SetNumericUpDownValue(this, numMaxAngleError, (decimal)pidAutotuneClass.GetMaxAngleError);
				ThreadHelperClass.SetNumericUpDownValue(this, numAvgAngleError, (decimal)pidAutotuneClass.GetAvgAngleError);
			});

			var pidAutotuneThread = new Thread(starter) { IsBackground = true };

			pidAutotuneThread.Start();
		}

		private void SerialMessages_MessageReceived1(object sender, Messages.MESSAGE_IDS msgId, object value)
		{
			switch (msgId)
			{
				case Messages.MESSAGE_IDS.VALUE_ANGLE_ERR:
					{
						float angError = (float)value;
						var span = pidAutotuneClass.AddAngleError(angError);
					}
					break;
				case Messages.MESSAGE_IDS.VALUE_ANGLE:
					{
						float ang = (float)value;
						var span = pidAutotuneClass.AddAngle(ang);
					}
					break;
			}
		}

		private void BtnFirmwareUpload_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFirmwareFile = new OpenFileDialog()
			{
				Filter = "Bin files|*.bin|Hex files|*.hex|All files|*.*",
				InitialDirectory = Environment.CurrentDirectory
			};

			if (openFirmwareFile.ShowDialog() != DialogResult.OK)
				return;

			var uploadFileName = openFirmwareFile.FileName;

			if (string.IsNullOrEmpty(uploadFileName) || !File.Exists(uploadFileName))
			{
				MessageBox.Show($"File not found!{Environment.NewLine}{uploadFileName}", "Error");
				return;
			}

			grpParameters.Enabled = grpOverview.Enabled = grpConnection.Enabled = grpControls.Enabled = false;

			// Step 1: Place closed loop drive into UART bootloader mode
			BtnBootloaderRun_Click(sender, e);

			// Close the port to make it available for the flashloader
			sPort.Close();
			while (sPort.IsOpen) ;
			Thread.Sleep(1000);

			// Step 2: Use the STMFlashloader program to flash the selected file
			var arguments = $"-b 115200 -w \"{uploadFileName}\" -R {cmbPortName.Text}";

			Action<int, string> stm32Finished = (exitCode, errMsg) =>
			{
				var message = exitCode == 0 ? "Done" : string.IsNullOrEmpty(errMsg) ? "Error" : errMsg;
				MessageBox.Show($"{message}{Environment.NewLine}Exit code: {exitCode}", $"Upload (stm32flash)");

				sPort.Open();
				grpParameters.Enabled = grpOverview.Enabled = grpConnection.Enabled = grpControls.Enabled = true;
			};

			RunStm32Flasher(arguments, stm32Finished);
		}

		private void BtnFirmwareDownload_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFirmwareFile = new SaveFileDialog();
			saveFirmwareFile.Filter = "Bin files|*.bin|Hex files|*.hex|All files|*.*";

			if (saveFirmwareFile.ShowDialog() != DialogResult.OK)
				return;

			string saveFileName = saveFirmwareFile.FileName;

			grpParameters.Enabled = grpOverview.Enabled = grpConnection.Enabled = grpControls.Enabled = false;

			// Step 1: Place closed loop drive into UART bootloader mode
			BtnBootloaderRun_Click(sender, e);

			// Close the port to make it available for the flashloader
			sPort.Close();
			while (sPort.IsOpen) ;
			Thread.Sleep(1000);

			// Step 2: Use the STMFlashloader program to download to the selected file
			var arguments = $"-b 115200 -r \"{saveFileName}\" -R {cmbPortName.Text}";

			rtfStm32Log.Text = "";

			Action<int, string> stm32Finished = (exitCode, errMsg) =>
			{
				var message = exitCode == 0 ? "Done" : string.IsNullOrEmpty(errMsg) ? "Error" : errMsg;
				MessageBox.Show($"{message}{Environment.NewLine}Exit code: {exitCode}", $"Download (stm32flash)");

				sPort.Open();
				grpParameters.Enabled = grpOverview.Enabled = grpConnection.Enabled = grpControls.Enabled = true;
			};

			RunStm32Flasher(arguments, stm32Finished);

		}

		private void RunStm32Flasher(string arguments, Action<int, string> processFinished)
		{
			var errorStream = new MemoryStream();

			try
			{
				var stm32flashFile = @"stm32flash\stm32flash.exe";

				var tpStream = new ThrouputStream();

				// STM32Flash process
				var threadProcessStart = new Thread(() =>
				{
					var exitCode = ThreadHelperClass.StartProcess(
						stm32flashFile,
						arguments,
#if !DEBUG
						timeout: 10000, 
#endif
						outputTextWriter: new StreamWriter(tpStream.OutputStream),
						errorTextWriter: new StreamWriter(errorStream)
					).Result;

					// process Finished
					_ = BeginInvoke(new Action(() =>
					{
						errorStream.Seek(0, SeekOrigin.Begin);
						var errMsg = new StreamReader(errorStream).ReadToEnd();
						processFinished(exitCode, errMsg);
					}));
					tpStream.Dispose();
				})
				{ Name = "StartProcess" };
				threadProcessStart.Start();

				var threadReadOutput = new Thread(() =>
				{
					var tr = new StreamReader(tpStream.InputStream);
					string line;
					var processRegex = new Regex(@"(?<name>\w+\s\w+)\s(?<addr>\dx\w+)\s\((?<proc>\d+.\d+)%\)");

					while (!tpStream.InputClosed)
					{
						line = tr.ReadLine();
						if (line == null) continue;

						var mc = processRegex.Match(line);
						if (mc.Groups.Count != 4)
							_ = BeginInvoke(new Action<string>((s) => { rtfStm32Log.Text += $"{s}{Environment.NewLine}"; }), line);
						else if (float.TryParse(mc.Groups["proc"].Value, out float proc))
							_ = BeginInvoke(new Action<string, int, string>(
							   (addr, p, l) =>
							   {
								   progressBarDownloadProgress.Value = p;
								   progressBarDownloadProgress.CustomText = $"addr:({addr}) [{p}%]";
								   //rtfStm32Log.Text += $"{l}{Environment.NewLine}";
							   })
							   , mc.Groups["addr"].Value, (int)proc, line);
						else
							_ = BeginInvoke(new Action<string>((s) => { rtfStm32Log.Text += $"{s}{Environment.NewLine}"; }), line);
					}
					//_ = BeginInvoke(new Action<string>((s) => { rtfStm32Log.Text += $"{s}{Environment.NewLine}"; }), "[DONE]");
				})

				{ Name = "ReadOutput" };
				threadReadOutput.Start();
			}
			catch (Exception ex)
			{
				//MessageBox.Show(ex.Message, $"Fatal error");
				processFinished(-1, ex.Message);
			}
		}


		private void ChkBTTProtocol_CheckedChanged(object sender, EventArgs e)
		{
			if (chkBTTProtocol.Checked)
			{
				tabControls.Enabled = false;
				btnControlGetAngle.Enabled = false;
				chkWriteToFlash.Checked = true;
				chkWriteToFlash.Enabled = false;
			}
			else
			{
				tabControls.Enabled = true;
				btnControlGetAngle.Enabled = true;
				chkWriteToFlash.Checked = false;
				chkWriteToFlash.Enabled = true;
			}
		}

		private void BtnBootloaderRun_Click(object sender, EventArgs e)
		{
			Messages.Msg_Command cmdJumpToBootloader = new Messages.Msg_Command { command = Messages.COMMAND_TYPES.JUMP_BOOTLOADER };
			byte[] msgJumpToBootloader = serialMessages.GeneratePacket(cmdJumpToBootloader.Serialize());
			if (sPort.IsOpen)
				sPort.Write(msgJumpToBootloader, 0, msgJumpToBootloader.Length);

			BtnConnect_Click(sender, e);
			MessageBox.Show("Now you device in a bootloader mode", "Bootloader");
		}
	}
}
