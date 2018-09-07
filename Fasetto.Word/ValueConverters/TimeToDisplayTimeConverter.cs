using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Fasetto.Word
{
    public class TimeToDisplayTimeConverter : BaseValueConverter<TimeToDisplayTimeConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // get the time passed in
            var time = (DateTimeOffset)value;

            // if it is today...
            if (time.Date == DateTimeOffset.UtcNow.Date)
                // return only hour and minute
                return time.ToLocalTime().ToString("HH:mm");

            // otherwise, return the full time
            return time.ToLocalTime().ToString("HH:mm, dd.MMM.yyyy");
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
