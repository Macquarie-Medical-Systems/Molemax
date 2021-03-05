using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Molemax.App.Core
{
    public static class ImageHelpers
    {
        public static BitmapImage ToBitmapImage(Bitmap bitmap)
        {
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            MemoryStream ms = new MemoryStream();
            bitmap.Save(ms, ImageFormat.Bmp);
            ms.Seek(0, SeekOrigin.Begin);
            bi.StreamSource = ms;
            bi.EndInit();
            return bi;
        }

        public static BitmapSource ToBitmapSource(Bitmap bitmap)
        {
            var bitmapData = bitmap.LockBits(
                new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height),
                System.Drawing.Imaging.ImageLockMode.ReadOnly, bitmap.PixelFormat);

            var bitmapSource = BitmapSource.Create(
                bitmapData.Width, bitmapData.Height,
                bitmap.HorizontalResolution, bitmap.VerticalResolution,
                PixelFormats.Bgr24, null,
                bitmapData.Scan0, bitmapData.Stride * bitmapData.Height, bitmapData.Stride);

            bitmap.UnlockBits(bitmapData);
            return bitmapSource;
        }

        public static void SaveBitmapSourceToFile(BitmapSource image, string filePath)
        {
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                BitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(image));
                encoder.Save(fileStream);
            }
        }

        public static void AddRectangleOrPoint(string originalImage, string newImage, bool bRectangle, int pointX, int pointY, int rectangleWidth = 0, int rectangleHeigh = 0)
        {
            //create image folder
            string dir = Path.GetDirectoryName(newImage);
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            //load image
            Image initImage = Image.FromFile(originalImage);
            Bitmap bmpImage = new Bitmap(initImage);
            Graphics graphics = null;
            graphics = System.Drawing.Graphics.FromImage(bmpImage);
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            if (bRectangle)
            {
                //prepare pen
                System.Drawing.Pen blackPen = new System.Drawing.Pen(System.Drawing.Color.Green, 20);
                graphics.DrawRectangle(blackPen, pointX, pointY, rectangleWidth, rectangleHeigh);
            }
            else
            {
                System.Drawing.Pen blackPen = new System.Drawing.Pen(System.Drawing.Color.Green, 20);
                graphics.DrawEllipse(blackPen, pointX, pointY, 10, 10);
            }
        


            ImageCodecInfo[] icis = ImageCodecInfo.GetImageEncoders();
            ImageCodecInfo ici = null;
            foreach (ImageCodecInfo i in icis)
            {
                if (i.MimeType == "image/jpeg" || i.MimeType == "image/bmp" || i.MimeType == "image/png" || i.MimeType == "image/gif")
                {
                    ici = i;
                }
            }
            EncoderParameters ep = new EncoderParameters(1);
            ep.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 75L);

            bmpImage.Save(newImage, ici, ep);

            ep.Dispose();
            bmpImage.Dispose();
            graphics.Dispose();
            initImage.Dispose();
        }
    }
}
