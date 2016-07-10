using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Collections.Generic;

namespace RealtimeInstrumentDataApp
{
    public class StateToBrushConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return DependencyProperty.UnsetValue;
            }

            switch (value.ToString().ToLower())
            {
                case "up":
                    return Brushes.LawnGreen;
                case "down":
                    return Brushes.IndianRed;
                case "nochange":
                    return Brushes.Transparent;
                default:
                    return DependencyProperty.UnsetValue;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
