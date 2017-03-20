using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Security.Permissions;

namespace SimpleOSD
{
    internal partial class OsdForm : Form
    {
        public OsdForm()
        {
            InitializeComponent();

            this.Clickhrough = true;
            this.StartPosition = FormStartPosition.Manual;
            this.CenterToScreen();
        }

        public OsdForm(bool i_Clickhrough)
            : this()
        {
            this.Clickhrough = i_Clickhrough;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                new SecurityPermission(SecurityPermissionFlag.UnmanagedCode).Demand();

                CreateParams baseParams = base.CreateParams;

                baseParams.ExStyle |= (int)WinApi.WS_EX_TOPMOST | (int)WinApi.WS_EX_NOACTIVATE |
                    (int)WinApi.WS_EX_TOOLWINDOW | (int)WinApi.WS_EX_LAYERED;

                if (this.Clickhrough)
                {
                    baseParams.ExStyle |= (int)WinApi.WS_EX_TRANSPARENT;
                }

                return baseParams;
            }
        }

        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }

        public bool Clickhrough
        {
            get;
            set;
        }

        public Label Label
        {
            get { return this.label; }
        }

        public virtual void ShowAnimate()
        {
            WinApi.SetWindowPos(this.Handle, (IntPtr)WinApi.HWND_TOPMOST, 0, 0, 0, 0, WinApi.SWP_NOSIZE | WinApi.SWP_NOACTIVATE | WinApi.SWP_NOMOVE);
            //WinApi.AnimateWindow(base.Handle, 100, WinApi.AnimateWindowFlags.AW_CENTER);
            this.Show();
        }

        public virtual void HideAnimate(int i_Time, WinApi.AnimateWindowFlags i_Animation)
        {
            WinApi.AnimateWindow(base.Handle, i_Time, WinApi.AnimateWindowFlags.AW_HIDE | i_Animation);
            //this.Hide();
        }

        public new void CenterToScreen()
        {
            base.CenterToScreen();
        }

        #region Move Form

        private bool m_Moving = false;
        private Point m_Position;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button == MouseButtons.Left && this.WindowState == FormWindowState.Normal)
            {
                m_Moving = true;
                m_Position = new Point(-e.X, -e.Y);
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (e.Button == MouseButtons.Left)
            {
                m_Moving = false;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (m_Moving)
            {
                Point pos = Cursor.Position;
                pos.Offset(m_Position);
                this.Location = pos;
            }
        }

        #endregion Move Form

        private void label_MouseDown(object sender, MouseEventArgs e)
        {
            this.OnMouseDown(e);
        }

        private void label_MouseMove(object sender, MouseEventArgs e)
        {
            this.OnMouseMove(e);
        }

        private void label_MouseUp(object sender, MouseEventArgs e)
        {
            this.OnMouseUp(e);
        }
    }
}
