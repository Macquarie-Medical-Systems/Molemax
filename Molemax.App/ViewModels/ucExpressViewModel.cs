using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Molemax.App.Core;
using System;
using System.Windows.Media.Imaging;
using System.Collections.Generic;
using System.Windows;

namespace Molemax.App.ViewModels
{
    public class ucExpressViewModel : BindableBase, IRegionMemberLifetime, INavigationAware
    {
        public DelegateCommand GoSaveCommand { get; set; }
        public DelegateCommand GoBackCommand { get; set; }
        public IRegionManager _regionManager { get; }
        private string fromForm;

        public bool KeepAlive => false;

        public ucExpressViewModel(IRegionManager regionManager)
        {
            GoBackCommand = new DelegateCommand(GoBack);
            GoSaveCommand = new DelegateCommand(GoSave);
            _regionManager = regionManager;          
        }


        private void GoSave()
        {
            var navigationParameters = new NavigationParameters();

            if (ucImageViewModel.camImageModels != null)
            {
                List<BitmapSource> snapshotImageList = new List<BitmapSource>();
                foreach (CamImageModel cim in ucImageViewModel.camImageModels)
                {
                    snapshotImageList.Add(cim.Path);
                }
                navigationParameters.Add(Constants.ParaImageList, snapshotImageList);
                _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.PatientExpress, navigationParameters);
            }

        }

        private void GoBack()
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.MainMenu);
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext.Parameters[Constants.FromForm] != null)
            {
                fromForm = (string)navigationContext.Parameters[Constants.FromForm];
                if (fromForm == UserControlNames.PatientExpress)
                {
                    MessageBoxResult result = MessageBox.Show("Continue with express session?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.No)
                    {
                        _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.MainMenu);
                    }
                }
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }
    }
}
