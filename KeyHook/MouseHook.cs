using System;
using System.Diagnostics;

namespace KeyHook
{
    public class MouseHook : IDisposable
    {
        // Variables used in the call to SetWindowsHookEx
        private WinApi.LowLevelMouseProc m_HookProc;
        private IntPtr m_HookID = IntPtr.Zero;

        public event MouseHookEventHandler MouseKeyHook;

        /// <summary>
        /// Delegate for MouseKeyHook
        /// </summary>
        /// <param name="e"></param>
        public delegate void MouseHookEventHandler(MouseHookEventArgs e);

        #region ctor
        /// <summary>
        /// Sets up a mouse hook to trap low level mouse messages.
        /// </summary>
        public MouseHook()
        {
            const uint k_Thread = 0;
            m_HookProc = new WinApi.LowLevelMouseProc(this.lowLevelMouseHookCallback);
            //m_HookProc = new WinApi.HookProc(lowLevelKeyboardHookCallback);

            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                IntPtr hModule = WinApi.GetModuleHandle(curModule.ModuleName);
                m_HookID = WinApi.SetWindowsHookEx(WinApi.HookType.WH_MOUSE_LL, m_HookProc, hModule, k_Thread);
                //System.Windows.Forms.MessageBox.Show(Marshal.GetLastWin32Error().ToString()); //for debugging
            }
        }
        #endregion

        #region callback
        /// <summary>
        /// Processes mouse event captured
        /// </summary>
        private int lowLevelMouseHookCallback(int nCode, WinApi.MouseMessages wParam, ref WinApi.MSLLHOOKSTRUCT lParam)
        {
            // if being suppressed, return a dummy value < 0
            int retValue = -1;
            bool handled = false;

            if (nCode >= 0)
            {
                MouseHookEventArgs eventArgs = new MouseHookEventArgs(wParam, lParam);

                OnMouseKeyHook(eventArgs);

                handled = eventArgs.Handled;
            }
            
            if (!handled)
            {
                // Pass msg to the next registered application
                retValue = WinApi.CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
            }

            return retValue;
        }
        #endregion callback

        #region Event Handling
        protected virtual void OnMouseKeyHook(MouseHookEventArgs e)
        {
            if (MouseKeyHook != null)
            {
                MouseKeyHook.Invoke(e);
            }
        }
        #endregion Event Handling

        public void UnregisterHook()
        {
            WinApi.UnhookWindowsHookEx(m_HookID);
            m_HookID = IntPtr.Zero;
        }

        #region IDisposable Members
        private bool disposed = false;

        /// <summary>
        /// Releases the mouse hook
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    // nothing todo here
                }

                this.UnregisterHook();
            }

            this.disposed = true;
        }

        ~MouseHook()
        {
            this.Dispose(false);
        }
        #endregion

        #region EventArgs class
        /// <summary>
        /// Event arguments for MouseHook
        /// </summary>
        public class MouseHookEventArgs : System.EventArgs
        {
            private WinApi.MouseMessages m_wParam;
            private WinApi.MSLLHOOKSTRUCT m_lParam;
            private bool m_Handled = false;

            public WinApi.MouseMessages wParam { get { return m_wParam; } }
            public WinApi.MSLLHOOKSTRUCT lParam { get { return m_lParam; } }

            /// <summary>
            /// Gets or sets if this key combination should pass to other applications or be trapped.
            /// if true key combination is trapped.
            /// </summary>
            public bool Handled
            {
                get { return m_Handled; }
                set { this.m_Handled = value; }
            }

            public MouseHookEventArgs(WinApi.MouseMessages wParam, WinApi.MSLLHOOKSTRUCT lParam)
            {
                m_wParam = wParam;
                m_lParam = lParam;
            }
        }
        #endregion EventArgs class
    }
}
