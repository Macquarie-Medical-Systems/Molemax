using Molemax.App.Core.TreeViewDiseaseExplorer.Enums;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Molemax.App.Core.TreeViewDiseaseExplorer
{
    [ValueConversion(typeof(DiseaseItem), typeof(BitmapImage))]
    public class HeaderToImageConverter : IValueConverter
    {
        public static HeaderToImageConverter Instance = new HeaderToImageConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var image = "Images/icons8-file-40.png";

            switch ((DataType)value)
            {
                case DataType.Pending:
                    image = "Images/icons-pending.bmp";
                    break;
                case DataType.CategoryClosed:
                    image = "Images/icons8-folder-50.png";
                    break;
                case DataType.CategoryOpened:
                    image = "Images/icons8-open-50.png";
                    break;
            }

            return new BitmapImage(new Uri($"pack://application:,,,/{image}"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
