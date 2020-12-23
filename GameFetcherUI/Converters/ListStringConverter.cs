using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace GameFetcherUI
{
    public class ListStringConverter : IValueConverter
    {
        // Joins string values into a string after validating its type and if its not null.
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null) return null;
            if (targetType != typeof(string))
                throw new InvalidOperationException("The target must be a String");
            string output = String.Join(", ", ((List<string>)value).ToArray());
            return output;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
