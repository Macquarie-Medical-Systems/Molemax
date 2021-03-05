using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Molemax.App.Core;
using System.IO;

namespace Molemax.App.ViewModels
{
    public class ucLiveVideoViewModel: BindableBase, IRegionMemberLifetime, INavigationAware
    {
        private IAppSettings _applicationSetting;
        private string fromForm;
        private string fromControl;
        public DelegateCommand GoBackCommand { get; set; }
        public DelegateCommand GoOKCommand { get; set; }
        public IRegionManager _regionManager { get; }

        public bool KeepAlive => false;

        public ucLiveVideoViewModel(IRegionManager regionManager, IAppSettings applicationSetting)
        {
            GoBackCommand = new DelegateCommand(GoBack);
            GoOKCommand = new DelegateCommand(GoOK);
            _regionManager = regionManager;
            _applicationSetting = applicationSetting;
        }


        private void GoOK()
        {
            var navigationParameters = new NavigationParameters();
            
            if (ucImageViewModel.camImageModel != null)
            {
                navigationParameters.Add(Constants.ParaImage, ucImageViewModel.camImageModel.Path);
                navigationParameters.Add(Constants.ImageKind, KIND_ENUM.KIND_MIKRO);
                navigationParameters.Add(Constants.ImageSource, IMAGING_SOURCES_INDEX.SOURCE_LIVEVIDEO);
                _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.Localization, navigationParameters);
            }
        }

        private void GoBack()
        {
            var navigationParameters = new NavigationParameters();
            navigationParameters.Add(Constants.FromForm, UserControlNames.LiveVideo);
            switch (fromForm)
            {
                case UserControlNames.Patient:
                    switch (fromControl)
                    {
                        case Constants.FaceImageLiveVideo:
                            _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.Patient, navigationParameters);
                            break;
                        case Constants.ImportSourceLiveVideo:
                            _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.PatientMenu, navigationParameters);
                            break;
                    }
                    break;
                case UserControlNames.Localization:
                case UserControlNames.PatientMenu:
                    _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.PatientMenu, navigationParameters);
                    break;
            }
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext.Parameters[Constants.FromForm] != null)
                fromForm = (string)navigationContext.Parameters[Constants.FromForm];

            if (navigationContext.Parameters[Constants.FromControl] != null)
                fromControl = (string)navigationContext.Parameters[Constants.FromControl];
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
