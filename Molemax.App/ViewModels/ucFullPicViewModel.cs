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
    public class ucFullPicViewModel : BindableBase, IRegionMemberLifetime, INavigationAware, IMouseCaptureProxy
    {
        private IRegionManager _regionManager;
        private IMolemaxRepository _repository;
        private IAppSettings _applicationSetting;
        private KIND_ENUM imageKind;
        private const int rectangleXOffset = 300;
        private const int rectangleYOffset = 100;
        private const int rectangleWidth = 400;
        private const int rectangleHeight = 200;
        private ImageHandler containerImage;
        private int containerImageListIndex;
        private System.Windows.Controls.Image image;
        private BitmapSource paraImage;
        private string fromControl;
        private List<ImageHandler> _patientCloseUpImageList;
        private List<ImageHandler> _patientMikroImageList;

        public event EventHandler Capture;
        public event EventHandler Release;

        #region Property
        private BitmapSource _fullImage;
        public BitmapSource FullImage
        {
            get { return _fullImage; }
            set { SetProperty(ref _fullImage, value); }
        }

        private double _rectangleX;
        public double RectangleX
        {
            get { return _rectangleX; }
            set { SetProperty(ref _rectangleX, value); }
        }

        private double _rectangleY;
        public double RectangleY
        {
            get { return _rectangleY; }
            set { SetProperty(ref _rectangleY, value); }
        }

        private double _rectangleWidth;
        public double RectangleWidth
        {
            get { return _rectangleWidth; }
            set { SetProperty(ref _rectangleWidth, value); }
        }

        private double _rectangleHeight;
        public double RectangleHeight
        {
            get { return _rectangleHeight; }
            set { SetProperty(ref _rectangleHeight, value); }
        }

        private Visibility _rectangleVisible;
        public Visibility RectangleVisible
        {
            get { return _rectangleVisible; }
            set { SetProperty(ref _rectangleVisible, value); }
        }

        //point X on image
        private double _pointX;
        public double PointX
        {
            get { return _pointX; }
            set { SetProperty(ref _pointX, value); }
        }

        //point Y on image
        private double _pointY;
        public double PointY
        {
            get { return _pointY; }
            set { SetProperty(ref _pointY, value); }
        }

        //show point on image
        private Visibility _pointVisible;
        public Visibility PointVisible
        {
            get { return _pointVisible; }
            set { SetProperty(ref _pointVisible, value); }
        }

        private ObservableCollection<PointItem> _historypointList;
        public ObservableCollection<PointItem> HistoryPointList
        {
            get { return _historypointList; }
            set { SetProperty(ref _historypointList, value); }
        }

        private Visibility _historyPointVisible;
        public Visibility HistoryPointVisible
        {
            get { return _historyPointVisible; }
            set { SetProperty(ref _historyPointVisible, value); }
        }

        private ObservableCollection<RectangleItem> _historyRectangleList;
        public ObservableCollection<RectangleItem> HistoryRectangleList
        {
            get { return _historyRectangleList; }
            set { SetProperty(ref _historyRectangleList, value); }
        }

        private Visibility _historyRectangleVisible;
        public Visibility HistoryRectangleVisible
        {
            get { return _historyRectangleVisible; }
            set { SetProperty(ref _historyRectangleVisible, value); }
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
                DrawHistoryPointOnImage();
            }
        }
        #endregion

        #region Command
        public DelegateCommand GoOKCommand { get; set; }
        public DelegateCommand GoBackCommand { get; set; }
        #endregion

        public bool KeepAlive => false;

        public ucFullPicViewModel(IRegionManager regionManager, IMolemaxRepository molemaxRepository, IAppSettings applicationSetting)
        {
            _regionManager = regionManager;
            _repository = molemaxRepository;
            _applicationSetting = applicationSetting;
            GoOKCommand = new DelegateCommand(GoOK);
            GoBackCommand = new DelegateCommand(GoBack);
            RectangleVisible = Visibility.Collapsed;
            PointVisible = Visibility.Collapsed;
        }

        private void GoBack()
        {
            var navigationParameters = new NavigationParameters();
            navigationParameters.Add(Constants.ParaImage, paraImage);
            navigationParameters.Add(Constants.FromForm, UserControlNames.FullPic);
            navigationParameters.Add(Constants.ContainerImage, containerImage);
            navigationParameters.Add(Constants.ImageKind, imageKind);
            navigationParameters.Add(Constants.FromControl, fromControl);
            _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.Localization, navigationParameters);

        }

        private void GoOK()
        {
            if (image != null)
            {
                if (imageKind == KIND_ENUM.KIND_CLOSEUP)
                {
                    containerImage.ImageAndRectangleXRatio = RectangleX / image.ActualWidth;
                    containerImage.ImageAndRectangleYRatio = RectangleY / image.ActualHeight;
                    containerImage.ImageAndRectangleWidthRatio = RectangleWidth / image.ActualWidth;
                    containerImage.ImageAndRectangleHeightRatio = RectangleHeight / image.ActualHeight;
                }

                if (imageKind == KIND_ENUM.KIND_MIKRO)
                {
                    containerImage.ImageAndRectangleXRatio = RectangleX / image.ActualWidth;
                    containerImage.ImageAndRectangleYRatio = RectangleY / image.ActualHeight;
                }

                containerImage.FullPicActualWidth = image.ActualWidth;
                containerImage.FullPicActualHeight = image.ActualHeight;
            }

            var navigationParameters = new NavigationParameters();
            navigationParameters.Add(Constants.ParaImage, paraImage);
            navigationParameters.Add(Constants.FromForm, UserControlNames.FullPic);
            navigationParameters.Add(Constants.ContainerImage, containerImage);
            navigationParameters.Add(Constants.ImageKind, imageKind);
            navigationParameters.Add(Constants.FromControl, fromControl);
            _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.Localization, navigationParameters);
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
                paraImage = (BitmapSource)navigationContext.Parameters[Constants.ParaImage];

            if (navigationContext.Parameters[Constants.ImageKind] != null)
                imageKind = (KIND_ENUM)Enum.Parse(typeof(KIND_ENUM), navigationContext.Parameters[Constants.ImageKind].ToString());

            if (navigationContext.Parameters[Constants.FromControl] != null)
                fromControl = (string)navigationContext.Parameters[Constants.FromControl];

            if (navigationContext.Parameters[Constants.ContainerImage] != null)
            {
                containerImage = (ImageHandler)navigationContext.Parameters[Constants.ContainerImage];
                containerImageListIndex = containerImage.Id;
                FullImage = containerImage.Image;
            }

            if (navigationContext.Parameters[Constants.ParaObject] != null)
            {
                _patientCloseUpImageList = (List<ImageHandler>)navigationContext.Parameters[Constants.ParaObject];
            }

            if (navigationContext.Parameters[Constants.ParaObject2] != null)
            {
                _patientMikroImageList = (List<ImageHandler>)navigationContext.Parameters[Constants.ParaObject2];
            }
        }

        public void OnMouseDown(object sender, MouseCaptureArgs e)
        {
            RectangleVisible = Visibility.Collapsed;
            PointVisible = Visibility.Collapsed;
            image = e.AssociatedObject as System.Windows.Controls.Image;

            //draw rectangle on makro image for closeup
            if (imageKind == KIND_ENUM.KIND_CLOSEUP)
            {
                if (e.X - rectangleXOffset < 0)
                    RectangleX = 0;
                else if (e.X - rectangleXOffset + rectangleWidth > image.ActualWidth)
                    RectangleX = image.ActualWidth - rectangleWidth;
                else
                    RectangleX = e.X - rectangleXOffset;

                if (e.Y - rectangleYOffset < 0)
                    RectangleY = 0;
                else if (e.Y - rectangleYOffset + rectangleHeight > image.ActualHeight)
                    RectangleY = image.ActualHeight - rectangleHeight;
                else
                    RectangleY = e.Y - rectangleYOffset;


                RectangleWidth = (double)(rectangleWidth);
                RectangleHeight = (double)(rectangleHeight);
                RectangleVisible = Visibility.Visible;
            }

            //draw point on makro or closeup image for mikro
            if (imageKind == KIND_ENUM.KIND_MIKRO)
            {
                RectangleX = e.X - 6;
                RectangleY = e.Y - 6;
                PointVisible = Visibility.Visible;
            }
        }

        public void OnMouseMove(object sender, MouseCaptureArgs e)
        {
            //MessageBox.Show("mousemove");
        }

        public void OnMouseUp(object sender, MouseCaptureArgs e)
        {
            //MessageBox.Show("mouseup");
        }

        private void DrawHistoryPointOnImage()
        {
            if (_patientMikroImageList != null && _patientMikroImageList.Count > 0)
            {
                HistoryPointList = new ObservableCollection<PointItem>();
                foreach (var i in _patientMikroImageList)
                {
                    HistoryPointList.Add(new PointItem() { X = i.FullPicPointX * ImageWidth / 1000, Y = i.FullPicPointY * ImageHeight / 1000 });
                }

                if (HistoryPointList.Count > 0)
                    HistoryPointVisible = Visibility.Visible;
                else
                    HistoryPointVisible = Visibility.Collapsed;
            }

            if (_patientCloseUpImageList != null && _patientCloseUpImageList.Count > 0)
            {
                HistoryRectangleList = new ObservableCollection<RectangleItem>();
                foreach (var i in _patientCloseUpImageList)
                {
                    HistoryRectangleList.Add(new RectangleItem() { 
                        X1 = i.ImageAndRectangleXRatio * ImageWidth / 1000,
                        Y1 = i.ImageAndRectangleYRatio * ImageHeight / 1000,
                        X2 = i.ImageAndRectangleWidthRatio * ImageWidth / 1000,
                        Y2 = i.ImageAndRectangleHeightRatio * ImageHeight / 1000,
                    });
                }

                if (HistoryRectangleList.Count > 0)
                    HistoryRectangleVisible = Visibility.Visible;
                else
                    HistoryRectangleVisible = Visibility.Collapsed;
            }
        }
    }

}
