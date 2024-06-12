using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace PhotoColor.MainViewModel
{
    public class ImageConverter : IValueConverter
    {
       

        public object Convert(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string filePath)
            {
                return new BitmapImage(new Uri(filePath));
            }
            return null;
        }

       

        public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
