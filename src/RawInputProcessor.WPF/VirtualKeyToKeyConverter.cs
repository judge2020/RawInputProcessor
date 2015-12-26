using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Input;

namespace RawInputProcessor.WPF
{
    /// <summary>
    /// Converts to/from AdjustedVirtualKey (int) from RawInputEventArgs and System.Windows.Input.Key
    /// </summary>
    public class VirtualKeyToKeyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return KeyInterop.KeyFromVirtualKey((int)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return KeyInterop.VirtualKeyFromKey((Key)value);
        }
    }
}
