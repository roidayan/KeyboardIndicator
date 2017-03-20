using System;
using System.Runtime.InteropServices;

namespace KeyHook
{
    [ComVisibleAttribute(false), System.Security.SuppressUnmanagedCodeSecurity()]
    public class WinApi
    {
        public const string k_Kernel32Dll = "kernel32.dll";
        public const string k_User32Dll = "user32.dll";

        //public delegate int LowLevelKeyboardDelegate(int nCode, IntPtr wParam, ref WinApi.KBDLLHOOKSTRUCT lParam);
        //public delegate int LowLevelKeyboardProc(int nCode, KeyboardMessages wParam, [In] KBDLLHOOKSTRUCT lParam);

        // Hook procedure for the WH_KEYBOARD_LL hook
        public delegate int LowLevelKeyboardProc(int nCode, KeyboardMessages wParam, ref KBDLLHOOKSTRUCT lParam);

        // Callback for low level mouse hook
        public delegate int LowLevelMouseProc(int code, MouseMessages wParam, ref MSLLHOOKSTRUCT lParam);

        public delegate int HookProc(int code, IntPtr wParam, IntPtr lParam);


        #region Methods

        [DllImport(k_Kernel32Dll, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        //[DllImport(k_User32Dll, CharSet = CharSet.Auto, SetLastError = true)]
        //public static extern IntPtr SetWindowsHookEx(HookType hookType, HookProc lpfn, IntPtr hMod, uint dwThreadId);
        [DllImport(k_User32Dll, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SetWindowsHookEx(HookType hookType, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);
        [DllImport(k_User32Dll, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SetWindowsHookEx(HookType hookType, LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport(k_User32Dll, CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UnhookWindowsHookEx(IntPtr hhk);
        
        // overload for use with LowLevelKeyboardProc
        [DllImport(k_User32Dll, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int CallNextHookEx(IntPtr hhk, int nCode, KeyboardMessages wParam, [In]KBDLLHOOKSTRUCT lParam);

        // overload for use with LowLevelMouseProc
        [DllImport(k_User32Dll, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int CallNextHookEx(IntPtr hhk, int nCode, MouseMessages wParam, [In]MSLLHOOKSTRUCT lParam);

        //public static extern int CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, ref KBDLLHOOKSTRUCT lParam);

        [DllImport(k_User32Dll, CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
        public static extern short GetKeyState(int nVirtKey);

        [DllImport(k_User32Dll, CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
        public static extern bool GetAsyncKeyState(System.Windows.Forms.Keys vKey);

        #endregion Methods

        #region HotKey Methods

        [DllImport(k_User32Dll, CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport(k_User32Dll, CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        #endregion HotKey Methods

        #region Atom Methods
        [DllImport(k_Kernel32Dll, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern ushort GlobalAddAtom(string lpString);

        [DllImport(k_Kernel32Dll, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern ushort GlobalFindAtom(string lpString);

        [DllImport(k_Kernel32Dll, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern ushort GlobalDeleteAtom(ushort atom);
        #endregion Atom Methods

        #region Constants
        public enum HookType
        {
            WH_KEYBOARD_LL = 13,
            WH_MOUSE_LL = 14
        }

        public enum KeyboardMessages
        {
            WM_KEYDOWN = 0x0100,
            WM_KEYUP = 0x0101,
            WM_SYSKEYDOWN = 0x0104,
            WM_SYSKEYUP = 0x0105
        }

        public const int WM_HOTKEY = 0x0312;

        public const int LLKHF_EXTENDED = 0x01;
        public const int LLKHF_ALTDOWN = 0x20;

        [Flags]
        public enum fsModifiers
        {
            None = 0,
            MOD_ALT = 1,
            MOD_CONTROL = 2,
            MOD_SHIFT = 4,
            MOD_WIN = 8,
            /// <summary>
            /// Windows7 and later.
            /// </summary>
            MOD_NOREPEAT = 16
        }

        public enum MouseMessages
        {
            WM_LBUTTONDOWN = 0x0201,
            WM_LBUTTONUP = 0x0202,
            WM_MOUSEMOVE = 0x0200,
            WM_MOUSEWHEEL = 0x020A,
            WM_RBUTTONDOWN = 0x0204,
            WM_RBUTTONUP = 0x0205
        }
        #endregion Constants

        // The KBDLLHOOKSTRUCT structure contains information about a low-level keyboard input event
        [StructLayout(LayoutKind.Sequential)]
        public struct KBDLLHOOKSTRUCT
        {
            public UInt32 vkCode;
            public UInt32 scanCode;
            public UInt32 flags;
            public UInt32 time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int x;
            public int y;
        }

        // The MSLLHOOKSTRUCT structure contains information about a low-level mouse input event.
        [StructLayout(LayoutKind.Sequential)]
        public struct MSLLHOOKSTRUCT
        {
            public POINT pt;
            public int mouseData;
            public int flags;
            public int time;
            public IntPtr dwExtraInfo;
        }
    }
}
