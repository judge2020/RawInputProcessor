using RawInputProcessor.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RawInputProcessor
{
    internal class RawInputUtilities
    {
        internal static int AdjustVirtualKey(IntPtr hDevice, int virtualKey, bool isE0BitSet, int makeCode)
        {
            var adjustedKey = virtualKey;

            if (hDevice == IntPtr.Zero)
            {
                // When hDevice is 0 and the vkey is VK_CONTROL indicates the ZOOM key
                if (virtualKey == Win32Consts.VK_CONTROL)
                {
                    adjustedKey = Win32Consts.VK_ZOOM;
                }
            }
            else
            {
                switch (virtualKey)
                {
                    // Right-hand CTRL and ALT have their e0 bit set 
                    case Win32Consts.VK_CONTROL:
                        adjustedKey = isE0BitSet ? Win32Consts.VK_RCONTROL : Win32Consts.VK_LCONTROL;
                        break;
                    case Win32Consts.VK_MENU:
                        adjustedKey = isE0BitSet ? Win32Consts.VK_RMENU : Win32Consts.VK_LMENU;
                        break;
                    case Win32Consts.VK_SHIFT:
                        adjustedKey = makeCode == Win32Consts.SC_SHIFT_R ? Win32Consts.VK_RSHIFT : Win32Consts.VK_LSHIFT;
                        break;
                    default:
                        adjustedKey = virtualKey;
                        break;
                }
            }

            return adjustedKey;
        }

    }
}
