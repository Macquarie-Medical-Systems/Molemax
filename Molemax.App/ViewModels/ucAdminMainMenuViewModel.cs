using Molemax.App.Core;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molemax.App.ViewModels
{
    public class ucAdminMainMenuViewModel: BindableBase, IRegionMemberLifetime
    {
        private IAppSettings _applicationSetting;
        public DelegateCommand GoLiveVideoCommand { get; set; }
        public DelegateCommand GoLiveImageCommand { get; set; }
        public DelegateCommand GoImageSelectionPreviewCommand { get; set; }
        public DelegateCommand GoImageSourcesCommand { get; set; }
        public DelegateCommand GoUserCommand { get; set; }
        public IRegionManager _regionManager { get; }

        public bool KeepAlive => false;

        public ucAdminMainMenuViewModel(IRegionManager regionManager, IAppSettings applicationSetting)
        {
            _regionManager = regionManager;
            _applicationSetting = applicationSetting;
            _applicationSetting.LoadSettings();
            GoLiveVideoCommand = new DelegateCommand(GoLiveVideo);
            GoLiveImageCommand = new DelegateCommand(GoLiveImage);
            GoImageSelectionPreviewCommand = new DelegateCommand(GoImageSelectionPreview);
            GoImageSourcesCommand = new DelegateCommand(GoImageSources);
            GoUserCommand = new DelegateCommand(GoUser);
        }

        private void GoUser()
        {
            _regionManager.RequestNavigate(RegionNames.AdminContentRegion, UserControlNames.AdminUser);
        }

        private void GoImageSources()
        {
            _regionManager.RequestNavigate(RegionNames.AdminContentRegion, UserControlNames.AdminImageSources);
        }

        private void GoImageSelectionPreview()
        {
            _regionManager.RequestNavigate(RegionNames.AdminContentRegion, UserControlNames.AdminImageSelectionPreview);
        }

        private void GoLiveImage()
        {
            _regionManager.RequestNavigate(RegionNames.AdminContentRegion, UserControlNames.AdminLiveImage);
        }

        private void GoLiveVideo()
        {
            _regionManager.RequestNavigate(RegionNames.AdminContentRegion, UserControlNames.AdminLiveVideo);
        }


    }
}
