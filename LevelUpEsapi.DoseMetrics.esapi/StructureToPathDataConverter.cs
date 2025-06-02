using System;
using System.Globalization;
using System.Windows.Data;

namespace LevelUpEsapi.DoseMetrics.esapi
{
    public class StructureToPathDataConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isEmpty)
            {
                return isEmpty
                    ? "M128,24A104,104,0,1,0,232,128,104.11,104.11,0,0,0,128,24Zm0,192a88,88,0,1,1,88-88A88.1,88.1,0,0,1,128,216Z"
                    : "M232,128A104,104,0,1,1,128,24,104.13,104.13,0,0,1,232,128Z";
            }

            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}