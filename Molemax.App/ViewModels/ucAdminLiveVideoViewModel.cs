using Molemax.App.Core;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Molemax.App.ViewModels
{
    public class ucAdminLiveVideoViewModel : BindableBase, IConfirmNavigationRequest, IRegionMemberLifetime
    {
        private IAppSettings _applicationSetting;
        private string oldFollowUpLiveVideoMode;
        public IRegionManager _regionManager { get; }
        public DelegateCommand GoBackCommand { get; set; }
        public OVERLAY_MODE FollowUpLiveVideoMode { get; set; }

        public bool KeepAlive => false;

        public ucAdminLiveVideoViewModel(IRegionManager regionManager, IAppSettings applicationSetting)
        {
            _regionManager = regionManager;
            _applicationSetting = applicationSetting;

            oldFollowUpLiveVideoMode = applicationSetting.FollowUpLiveVideoMode;

            if (!string.IsNullOrEmpty(applicationSetting.FollowUpLiveVideoMode))
                FollowUpLiveVideoMode = (OVERLAY_MODE)Enum.Parse(typeof(OVERLAY_MODE), applicationSetting.FollowUpLiveVideoMode);
            
            GoBackCommand = new DelegateCommand(GoBack);
        }

        private void GoBack()
        {
            CompareAndSaveSetting();

            foreach (var view in _regionManager.Regions[RegionNames.AdminContentRegion].Views)
            {
                _regionManager.Regions[RegionNames.AdminContentRegion].Remove(view);
            }
            
            _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.MainMenu);
        }

        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            var result = true;

            CompareAndSaveSetting();

            continuationCallback(result);
        }

        private void CompareAndSaveSetting()
        {
            if (oldFollowUpLiveVideoMode != FollowUpLiveVideoMode.ToString())
            {
                if (MessageBox.Show("Save settings for 'LiveVideo'?", "Navigate?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    _applicationSetting.FollowUpLiveVideoMode = FollowUpLiveVideoMode.ToString();
                    _applicationSetting.SaveSettings();
                }
            }
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }
    }
}
