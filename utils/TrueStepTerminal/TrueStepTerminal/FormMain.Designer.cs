using TrueStepTerminal.Controls;

namespace TrueStepTerminal
{
	partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.grpParameters = new System.Windows.Forms.GroupBox();
			this.panelParameters = new System.Windows.Forms.Panel();
			this.chkWriteToFlash = new System.Windows.Forms.CheckBox();
			this.btnWriteParameters = new System.Windows.Forms.Button();
			this.btnReadParameters = new System.Windows.Forms.Button();
			this.dataGridViewParameters = new System.Windows.Forms.DataGridView();
			this.grpOverview = new System.Windows.Forms.GroupBox();
			this.panelOverview = new System.Windows.Forms.Panel();
			this.btnControlGetAngle = new System.Windows.Forms.Button();
			this.lblAngleError = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.lblAngleValue = new System.Windows.Forms.Label();
			this.grpControls = new System.Windows.Forms.GroupBox();
			this.tabControls = new System.Windows.Forms.TabControl();
			this.tabPageMain = new System.Windows.Forms.TabPage();
			this.panelControlsMain = new System.Windows.Forms.Panel();
			this.btnMove = new System.Windows.Forms.Button();
			this.chkChangeDirection = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rdClosedLoop = new System.Windows.Forms.RadioButton();
			this.rdOpenLoop = new System.Windows.Forms.RadioButton();
			this.chkEnable = new System.Windows.Forms.CheckBox();
			this.btnControlStep = new System.Windows.Forms.Button();
			this.tabPageTuning = new System.Windows.Forms.TabPage();
			this.panelControlsTuning = new System.Windows.Forms.Panel();
			this.numAvgAngleError = new System.Windows.Forms.NumericUpDown();
			this.numMaxAngleError = new System.Windows.Forms.NumericUpDown();
			this.label14 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.numericUpDownStepInterval = new System.Windows.Forms.NumericUpDown();
			this.btnAutoTune = new System.Windows.Forms.Button();
			this.chkTuningEnable = new System.Windows.Forms.CheckBox();
			this.formsPlot1 = new TrueStepTerminal.Controls.FormsPlotMouseYTrack();
			this.tabPageFirmware = new System.Windows.Forms.TabPage();
			this.panelControlsFirmware = new System.Windows.Forms.Panel();
			this.btnBootloaderRun = new System.Windows.Forms.Button();
			this.progressBarDownloadProgress = new TrueStepTerminal.Controls.CustomProgressBar();
			this.rtfStm32Log = new System.Windows.Forms.RichTextBox();
			this.btnFirmwareDownload = new System.Windows.Forms.Button();
			this.btnFirmwareUpload = new System.Windows.Forms.Button();
			this.label11 = new System.Windows.Forms.Label();
			this.tabPageExperimental = new System.Windows.Forms.TabPage();
			this.panelControlsExperimental = new System.Windows.Forms.Panel();
			this.label7 = new System.Windows.Forms.Label();
			this.cmbStepCurrent = new System.Windows.Forms.ComboBox();
			this.cmbStepLoop = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.cmbStepSize = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.cmbStepDirection = new System.Windows.Forms.ComboBox();
			this.grpConnection = new System.Windows.Forms.GroupBox();
			this.panelConnection = new System.Windows.Forms.Panel();
			this.chkBTTProtocol = new System.Windows.Forms.CheckBox();
			this.btnConnect = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.cmbPortBaud = new System.Windows.Forms.ComboBox();
			this.cmbPortName = new System.Windows.Forms.ComboBox();
			this.btnClose = new System.Windows.Forms.Button();
			this.toolTips = new System.Windows.Forms.ToolTip(this.components);
			this.panelMain = new System.Windows.Forms.Panel();
			this.grpParameters.SuspendLayout();
			this.panelParameters.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewParameters)).BeginInit();
			this.grpOverview.SuspendLayout();
			this.panelOverview.SuspendLayout();
			this.grpControls.SuspendLayout();
			this.tabControls.SuspendLayout();
			this.tabPageMain.SuspendLayout();
			this.panelControlsMain.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabPageTuning.SuspendLayout();
			this.panelControlsTuning.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numAvgAngleError)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numMaxAngleError)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownStepInterval)).BeginInit();
			this.tabPageFirmware.SuspendLayout();
			this.panelControlsFirmware.SuspendLayout();
			this.tabPageExperimental.SuspendLayout();
			this.panelControlsExperimental.SuspendLayout();
			this.grpConnection.SuspendLayout();
			this.panelConnection.SuspendLayout();
			this.panelMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpParameters
			// 
			this.grpParameters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpParameters.Controls.Add(this.panelParameters);
			this.grpParameters.Location = new System.Drawing.Point(241, 6);
			this.grpParameters.Name = "grpParameters";
			this.grpParameters.Size = new System.Drawing.Size(467, 200);
			this.grpParameters.TabIndex = 1;
			this.grpParameters.TabStop = false;
			this.grpParameters.Text = "Parameters";
			// 
			// panelParameters
			// 
			this.panelParameters.Controls.Add(this.chkWriteToFlash);
			this.panelParameters.Controls.Add(this.btnWriteParameters);
			this.panelParameters.Controls.Add(this.btnReadParameters);
			this.panelParameters.Controls.Add(this.dataGridViewParameters);
			this.panelParameters.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelParameters.Location = new System.Drawing.Point(3, 16);
			this.panelParameters.Name = "panelParameters";
			this.panelParameters.Size = new System.Drawing.Size(461, 181);
			this.panelParameters.TabIndex = 6;
			// 
			// chkWriteToFlash
			// 
			this.chkWriteToFlash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.chkWriteToFlash.AutoSize = true;
			this.chkWriteToFlash.Location = new System.Drawing.Point(382, 61);
			this.chkWriteToFlash.Name = "chkWriteToFlash";
			this.chkWriteToFlash.Size = new System.Drawing.Size(67, 17);
			this.chkWriteToFlash.TabIndex = 7;
			this.chkWriteToFlash.Text = "To Flash";
			this.chkWriteToFlash.UseVisualStyleBackColor = true;
			// 
			// btnWriteParameters
			// 
			this.btnWriteParameters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnWriteParameters.Location = new System.Drawing.Point(382, 32);
			this.btnWriteParameters.Name = "btnWriteParameters";
			this.btnWriteParameters.Size = new System.Drawing.Size(75, 23);
			this.btnWriteParameters.TabIndex = 6;
			this.btnWriteParameters.Text = "Write";
			this.btnWriteParameters.UseVisualStyleBackColor = true;
			this.btnWriteParameters.Click += new System.EventHandler(this.btnWriteParameters_Click);
			// 
			// btnReadParameters
			// 
			this.btnReadParameters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnReadParameters.Location = new System.Drawing.Point(382, 3);
			this.btnReadParameters.Name = "btnReadParameters";
			this.btnReadParameters.Size = new System.Drawing.Size(75, 23);
			this.btnReadParameters.TabIndex = 5;
			this.btnReadParameters.Text = "Read";
			this.btnReadParameters.UseVisualStyleBackColor = true;
			this.btnReadParameters.Click += new System.EventHandler(this.btnReadParameters_Click);
			// 
			// dataGridViewParameters
			// 
			this.dataGridViewParameters.AllowUserToAddRows = false;
			this.dataGridViewParameters.AllowUserToDeleteRows = false;
			this.dataGridViewParameters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridViewParameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewParameters.Location = new System.Drawing.Point(3, 3);
			this.dataGridViewParameters.Name = "dataGridViewParameters";
			this.dataGridViewParameters.Size = new System.Drawing.Size(373, 175);
			this.dataGridViewParameters.TabIndex = 2;
			// 
			// grpOverview
			// 
			this.grpOverview.Controls.Add(this.panelOverview);
			this.grpOverview.Location = new System.Drawing.Point(3, 126);
			this.grpOverview.Name = "grpOverview";
			this.grpOverview.Size = new System.Drawing.Size(232, 80);
			this.grpOverview.TabIndex = 2;
			this.grpOverview.TabStop = false;
			this.grpOverview.Text = "Overview";
			// 
			// panelOverview
			// 
			this.panelOverview.Controls.Add(this.btnControlGetAngle);
			this.panelOverview.Controls.Add(this.lblAngleError);
			this.panelOverview.Controls.Add(this.label8);
			this.panelOverview.Controls.Add(this.label9);
			this.panelOverview.Controls.Add(this.lblAngleValue);
			this.panelOverview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelOverview.Location = new System.Drawing.Point(3, 16);
			this.panelOverview.Name = "panelOverview";
			this.panelOverview.Size = new System.Drawing.Size(226, 61);
			this.panelOverview.TabIndex = 16;
			// 
			// btnControlGetAngle
			// 
			this.btnControlGetAngle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnControlGetAngle.Location = new System.Drawing.Point(148, 9);
			this.btnControlGetAngle.Name = "btnControlGetAngle";
			this.btnControlGetAngle.Size = new System.Drawing.Size(75, 23);
			this.btnControlGetAngle.TabIndex = 1;
			this.btnControlGetAngle.Text = "Get Angle";
			this.btnControlGetAngle.UseVisualStyleBackColor = true;
			this.btnControlGetAngle.Click += new System.EventHandler(this.btnControlGetAngle_Click);
			// 
			// lblAngleError
			// 
			this.lblAngleError.AutoSize = true;
			this.lblAngleError.Location = new System.Drawing.Point(55, 22);
			this.lblAngleError.Name = "lblAngleError";
			this.lblAngleError.Size = new System.Drawing.Size(13, 13);
			this.lblAngleError.TabIndex = 15;
			this.lblAngleError.Text = "0";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(5, 9);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(34, 13);
			this.label8.TabIndex = 12;
			this.label8.Text = "Angle";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(5, 22);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(29, 13);
			this.label9.TabIndex = 14;
			this.label9.Text = "Error";
			// 
			// lblAngleValue
			// 
			this.lblAngleValue.AutoSize = true;
			this.lblAngleValue.Location = new System.Drawing.Point(55, 9);
			this.lblAngleValue.Name = "lblAngleValue";
			this.lblAngleValue.Size = new System.Drawing.Size(13, 13);
			this.lblAngleValue.TabIndex = 13;
			this.lblAngleValue.Text = "0";
			// 
			// grpControls
			// 
			this.grpControls.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpControls.Controls.Add(this.tabControls);
			this.grpControls.Location = new System.Drawing.Point(3, 212);
			this.grpControls.Name = "grpControls";
			this.grpControls.Size = new System.Drawing.Size(705, 354);
			this.grpControls.TabIndex = 3;
			this.grpControls.TabStop = false;
			this.grpControls.Text = "Controls";
			// 
			// tabControls
			// 
			this.tabControls.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControls.Controls.Add(this.tabPageMain);
			this.tabControls.Controls.Add(this.tabPageTuning);
			this.tabControls.Controls.Add(this.tabPageFirmware);
			this.tabControls.Controls.Add(this.tabPageExperimental);
			this.tabControls.Location = new System.Drawing.Point(9, 19);
			this.tabControls.Name = "tabControls";
			this.tabControls.SelectedIndex = 0;
			this.tabControls.Size = new System.Drawing.Size(693, 329);
			this.tabControls.TabIndex = 12;
			// 
			// tabPageMain
			// 
			this.tabPageMain.Controls.Add(this.panelControlsMain);
			this.tabPageMain.Location = new System.Drawing.Point(4, 22);
			this.tabPageMain.Name = "tabPageMain";
			this.tabPageMain.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageMain.Size = new System.Drawing.Size(638, 273);
			this.tabPageMain.TabIndex = 0;
			this.tabPageMain.Text = "Main";
			this.tabPageMain.UseVisualStyleBackColor = true;
			// 
			// panelControlsMain
			// 
			this.panelControlsMain.Controls.Add(this.btnMove);
			this.panelControlsMain.Controls.Add(this.chkChangeDirection);
			this.panelControlsMain.Controls.Add(this.groupBox1);
			this.panelControlsMain.Controls.Add(this.chkEnable);
			this.panelControlsMain.Controls.Add(this.btnControlStep);
			this.panelControlsMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelControlsMain.Location = new System.Drawing.Point(3, 3);
			this.panelControlsMain.Name = "panelControlsMain";
			this.panelControlsMain.Size = new System.Drawing.Size(632, 267);
			this.panelControlsMain.TabIndex = 18;
			// 
			// btnMove
			// 
			this.btnMove.Location = new System.Drawing.Point(124, 3);
			this.btnMove.Name = "btnMove";
			this.btnMove.Size = new System.Drawing.Size(75, 23);
			this.btnMove.TabIndex = 21;
			this.btnMove.Text = "Move";
			this.btnMove.UseVisualStyleBackColor = true;
			this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
			// 
			// chkChangeDirection
			// 
			this.chkChangeDirection.AutoSize = true;
			this.chkChangeDirection.Location = new System.Drawing.Point(3, 101);
			this.chkChangeDirection.Name = "chkChangeDirection";
			this.chkChangeDirection.Size = new System.Drawing.Size(108, 17);
			this.chkChangeDirection.TabIndex = 20;
			this.chkChangeDirection.Text = "Change Direction";
			this.chkChangeDirection.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.rdClosedLoop);
			this.groupBox1.Controls.Add(this.rdOpenLoop);
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(115, 69);
			this.groupBox1.TabIndex = 19;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Mode";
			// 
			// rdClosedLoop
			// 
			this.rdClosedLoop.AutoSize = true;
			this.rdClosedLoop.Location = new System.Drawing.Point(6, 42);
			this.rdClosedLoop.Name = "rdClosedLoop";
			this.rdClosedLoop.Size = new System.Drawing.Size(84, 17);
			this.rdClosedLoop.TabIndex = 16;
			this.rdClosedLoop.Text = "Closed Loop";
			this.rdClosedLoop.UseVisualStyleBackColor = true;
			this.rdClosedLoop.CheckedChanged += new System.EventHandler(this.rdClosedLoop_CheckedChanged);
			// 
			// rdOpenLoop
			// 
			this.rdOpenLoop.AutoSize = true;
			this.rdOpenLoop.Checked = true;
			this.rdOpenLoop.Location = new System.Drawing.Point(6, 19);
			this.rdOpenLoop.Name = "rdOpenLoop";
			this.rdOpenLoop.Size = new System.Drawing.Size(78, 17);
			this.rdOpenLoop.TabIndex = 15;
			this.rdOpenLoop.TabStop = true;
			this.rdOpenLoop.Text = "Open Loop";
			this.rdOpenLoop.UseVisualStyleBackColor = true;
			this.rdOpenLoop.CheckedChanged += new System.EventHandler(this.rdOpenLoop_CheckedChanged);
			// 
			// chkEnable
			// 
			this.chkEnable.AutoSize = true;
			this.chkEnable.Location = new System.Drawing.Point(3, 78);
			this.chkEnable.Name = "chkEnable";
			this.chkEnable.Size = new System.Drawing.Size(59, 17);
			this.chkEnable.TabIndex = 18;
			this.chkEnable.Text = "Enable";
			this.chkEnable.UseVisualStyleBackColor = true;
			this.chkEnable.CheckedChanged += new System.EventHandler(this.chkEnable_CheckedChanged);
			// 
			// btnControlStep
			// 
			this.btnControlStep.Location = new System.Drawing.Point(124, 32);
			this.btnControlStep.Name = "btnControlStep";
			this.btnControlStep.Size = new System.Drawing.Size(75, 23);
			this.btnControlStep.TabIndex = 17;
			this.btnControlStep.Text = "Step";
			this.btnControlStep.UseVisualStyleBackColor = true;
			this.btnControlStep.Click += new System.EventHandler(this.btnControlStep_Click);
			// 
			// tabPageTuning
			// 
			this.tabPageTuning.Controls.Add(this.panelControlsTuning);
			this.tabPageTuning.Location = new System.Drawing.Point(4, 22);
			this.tabPageTuning.Name = "tabPageTuning";
			this.tabPageTuning.Size = new System.Drawing.Size(685, 303);
			this.tabPageTuning.TabIndex = 2;
			this.tabPageTuning.Text = "Tuning";
			this.tabPageTuning.UseVisualStyleBackColor = true;
			// 
			// panelControlsTuning
			// 
			this.panelControlsTuning.Controls.Add(this.numAvgAngleError);
			this.panelControlsTuning.Controls.Add(this.numMaxAngleError);
			this.panelControlsTuning.Controls.Add(this.label14);
			this.panelControlsTuning.Controls.Add(this.label13);
			this.panelControlsTuning.Controls.Add(this.label12);
			this.panelControlsTuning.Controls.Add(this.numericUpDownStepInterval);
			this.panelControlsTuning.Controls.Add(this.btnAutoTune);
			this.panelControlsTuning.Controls.Add(this.chkTuningEnable);
			this.panelControlsTuning.Controls.Add(this.formsPlot1);
			this.panelControlsTuning.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelControlsTuning.Location = new System.Drawing.Point(0, 0);
			this.panelControlsTuning.Name = "panelControlsTuning";
			this.panelControlsTuning.Size = new System.Drawing.Size(685, 303);
			this.panelControlsTuning.TabIndex = 25;
			// 
			// numAvgAngleError
			// 
			this.numAvgAngleError.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.numAvgAngleError.DecimalPlaces = 2;
			this.numAvgAngleError.Location = new System.Drawing.Point(598, 101);
			this.numAvgAngleError.Name = "numAvgAngleError";
			this.numAvgAngleError.ReadOnly = true;
			this.numAvgAngleError.Size = new System.Drawing.Size(54, 20);
			this.numAvgAngleError.TabIndex = 31;
			// 
			// numMaxAngleError
			// 
			this.numMaxAngleError.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.numMaxAngleError.DecimalPlaces = 2;
			this.numMaxAngleError.Location = new System.Drawing.Point(598, 81);
			this.numMaxAngleError.Name = "numMaxAngleError";
			this.numMaxAngleError.ReadOnly = true;
			this.numMaxAngleError.Size = new System.Drawing.Size(54, 20);
			this.numMaxAngleError.TabIndex = 32;
			// 
			// label14
			// 
			this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(533, 103);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(51, 13);
			this.label14.TabIndex = 29;
			this.label14.Text = "Avg Arror";
			// 
			// label13
			// 
			this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(533, 83);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(52, 13);
			this.label13.TabIndex = 30;
			this.label13.Text = "Max Error";
			// 
			// label12
			// 
			this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(658, 132);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(20, 13);
			this.label12.TabIndex = 28;
			this.label12.Text = "ms";
			// 
			// numericUpDownStepInterval
			// 
			this.numericUpDownStepInterval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.numericUpDownStepInterval.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.numericUpDownStepInterval.Location = new System.Drawing.Point(614, 130);
			this.numericUpDownStepInterval.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
			this.numericUpDownStepInterval.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.numericUpDownStepInterval.Name = "numericUpDownStepInterval";
			this.numericUpDownStepInterval.Size = new System.Drawing.Size(38, 20);
			this.numericUpDownStepInterval.TabIndex = 27;
			this.numericUpDownStepInterval.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
			// 
			// btnAutoTune
			// 
			this.btnAutoTune.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAutoTune.Location = new System.Drawing.Point(533, 127);
			this.btnAutoTune.Name = "btnAutoTune";
			this.btnAutoTune.Size = new System.Drawing.Size(75, 23);
			this.btnAutoTune.TabIndex = 26;
			this.btnAutoTune.Text = "Auto Tune";
			this.btnAutoTune.UseVisualStyleBackColor = true;
			this.btnAutoTune.Click += new System.EventHandler(this.BtnAutoTune_Click);
			// 
			// chkTuningEnable
			// 
			this.chkTuningEnable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.chkTuningEnable.AutoSize = true;
			this.chkTuningEnable.Location = new System.Drawing.Point(536, 14);
			this.chkTuningEnable.Name = "chkTuningEnable";
			this.chkTuningEnable.Size = new System.Drawing.Size(100, 17);
			this.chkTuningEnable.TabIndex = 25;
			this.chkTuningEnable.Text = "Enable Logging";
			this.chkTuningEnable.UseVisualStyleBackColor = true;
			this.chkTuningEnable.CheckedChanged += new System.EventHandler(this.chkTuningEnable_CheckedChanged);
			// 
			// formsPlot1
			// 
			this.formsPlot1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.formsPlot1.BackColor = System.Drawing.Color.Transparent;
			this.formsPlot1.Location = new System.Drawing.Point(3, 3);
			this.formsPlot1.Name = "formsPlot1";
			this.formsPlot1.Size = new System.Drawing.Size(527, 297);
			this.formsPlot1.TabIndex = 24;
			this.formsPlot1.YWarningLine = 0D;
			// 
			// tabPageFirmware
			// 
			this.tabPageFirmware.Controls.Add(this.panelControlsFirmware);
			this.tabPageFirmware.Location = new System.Drawing.Point(4, 22);
			this.tabPageFirmware.Name = "tabPageFirmware";
			this.tabPageFirmware.Size = new System.Drawing.Size(649, 284);
			this.tabPageFirmware.TabIndex = 3;
			this.tabPageFirmware.Text = "Firmware Upload";
			this.tabPageFirmware.UseVisualStyleBackColor = true;
			// 
			// panelControlsFirmware
			// 
			this.panelControlsFirmware.Controls.Add(this.btnBootloaderRun);
			this.panelControlsFirmware.Controls.Add(this.progressBarDownloadProgress);
			this.panelControlsFirmware.Controls.Add(this.rtfStm32Log);
			this.panelControlsFirmware.Controls.Add(this.btnFirmwareDownload);
			this.panelControlsFirmware.Controls.Add(this.btnFirmwareUpload);
			this.panelControlsFirmware.Controls.Add(this.label11);
			this.panelControlsFirmware.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelControlsFirmware.Location = new System.Drawing.Point(0, 0);
			this.panelControlsFirmware.Name = "panelControlsFirmware";
			this.panelControlsFirmware.Size = new System.Drawing.Size(649, 284);
			this.panelControlsFirmware.TabIndex = 23;
			// 
			// btnBootloaderRun
			// 
			this.btnBootloaderRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBootloaderRun.Location = new System.Drawing.Point(571, 81);
			this.btnBootloaderRun.Name = "btnBootloaderRun";
			this.btnBootloaderRun.Size = new System.Drawing.Size(74, 24);
			this.btnBootloaderRun.TabIndex = 28;
			this.btnBootloaderRun.Text = "Bootloader";
			this.btnBootloaderRun.UseVisualStyleBackColor = true;
			this.btnBootloaderRun.Click += new System.EventHandler(this.BtnBootloaderRun_Click);
			// 
			// progressBarDownloadProgress
			// 
			this.progressBarDownloadProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.progressBarDownloadProgress.CustomText = null;
			this.progressBarDownloadProgress.DisplayStyle = TrueStepTerminal.Controls.ProgressBarDisplayText.CustomText;
			this.progressBarDownloadProgress.Location = new System.Drawing.Point(3, 25);
			this.progressBarDownloadProgress.Name = "progressBarDownloadProgress";
			this.progressBarDownloadProgress.Size = new System.Drawing.Size(562, 23);
			this.progressBarDownloadProgress.TabIndex = 27;
			// 
			// rtfStm32Log
			// 
			this.rtfStm32Log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.rtfStm32Log.Location = new System.Drawing.Point(3, 54);
			this.rtfStm32Log.Name = "rtfStm32Log";
			this.rtfStm32Log.ReadOnly = true;
			this.rtfStm32Log.Size = new System.Drawing.Size(562, 227);
			this.rtfStm32Log.TabIndex = 26;
			this.rtfStm32Log.Text = "";
			// 
			// btnFirmwareDownload
			// 
			this.btnFirmwareDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFirmwareDownload.Location = new System.Drawing.Point(571, 52);
			this.btnFirmwareDownload.Name = "btnFirmwareDownload";
			this.btnFirmwareDownload.Size = new System.Drawing.Size(75, 23);
			this.btnFirmwareDownload.TabIndex = 22;
			this.btnFirmwareDownload.Text = "Download";
			this.btnFirmwareDownload.UseVisualStyleBackColor = true;
			this.btnFirmwareDownload.Click += new System.EventHandler(this.BtnFirmwareDownload_Click);
			// 
			// btnFirmwareUpload
			// 
			this.btnFirmwareUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFirmwareUpload.Location = new System.Drawing.Point(571, 25);
			this.btnFirmwareUpload.Name = "btnFirmwareUpload";
			this.btnFirmwareUpload.Size = new System.Drawing.Size(75, 23);
			this.btnFirmwareUpload.TabIndex = 17;
			this.btnFirmwareUpload.Text = "Upload";
			this.btnFirmwareUpload.UseVisualStyleBackColor = true;
			this.btnFirmwareUpload.Click += new System.EventHandler(this.BtnFirmwareUpload_Click);
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label11.Location = new System.Drawing.Point(3, 9);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(267, 13);
			this.label11.TabIndex = 21;
			this.label11.Text = "Firmware upload/download using the UART bootloader";
			// 
			// tabPageExperimental
			// 
			this.tabPageExperimental.Controls.Add(this.panelControlsExperimental);
			this.tabPageExperimental.Location = new System.Drawing.Point(4, 22);
			this.tabPageExperimental.Name = "tabPageExperimental";
			this.tabPageExperimental.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageExperimental.Size = new System.Drawing.Size(599, 250);
			this.tabPageExperimental.TabIndex = 1;
			this.tabPageExperimental.Text = "Experimental";
			this.tabPageExperimental.UseVisualStyleBackColor = true;
			// 
			// panelControlsExperimental
			// 
			this.panelControlsExperimental.Controls.Add(this.label7);
			this.panelControlsExperimental.Controls.Add(this.cmbStepCurrent);
			this.panelControlsExperimental.Controls.Add(this.cmbStepLoop);
			this.panelControlsExperimental.Controls.Add(this.label5);
			this.panelControlsExperimental.Controls.Add(this.label6);
			this.panelControlsExperimental.Controls.Add(this.cmbStepSize);
			this.panelControlsExperimental.Controls.Add(this.label3);
			this.panelControlsExperimental.Controls.Add(this.label4);
			this.panelControlsExperimental.Controls.Add(this.cmbStepDirection);
			this.panelControlsExperimental.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelControlsExperimental.Location = new System.Drawing.Point(3, 3);
			this.panelControlsExperimental.Name = "panelControlsExperimental";
			this.panelControlsExperimental.Size = new System.Drawing.Size(593, 244);
			this.panelControlsExperimental.TabIndex = 12;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(3, 5);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(237, 13);
			this.label7.TabIndex = 11;
			this.label7.Text = "Fine Step Settings used for experimental purpose";
			// 
			// cmbStepCurrent
			// 
			this.cmbStepCurrent.FormattingEnabled = true;
			this.cmbStepCurrent.Items.AddRange(new object[] {
            "100",
            "200",
            "300",
            "400",
            "500",
            "600",
            "700",
            "800",
            "900",
            "1000"});
			this.cmbStepCurrent.Location = new System.Drawing.Point(97, 81);
			this.cmbStepCurrent.Name = "cmbStepCurrent";
			this.cmbStepCurrent.Size = new System.Drawing.Size(48, 21);
			this.cmbStepCurrent.TabIndex = 8;
			this.cmbStepCurrent.Text = "500";
			// 
			// cmbStepLoop
			// 
			this.cmbStepLoop.FormattingEnabled = true;
			this.cmbStepLoop.Items.AddRange(new object[] {
            "1",
            "200",
            "400",
            "800",
            "1600"});
			this.cmbStepLoop.Location = new System.Drawing.Point(226, 81);
			this.cmbStepLoop.Name = "cmbStepLoop";
			this.cmbStepLoop.Size = new System.Drawing.Size(48, 21);
			this.cmbStepLoop.TabIndex = 10;
			this.cmbStepLoop.Text = "1";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(5, 84);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(41, 13);
			this.label5.TabIndex = 7;
			this.label5.Text = "Current";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(189, 84);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(31, 13);
			this.label6.TabIndex = 9;
			this.label6.Text = "Loop";
			// 
			// cmbStepSize
			// 
			this.cmbStepSize.FormattingEnabled = true;
			this.cmbStepSize.Items.AddRange(new object[] {
            "225",
            "450",
            "900",
            "1800"});
			this.cmbStepSize.Location = new System.Drawing.Point(97, 54);
			this.cmbStepSize.Name = "cmbStepSize";
			this.cmbStepSize.Size = new System.Drawing.Size(48, 21);
			this.cmbStepSize.TabIndex = 6;
			this.cmbStepSize.Text = "1800";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(5, 30);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(74, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "Step Direction";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(5, 57);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(52, 13);
			this.label4.TabIndex = 5;
			this.label4.Text = "Step Size";
			// 
			// cmbStepDirection
			// 
			this.cmbStepDirection.FormattingEnabled = true;
			this.cmbStepDirection.Items.AddRange(new object[] {
            "CW",
            "CCW"});
			this.cmbStepDirection.Location = new System.Drawing.Point(97, 27);
			this.cmbStepDirection.Name = "cmbStepDirection";
			this.cmbStepDirection.Size = new System.Drawing.Size(48, 21);
			this.cmbStepDirection.TabIndex = 4;
			this.cmbStepDirection.Text = "CW";
			// 
			// grpConnection
			// 
			this.grpConnection.Controls.Add(this.panelConnection);
			this.grpConnection.Location = new System.Drawing.Point(3, 6);
			this.grpConnection.Name = "grpConnection";
			this.grpConnection.Size = new System.Drawing.Size(232, 114);
			this.grpConnection.TabIndex = 4;
			this.grpConnection.TabStop = false;
			this.grpConnection.Text = "Connection";
			// 
			// panelConnection
			// 
			this.panelConnection.Controls.Add(this.chkBTTProtocol);
			this.panelConnection.Controls.Add(this.btnConnect);
			this.panelConnection.Controls.Add(this.label2);
			this.panelConnection.Controls.Add(this.label1);
			this.panelConnection.Controls.Add(this.cmbPortBaud);
			this.panelConnection.Controls.Add(this.cmbPortName);
			this.panelConnection.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelConnection.Location = new System.Drawing.Point(3, 16);
			this.panelConnection.Name = "panelConnection";
			this.panelConnection.Size = new System.Drawing.Size(226, 95);
			this.panelConnection.TabIndex = 0;
			// 
			// chkBTTProtocol
			// 
			this.chkBTTProtocol.AutoSize = true;
			this.chkBTTProtocol.Location = new System.Drawing.Point(6, 62);
			this.chkBTTProtocol.Name = "chkBTTProtocol";
			this.chkBTTProtocol.Size = new System.Drawing.Size(110, 17);
			this.chkBTTProtocol.TabIndex = 11;
			this.chkBTTProtocol.Text = "Use BTT protocol";
			this.chkBTTProtocol.UseVisualStyleBackColor = true;
			this.chkBTTProtocol.CheckedChanged += new System.EventHandler(this.ChkBTTProtocol_CheckedChanged);
			// 
			// btnConnect
			// 
			this.btnConnect.Location = new System.Drawing.Point(145, 8);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.Size = new System.Drawing.Size(75, 48);
			this.btnConnect.TabIndex = 10;
			this.btnConnect.Text = "Connect";
			this.btnConnect.UseVisualStyleBackColor = true;
			this.btnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 38);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(32, 13);
			this.label2.TabIndex = 9;
			this.label2.Text = "Baud";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(26, 13);
			this.label1.TabIndex = 8;
			this.label1.Text = "Port";
			// 
			// cmbPortBaud
			// 
			this.cmbPortBaud.FormattingEnabled = true;
			this.cmbPortBaud.Location = new System.Drawing.Point(41, 35);
			this.cmbPortBaud.Name = "cmbPortBaud";
			this.cmbPortBaud.Size = new System.Drawing.Size(98, 21);
			this.cmbPortBaud.TabIndex = 7;
			// 
			// cmbPortName
			// 
			this.cmbPortName.FormattingEnabled = true;
			this.cmbPortName.Location = new System.Drawing.Point(41, 8);
			this.cmbPortName.Name = "cmbPortName";
			this.cmbPortName.Size = new System.Drawing.Size(98, 21);
			this.cmbPortName.TabIndex = 6;
			this.cmbPortName.DropDown += new System.EventHandler(this.cmbPortName_DropDown);
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.Location = new System.Drawing.Point(648, 587);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 5;
			this.btnClose.Text = "&Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// panelMain
			// 
			this.panelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelMain.Controls.Add(this.grpConnection);
			this.panelMain.Controls.Add(this.grpOverview);
			this.panelMain.Controls.Add(this.grpControls);
			this.panelMain.Controls.Add(this.grpParameters);
			this.panelMain.Location = new System.Drawing.Point(12, 12);
			this.panelMain.Name = "panelMain";
			this.panelMain.Size = new System.Drawing.Size(711, 569);
			this.panelMain.TabIndex = 6;
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(735, 622);
			this.Controls.Add(this.panelMain);
			this.Controls.Add(this.btnClose);
			this.DoubleBuffered = true;
			this.MinimumSize = new System.Drawing.Size(450, 650);
			this.Name = "FormMain";
			this.Text = "TrueStep Terminal";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
			this.Load += new System.EventHandler(this.FrmMain_Load);
			this.grpParameters.ResumeLayout(false);
			this.panelParameters.ResumeLayout(false);
			this.panelParameters.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewParameters)).EndInit();
			this.grpOverview.ResumeLayout(false);
			this.panelOverview.ResumeLayout(false);
			this.panelOverview.PerformLayout();
			this.grpControls.ResumeLayout(false);
			this.tabControls.ResumeLayout(false);
			this.tabPageMain.ResumeLayout(false);
			this.panelControlsMain.ResumeLayout(false);
			this.panelControlsMain.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.tabPageTuning.ResumeLayout(false);
			this.panelControlsTuning.ResumeLayout(false);
			this.panelControlsTuning.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numAvgAngleError)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numMaxAngleError)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownStepInterval)).EndInit();
			this.tabPageFirmware.ResumeLayout(false);
			this.panelControlsFirmware.ResumeLayout(false);
			this.panelControlsFirmware.PerformLayout();
			this.tabPageExperimental.ResumeLayout(false);
			this.panelControlsExperimental.ResumeLayout(false);
			this.panelControlsExperimental.PerformLayout();
			this.grpConnection.ResumeLayout(false);
			this.panelConnection.ResumeLayout(false);
			this.panelConnection.PerformLayout();
			this.panelMain.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grpParameters;
        private System.Windows.Forms.GroupBox grpOverview;
        private System.Windows.Forms.GroupBox grpConnection;
        private System.Windows.Forms.Button btnControlGetAngle;
        private System.Windows.Forms.ComboBox cmbStepDirection;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbStepCurrent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbStepSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbStepLoop;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TabControl tabControls;
        private System.Windows.Forms.TabPage tabPageMain;
        private System.Windows.Forms.TabPage tabPageExperimental;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblAngleValue;
        private System.Windows.Forms.Label lblAngleError;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage tabPageTuning;
        private System.Windows.Forms.Button btnFirmwareUpload;
        private System.Windows.Forms.TabPage tabPageFirmware;
        private System.Windows.Forms.ToolTip toolTips;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnFirmwareDownload;
		private FormsPlotMouseYTrack formsPlot1;
		private System.Windows.Forms.Panel panelParameters;
		private System.Windows.Forms.CheckBox chkWriteToFlash;
		private System.Windows.Forms.Button btnWriteParameters;
		private System.Windows.Forms.Button btnReadParameters;
		private System.Windows.Forms.DataGridView dataGridViewParameters;
		private System.Windows.Forms.Panel panelControlsMain;
		private System.Windows.Forms.Button btnMove;
		private System.Windows.Forms.CheckBox chkChangeDirection;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rdClosedLoop;
		private System.Windows.Forms.RadioButton rdOpenLoop;
		private System.Windows.Forms.CheckBox chkEnable;
		private System.Windows.Forms.Button btnControlStep;
		private System.Windows.Forms.Panel panelOverview;
		private System.Windows.Forms.Panel panelControlsTuning;
		private System.Windows.Forms.NumericUpDown numAvgAngleError;
		private System.Windows.Forms.NumericUpDown numMaxAngleError;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.NumericUpDown numericUpDownStepInterval;
		private System.Windows.Forms.Button btnAutoTune;
		private System.Windows.Forms.CheckBox chkTuningEnable;
		private System.Windows.Forms.Panel panelControlsFirmware;
		private System.Windows.Forms.Panel panelControlsExperimental;
		private System.Windows.Forms.Panel panelConnection;
		private System.Windows.Forms.CheckBox chkBTTProtocol;
		private System.Windows.Forms.Button btnConnect;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cmbPortBaud;
		private System.Windows.Forms.ComboBox cmbPortName;
		private System.Windows.Forms.Panel panelMain;
		private System.Windows.Forms.RichTextBox rtfStm32Log;
		private Controls.CustomProgressBar progressBarDownloadProgress;
		private System.Windows.Forms.Button btnBootloaderRun;
		private System.Windows.Forms.GroupBox grpControls;
	}
}

