using System;
using System.Windows.Forms;
using System.Drawing;

namespace SimpleOSD
{
    public class SimpleOsdForm
    {
        private const int k_DefaultIntervalHide = 1000;
        private const int k_DefaultAnimationSpeed = 100;
        private const WinApi.AnimateWindowFlags k_DefaultAnimation = WinApi.AnimateWindowFlags.AW_CENTER;

        private OsdForm m_OsdForm = new OsdForm();
        private Timer m_Timer = new Timer();

        public event EventHandler Move
        {
            add { this.m_OsdForm.Move += value; }
            remove { this.m_OsdForm.Move -= value; }
        }

        public event MouseEventHandler MouseDown
        {
            add { this.m_OsdForm.MouseDown += value; }
            remove { this.m_OsdForm.MouseDown -= value; }
        }

        public event MouseEventHandler MouseUp
        {
            add { this.m_OsdForm.MouseUp += value; }
            remove { this.m_OsdForm.MouseUp -= value; }
        }

        public SimpleOsdForm()
        {
            this.IntervalHide = k_DefaultIntervalHide;
            this.IntervalAnimation = k_DefaultAnimationSpeed;

            this.m_Timer.Enabled = false;
            this.m_Timer.Tick += new EventHandler(m_Timer_Tick);

            this.Opacity = 1;
        }

        public SimpleOsdForm(bool i_Clickthrough)
            : this()
        {
            this.m_OsdForm.Clickhrough = i_Clickthrough;
        }

        private void m_Timer_Tick(object sender, EventArgs e)
        {
            this.Hide();
        }

        public int IntervalHide
        {
            get { return this.m_Timer.Interval; }
            set { this.m_Timer.Interval = value; }
        }

        private WinApi.AnimateWindowFlags m_Animation = k_DefaultAnimation;

        public WinApi.AnimateWindowFlags Animation
        {
            get { return m_Animation; }
            set
            {
                // workaround opacity bug when using blend animation
                // create new osd object when changing from blend
                if (m_Animation != value)
                {
                    if (m_Animation == WinApi.AnimateWindowFlags.AW_BLEND)
                    {
                        // change from blend
                        bool clickthrough = this.m_OsdForm.Clickhrough;
                        OsdForm o = new OsdForm(m_OsdForm.Clickhrough);
                        m_OsdForm.Close();
                        m_OsdForm = o;
                    }
                    else if (value == WinApi.AnimateWindowFlags.AW_BLEND)
                    {
                        // workaround first blend animation not working
                        m_OsdForm.Opacity = 0;
                        m_OsdForm.Show();
                        m_OsdForm.HideAnimate(1, value);
                        m_OsdForm.WindowState = FormWindowState.Normal;
                    }

                    m_Animation = value;
                }
                m_Animation = value;
            }
        }

        public int IntervalAnimation { get; set; }

        public Label Label
        {
            get { return this.m_OsdForm.Label; }
        }

        public void Show()
        {
            this.m_Timer.Stop();
            this.m_OsdForm.ShowAnimate();
            this.m_Timer.Start();
        }

        public void ShowAlways()
        {
            this.m_Timer.Stop();
            this.m_OsdForm.Show();
        }

        public void ShowAlways(IWin32Window i_Owner)
        {
            this.m_Timer.Stop();
            this.m_OsdForm.Hide();
            this.m_OsdForm.Show(i_Owner);
        }

        public void Hide()
        {
            this.m_Timer.Stop();
            this.m_OsdForm.HideAnimate(this.IntervalAnimation, this.Animation);
        }

        public void HideFast()
        {
            this.m_OsdForm.Hide();
        }

        public void Close()
        {
            this.m_OsdForm.Close();
        }

        public Point Location
        {
            get { return this.m_OsdForm.Location; }
            set { this.m_OsdForm.Location = value; }
        }

        public void CenterToScreen()
        {
            m_OsdForm.CenterToScreen();
        }

        public int Height
        {
            get { return this.m_OsdForm.Height; }
        }

        public int Width
        {
            get { return this.m_OsdForm.Width; }
        }

        public bool Visible
        {
            get { return this.m_OsdForm.Visible; }
        }

        public double Opacity
        {
            get { return this.m_OsdForm.Opacity; }
            set {
                // workaround for blend animation
                if (value != this.m_OsdForm.Opacity && m_Animation != WinApi.AnimateWindowFlags.AW_BLEND)
                {
                    if ((int)value == 1)    // workaround opacity 100%
                        this.m_OsdForm.Opacity = 0.99;
                    this.m_OsdForm.Opacity = value;
                }
            }
        }

        public bool Border
        {
            get { return this.m_OsdForm.Label.BorderStyle != BorderStyle.None; }
            set
            {
                if (value)
                    this.m_OsdForm.Label.BorderStyle = BorderStyle.FixedSingle;
                else
                    this.m_OsdForm.Label.BorderStyle = BorderStyle.None;
            }
        }
    }
}
