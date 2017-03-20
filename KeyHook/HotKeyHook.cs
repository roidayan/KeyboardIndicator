using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace KeyHook
{
    public class HotKeyHook : IDisposable
    {
        private struct HandleIdPair {
            public IntPtr Handle;
            public ushort Atom;
        }

        private static readonly HotKeyHook sr_HotKeyHook = new HotKeyHook();

        public static HotKeyHook Default
        {
            get { return sr_HotKeyHook; }
        }

        private readonly List<HandleIdPair> r_HotKeysIDs = new List<HandleIdPair>();

        public ushort RegisterHotKey(string i_String, IntPtr i_Handle, WinApi.fsModifiers i_Modifiers, uint i_Key)
        {
            HandleIdPair pair = new HandleIdPair();
            pair.Handle = i_Handle;
            pair.Atom = WinApi.GlobalAddAtom(i_String);
            uint modifiers = (uint)i_Modifiers;
            bool success = WinApi.RegisterHotKey(i_Handle, pair.Atom, modifiers, i_Key);

            if (success)
            {
                this.r_HotKeysIDs.Add(pair);
            }
            else
            {
                pair.Atom = 0;
            }

            return pair.Atom;
        }

        public bool UnregisterHotKey(IntPtr i_Handle, ushort i_Atom)
        {
            HandleIdPair pair = new HandleIdPair();
            pair.Atom = i_Atom;
            pair.Handle = i_Handle;

            return this.unregisterHotKey(pair);
        }

        private bool unregisterHotKey(HandleIdPair i_Pair)
        {
            bool retValue = WinApi.UnregisterHotKey(i_Pair.Handle, i_Pair.Atom);
            this.r_HotKeysIDs.Remove(i_Pair);

            return retValue;
        }

        /// <summary>
        /// Unregister all registered hotkeys
        /// </summary>
        public void UnregisterAllHotKeys()
        {
            foreach (HandleIdPair pair in this.r_HotKeysIDs)
            {
                WinApi.UnregisterHotKey(pair.Handle, pair.Atom);
            }

            this.r_HotKeysIDs.Clear();
        }

        #region IDisposable Members

        private bool disposed = false;

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

                this.UnregisterAllHotKeys();
            }

            this.disposed = true;
        }

        ~HotKeyHook()
        {
            this.Dispose(false);
        }

        #endregion
    }
}
