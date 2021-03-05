using Molemax.App.Core;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Molemax.App.ViewModels
{
    public class ucAdminUserViewModel : BindableBase, IConfirmNavigationRequest, IRegionMemberLifetime
    {
        private IAppSettings _applicationSetting;
        private IDialogService _dialogService;
        private string oldFollowUpLiveImageMode;
        public IRegionManager _regionManager { get; }
        public DelegateCommand GoBackCommand { get; set; }
        public DelegateCommand GoAddUserCommand { get; set; }
        public OVERLAY_MODE FollowUpLiveImageMode { get; set; }

        public string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public bool KeepAlive => false;

        public ucAdminUserViewModel(IRegionManager regionManager, IAppSettings applicationSetting, IDialogService dialogService)
        {
            _regionManager = regionManager;
            _applicationSetting = applicationSetting;
            _dialogService = dialogService;
            oldFollowUpLiveImageMode = applicationSetting.FollowUpLiveImageMode;
            if (!string.IsNullOrEmpty(applicationSetting.FollowUpLiveImageMode))
                FollowUpLiveImageMode = (OVERLAY_MODE)Enum.Parse(typeof(OVERLAY_MODE), applicationSetting.FollowUpLiveImageMode);
            
            GoBackCommand = new DelegateCommand(GoBack);
            GoAddUserCommand = new DelegateCommand(GoUser);
        }

        private void GoUser()
        {
            
            var message = "This is a message that should be shown in the dialog .";

            //using the dialog service as-is
            _dialogService.ShowDialog("ucAdminUserAdd", new DialogParameters($"message={message}"), r =>
            {
                if (r.Result == ButtonResult.OK)
                {
                    string userName = r.Parameters.GetValue<string>("UserName");
                    string Password = r.Parameters.GetValue<string>("Password");
                }
                else if (r.Result == ButtonResult.Cancel)
                    Title = "Result is Cancel";
            });
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
