using System;
using System.Drawing;

namespace KeyboardIndicator
{
    public class Window
    {
        public static Rectangle GetSystemTrayLocation()
        {
            const string k_ShellTrayWnd = "Shell_TrayWnd";
            const string k_TrayNotifyWnd = "TrayNotifyWnd";
            const string k_NullString = null;

            Rectangle retRect = Rectangle.Empty;

            IntPtr taskBarHandle = WinApi.FindWindow(k_ShellTrayWnd, k_NullString);

            if (taskBarHandle != IntPtr.Zero)
            {
                IntPtr systemTrayHandle = WinApi.FindWindowEx(taskBarHandle, IntPtr.Zero, k_TrayNotifyWnd, k_NullString);

                if (systemTrayHandle != IntPtr.Zero)
                {
                    WinApi.RECT rect = new WinApi.RECT();
                    WinApi.GetWindowRect(systemTrayHandle, ref rect);
                    retRect = Rectangle.FromLTRB(rect.Left, rect.Top, rect.Right, rect.Bottom);
                }
            }

            return retRect;
        }
    }
}
