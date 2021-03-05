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
    public class ucAdminImageSelectionPreviewViewModel : BindableBase, IConfirmNavigationRequest, IRegionMemberLifetime
    {
        private IAppSettings _applicationSetting;
        private string oldSheetDisplayMode;
        public IRegionManager _regionManager { get; }
        public DelegateCommand GoBackCommand { get; set; }
        public SHEET_DISPLAY_MODE SheetDisplayMode { get; set; }

        public bool KeepAlive => false;

        public ucAdminImageSelectionPreviewViewModel(IRegionManager regionManager, IAppSettings applicationSetting)
        {
            _regionManager = regionManager;
            _applicationSetting = applicationSetting;

            oldSheetDisplayMode = applicationSetting.SheetDisplayMode;

            if (!string.IsNullOrEmpty(applicationSetting.SheetDisplayMode))
                SheetDisplayMode = (SHEET_DISPLAY_MODE)Enum.Parse(typeof(SHEET_DISPLAY_MODE), applicationSetting.SheetDisplayMode);

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
            if (oldSheetDisplayMode != SheetDisplayMode.ToString())
            {
                if (MessageBox.Show("Save settings for 'Image Selection Preview'?", "Navigate?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    _applicationSetting.SheetDisplayMode = SheetDisplayMode.ToString();
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
