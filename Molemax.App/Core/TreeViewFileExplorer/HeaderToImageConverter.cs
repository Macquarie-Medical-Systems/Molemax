using Molemax.App.Core.TreeViewFileExplorer.Enums;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Molemax.App.Core.TreeViewFileExplorer
{
    [ValueConversion(typeof(DataItem), typeof(BitmapImage))]
    public class HeaderToImageConverter : IValueConverter
    {
        public static HeaderToImageConverter Instance = new HeaderToImageConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var image = "Images/icons8-file-40.png";

            switch ((DataType)value)
            {
                case DataType.Drive:
                    image = "Images/icons8-hdd-48.png";
                    break;
                case DataType.FolderClosed:
                    image = "Images/icons8-folder-50.png";
                    break;
                case DataType.FolderOpened:
                    image = "Images/icons8-open-50.png";
                    break;
                case DataType.Empty:
                    return null;
            }

            return new BitmapImage(new Uri($"pack://application:,,,/{image}"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
