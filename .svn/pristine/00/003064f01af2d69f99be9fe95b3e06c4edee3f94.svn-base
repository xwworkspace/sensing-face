using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using SING.Data.BaseTools;

namespace SING.Infrastructure.Converter
{
    public class ForeColorConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SolidColorBrush color = new SolidColorBrush(Colors.LightBlue);

            if (AppConfig.Instance.CurrentTheme.ToString() == "Windows7")
            {
                color = new SolidColorBrush(Colors.Black);
            }
            else if (AppConfig.Instance.CurrentTheme.ToString() == "Expression_Dark")
            {
                color = new SolidColorBrush(Colors.White);
            }

            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    public class TextboxBackgroudConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SolidColorBrush color = new SolidColorBrush(Colors.LightBlue);

            if (AppConfig.Instance.CurrentTheme.ToString() == "Windows7")
            {
                color = new SolidColorBrush(Colors.White);
            }
            else if (AppConfig.Instance.CurrentTheme.ToString() == "Expression_Dark")
            {
                color = new SolidColorBrush(Color.FromRgb(51, 51, 51));
            }

            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
