using System;
using System.Globalization;
using System.Windows.Data;

namespace MangaReader.Utilities
{
    public class DimensionConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length == 2
                && values[0] is double first
                && values[1] is double second)
            {
                return second / first;
            }

            return parameter;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}