using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Molemax.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
        }



        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Color imageColor = GetColor(e.GetPosition(KenImage).X, e.GetPosition(KenImage).Y);
            if (imageColor != null)
            {
                MessageBox.Show(string.Format("Image RGB is {0},{1},{2}", imageColor.R.ToString(), imageColor.G.ToString(), imageColor.B.ToString()));
            }

            //MessageBox.Show(string.Format("image1 X is {0}, Y is {1}, image2 X is {2}, Y is {3}",e.GetPosition(KenImage).X.ToString(), e.GetPosition(KenImage).Y.ToString(), e.GetPosition(KenImage2).X.ToString(), e.GetPosition(KenImage2).Y.ToString()));

        }

        private Color GetColor(double x, double y)
        {
            byte[] pixels;
            int stride;
            BitmapSource bitmapSource = KenImage.Source as BitmapSource;
            if (bitmapSource != null)
            { // Get color from bitmap pixel.
              // Convert coopdinates from WPF pixels to Bitmap pixels
              // and restrict them by the Bitmap bounds.
                x *= bitmapSource.PixelWidth / KenImage.Width;
                if ((int)x > bitmapSource.PixelWidth - 1)
                    x = bitmapSource.PixelWidth - 1;
                else if (x < 0)
                    x = 0;
                y *= bitmapSource.PixelHeight / KenImage.Height;
                if ((int)y > bitmapSource.PixelHeight - 1)
                    y = bitmapSource.PixelHeight - 1;
                else if (y < 0)
                    y = 0;

                // Alternative approach
                if (bitmapSource.Format == PixelFormats.Indexed4)
                {
                    pixels = new byte[1];
                    stride = (bitmapSource.PixelWidth *
                                  bitmapSource.Format.BitsPerPixel + 3) / 4;
                    bitmapSource.CopyPixels(new Int32Rect((int)x, (int)y, 1, 1),
                                                           pixels, stride, 0);

                    return bitmapSource.Palette.Colors[pixels[0] >> 4];
                }
                else if (bitmapSource.Format == PixelFormats.Indexed8)
                {
                    pixels = new byte[1];
                    stride = (bitmapSource.PixelWidth *
                                  bitmapSource.Format.BitsPerPixel + 7) / 8;
                    bitmapSource.CopyPixels(new Int32Rect((int)x, (int)y, 1, 1),
                                                           pixels, stride, 0);

                    return bitmapSource.Palette.Colors[pixels[0]];
                }
                else
                {
                    pixels = new byte[4];
                    stride = (bitmapSource.PixelWidth *
                                  bitmapSource.Format.BitsPerPixel + 7) / 8;
                    bitmapSource.CopyPixels(new Int32Rect((int)x, (int)y, 1, 1),
                                                           pixels, stride, 0);

                    return Color.FromArgb(pixels[3], pixels[2], pixels[1], pixels[0]);
                }
                // TODO There are other PixelFormats which processing should be added if desired.
            }
            return Color.FromRgb(255, 255, 255);
        }


    }
}
