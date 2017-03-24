namespace KeyboardIndicator
{
    partial class KeyboardIndicator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KeyboardIndicator));
            this.notifyIconCapsLock = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIconNumLock = new System.Windows.Forms.NotifyIcon(this.components);
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.buttonForeColor = new System.Windows.Forms.Button();
            this.buttonBackColor = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.checkBoxStartWithWindows = new System.Windows.Forms.CheckBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.cbLocation = new System.Windows.Forms.ComboBox();
            this.buttonReset = new System.Windows.Forms.Button();
            this.notifyIconScrollLock = new System.Windows.Forms.NotifyIcon(this.components);
            this.checkBoxEnableSound = new System.Windows.Forms.CheckBox();
            this.tbInsert = new System.Windows.Forms.TextBox();
            this.tbScrollLockOff = new System.Windows.Forms.TextBox();
            this.tbScrollLockOn = new System.Windows.Forms.TextBox();
            this.tbNumLockOff = new System.Windows.Forms.TextBox();
            this.tbNumLockOn = new System.Windows.Forms.TextBox();
            this.tbCapsLockOff = new System.Windows.Forms.TextBox();
            this.tbCapsLockOn = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.buttonFont = new System.Windows.Forms.Button();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.lblAnimation = new System.Windows.Forms.Label();
            this.lblAnimationSpeed = new System.Windows.Forms.Label();
            this.labelOpacity = new System.Windows.Forms.Label();
            this.numAnimationSpeed = new System.Windows.Forms.NumericUpDown();
            this.numOpacity = new System.Windows.Forms.NumericUpDown();
            this.cbAnimation = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cbUseGlobalConfig = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cbStyle = new System.Windows.Forms.ComboBox();
            this.lblManualLocation = new System.Windows.Forms.Label();
            this.tbLocation = new System.Windows.Forms.TextBox();
            this.lblInterval = new System.Windows.Forms.Label();
            this.lblStyle = new System.Windows.Forms.Label();
            this.numInterval = new System.Windows.Forms.NumericUpDown();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.lblAbout = new System.Windows.Forms.Label();
            this.cbOsdBorder = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAnimationSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOpacity)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInterval)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIconCapsLock
            // 
            this.notifyIconCapsLock.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIconCapsLock.Text = "notifyIconCapsLock";
            this.notifyIconCapsLock.Visible = true;
            this.notifyIconCapsLock.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemSettings,
            this.aboutToolStripMenuItem,
            this.menuItemExit});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(117, 70);
            // 
            // menuItemSettings
            // 
            this.menuItemSettings.Name = "menuItemSettings";
            this.menuItemSettings.Size = new System.Drawing.Size(116, 22);
            this.menuItemSettings.Text = "Settings";
            this.menuItemSettings.Click += new System.EventHandler(this.menuItemSettings_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // menuItemExit
            // 
            this.menuItemExit.Name = "menuItemExit";
            this.menuItemExit.Size = new System.Drawing.Size(116, 22);
            this.menuItemExit.Text = "Exit";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // notifyIconNumLock
            // 
            this.notifyIconNumLock.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIconNumLock.Text = "notifyIconNumLock";
            this.notifyIconNumLock.Visible = true;
            this.notifyIconNumLock.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // buttonForeColor
            // 
            this.buttonForeColor.Location = new System.Drawing.Point(6, 6);
            this.buttonForeColor.Name = "buttonForeColor";
            this.buttonForeColor.Size = new System.Drawing.Size(75, 23);
            this.buttonForeColor.TabIndex = 2;
            this.buttonForeColor.Text = "Fore Color";
            this.buttonForeColor.UseVisualStyleBackColor = true;
            this.buttonForeColor.Click += new System.EventHandler(this.buttonForeColor_Click);
            // 
            // buttonBackColor
            // 
            this.buttonBackColor.Location = new System.Drawing.Point(87, 6);
            this.buttonBackColor.Name = "buttonBackColor";
            this.buttonBackColor.Size = new System.Drawing.Size(75, 23);
            this.buttonBackColor.TabIndex = 3;
            this.buttonBackColor.Text = "Back Color";
            this.buttonBackColor.UseVisualStyleBackColor = true;
            this.buttonBackColor.Click += new System.EventHandler(this.buttonBackColor_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Location = new System.Drawing.Point(261, 212);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(342, 212);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // checkBoxStartWithWindows
            // 
            this.checkBoxStartWithWindows.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxStartWithWindows.AutoSize = true;
            this.checkBoxStartWithWindows.Location = new System.Drawing.Point(6, 122);
            this.checkBoxStartWithWindows.Name = "checkBoxStartWithWindows";
            this.checkBoxStartWithWindows.Size = new System.Drawing.Size(114, 17);
            this.checkBoxStartWithWindows.TabIndex = 5;
            this.checkBoxStartWithWindows.Text = "Start with windows";
            this.checkBoxStartWithWindows.UseVisualStyleBackColor = true;
            this.checkBoxStartWithWindows.CheckedChanged += new System.EventHandler(this.checkBoxStartWithWindows_CheckedChanged);
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblLocation.Location = new System.Drawing.Point(6, 6);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(71, 16);
            this.lblLocation.TabIndex = 6;
            this.lblLocation.Text = "Location:";
            // 
            // cbLocation
            // 
            this.cbLocation.DisplayMember = "0";
            this.cbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLocation.FormattingEnabled = true;
            this.cbLocation.Items.AddRange(new object[] {
            "Bottom Left",
            "Bottom Right",
            "Upper Left",
            "Upper Right",
            "Center",
            "Manual"});
            this.cbLocation.Location = new System.Drawing.Point(121, 6);
            this.cbLocation.Name = "cbLocation";
            this.cbLocation.Size = new System.Drawing.Size(121, 21);
            this.cbLocation.TabIndex = 7;
            this.cbLocation.SelectedIndexChanged += new System.EventHandler(this.cbLocation_SelectedIndexChanged);
            // 
            // buttonReset
            // 
            this.buttonReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReset.Location = new System.Drawing.Point(180, 212);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 3;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // notifyIconScrollLock
            // 
            this.notifyIconScrollLock.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIconScrollLock.Text = "notifyIconScrollLock";
            this.notifyIconScrollLock.Visible = true;
            this.notifyIconScrollLock.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // checkBoxEnableSound
            // 
            this.checkBoxEnableSound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxEnableSound.AutoSize = true;
            this.checkBoxEnableSound.Location = new System.Drawing.Point(6, 145);
            this.checkBoxEnableSound.Name = "checkBoxEnableSound";
            this.checkBoxEnableSound.Size = new System.Drawing.Size(91, 17);
            this.checkBoxEnableSound.TabIndex = 5;
            this.checkBoxEnableSound.Text = "Enable sound";
            this.checkBoxEnableSound.UseVisualStyleBackColor = true;
            this.checkBoxEnableSound.CheckedChanged += new System.EventHandler(this.checkBoxEnableSound_CheckedChanged);
            // 
            // tbInsert
            // 
            this.tbInsert.Location = new System.Drawing.Point(2, 94);
            this.tbInsert.Name = "tbInsert";
            this.tbInsert.Size = new System.Drawing.Size(100, 20);
            this.tbInsert.TabIndex = 0;
            this.tbInsert.Text = "Insert";
            this.toolTip1.SetToolTip(this.tbInsert, "Insert");
            // 
            // tbScrollLockOff
            // 
            this.tbScrollLockOff.Location = new System.Drawing.Point(108, 68);
            this.tbScrollLockOff.Name = "tbScrollLockOff";
            this.tbScrollLockOff.Size = new System.Drawing.Size(100, 20);
            this.tbScrollLockOff.TabIndex = 0;
            this.tbScrollLockOff.Text = "Scroll Lock Off";
            this.toolTip1.SetToolTip(this.tbScrollLockOff, "Scroll Lock Off");
            // 
            // tbScrollLockOn
            // 
            this.tbScrollLockOn.Location = new System.Drawing.Point(2, 68);
            this.tbScrollLockOn.Name = "tbScrollLockOn";
            this.tbScrollLockOn.Size = new System.Drawing.Size(100, 20);
            this.tbScrollLockOn.TabIndex = 0;
            this.tbScrollLockOn.Text = "Scroll Lock On";
            this.toolTip1.SetToolTip(this.tbScrollLockOn, "Scroll Lock On");
            // 
            // tbNumLockOff
            // 
            this.tbNumLockOff.Location = new System.Drawing.Point(108, 42);
            this.tbNumLockOff.Name = "tbNumLockOff";
            this.tbNumLockOff.Size = new System.Drawing.Size(100, 20);
            this.tbNumLockOff.TabIndex = 0;
            this.tbNumLockOff.Text = "Num Lock Off";
            this.toolTip1.SetToolTip(this.tbNumLockOff, "Num Lock Off");
            // 
            // tbNumLockOn
            // 
            this.tbNumLockOn.Location = new System.Drawing.Point(2, 42);
            this.tbNumLockOn.Name = "tbNumLockOn";
            this.tbNumLockOn.Size = new System.Drawing.Size(100, 20);
            this.tbNumLockOn.TabIndex = 0;
            this.tbNumLockOn.Text = "Num Lock On";
            this.toolTip1.SetToolTip(this.tbNumLockOn, "Num Lock On");
            // 
            // tbCapsLockOff
            // 
            this.tbCapsLockOff.Location = new System.Drawing.Point(108, 16);
            this.tbCapsLockOff.Name = "tbCapsLockOff";
            this.tbCapsLockOff.Size = new System.Drawing.Size(100, 20);
            this.tbCapsLockOff.TabIndex = 0;
            this.tbCapsLockOff.Text = "Caps Lock Off";
            this.toolTip1.SetToolTip(this.tbCapsLockOff, "Caps Lock Off");
            // 
            // tbCapsLockOn
            // 
            this.tbCapsLockOn.Location = new System.Drawing.Point(2, 16);
            this.tbCapsLockOn.Name = "tbCapsLockOn";
            this.tbCapsLockOn.Size = new System.Drawing.Size(100, 20);
            this.tbCapsLockOn.TabIndex = 0;
            this.tbCapsLockOn.Text = "Caps Lock On";
            this.toolTip1.SetToolTip(this.tbCapsLockOn, "Caps Lock On");
            // 
            // buttonFont
            // 
            this.buttonFont.Location = new System.Drawing.Point(168, 6);
            this.buttonFont.Name = "buttonFont";
            this.buttonFont.Size = new System.Drawing.Size(75, 23);
            this.buttonFont.TabIndex = 9;
            this.buttonFont.Text = "Font";
            this.buttonFont.UseVisualStyleBackColor = true;
            this.buttonFont.Click += new System.EventHandler(this.buttonFont_Click);
            // 
            // lblAnimation
            // 
            this.lblAnimation.AutoSize = true;
            this.lblAnimation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblAnimation.Location = new System.Drawing.Point(6, 115);
            this.lblAnimation.Name = "lblAnimation";
            this.lblAnimation.Size = new System.Drawing.Size(80, 16);
            this.lblAnimation.TabIndex = 11;
            this.lblAnimation.Text = "Animation:";
            // 
            // lblAnimationSpeed
            // 
            this.lblAnimationSpeed.AutoSize = true;
            this.lblAnimationSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblAnimationSpeed.Location = new System.Drawing.Point(6, 142);
            this.lblAnimationSpeed.Name = "lblAnimationSpeed";
            this.lblAnimationSpeed.Size = new System.Drawing.Size(58, 16);
            this.lblAnimationSpeed.TabIndex = 11;
            this.lblAnimationSpeed.Text = "Speed:";
            // 
            // labelOpacity
            // 
            this.labelOpacity.AutoSize = true;
            this.labelOpacity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelOpacity.Location = new System.Drawing.Point(6, 32);
            this.labelOpacity.Name = "labelOpacity";
            this.labelOpacity.Size = new System.Drawing.Size(65, 16);
            this.labelOpacity.TabIndex = 11;
            this.labelOpacity.Text = "Opacity:";
            // 
            // numAnimationSpeed
            // 
            this.numAnimationSpeed.Location = new System.Drawing.Point(121, 142);
            this.numAnimationSpeed.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numAnimationSpeed.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numAnimationSpeed.Name = "numAnimationSpeed";
            this.numAnimationSpeed.Size = new System.Drawing.Size(49, 20);
            this.numAnimationSpeed.TabIndex = 10;
            this.numAnimationSpeed.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numAnimationSpeed.ValueChanged += new System.EventHandler(this.numOpacity_ValueChanged);
            // 
            // numOpacity
            // 
            this.numOpacity.DecimalPlaces = 2;
            this.numOpacity.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numOpacity.Location = new System.Drawing.Point(113, 32);
            this.numOpacity.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numOpacity.Name = "numOpacity";
            this.numOpacity.Size = new System.Drawing.Size(49, 20);
            this.numOpacity.TabIndex = 10;
            this.numOpacity.Value = new decimal(new int[] {
            9,
            0,
            0,
            65536});
            this.numOpacity.ValueChanged += new System.EventHandler(this.numOpacity_ValueChanged);
            // 
            // cbAnimation
            // 
            this.cbAnimation.DisplayMember = "0";
            this.cbAnimation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAnimation.FormattingEnabled = true;
            this.cbAnimation.Location = new System.Drawing.Point(121, 114);
            this.cbAnimation.Name = "cbAnimation";
            this.cbAnimation.Size = new System.Drawing.Size(121, 21);
            this.cbAnimation.TabIndex = 7;
            this.cbAnimation.SelectedIndexChanged += new System.EventHandler(this.cbAnimation_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(409, 194);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cbOsdBorder);
            this.tabPage1.Controls.Add(this.buttonForeColor);
            this.tabPage1.Controls.Add(this.buttonBackColor);
            this.tabPage1.Controls.Add(this.labelOpacity);
            this.tabPage1.Controls.Add(this.numOpacity);
            this.tabPage1.Controls.Add(this.cbUseGlobalConfig);
            this.tabPage1.Controls.Add(this.checkBoxStartWithWindows);
            this.tabPage1.Controls.Add(this.buttonFont);
            this.tabPage1.Controls.Add(this.checkBoxEnableSound);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(401, 168);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cbUseGlobalConfig
            // 
            this.cbUseGlobalConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbUseGlobalConfig.AutoSize = true;
            this.cbUseGlobalConfig.Location = new System.Drawing.Point(6, 99);
            this.cbUseGlobalConfig.Name = "cbUseGlobalConfig";
            this.cbUseGlobalConfig.Size = new System.Drawing.Size(248, 17);
            this.cbUseGlobalConfig.TabIndex = 5;
            this.cbUseGlobalConfig.Text = "Save to global configuration instead of per user";
            this.cbUseGlobalConfig.UseVisualStyleBackColor = true;
            this.cbUseGlobalConfig.CheckedChanged += new System.EventHandler(this.checkBoxStartWithWindows_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cbStyle);
            this.tabPage2.Controls.Add(this.lblManualLocation);
            this.tabPage2.Controls.Add(this.tbLocation);
            this.tabPage2.Controls.Add(this.lblInterval);
            this.tabPage2.Controls.Add(this.lblAnimation);
            this.tabPage2.Controls.Add(this.lblStyle);
            this.tabPage2.Controls.Add(this.lblLocation);
            this.tabPage2.Controls.Add(this.lblAnimationSpeed);
            this.tabPage2.Controls.Add(this.cbLocation);
            this.tabPage2.Controls.Add(this.numInterval);
            this.tabPage2.Controls.Add(this.numAnimationSpeed);
            this.tabPage2.Controls.Add(this.cbAnimation);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(401, 168);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "View";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cbStyle
            // 
            this.cbStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStyle.FormattingEnabled = true;
            this.cbStyle.Location = new System.Drawing.Point(121, 46);
            this.cbStyle.Name = "cbStyle";
            this.cbStyle.Size = new System.Drawing.Size(152, 21);
            this.cbStyle.TabIndex = 3;
            this.cbStyle.SelectedIndexChanged += new System.EventHandler(this.cbStyle_SelectedIndexChanged);
            // 
            // lblManualLocation
            // 
            this.lblManualLocation.AutoSize = true;
            this.lblManualLocation.Location = new System.Drawing.Point(118, 30);
            this.lblManualLocation.Name = "lblManualLocation";
            this.lblManualLocation.Size = new System.Drawing.Size(202, 13);
            this.lblManualLocation.TabIndex = 13;
            this.lblManualLocation.Text = "For manual position drag the example osd";
            // 
            // tbLocation
            // 
            this.tbLocation.Enabled = false;
            this.tbLocation.Location = new System.Drawing.Point(260, 6);
            this.tbLocation.Name = "tbLocation";
            this.tbLocation.Size = new System.Drawing.Size(88, 20);
            this.tbLocation.TabIndex = 12;
            // 
            // lblInterval
            // 
            this.lblInterval.AutoSize = true;
            this.lblInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblInterval.Location = new System.Drawing.Point(6, 88);
            this.lblInterval.Name = "lblInterval";
            this.lblInterval.Size = new System.Drawing.Size(63, 16);
            this.lblInterval.TabIndex = 11;
            this.lblInterval.Text = "Interval:";
            // 
            // lblStyle
            // 
            this.lblStyle.AutoSize = true;
            this.lblStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblStyle.Location = new System.Drawing.Point(6, 47);
            this.lblStyle.Name = "lblStyle";
            this.lblStyle.Size = new System.Drawing.Size(47, 16);
            this.lblStyle.TabIndex = 6;
            this.lblStyle.Text = "Style:";
            // 
            // numInterval
            // 
            this.numInterval.Location = new System.Drawing.Point(121, 88);
            this.numInterval.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numInterval.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numInterval.Name = "numInterval";
            this.numInterval.Size = new System.Drawing.Size(49, 20);
            this.numInterval.TabIndex = 10;
            this.numInterval.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numInterval.ValueChanged += new System.EventHandler(this.numOpacity_ValueChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.tbInsert);
            this.tabPage3.Controls.Add(this.tbCapsLockOn);
            this.tabPage3.Controls.Add(this.tbScrollLockOff);
            this.tabPage3.Controls.Add(this.tbCapsLockOff);
            this.tabPage3.Controls.Add(this.tbScrollLockOn);
            this.tabPage3.Controls.Add(this.tbNumLockOn);
            this.tabPage3.Controls.Add(this.tbNumLockOff);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(401, 168);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Labels";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Leave blank to disable osd message";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.lblAbout);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(401, 168);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "About";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // lblAbout
            // 
            this.lblAbout.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAbout.Location = new System.Drawing.Point(9, 12);
            this.lblAbout.Margin = new System.Windows.Forms.Padding(0);
            this.lblAbout.Name = "lblAbout";
            this.lblAbout.Size = new System.Drawing.Size(366, 141);
            this.lblAbout.TabIndex = 10;
            this.lblAbout.Text = "About";
            // 
            // cbOsdBorder
            // 
            this.cbOsdBorder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbOsdBorder.AutoSize = true;
            this.cbOsdBorder.Location = new System.Drawing.Point(6, 76);
            this.cbOsdBorder.Name = "cbOsdBorder";
            this.cbOsdBorder.Size = new System.Drawing.Size(86, 17);
            this.cbOsdBorder.TabIndex = 12;
            this.cbOsdBorder.Text = "Show border";
            this.cbOsdBorder.UseVisualStyleBackColor = true;
            this.cbOsdBorder.CheckedChanged += new System.EventHandler(this.cbOsdBorder_CheckedChanged);
            // 
            // KeyboardIndicator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(433, 246);
            this.ContextMenuStrip = this.contextMenuStrip;
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonReset);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "KeyboardIndicator";
            this.ShowInTaskbar = false;
            this.Text = "Keyboard Indicator";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numAnimationSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOpacity)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInterval)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIconCapsLock;
        private System.Windows.Forms.NotifyIcon notifyIconNumLock;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button buttonForeColor;
        private System.Windows.Forms.Button buttonBackColor;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.CheckBox checkBoxStartWithWindows;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.ComboBox cbLocation;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.NotifyIcon notifyIconScrollLock;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;
        private System.Windows.Forms.ToolStripMenuItem menuItemSettings;
        private System.Windows.Forms.CheckBox checkBoxEnableSound;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TextBox tbCapsLockOn;
        private System.Windows.Forms.TextBox tbScrollLockOff;
        private System.Windows.Forms.TextBox tbScrollLockOn;
        private System.Windows.Forms.TextBox tbNumLockOff;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox tbNumLockOn;
        private System.Windows.Forms.TextBox tbCapsLockOff;
        private System.Windows.Forms.TextBox tbInsert;
        private System.Windows.Forms.Button buttonFont;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.Label labelOpacity;
        private System.Windows.Forms.NumericUpDown numOpacity;
        private System.Windows.Forms.ComboBox cbAnimation;
        private System.Windows.Forms.Label lblAnimation;
        private System.Windows.Forms.NumericUpDown numAnimationSpeed;
        private System.Windows.Forms.Label lblAnimationSpeed;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox tbLocation;
        private System.Windows.Forms.Label lblManualLocation;
        private System.Windows.Forms.Label lblAbout;
        private System.Windows.Forms.ComboBox cbStyle;
        private System.Windows.Forms.Label lblStyle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblInterval;
        private System.Windows.Forms.NumericUpDown numInterval;
        private System.Windows.Forms.CheckBox cbUseGlobalConfig;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.CheckBox cbOsdBorder;
    }
}