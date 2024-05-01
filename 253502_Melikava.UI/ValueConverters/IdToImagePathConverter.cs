using _253502_Melikava.UI.ViewModels;
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253502_Melikava.UI.ValueConverters
{
    public class IdToImagePathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int id)
            {

                string imagesFolderPath =  OrderDetailsViewModel.GetImagesFolderPath();
                string imagePath = Path.Combine(imagesFolderPath, $"{id}.png");
                if (File.Exists(imagePath))
                {
                    return ImageSource.FromFile(imagePath);
                }
                else
                {
                    return "placeholder.png";
                }

            }

            return "placeholder.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
