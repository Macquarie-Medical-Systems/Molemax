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

        }
    }

}
