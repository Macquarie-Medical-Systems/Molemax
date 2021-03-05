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
    public class ucAdminLiveImageViewModel : BindableBase, IConfirmNavigationRequest, IRegionMemberLifetime
    {
        private IAppSettings _applicationSetting;
        private string oldFollowUpLiveImageMode;
        public IRegionManager _regionManager { get; }
        public DelegateCommand GoBackCommand { get; set; }
        public OVERLAY_MODE FollowUpLiveImageMode { get; set; }

        public bool KeepAlive => false;

        public ucAdminLiveImageViewModel(IRegionManager regionManager, IAppSettings applicationSetting)
        {
            _regionManager = regionManager;
            _applicationSetting = applicationSetting;
            oldFollowUpLiveImageMode = applicationSetting.FollowUpLiveImageMode;
            if (!string.IsNullOrEmpty(applicationSetting.FollowUpLiveImageMode))
                FollowUpLiveImageMode = (OVERLAY_MODE)Enum.Parse(typeof(OVERLAY_MODE), applicationSetting.FollowUpLiveImageMode);
            
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
            if (oldFollowUpLiveImageMode != FollowUpLiveImageMode.ToString())
            {
                if (MessageBox.Show("Save settings for 'LiveImage'?", "Navigate?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    _applicationSetting.FollowUpLiveImageMode = FollowUpLiveImageMode.ToString();
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
