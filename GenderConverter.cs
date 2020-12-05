using System;
using System.Globalization;
using System.Windows.Data;

namespace ISP_Lab18
{
    class GenderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Gender valueGender = (Gender)value;
            Gender parameterGender = (Gender)parameter;
            return valueGender == parameterGender;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return parameter;
        }
    }
}
