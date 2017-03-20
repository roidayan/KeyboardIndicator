using System;
using System.Runtime.InteropServices;

namespace KeyboardIndicator
{
    [ComVisibleAttribute(false), System.Security.SuppressUnmanagedCodeSecurity()]
    public class WinApi
    {
        public const string k_User32Dll = "user32.dll";

        #region Methods

        [DllImport(k_User32Dll, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport(k_User32Dll, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport(k_User32Dll, CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

        #endregion Methods

        // Win32 RECT
        [Serializable, StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
    }
}
