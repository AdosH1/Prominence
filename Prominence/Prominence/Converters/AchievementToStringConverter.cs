using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;
using Core.Models;

namespace Prominence.Converters
{
    public class AchievementToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var achievement = value as Achievement;
            if (achievement != null)
            {
                string checkbox;
                if (achievement.Completed) checkbox = "    [ x ]";
                else checkbox = "    [   ]";

                return $"{checkbox} {achievement.DisplayName}";
            }

            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
