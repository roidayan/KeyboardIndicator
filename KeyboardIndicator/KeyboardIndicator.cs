using System;
using System.Reflection;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
using System.Collections.Generic;
using Microsoft.Win32;
using SimpleOSD;
using KeyHook;
using AnimateWindowFlags = SimpleOSD.WinApi.AnimateWindowFlags;


namespace KeyboardIndicator
{
    public partial class KeyboardIndicator : Form
    {
        static AssemblyCopyrightAttribute copyright = Assembly.GetExecutingAssembly()
            .GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false)[0] as AssemblyCopyrightAttribute;

        static AssemblyDescriptionAttribute desc = Assembly.GetExecutingAssembly()
            .GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false)[0] as AssemblyDescriptionAttribute;

        private readonly string r_AboutString = string.Format("{0} {1}\n{2}\n{3}",
            Application.ProductName,
            Application.ProductVersion,
            copyright.Copyright,
            desc.Description);

        private const bool k_ResetColors = true;
        private string m_OsdString;
        private eLocation m_OsdLocation = eLocation.BottomRight;
        private SimpleOsdForm m_OSD = new SimpleOsdForm();
        private SimpleOsdForm m_ExampleOSD = null;
        private const int k_Margin = 3;
        private Keys m_LastKey = Keys.None;
        private SoundPlayer m_SoundPlayer = null;
        private bool m_EnableSound = true;
        private AnimateWindowFlags m_HideAnimation = AnimateWindowFlags.AW_CENTER;
        private eStyle m_Style = eStyle.Normal;
        
        KeyboardHook m_KBH = new KeyboardHook();

        private Icon[] m_IndicatorIcons = new Icon[] {
            Icon.FromHandle(Properties.Resources.CapsLockOff.GetHicon()),
            Icon.FromHandle(Properties.Resources.CapsLockOn.GetHicon()),
            Icon.FromHandle(Properties.Resources.NumLockOff.GetHicon()),
            Icon.FromHandle(Properties.Resources.NumLockOn.GetHicon()),
            Icon.FromHandle(Properties.Resources.ScrollLockOff.GetHicon()),
            Icon.FromHandle(Properties.Resources.ScrollLockOn.GetHicon())
        };

        public enum eStyle
        {
            Normal,
            StickyHorizontal,
            StickyVertical
        }

        private enum eIconIndex : int
        {
            CapsLockOff,
            CapsLockOn,
            NumLockOff,
            NumLockOn,
            ScrollLockOff,
            ScrollLockOn
        }

        public KeyboardIndicator()
        {
            InitializeComponent();
            
            this.fillAnimationCb();
            this.fillStyleCb();
            lblAbout.Text = r_AboutString;
        }

        private void fillStyleCb()
        {
            List<KeyValuePair<string, eStyle>> l = new List<KeyValuePair<string, eStyle>>();
            l.Add(new KeyValuePair<string, eStyle>("Normal", eStyle.Normal));
            l.Add(new KeyValuePair<string, eStyle>("Sticky Horizontal", eStyle.StickyHorizontal));
            l.Add(new KeyValuePair<string, eStyle>("Sticky Vertical", eStyle.StickyVertical));
            cbStyle.DataSource = l;
            cbStyle.ValueMember = "Key";
        }

        private void fillAnimationCb()
        {
            List<KeyValuePair<string, AnimateWindowFlags>> l = new List<KeyValuePair<string, AnimateWindowFlags>>();
            l.Add(new KeyValuePair<string, AnimateWindowFlags>("Center", AnimateWindowFlags.AW_CENTER));
            l.Add(new KeyValuePair<string, AnimateWindowFlags>("Blend", AnimateWindowFlags.AW_BLEND));
            l.Add(new KeyValuePair<string, AnimateWindowFlags>("Horizontal Negative", AnimateWindowFlags.AW_HOR_NEGATIVE));
            l.Add(new KeyValuePair<string, AnimateWindowFlags>("Horizontal Positive", AnimateWindowFlags.AW_HOR_POSITIVE));
            l.Add(new KeyValuePair<string, AnimateWindowFlags>("Vertical Negative", AnimateWindowFlags.AW_VER_NEGATIVE));
            l.Add(new KeyValuePair<string, AnimateWindowFlags>("Vertical Positive", AnimateWindowFlags.AW_VER_POSITIVE));
            cbAnimation.DataSource = l;
            cbAnimation.ValueMember = "Key";
        }

        private void selectAnimationCb(AnimateWindowFlags i_Animation)
        {
            foreach (KeyValuePair<string, AnimateWindowFlags> item in cbAnimation.Items)
            {
                if (item.Value == i_Animation)
                {
                    cbAnimation.SelectedItem = item;
                    break;
                }
            }
        }

        private void selectStyleCb(eStyle i_Style)
        {
            foreach (KeyValuePair<string, eStyle> item in cbStyle.Items)
            {
                if (item.Value == i_Style)
                {
                    cbStyle.SelectedItem = item;
                    break;
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.hideMyself();
            this.loadSettings();
            this.m_KBH.KeyDownIntercepted += new KeyboardHook.KeyboardHookEventHandler(KBH_KeyDownIntercepted);
            this.m_KBH.KeyUpIntercepted += new KeyboardHook.KeyboardHookEventHandler(KBH_KeyUpIntercepted);
        }

        private void updateModifiers()
        {
            this.updateCapsLock(KeyboardState.CapsLock);
            this.updateNumLock(KeyboardState.NumLock);
            this.updateScrollLock(KeyboardState.Scroll);
        }

        void KBH_KeyUpIntercepted(KeyboardHook.KeyboardHookEventArgs e)
        {
            this.m_LastKey = Keys.None;
        }

        private void KBH_KeyDownIntercepted(KeyboardHook.KeyboardHookEventArgs e)
        {
            // note: key not intercepted yet by the os
            // e.g. caps lock press from off to on still gives False

            if (e.Key != this.m_LastKey)
            {
                switch (e.Key)
                {
                    case Keys.CapsLock:
                        this.updateCapsLock(!KeyboardState.CapsLock);
                        this.ShowOSD();
                        break;

                    case Keys.NumLock:
                        this.updateNumLock(!KeyboardState.NumLock);
                        this.ShowOSD();
                        break;

                    case Keys.Scroll:
                        this.updateScrollLock(!KeyboardState.Scroll);
                        this.ShowOSD();
                        break;

                    case Keys.Insert:
                        this.updateInsert();
                        this.ShowOSD();
                        break;
                }

                this.m_LastKey = e.Key;
            }
        }

        private void updateCapsLock(bool i_Toggle)
        {
            string text = i_Toggle ? tbCapsLockOn.Text : tbCapsLockOff.Text;
            this.m_OsdString = text;
            this.notifyIconCapsLock.Icon = i_Toggle ? this.m_IndicatorIcons[(int)eIconIndex.CapsLockOn]
                                    : this.m_IndicatorIcons[(int)eIconIndex.CapsLockOff];
            this.notifyIconCapsLock.Text = text;
            this.notifyIconCapsLock.BalloonTipText = text;
            this.m_ListLabels[(int)eOSD.CapsLock] = text;
        }

        private void updateNumLock(bool i_Toggle)
        {
            string text = i_Toggle ? tbNumLockOn.Text : tbNumLockOff.Text;
            this.m_OsdString = text;
            this.notifyIconNumLock.Icon = i_Toggle ? this.m_IndicatorIcons[(int)eIconIndex.NumLockOn]
                                    : this.m_IndicatorIcons[(int)eIconIndex.NumLockOff];
            this.notifyIconNumLock.Text = text;
            this.notifyIconNumLock.BalloonTipText = text;
            this.m_ListLabels[(int)eOSD.NumLock] = text;
        }

        private void updateScrollLock(bool i_Toggle)
        {
            string text = i_Toggle ? tbScrollLockOn.Text : tbScrollLockOff.Text;
            this.m_OsdString = text;
            this.notifyIconScrollLock.Icon = i_Toggle ? this.m_IndicatorIcons[(int)eIconIndex.ScrollLockOn]
                                    : this.m_IndicatorIcons[(int)eIconIndex.ScrollLockOff];
            this.notifyIconScrollLock.Text = text;
            this.notifyIconScrollLock.BalloonTipText = text;
            this.m_ListLabels[(int)eOSD.ScrollLock] = text;
        }

        private void updateInsert()
        {
            this.m_OsdString = tbInsert.Text;
        }

        private void ShowOSD()
        {
            if (m_Style == eStyle.Normal && this.m_OsdString != string.Empty)
            {
                this.m_OSD.Label.Text = this.m_OsdString;
                Point p = new Point();
                p.X = SystemInformation.VirtualScreen.X;
                p.Y = SystemInformation.VirtualScreen.Y;
                //this.m_OSD.Location = new Point(p.X, p.Y);
                this.updateLocation();
                this.m_OSD.Show();
            }
            else
            {
                this.updateStickyOSD();
            }
            this.playSound();
        }

        private enum eOSD : int
        {
            CapsLock,
            NumLock,
            ScrollLock
        }

        private List<string> m_ListLabels =
            new List<string>(3) { string.Empty, string.Empty, string.Empty };

        private List<SimpleOsdForm> m_ListStickyOSD = new List<SimpleOsdForm>(3);

        private void updateStickyOSD()
        {
            // style normal - hide and return
            if (this.m_Style == eStyle.Normal)
            {
                foreach (SimpleOsdForm o in m_ListStickyOSD)
                    o.HideFast();
                return;
            }

            // initialize osds
            if (m_ListStickyOSD.Count == 0)
            {
                for (int c = 0; c < 3; c++)
                {
                    SimpleOsdForm o = new SimpleOsdForm();
                    this.applySettingsToOSD(o);
                    m_ListStickyOSD.Add(o);
                }
            }

            int width = 0;
            int height = 0;
            int active = 0;

            foreach (eOSD o in Enum.GetValues(typeof(eOSD)))
            {
                int i = (int)o;

                if (m_ListLabels[i] == string.Empty)
                {
                    m_ListStickyOSD[i].HideFast();
                    continue;
                }

                active++;

                m_ListStickyOSD[i].Label.AutoSize = true; // this fix width and height
                m_ListStickyOSD[i].Label.Text = m_ListLabels[i];
                
                // get max width
                if (m_ListStickyOSD[i].Label.Width > width)
                    width = m_ListStickyOSD[i].Label.Width;

                if (height == 0)
                    height = m_ListStickyOSD[i].Label.Height;

                m_ListStickyOSD[i].ShowAlways();
            }

            Point p = this.m_OSD.Location;

            if (this.m_OsdLocation == eLocation.BottomRight ||
                this.m_OsdLocation == eLocation.UpperRight)
            {
                p.X = Screen.PrimaryScreen.WorkingArea.Width - width - k_Margin;
            }

            int horizontal_width = active * width + active * k_Margin;
            int hz_half_width = horizontal_width / 2;

            if (this.m_Style == eStyle.StickyHorizontal &&
                (this.m_OsdLocation == eLocation.BottomRight ||
                 this.m_OsdLocation == eLocation.UpperRight))
            {
                p.X = Screen.PrimaryScreen.WorkingArea.Width - horizontal_width;
            }

            int vertical_height = active * height + active * k_Margin;
            int vt_half_height = vertical_height / 2;

            if (this.m_Style == eStyle.StickyVertical &&
                (this.m_OsdLocation == eLocation.BottomLeft ||
                 this.m_OsdLocation == eLocation.BottomRight))
            {
                p.Y = Screen.PrimaryScreen.WorkingArea.Height - vertical_height;
            }

            if (this.m_OsdLocation == eLocation.Center)
            {
                if (this.m_Style == eStyle.StickyHorizontal)
                    p.X = p.X - hz_half_width;
                else if (this.m_Style == eStyle.StickyVertical)
                    p.Y = p.Y - vt_half_height;
            }

            this.m_OSD.Location = p;

            foreach (eOSD o in Enum.GetValues(typeof(eOSD)))
            {
                int i = (int)o;

                if (m_ListLabels[i] == string.Empty)
                    continue;

                m_ListStickyOSD[i].Location = p;

                switch (this.m_Style)
                {
                    case eStyle.StickyHorizontal:
                        //p.X = p.X + m_ListStickyOSD[i].Label.Width + k_Margin;
                        p.X = p.X + width + k_Margin;
                        break;

                    case eStyle.StickyVertical:
                        p.Y = p.Y + m_ListStickyOSD[i].Label.Height + k_Margin;
                        break;
                }
            }

            foreach (SimpleOsdForm o in m_ListStickyOSD)
            {
                if (width > 0)
                {
                    // fixed width for sticky vertical
                    o.Label.AutoSize = false;
                    o.Label.Width = width;
                }
            }
        }

        private void playSound()
        {
            if (this.m_EnableSound && this.m_SoundPlayer != null)
            {
                this.m_SoundPlayer.Play();
            }
        }

        private void updateLocation()
        {
            switch (this.m_OsdLocation)
            {
                case eLocation.BottomLeft:
                    this.setBottomLeft(this.m_OSD);
                    break;

                case eLocation.BottomRight:
                    this.setBottomRight(this.m_OSD);
                    break;

                case eLocation.UpperLeft:
                    this.setUpperLeft(this.m_OSD);
                    break;
                
                case eLocation.UpperRight:
                    this.setUpperRight(this.m_OSD);
                    break;

                case eLocation.Center:
                    this.m_OSD.CenterToScreen();
                    break;

                case eLocation.Manual:
                    this.m_OSD.Location = Properties.Settings.Default.OsdPoint;
                    break;
            }
        }

        private enum eLocation
        {
            BottomLeft,
            BottomRight,
            UpperLeft,
            UpperRight,
            Center,
            Manual
        }

        private void setBottomLeft(SimpleOsdForm i_Osd)
        {
            Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
            int x = workingArea.Left + k_Margin;
            int y = workingArea.Bottom - i_Osd.Height - k_Margin;
            i_Osd.Location = new Point(x, y);
        }

        private void setBottomRight(SimpleOsdForm i_Osd)
        {
            Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
            int x = workingArea.Right - i_Osd.Width - k_Margin;
            int y = workingArea.Bottom - i_Osd.Height - k_Margin;
            i_Osd.Location = new Point(x, y);
        }

        private void setUpperLeft(SimpleOsdForm i_Osd)
        {
            i_Osd.Location = new Point(k_Margin, k_Margin);
        }

        private void setUpperRight(SimpleOsdForm i_Osd)
        {
            this.setBottomRight(i_Osd);
            i_Osd.Location = new Point(i_Osd.Location.X, k_Margin);
        }

        private void buttonForeColor_Click(object sender, EventArgs e)
        {
            this.colorDialog.Color = this.m_ExampleOSD.Label.ForeColor;

            if (this.colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.m_ExampleOSD.Label.ForeColor = this.colorDialog.Color;
            }
        }

        private void buttonBackColor_Click(object sender, EventArgs e)
        {
            this.colorDialog.Color = this.m_ExampleOSD.Label.BackColor;

            if (this.colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.m_ExampleOSD.Label.BackColor = this.colorDialog.Color;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.hideMyself();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.saveSettings();
            this.updateModifiers();
            this.applySettings();
            this.updateStickyOSD();
            this.hideMyself();
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.showMyself();
        }

        private void showMyself()
        {
            this.ShowInTaskbar = true;
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.loadExample();
            this.Activate();
        }

        private void loadExample()
        {
            if (this.m_ExampleOSD == null)
            {
                const bool k_Clickthrough = true;

                this.m_ExampleOSD = new SimpleOsdForm(!k_Clickthrough);
                this.m_ExampleOSD.MouseUp += new MouseEventHandler(m_ExampleOSD_MouseUp);
                this.m_ExampleOSD.MouseDown += new MouseEventHandler(m_ExampleOSD_MouseDown);
                this.m_ExampleOSD.Move += new EventHandler(m_ExampleOSD_Move);
                this.m_ExampleOSD.Label.Text = "Example";
                this.updateExampleLocation();

                this.applySettingsToOSD(this.m_ExampleOSD);
            }

            this.m_ExampleOSD.ShowAlways(this);
        }

        private void applySettingsToOSD(SimpleOsdForm i_Osd)
        {
            i_Osd.HideFast();
            // apply initial settings
            i_Osd.Label.ForeColor = Properties.Settings.Default.ForeColor;
            i_Osd.Label.BackColor = Properties.Settings.Default.BackColor;
            i_Osd.Label.Font = Properties.Settings.Default.Font;
            i_Osd.Opacity = Properties.Settings.Default.Opacity;
            i_Osd.Border = Properties.Settings.Default.OsdBorder;
        }

        private bool m_OsdMove = false;

        void m_ExampleOSD_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                m_OsdMove = true;
            }
        }

        void m_ExampleOSD_Move(object sender, EventArgs e)
        {
            if (m_OsdMove)
            {
                tbLocation.Text = this.m_ExampleOSD.Location.ToString();
            }
        }

        void m_ExampleOSD_MouseUp(object sender, MouseEventArgs e)
        {
            if (m_OsdMove && e.Button == MouseButtons.Left)
            {
                m_OsdMove = false;
                tbLocation.Text = new PointConverter().ConvertToString(this.m_ExampleOSD.Location);
                Properties.Settings.Default.OsdPoint = (Point)(new PointConverter().ConvertFromString(tbLocation.Text));
                this.updateExampleLocation();
                this.updateLocation();
            }
        }

        private void updateExampleLocation()
        {
            const int k_PadTop = 10;
            Point location = this.Location;
            location.Y += this.Height + k_PadTop;
            this.m_ExampleOSD.Location = location;
        }

        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);

            if (this.m_ExampleOSD != null)
            {
                this.updateExampleLocation();
            }
        }

        private void hideMyself()
        {
            this.WindowState = FormWindowState.Minimized;
            this.Hide();
        }

        private void checkBoxStartWithWindows_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxStartWithWindows.Checked)
            {
                this.setOnStartup();
            }
            else
            {
                this.removeFromStartup();
            }
        }

        #region Registry Handling

        //HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run
        const string k_RegSoftMicrosoftWinCurrVerRun = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
        const string k_RegKeyboardIndicator = "KeyboardIndicator";
        const bool v_Writeable = true;

        private bool isOnStartup()
        {
            const bool v_OnStartup = true;
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey(k_RegSoftMicrosoftWinCurrVerRun, !v_Writeable);
            object value = regKey.GetValue(k_RegKeyboardIndicator);

            return value == null ? !v_OnStartup : v_OnStartup;
        }

        private void setOnStartup()
        {
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey(k_RegSoftMicrosoftWinCurrVerRun, v_Writeable);
            object value = regKey.GetValue(k_RegKeyboardIndicator);

            if (value == null)
            {
                string regStartup = Environment.CommandLine;
                regKey.SetValue(k_RegKeyboardIndicator, regStartup);
            }

            regKey.Close();
        }

        private void removeFromStartup()
        {
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey(k_RegSoftMicrosoftWinCurrVerRun, v_Writeable);
            object value = regKey.GetValue(k_RegKeyboardIndicator);

            if (value != null)
            {
                regKey.DeleteValue(k_RegKeyboardIndicator);
            }

            regKey.Close();
        }

        #endregion Registry Handling

        private void loadSettings()
        {
            // Global config
            this.cbUseGlobalConfig.Checked = Properties.Settings.Default.UseGlobalConfig;

            // Registry
            this.checkBoxStartWithWindows.Checked = this.isOnStartup();
            
            // Sound
            this.m_EnableSound = Properties.Settings.Default.EnableSound;
            this.checkBoxEnableSound.Checked = this.m_EnableSound;
            
            if (this.m_EnableSound)
            {
                this.loadSound();
            }

            // Location
            try
            {
                this.m_OsdLocation = (eLocation)Enum.Parse(typeof(eLocation), Properties.Settings.Default.OsdLocation);
            }
            catch
            {
                this.m_OsdLocation = eLocation.BottomRight;
            }
            this.cbLocation.SelectedIndex = (int)this.m_OsdLocation;
            tbLocation.Text = new PointConverter().ConvertToString(Properties.Settings.Default.OsdPoint);

            // Text
            tbCapsLockOn.Text = Properties.Settings.Default.CapsLockOn.Trim();
            tbCapsLockOff.Text = Properties.Settings.Default.CapsLockOff.Trim();
            tbNumLockOn.Text = Properties.Settings.Default.NumLockOn.Trim();
            tbNumLockOff.Text = Properties.Settings.Default.NumLockOff.Trim();
            tbScrollLockOn.Text = Properties.Settings.Default.ScrollLockOn.Trim();
            tbScrollLockOff.Text = Properties.Settings.Default.ScrollLockOff.Trim();
            tbInsert.Text = Properties.Settings.Default.InsertPress.Trim();

            numOpacity.Value = (decimal) Properties.Settings.Default.Opacity;
            cbOsdBorder.Checked = Properties.Settings.Default.OsdBorder;

            // Animation
            try
            {
                this.m_HideAnimation = (AnimateWindowFlags)Enum.Parse(typeof(AnimateWindowFlags), Properties.Settings.Default.HideAnimation);
            }
            catch
            {
                this.m_HideAnimation = AnimateWindowFlags.AW_CENTER;
            }
            this.selectAnimationCb(this.m_HideAnimation);
            this.numAnimationSpeed.Value = Properties.Settings.Default.AnimationSpeed;
            
            // Interval
            this.numInterval.Value = Properties.Settings.Default.Interval;

            // Style
            try
            {
                this.m_Style = (eStyle)Enum.Parse(typeof(eStyle), Properties.Settings.Default.OsdStyle);
            }
            catch
            {
                this.m_Style = eStyle.Normal;
            }
            this.selectStyleCb(this.m_Style);

            this.updateModifiers();
            this.applySettings();
            this.updateStickyOSD();
        }

        private void loadSound()
        {
            if (this.m_SoundPlayer == null)
            {
                this.m_SoundPlayer = new SoundPlayer(Properties.Resources.WavClick);
                // This make sure first Play() execution wont freeze a little.
                this.m_SoundPlayer.LoadAsync();
                this.m_SoundPlayer.Stop();
            }
        }

        /// <summary>
        /// Apply settings from the example osd
        /// </summary>
        private void applySettings()
        {
            this.m_OSD.Animation = this.m_HideAnimation;
            this.m_OSD.IntervalAnimation = (int)numAnimationSpeed.Value;
            this.m_OSD.IntervalHide = (int)numInterval.Value;
            this.applySettingsToOSD(this.m_OSD);

            this.updateLocation();

            foreach (SimpleOsdForm o in this.m_ListStickyOSD)
                this.applySettingsToOSD(o);
        }

        private void saveSettings()
        {
            Properties.Settings.Default.CapsLockOn = tbCapsLockOn.Text.Trim();
            Properties.Settings.Default.CapsLockOff = tbCapsLockOff.Text.Trim();
            Properties.Settings.Default.NumLockOn = tbNumLockOn.Text.Trim();
            Properties.Settings.Default.NumLockOff = tbNumLockOff.Text.Trim();
            Properties.Settings.Default.ScrollLockOn = tbScrollLockOn.Text.Trim();
            Properties.Settings.Default.ScrollLockOff = tbScrollLockOff.Text.Trim();
            Properties.Settings.Default.InsertPress = tbInsert.Text.Trim();
            Properties.Settings.Default.OsdLocation = this.m_OsdLocation.ToString();
            Properties.Settings.Default.OsdPoint = (Point)(new PointConverter().ConvertFromString(tbLocation.Text));
            Properties.Settings.Default.OsdStyle = this.m_Style.ToString();
            Properties.Settings.Default.ForeColor = this.m_ExampleOSD.Label.ForeColor;
            Properties.Settings.Default.BackColor = this.m_ExampleOSD.Label.BackColor;
            Properties.Settings.Default.Font = this.m_ExampleOSD.Label.Font;
            Properties.Settings.Default.Opacity = this.m_ExampleOSD.Opacity;
            Properties.Settings.Default.HideAnimation = this.m_HideAnimation.ToString();
            Properties.Settings.Default.AnimationSpeed = (int)numAnimationSpeed.Value;
            Properties.Settings.Default.Interval = (int)numInterval.Value;
            Properties.Settings.Default.EnableSound = this.m_EnableSound;
            Properties.Settings.Default.UseGlobalConfig = this.cbUseGlobalConfig.Checked;
            Properties.Settings.Default.OsdBorder = this.cbOsdBorder.Checked;

            if (cbUseGlobalConfig.Checked)
            {
                saveSettingsGlobal();
            }
            else
            {
                Properties.Settings.Default.Save();
            }
        }

        private void saveSettingsGlobal()
        {
            CustomSettings.Default.Save();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            this.resetSettings();
        }

        private void resetSettings()
        {
            Properties.Settings.Default.Reset();
            this.loadSettings();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.hideMyself();
            }

            base.OnFormClosing(e);
        }

        private void menuItemSettings_Click(object sender, EventArgs e)
        {
            this.showMyself();
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBoxEnableSound_CheckedChanged(object sender, EventArgs e)
        {
            this.m_EnableSound = this.checkBoxEnableSound.Checked;

            if (this.m_EnableSound)
            {
                this.loadSound();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, r_AboutString, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonFont_Click(object sender, EventArgs e)
        {
            this.fontDialog.Font = this.m_ExampleOSD.Label.Font;

            if (this.fontDialog.ShowDialog() == DialogResult.OK)
            {
                this.m_ExampleOSD.Label.Font = this.fontDialog.Font;
            }
        }

        private void cbLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.m_OsdLocation = (eLocation)cbLocation.SelectedIndex;
            tbLocation.Enabled = m_OsdLocation == eLocation.Manual;
            updateLocation();
        }

        private void numOpacity_ValueChanged(object sender, EventArgs e)
        {
            if (this.m_ExampleOSD != null)
            {
                this.m_ExampleOSD.Opacity = (double)numOpacity.Value;
            }
        }

        private void cbOsdBorder_CheckedChanged(object sender, EventArgs e)
        {
            if (this.m_ExampleOSD != null)
            {
                this.m_ExampleOSD.Border = this.cbOsdBorder.Checked;
            }
        }

        private void cbAnimation_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeyValuePair<string, AnimateWindowFlags> item = (KeyValuePair<string, AnimateWindowFlags>)cbAnimation.SelectedItem;
            this.m_HideAnimation = item.Value;
        }

        private void cbStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeyValuePair<string, eStyle> item = (KeyValuePair<string, eStyle>)cbStyle.SelectedItem;
            this.m_Style = item.Value;
            this.updateStickyOSD();
        }
    }
}
