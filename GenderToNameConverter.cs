using System;
using System.Globalization;
using System.Windows.Data;

namespace ISP_Lab18
{
    class GenderToNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((Gender)value) {
                case Gender.Female: return "Женский";
                case Gender.Male: return "Мужской";
                default: throw new ArgumentException("Unsupported gender: " + value);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
