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
    public class ucFupLiveVideoViewModel: BindableBase, IRegionMemberLifetime, INavigationAware
    {
        private IAppSettings _applicationSetting;
        public DelegateCommand GoBackCommand { get; set; }
        public DelegateCommand GoOKCommand { get; set; }
        public IRegionManager _regionManager { get; }

        public ImageHandler _paraImage;
        public ImageHandler ParaImage
        {
            get { return _paraImage; }
            set { SetProperty(ref _paraImage, value); }
        }

        public bool KeepAlive => false;

        public ucFupLiveVideoViewModel(IRegionManager regionManager, IAppSettings applicationSetting)
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
                navigationParameters.Add(Constants.FromForm, UserControlNames.FupLiveVideo);
                navigationParameters.Add(Constants.FupImage, ucImageViewModel.camImageModel.Path);
                navigationParameters.Add(Constants.OriginalImage, ParaImage);
                navigationParameters.Add(Constants.ImageKind, KIND_ENUM.KIND_MIKRO);
                navigationParameters.Add(Constants.ImageSource, IMAGING_SOURCES_INDEX.SOURCE_LIVEVIDEO);
                _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.FupLocalization, navigationParameters);
            }
        }

        private void GoBack()
        {
            var navigationParameters = new NavigationParameters();
            navigationParameters.Add(Constants.FromForm, UserControlNames.FupLiveVideo);

            _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.Selection, navigationParameters);

        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext.Parameters[Constants.ParaImage] != null)
                ParaImage = (ImageHandler)navigationContext.Parameters[Constants.ParaImage];
            else
                ParaImage = null;
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
