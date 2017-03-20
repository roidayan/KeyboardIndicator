using System;
using System.Windows.Forms;

namespace KeyHook
{
    public class KeyboardState
    {
        #region Modifier keys

        public const int k_Toggle = 0x0001;
        public const int k_Pressed = 0x1000;

        /// <summary>
        /// Caps Lock toggle
        /// </summary>
        public static bool CapsLock
        {
            get { return Convert.ToBoolean((WinApi.GetKeyState((int)Keys.Capital) & k_Toggle) != 0); }
        }

        /// <summary>
        /// Caps Lock toggle
        /// </summary>
        public static bool Capital
        {
            get { return CapsLock; }
        }

        public static bool NumLock
        {
            get { return (WinApi.GetKeyState((int)Keys.NumLock) & k_Toggle) != 0; }
        }

        /// <summary>
        /// Scroll Lock toggle
        /// </summary>
        public static bool Scroll
        {
            get { return (WinApi.GetKeyState((int)Keys.Scroll) & k_Toggle) != 0; }
        }

        /// <summary>
        /// Ctrl key pressed
        /// </summary>
        public static bool Control
        {
            get { return (WinApi.GetKeyState((int)Keys.ControlKey) & k_Pressed) != 0; }
        }

        /// <summary>
        /// Ctrl key pressed
        /// </summary>
        public static bool Ctrl
        {
            get { return Control; }
        }

        /// <summary>
        /// Alt key pressed
        /// </summary>
        public static bool Menu
        {
            get { return (WinApi.GetKeyState((int)Keys.Menu) & k_Pressed) != 0; }
        }

        /// <summary>
        /// Aly key pressed
        /// </summary>
        public static bool Alt
        {
            get { return Menu; }
        }

        /// <summary>
        /// Shift key pressed
        /// </summary>
        public static bool Shift
        {
            get { return (WinApi.GetKeyState((int)Keys.ShiftKey) & k_Pressed) != 0; }
        }

        /// <summary>
        /// Check if key is pressed
        /// </summary>
        /// <param name="i_Key"></param>
        /// <returns>boolean</returns>
        public static bool KeyPressed(Keys i_Key)
        {
            return (WinApi.GetKeyState((int)i_Key) & k_Pressed) != 0;
        }

        #endregion Modifier keys
    }
}
