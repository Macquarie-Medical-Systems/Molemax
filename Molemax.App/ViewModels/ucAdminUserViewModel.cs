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
        private User user;
        private IEnumerable<User> _dbUsers
        {
            get { return _repository.Users.Get(); }
        }
        public DelegateCommand GoBackCommand { get; set; }
        public DelegateCommand GoAddUserCommand { get; set; }
        public DelegateCommand GoUserTableClickCommand { get; set; }

        private User _selectedUser;
        public User SelectedUser
        {
            get { return _selectedUser; }
            set { SetProperty(ref _selectedUser, value); }
        }

        private ObservableCollection<User> _userList;
        public ObservableCollection<User> UserList
        {
            get { return _userList; }
            set { SetProperty(ref _userList, value); }
        }

        private ObservableCollection<UserSpecifyRight> _userSpecifyRightList;
        public ObservableCollection<UserSpecifyRight> UserSpecifyRightList
        {
            get { return _userSpecifyRightList; }
            set { SetProperty(ref _userSpecifyRightList, value); }
        }

        private bool _right_ReadOnly;
        public bool Right_ReadOnly
        {
            get { return _right_ReadOnly; }
            set { SetProperty(ref _right_ReadOnly, value); }
        }

        private bool _right_ReadWrite;
        public bool Right_ReadWrite
        {
            get { return _right_ReadWrite; }
            set { SetProperty(ref _right_ReadWrite, value); }
        }

        private bool _right_Delete;
        public bool Right_Delete
        {
            get { return _right_Delete; }
            set { SetProperty(ref _right_Delete, value); }
        }

        public bool KeepAlive => false;

        public ucAdminUserViewModel(IRegionManager regionManager, IMolemaxRepository molemaxRepository, IAppSettings applicationSetting, IDialogService dialogService)
        {
            _regionManager = regionManager;
            _repository = molemaxRepository;
            _applicationSetting = applicationSetting;
            _dialogService = dialogService;
            user = new User();
            UserList = new ObservableCollection<User>(_dbUsers.ToList());
            UserSpecifyRightList = new ObservableCollection<UserSpecifyRight>();

            GoBackCommand = new DelegateCommand(GoBack);
            GoAddUserCommand = new DelegateCommand(GoAddUser);
            GoUserTableClickCommand = new DelegateCommand(GoUserTableClick);
        }

        private void GoUserTableClick()
        {
            if (SelectedUser != null)
            {
                //set global user right
                switch (SelectedUser.myrights)
                {
                    case 1:
                        Right_ReadOnly = true;
                        Right_ReadWrite = false;
                        Right_Delete = false;
                        break;
                    case 2:
                        Right_ReadOnly = true;
                        Right_ReadWrite = true;
                        Right_Delete = false;
                        break;
                    case 3:
                        Right_ReadOnly = true;
                        Right_ReadWrite = true;
                        Right_Delete = true;
                        break;
                }

                //clean specify rights datagrid
                UserSpecifyRightList = new ObservableCollection<UserSpecifyRight>();

                //get specify rights then add into datagrid
                //loop user list
                foreach (var user in UserList)
                {
                    //if user is admin, full rights to all users
                    if (user.username == "admin")
                    {
                        var otherUsers = UserList.Where(i => i.username != user.username).ToList();
                        if (otherUsers != null && otherUsers.Count > 0)
                        {
                            SetSpecifyRightsForOtherUser(otherUsers, USER_RIGHTS.RIGHT_DELETE);
                        }
                    }
                    //if my rights is 0, no rights to all users
                    if (SelectedUser.myrights == (short)USER_RIGHTS.RIGHT_NONE)
                    {
                        var otherUsers = UserList.Where(i => i.username != user.username).ToList();
                        if (otherUsers != null && otherUsers.Count > 0)
                        {
                            SetSpecifyRightsForOtherUser(otherUsers, 0);
                        }
                    }

                    //if my rights is 1 , split rights by '/' into array, then add array to UserSpecifyRightList except current user
                    //if other user is not exist in array, then set readonly right to this user
                    if (SelectedUser.myrights == (short)USER_RIGHTS.RIGHT_READ)
                    {
                        var otherUsers = UserList.Where(i => i.username != user.username).ToList();
                        if (otherUsers != null && otherUsers.Count > 0)
                        {
                            SetSpecifyRightsForOtherUser(otherUsers, 0, SelectedUser.rights);
                        }
                    }

                    //if my rights is 2 and rights is empty, set readonly and readwrite rights to all users

                    //if my rights is 2 and rights is not empty, split rights by '/' into array, add array to UserSpecifyRightList except current user
                    //If other user is not exist in array, then set readonly and readwrite rights to this user

                    //if my rights is 3 and user is not admin, split rights by '/' into array,
                    //if array only has one record and the user in this record is current user, ignort it
                    //otherwise, add add array to UserSpecifyRightList except current user
                    //If other user is not exist in array, then set readonly and readwrite rights to this user
                }


            }
        }

        private void SetSpecifyRightsForOtherUser(List<User> otherUsers, USER_RIGHTS myRights, string rights = null)
        {
            if (string.IsNullOrEmpty(rights))
            {
                foreach (var user in otherUsers)
                {
                    if (myRights == USER_RIGHTS.RIGHT_DELETE)
                        UserSpecifyRightList.Add(new UserSpecifyRight() { UserName = user.username, IsReadOnly = true, IsReadWrite = true, IsDelete = true });

                    if (myRights == USER_RIGHTS.RIGHT_NONE)
                        UserSpecifyRightList.Add(new UserSpecifyRight() { UserName = user.username, IsReadOnly = false, IsReadWrite = false, IsDelete = false });

                }
            }

            else
            {


            }
        }

        private void GoAddUser()
        {
            
            var message = "This is a message that should be shown in the dialog .";

            //using the dialog service as-is
            _dialogService.ShowDialog("ucAdminUserAdd", new DialogParameters($"message={message}"), r =>
            {
                if (r.Result == ButtonResult.OK)
                {
                    user.username = r.Parameters.GetValue<string>("UserName");
                    user.pwd = r.Parameters.GetValue<string>("Password");
                    //user.myrights = (short)USER_RIGHTS.RIGHT_WRITE;
                    UserList.Add(user);

                    //拿到除旧的user之外其他users

                    //循环旧的users，添加special user right, 清空 UserSpecifyRightList， 然后添加到UserSpecifyRightList

                    //Right_ReadOnly = true;
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
