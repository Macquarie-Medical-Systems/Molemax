using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Molemax.App.ViewModels;

namespace Molemax.App.Views
{
    /// <summary>
    /// Interaction logic for ucExpress.xaml
    /// </summary>
    public partial class ucExpress : UserControl
    {
        ucImageViewModel iVM = new ucImageViewModel();

        public static Action AddImageToViewList;
        public ucExpress()
        {
            InitializeComponent();
            snapshot.DataContext = iVM;
            lvSnapshot.ItemsSource = ucImageViewModel.camImageModels;
            btSave.IsEnabled = false;
            btOK.IsEnabled = false;
            ucImageViewModel.PushButtonOnCamera += OnPushButtonOnCamera;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            capture.CaptureControl.SetCamera("See3CAM_30", 2048, 1536);
            capture.CaptureControl.SetCallback(iVM.SnapshotCallback);
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            capture.CaptureControl.CloseCamera();
        }

        private void btOK_Click(object sender, RoutedEventArgs e)
        {
            AddImageToViewList?.Invoke();
            btLive.Content = "Freeze";
            snapshot.Visibility = Visibility.Hidden;
            capture.Visibility = Visibility.Visible;
            btSave.IsEnabled = true;
            btOK.IsEnabled = false;
        }

        private void btLive_Click(object sender, RoutedEventArgs e)
        {
            if (btLive.Content.ToString() == "Freeze")
            {
                capture.CaptureControl.Snapshot();
            }
            else
            {
                btLive.Content = "Freeze";
                snapshot.Visibility = Visibility.Hidden;
                capture.Visibility = Visibility.Visible;
                btOK.IsEnabled = false;
            }
        }

        public void OnPushButtonOnCamera()
        {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => {
                if (btLive.Content.ToString() == "Freeze")
                {
                    btLive.Content = "Live";
                    snapshot.Visibility = Visibility.Visible;
                    capture.Visibility = Visibility.Hidden;
                    btOK.IsEnabled = true;
                }
                else
                {
                    btLive.Content = "Freeze";
                    snapshot.Visibility = Visibility.Hidden;
                    capture.Visibility = Visibility.Visible;
                    btOK.IsEnabled = false;
                }
            }));

        }
    }


}
