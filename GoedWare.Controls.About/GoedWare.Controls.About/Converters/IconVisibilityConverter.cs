using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace GoedWare.Controls.About.Converters
{
    public class IconVisibilityConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null) return Visibility.Collapsed;
            if (value is bool) return (bool)value ? Visibility.Visible : Visibility.Collapsed;
            if (value is int) return (int)value > 0 ? Visibility.Visible : Visibility.Collapsed;
            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }
}
