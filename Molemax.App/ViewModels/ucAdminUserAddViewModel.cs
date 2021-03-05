using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molemax.App.ViewModels
{
    public class ucAdminUserAddViewModel: BindableBase, IDialogAware
    {
        public DelegateCommand<string> GoOKCommand { get; set; }

        private bool _isEnable;
        public bool IsEnable
        {
            get { return _isEnable; }
            set { SetProperty(ref _isEnable, value); }
        }

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            { 
                SetProperty(ref _password, value);
                if (_password == _confirmPassword)
                    IsEnable = true;
                else
                    IsEnable = false;
            }
        }

        private string _confirmPassword;
        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set
            {
                SetProperty(ref _confirmPassword, value);
                if (_password == _confirmPassword)
                    IsEnable = true;
                else
                    IsEnable = false;
            }
        }

        private string _title = "Add New User";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public event Action<IDialogResult> RequestClose;

        public ucAdminUserAddViewModel()
        {
            Password = string.Empty;
            ConfirmPassword = string.Empty;
            GoOKCommand = new DelegateCommand<string>(GoOK).ObservesCanExecute(()=> IsEnable);
        }
        protected virtual void GoOK(string parameter)
        {
            ButtonResult result = ButtonResult.None;

            if (parameter?.ToLower() == "true")
                result = ButtonResult.OK;
            else if (parameter?.ToLower() == "false")
                result = ButtonResult.Cancel;

            RaiseRequestClose(new DialogResult(result));
        }

        public virtual void RaiseRequestClose(IDialogResult dialogResult)
        {
            dialogResult.Parameters.Add("UserName", UserName);
            dialogResult.Parameters.Add("Password", Password);
            RequestClose?.Invoke(dialogResult);
        }

        public virtual bool CanCloseDialog()
        {
            return true;
        }

        public virtual void OnDialogClosed()
        {

        }

        public virtual void OnDialogOpened(IDialogParameters parameters)
        {
            //Message = parameters.GetValue<string>("message");
        }
    }
}
