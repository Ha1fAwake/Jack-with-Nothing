using System;
using System.Runtime.InteropServices;

namespace ReadyGamerOne.Utility
{
        
#if UNITY_STANDALONE_WIN
    
    public static class WindowsUtil
    {

        #region Windows_MessageBox
        
        [DllImport("User32.dll", SetLastError = true, ThrowOnUnmappableChar = true, CharSet = CharSet.Auto)]
        private static extern int MessageBox(IntPtr handle, String message, String title, int type);

        public static int MessageBox(object obj, string title = "Message", int type = 0)
        {
            return MessageBox(IntPtr.Zero, obj.ToString(), title, type);
        }
        #endregion

    }
        
#endif
}