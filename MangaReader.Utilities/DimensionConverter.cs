using System;
using System.Globalization;
using System.Windows.Data;

namespace MangaReader.Utilities
{
    public class DimensionConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return values.Length == 2
                ? ((double)values[1] - 20) / (double)values[0]
                : (double)parameter;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}