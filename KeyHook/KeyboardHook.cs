using System;
using System.Windows.Forms;
using System.Diagnostics;

/// ref: http://www.codeproject.com/KB/cs/globalhook.aspx
/// ref: http://www.pinvoke.net

namespace KeyHook
{
    /// <summary>
    /// Low-level keyboard intercept class to trap and suppress system keys.
    /// </summary>
    public class KeyboardHook : IDisposable
    {
        // Variables used in the call to SetWindowsHookEx
        private WinApi.LowLevelKeyboardProc m_HookProc;
        private IntPtr m_HookID = IntPtr.Zero;

        public event KeyboardHookEventHandler KeyIntercepted;
        public event KeyboardHookEventHandler KeyDownIntercepted;
        public event KeyboardHookEventHandler KeyUpIntercepted;

        /// <summary>
        /// Delegate for KeyboardHook event handling.
        /// </summary>
        /// <param name="e"></param>
        public delegate void KeyboardHookEventHandler(KeyboardHookEventArgs e);

        #region ctor
        /// <summary>
        /// Sets up a keyboard hook to trap low level keyboard messages.
        /// </summary>
        public KeyboardHook()
        {
            const uint k_Thread = 0;
            m_HookProc = new WinApi.LowLevelKeyboardProc(this.lowLevelKeyboardHookCallback);
            //m_HookProc = new WinApi.HookProc(lowLevelKeyboardHookCallback);

            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                IntPtr hModule = WinApi.GetModuleHandle(curModule.ModuleName);
                //m_HookID = WinApi.SetWindowsHookEx(WinApi.HookType.WH_KEYBOARD_LL, hook, hModule, k_Thread);
                m_HookID = WinApi.SetWindowsHookEx(WinApi.HookType.WH_KEYBOARD_LL, m_HookProc, hModule, k_Thread);
            }
        }
        #endregion

        #region callback
        /// <summary>
        /// Processes the key event captured by the hook.
        /// </summary>
        //private int lowLevelKeyboardHookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        private int lowLevelKeyboardHookCallback(int nCode, WinApi.KeyboardMessages wParam, ref WinApi.KBDLLHOOKSTRUCT lParam)
        {
            // If this key is being suppressed, return a dummy value < 0
            int retValue = -1;
            bool handledKey = false;

            // Filter wParam for KeyUp events only
            if (nCode >= 0)
            {
                //if ((lParam.flags & WinApi.LLKHF_ALTDOWN) != 0)
                //{
                //    // altKey is down
                //}

                //if ((lParam.flags & WinApi.LLKHF_EXTENDED) != 0)
                //{
                //    // winKey is down
                //}

                //WinApi.KBDLLHOOKSTRUCT hookStruct = (WinApi.KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(WinApi.KBDLLHOOKSTRUCT));
                KeyboardHookEventArgs eventArgs = new KeyboardHookEventArgs(lParam.vkCode);

                if (wParam == WinApi.KeyboardMessages.WM_KEYDOWN || wParam == WinApi.KeyboardMessages.WM_SYSKEYDOWN)
                {
                    this.OnKeyDownIntercepted(eventArgs);
                }
                else if (wParam == WinApi.KeyboardMessages.WM_KEYUP || wParam == WinApi.KeyboardMessages.WM_SYSKEYUP)
                {
                    this.OnKeyUpIntercepted(eventArgs);
                }

                if (!eventArgs.Handled)
                {
                    OnKeyIntercepted(eventArgs);    
                }

                handledKey = eventArgs.Handled;
            }

            if (!handledKey)
            {
                // Pass key to the next registered application
                retValue = WinApi.CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
            }

            return retValue;
        }
        #endregion callback

        #region Event Handling
        /// <summary>
        /// Raises the KeyIntercepted event.
        /// </summary>
        /// <param name="e">An instance of KeyboardHookEventArgs</param>
        protected virtual void OnKeyIntercepted(KeyboardHookEventArgs e)
        {
            if (KeyIntercepted != null)
            {
                KeyIntercepted.Invoke(e);
            }
        }

        protected virtual void OnKeyDownIntercepted(KeyboardHookEventArgs e)
        {
            if (KeyDownIntercepted != null)
            {
                KeyDownIntercepted.Invoke(e);
            }
        }

        protected virtual void OnKeyUpIntercepted(KeyboardHookEventArgs e)
        {
            if (KeyUpIntercepted != null)
            {
                KeyUpIntercepted.Invoke(e);
            }
        }
        #endregion Event Handling

        #region IDisposable Members
        private bool disposed = false;

        /// <summary>
        /// Releases the keyboard hook.
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

                WinApi.UnhookWindowsHookEx(m_HookID);    
            }

            this.disposed = true;
        }

        ~KeyboardHook()
        {
            this.Dispose(false);
        }
        #endregion

        #region EventArgs class
        /// <summary>
        /// Event arguments for the KeyboardHook class's KeyIntercepted event.
        /// </summary>
        public class KeyboardHookEventArgs : System.EventArgs
        {
            private string m_KeyName;
            private UInt32 m_KeyCode;
            private bool m_Handled = false;

            /// <summary>
            /// The name of the key that was pressed.
            /// </summary>
            public string KeyName
            {
                get { return this.m_KeyName; }
            }

            /// <summary>
            /// The virtual key code of the key that was pressed.
            /// </summary>
            public UInt32 KeyCode
            {
                get { return this.m_KeyCode; }
            }

            public Keys Key
            {
                get { return (Keys)this.m_KeyCode; }
            }

            /// <summary>
            /// Gets or sets if this key combination should pass to other applications or be trapped.
            /// if true key combination is trapped.
            /// </summary>
            public bool Handled
            {
                get { return m_Handled; }
                set { this.m_Handled = value; }
            }

            public KeyboardHookEventArgs(UInt32 i_KeyCode)
            {
                this.m_KeyName = ((Keys)i_KeyCode).ToString();
                this.m_KeyCode = i_KeyCode;
            }
        }
        #endregion EventArgs class
    }
}
