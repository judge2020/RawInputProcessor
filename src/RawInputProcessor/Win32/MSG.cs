using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawInputProcessor.Win32
{
    [Serializable]
    internal struct MSG
    {
        // Summary:
        //     Gets or sets the window handle (HWND) to the window whose window procedure
        //     receives the message.
        //
        // Returns:
        //     The window handle (HWND).
        public IntPtr hwnd { get; set; }
        //
        // Summary:
        //     Gets or sets the lParam value that specifies additional information about
        //     the message. The exact meaning depends on the value of the System.Windows.Interop.MSG.message
        //     member.
        //
        // Returns:
        //     The lParam value for the message.
        public IntPtr lParam { get; set; }
        //
        // Summary:
        //     Gets or sets the message identifier.
        //
        // Returns:
        //     The message identifier.
        public int message { get; set; }
        //
        // Summary:
        //     Gets or sets the x coordinate of the cursor position on the screen, when
        //     the message was posted.
        //
        // Returns:
        //     The x coordinate of the cursor position.
        public int pt_x { get; set; }
        //
        // Summary:
        //     Gets or sets the y coordinate of the cursor position on the screen, when
        //     the message was posted.
        //
        // Returns:
        //     The y coordinate of the cursor position.
        public int pt_y { get; set; }
        //
        // Summary:
        //     Gets or sets the time at which the message was posted.
        //
        // Returns:
        //     The time that the message was posted.
        public int time { get; set; }
        //
        // Summary:
        //     Gets or sets the wParam value for the message, which specifies additional
        //     information about the message. The exact meaning depends on the value of
        //     the message.
        //
        // Returns:
        //     The wParam value for the message.
        public IntPtr wParam { get; set; }
    }
}
