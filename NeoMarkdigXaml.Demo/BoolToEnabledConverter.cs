using System;
using System.Globalization;
using System.Windows.Data;

namespace NeoMarkdigXaml.Demo
{
    class BoolToEnabledConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? false : true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? false : true;
        }
    }
}
