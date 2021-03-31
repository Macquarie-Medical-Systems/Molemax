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
        //private System.Windows.Controls.Image image;

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

        private ObservableCollection<LineItem> _lineList;
        public ObservableCollection<LineItem> LineList
        {
            get { return _lineList; }
            set { SetProperty(ref _lineList, value); }
        }

        private double _ImageWidth;
        public double ImageWidth
        {
            get { return _ImageWidth; }
            set
            {
                SetProperty(ref _ImageWidth, value);
            }
        }

        private double _ImageHeight;
        public double ImageHeight
        {
            get { return _ImageHeight; }
            set
            {
                SetProperty(ref _ImageHeight, value);
            }
        }
        #endregion

        #region Command
        public DelegateCommand GoOKCommand { get; set; }
        public DelegateCommand GoBackCommand { get; set; }
        public DelegateCommand GoResetCommand { get; set; }
        #endregion

        public bool KeepAlive => false;

        public ucFullPic_SegmentationViewModel(IRegionManager regionManager, IMolemaxRepository molemaxRepository, IAppSettings applicationSetting)
        {
            _regionManager = regionManager;
            _repository = molemaxRepository;
            _applicationSetting = applicationSetting;
            GoOKCommand = new DelegateCommand(GoOK);
            GoBackCommand = new DelegateCommand(GoBack);
            GoResetCommand = new DelegateCommand(GoReset);
            PointList = new ObservableCollection<PointItem>();
            LineList = new ObservableCollection<LineItem>();
        }

        private void GoReset()
        {
            PointList = new ObservableCollection<PointItem>();
            LineList = new ObservableCollection<LineItem>();
        }

        private void GoBack()
        {
            var navigationParameters = new NavigationParameters();
            _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.Segmentation, navigationParameters);

        }

        private void GoOK()
        {
            ObservableCollection<LineItem> paraLineList = new ObservableCollection<LineItem>();
            if (PointList.Count < 8)
            {
                MessageBox.Show("At least 8 Connection points are required!");
                return;
            }

            foreach (var i in LineList)
            {
                paraLineList.Add(new LineItem { X1 = i.X1 / ImageWidth, X2 = i.X2 / ImageWidth, Y1 = i.Y1 / ImageHeight, Y2 = i.Y2 / ImageHeight });
            }

            var navigationParameters = new NavigationParameters();
            navigationParameters.Add(Constants.ParaObject, paraLineList);
            navigationParameters.Add(Constants.ParaImage, FullImage);
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
            //MessageBox.Show("Mouse down at" + e.X + ", " + e.Y);

            PointItem pi = new PointItem();
            pi.X = e.X-2;
            pi.Y = e.Y-2;

            PointList.Add(pi);

            if (PointList.Count > 1)
            {
                LineItem li = new LineItem();
                PointItem lastPoint = PointList[PointList.Count-2];
                li.X1 = lastPoint.X + 2;
                li.Y1 = lastPoint.Y + 2;
                li.X2 = e.X;
                li.Y2 = e.Y;
                LineList.Add(li);
            }

        }

        public void OnMouseMove(object sender, MouseCaptureArgs e)
        {

        }

        public void OnMouseUp(object sender, MouseCaptureArgs e)
        {

        }
    }

}
