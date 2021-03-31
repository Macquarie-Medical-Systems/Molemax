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
    public class ucSegmentationViewModel : BindableBase, IRegionMemberLifetime, INavigationAware
    {
        private IRegionManager _regionManager;
        private IMolemaxRepository _repository;
        private IAppSettings _applicationSetting;
        private string fromForm;
        private ObservableCollection<LineItem> paraLineList;

        #region Property
        private BitmapSource _egmentationImage;
        public BitmapSource SegmentationImage
        {
            get { return _egmentationImage; }
            set { SetProperty(ref _egmentationImage, value); }
        }

        private string _segmentationMethod;
        public string SegmentationMethod
        {
            get { return _segmentationMethod; }
            set { SetProperty(ref _segmentationMethod, value); }
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
                DrawLinesOnImage();
            }
        }
        #endregion

        #region Command
        public DelegateCommand GoManualCommand { get; set; }
        public DelegateCommand GoABCDCommand { get; set; }
        public DelegateCommand GoCancelCommand { get; set; }
        #endregion

        public bool KeepAlive => false;

        public ucSegmentationViewModel(IRegionManager regionManager, IMolemaxRepository molemaxRepository, IAppSettings applicationSetting)
        {
            _regionManager = regionManager;
            _repository = molemaxRepository;
            _applicationSetting = applicationSetting;
            GoManualCommand = new DelegateCommand(GoManual);
            GoABCDCommand = new DelegateCommand(GoABCD);
            GoCancelCommand = new DelegateCommand(GoCancel);
            LineList = new ObservableCollection<LineItem>();
        }

        private void GoABCD()
        {
            throw new NotImplementedException();
        }

        private void GoManual()
        {
            var navigationParameters = new NavigationParameters();
            navigationParameters.Add(Constants.FromForm, UserControlNames.Segmentation);
            navigationParameters.Add(Constants.ParaImage, SegmentationImage);
            _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.FullPic_Segmentation, navigationParameters);

        }

        private void GoCancel()
        {
            var navigationParameters = new NavigationParameters();
            _regionManager.RequestNavigate(RegionNames.ContentRegion, fromForm, navigationParameters);

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
                SegmentationImage = (BitmapSource)navigationContext.Parameters[Constants.ParaImage];

            if (navigationContext.Parameters[Constants.FromForm] != null)
                fromForm = (string)navigationContext.Parameters[Constants.FromForm];

            if (navigationContext.Parameters[Constants.ParaObject] != null)
            {
                paraLineList = (ObservableCollection<LineItem>)navigationContext.Parameters[Constants.ParaObject];
            }


            //PointItem pi = new PointItem();
            //pi.X = e.X - 2;
            //pi.Y = e.Y - 2;

            //PointList.Add(pi);

            //if (PointList.Count > 1)
            //{
            //    LineItem li = new LineItem();
            //    PointItem lastPoint = PointList[PointList.Count - 2];
            //    li.X1 = lastPoint.X + 2;
            //    li.Y1 = lastPoint.Y + 2;
            //    li.X2 = e.X;
            //    li.Y2 = e.Y;
            //    LineList.Add(li);
            //}
        }

        private void DrawLinesOnImage()
        {
            if (paraLineList != null && paraLineList.Count > 0)
            {
                LineList = new ObservableCollection<LineItem>();
                foreach (var i in paraLineList)
                {
                    LineList.Add(new LineItem { X1 = i.X1 * ImageWidth, X2 = i.X2 * ImageWidth, Y1 = i.Y1 * ImageHeight, Y2 = i.Y2 * ImageHeight });
                }
            }
        
        }
    }

}
