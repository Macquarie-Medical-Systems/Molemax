using Microsoft.EntityFrameworkCore;
using Molemax.App.Core;
using Molemax.App.Core.MouseCapture;
using Molemax.Models;
using Molemax.Repository;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
//using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Molemax.App.ViewModels
{
    public class ucFullPic_SegmentationViewModel : BindableBase, IRegionMemberLifetime, INavigationAware, IMouseCaptureProxy
    {
        private IRegionManager _regionManager;
        private IMolemaxRepository _repository;
        private IAppSettings _applicationSetting;
        private string fromForm;
        private System.Windows.Controls.Image image;

        public event EventHandler Capture;
        public event EventHandler Release;

        #region Property
        private BitmapSource _fullImage;
        public BitmapSource FullImage
        {
            get { return _fullImage; }
            set { SetProperty(ref _fullImage, value); }
        }

        private ObservableCollection<PointItem> _pointList;
        public ObservableCollection<PointItem> PointList
        {
            get { return _pointList; }
            set { SetProperty(ref _pointList, value); }
        }
        #endregion

        #region Command
        public DelegateCommand GoOKCommand { get; set; }
        public DelegateCommand GoBackCommand { get; set; }
        #endregion

        public bool KeepAlive => false;

        public ucFullPic_SegmentationViewModel(IRegionManager regionManager, IMolemaxRepository molemaxRepository, IAppSettings applicationSetting)
        {
            _regionManager = regionManager;
            _repository = molemaxRepository;
            _applicationSetting = applicationSetting;
            GoOKCommand = new DelegateCommand(GoOK);
            GoBackCommand = new DelegateCommand(GoBack);
            PointList = new ObservableCollection<PointItem>();
        }

        private void GoBack()
        {
            var navigationParameters = new NavigationParameters();
            _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.Segmentation, navigationParameters);

        }

        private void GoOK()
        {
            var navigationParameters = new NavigationParameters();

            _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.Segmentation, navigationParameters);
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {

            if (navigationContext.Parameters[Constants.ParaImage] != null)
                FullImage = (BitmapSource)navigationContext.Parameters[Constants.ParaImage];

            if (navigationContext.Parameters[Constants.FromForm] != null)
                fromForm = (string)navigationContext.Parameters[Constants.FromForm];
        }

        public void OnMouseDown(object sender, MouseCaptureArgs e)
        {
            MessageBox.Show("Mouse down at" + e.X + ", " + e.Y);

            PointItem pi = new PointItem();
            pi.X = e.X;
            pi.Y = e.Y;

            PointList.Add(pi);
        }

        public void OnMouseMove(object sender, MouseCaptureArgs e)
        {

        }

        public void OnMouseUp(object sender, MouseCaptureArgs e)
        {

        }
    }

}
