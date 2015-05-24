using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
enum RecycleFlags : int
{
    SHERB_NOCONFIRMATION = 0x00000001,
    SHERB_NOPROGRESSUI = 0x00000001,
    SHERB_NOSOUND = 0x00000004
}

namespace Commander
{
    class Shell32
    {
        [DllImport("Shell32.dll")]
        private static extern int SHEmptyRecycleBin(IntPtr hwnd, string pszRootPath, RecycleFlags dwFlags);
        public static void clearBasket()
        {
            SHEmptyRecycleBin(IntPtr.Zero, null, RecycleFlags.SHERB_NOPROGRESSUI);
        }
    }
}
