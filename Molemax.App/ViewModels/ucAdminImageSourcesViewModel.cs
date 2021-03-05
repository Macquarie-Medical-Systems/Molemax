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
    public class ucAdminImageSourcesViewModel : BindableBase, IConfirmNavigationRequest, IRegionMemberLifetime
    {
        private IAppSettings _applicationSetting;
        private string oldSelectImageSource_LiveVideo;
        private string oldSelectImageSource_LiveImage;
        private string oldSelectImageSource_FileImport;
        private string oldSelectImageSource_Extern;
        public IRegionManager _regionManager { get; }
        public DelegateCommand GoBackCommand { get; set; }
        public string SelectImageSource_LiveVideo { get; set; }
        public string SelectImageSource_LiveImage { get; set; }
        public string SelectImageSource_FileImport { get; set; }
        public string SelectImageSource_Extern { get; set; }

        public bool KeepAlive => false;

        public ucAdminImageSourcesViewModel(IRegionManager regionManager, IAppSettings applicationSetting)
        {
            _regionManager = regionManager;
            _applicationSetting = applicationSetting;

            oldSelectImageSource_LiveVideo = "True";
            SelectImageSource_LiveVideo = "True";

            oldSelectImageSource_LiveImage = applicationSetting.SelectImageSource_LiveImage;

            if (!string.IsNullOrEmpty(applicationSetting.SelectImageSource_LiveImage))
                SelectImageSource_LiveImage = applicationSetting.SelectImageSource_LiveImage;

            oldSelectImageSource_FileImport = applicationSetting.SelectImageSource_FileImport;

            if (!string.IsNullOrEmpty(applicationSetting.SelectImageSource_FileImport))
                SelectImageSource_FileImport = applicationSetting.SelectImageSource_FileImport;

            oldSelectImageSource_Extern = applicationSetting.SelectImageSource_Extern;

            if (!string.IsNullOrEmpty(applicationSetting.SelectImageSource_Extern))
                SelectImageSource_Extern = applicationSetting.SelectImageSource_Extern;

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
            if (oldSelectImageSource_LiveVideo != SelectImageSource_LiveVideo
                || oldSelectImageSource_LiveImage != SelectImageSource_LiveImage
                || oldSelectImageSource_FileImport != SelectImageSource_FileImport
                || oldSelectImageSource_Extern != SelectImageSource_Extern)
            {
                if (MessageBox.Show("Save settings for 'Select image source to show'?", "Navigate?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    _applicationSetting.SelectImageSource_LiveVideo = SelectImageSource_LiveVideo;
                    _applicationSetting.SelectImageSource_LiveImage = SelectImageSource_LiveImage;
                    _applicationSetting.SelectImageSource_FileImport = SelectImageSource_FileImport;
                    _applicationSetting.SelectImageSource_Extern = SelectImageSource_Extern;
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
