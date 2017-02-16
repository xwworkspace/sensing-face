using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using SING.Data.Help;
using SING.Data.Data;

namespace FACE_CaptureComparisonManagement.Converter
{
    public class MonthYearStringByLongConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string result = string.Empty;
           
            try
            {
                DateTime s = new DateTime(1970, 1, 1);
                long _longtime = (long)value;
                s = s.AddSeconds(_longtime);

                result = s.ToString("yyyyMMdd");
                
            }
            catch (Exception)
            {

            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    public class HHmmTimeStringByLongConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string result = string.Empty;

            try
            {
                DateTime s = new DateTime(1970, 1, 1);
                long _longtime = (long)value;
                s = s.AddSeconds(_longtime);

                result = s.ToString("HH:mm:dd");

            }
            catch (Exception)
            {

            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
    public class DescriptionByTypeConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string result = string.Empty;

            try
            {
                if (value == null) return string.Empty;
                int Type = (int)value;
                STypeInfoData DType = BasicData.DefFaceObjType.FirstOrDefault(p => p.Type == Type);

                result = DType.Description;

            }
            catch (Exception)
            {

            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
