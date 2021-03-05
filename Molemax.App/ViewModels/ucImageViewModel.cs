using Molemax.App.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Molemax.App.ViewModels
{
    public class ucImageViewModel : INotifyPropertyChanged
    {
        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool DeleteObject(IntPtr value);

        private BitmapSource _image;
        public BitmapSource Image
        {
            get { return _image; }
            set
            {
                _image = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static ObservableCollection<CamImageModel> camImageModels;

        public static CamImageModel camImageModel;

        public static Action PushButtonOnCamera;
        public void SnapshotCallback(System.Drawing.Image image)
        {
            var bitmap = GetImageStream(image);
            bitmap.Freeze();
            Image = bitmap;
            camImageModel = new CamImageModel { Path = Image };
            //IMList.Add(new ImageModel { Path = Image });

            PushButtonOnCamera?.Invoke();


            //Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => ImageModels.Add(im)));
            //Dispatcher.CurrentDispatcher.Invoke(() => Images.Add(im));
            //Images.Add(im);
            //capture.Visibility = Visibility.Hidden;
            //var dialog = new SaveFileDialog();
            //dialog.FileName = "Snapshot1";
            //dialog.DefaultExt = ".png";
            //var dialogresult = dialog.ShowDialog();
            //if (dialogresult != true)
            //{
            //    return;
            //}
            //string snapshotName = @"c:\" + Guid.NewGuid().ToString();

            //var encoder = new PngBitmapEncoder();
            //encoder.Frames.Add(BitmapFrame.Create(bitmap));
            //using (var filestream = new FileStream(snapshotName, FileMode.Create))
            //{
            //    encoder.Save(filestream);
            //}
        }

        public BitmapSource GetImageStream(System.Drawing.Image myImage)
        {
            var bitmap = new Bitmap(myImage);
            IntPtr bmpPt = bitmap.GetHbitmap();
            BitmapSource bitmapSource =
             System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                   bmpPt,
                   IntPtr.Zero,
                   Int32Rect.Empty,
                   BitmapSizeOptions.FromEmptyOptions());

            //freeze bitmapSource and clear memory to avoid memory leaks
            bitmapSource.Freeze();
            DeleteObject(bmpPt);

            return bitmapSource;
        }

        public ucImageViewModel()
        {
            camImageModels = new ObservableCollection<CamImageModel>();
            //camImageModelList = new List<CamImageModel>();
            ucExpress.AddImageToViewList += OnAddImageToViewList;
        }

        public void OnAddImageToViewList()
        {
            if (camImageModel != null)
                camImageModels.Add(camImageModel);
            camImageModel = null;
        }
    }

    public class CamImageModel
    {
        public BitmapSource Path { get; set; }

    }
}
