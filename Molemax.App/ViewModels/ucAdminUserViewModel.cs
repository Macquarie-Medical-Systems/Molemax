using Molemax.App.Core;
using Molemax.Models;
using Molemax.Repository;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Molemax.App.ViewModels
{
    public class ucAdminUserViewModel : BindableBase, IConfirmNavigationRequest, IRegionMemberLifetime
    {
        private IAppSettings _applicationSetting;
        private IMolemaxRepository _repository;
        private IDialogService _dialogService;
        private IRegionManager _regionManager;
        private User userModel;
        private IEnumerable<User> _dbUsers
        {
            get { return _repository.Users.Get(); }
        }
        public DelegateCommand GoBackCommand { get; set; }
        public DelegateCommand GoAddUserCommand { get; set; }

        private ObservableCollection<User> _userList;
        public ObservableCollection<User> UserList
        {
            get { return _userList; }
            set { SetProperty(ref _userList, value); }
        }

        private bool _right_ReadOnly;
        public bool Right_ReadOnly
        {
            get { return _right_ReadOnly; }
            set { SetProperty(ref _right_ReadOnly, value); }
        }

        public bool KeepAlive => false;

        public ucAdminUserViewModel(IRegionManager regionManager, IMolemaxRepository molemaxRepository, IAppSettings applicationSetting, IDialogService dialogService)
        {
            _regionManager = regionManager;
            _repository = molemaxRepository;
            _applicationSetting = applicationSetting;
            _dialogService = dialogService;
            userModel = new User();
            UserList = new ObservableCollection<User>();

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
                    userModel.username = r.Parameters.GetValue<string>("UserName");
                    userModel.pwd = r.Parameters.GetValue<string>("Password");
                    userModel.myrights = (short)USER_RIGHTS.RIGHT_WRITE;
                    UserList.Add(userModel);
                    Right_ReadOnly = true;
                }
                //else if (r.Result == ButtonResult.Cancel)
                //    Title = "Result is Cancel";
            });
        }

        private void GoBack()
        {
            CompareAndSaveSetting();

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
