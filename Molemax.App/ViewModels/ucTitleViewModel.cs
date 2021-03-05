using Molemax.App.Core;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molemax.App.ViewModels
{
    public class ucTitleViewModel : BindableBase, IRegionMemberLifetime
    {
        IEventAggregator _ea;

        private string _viewName;
        public string ViewName
        {
            get { return _viewName; }
            set { SetProperty(ref _viewName, value); }
        }

        private string _patientInfo;
        public string PatientInfo
        {
            get { return _patientInfo; }
            set { SetProperty(ref _patientInfo, value); }
        }

        private string _user;
        public string User
        {
            get { return _user; }
            set { SetProperty(ref _user, value); }
        }

        public bool KeepAlive => true;

        public ucTitleViewModel(IEventAggregator ea)
        {
            _ea = ea;
            _ea.GetEvent<UpdateViewNameInTitleEvent>().Subscribe(ViewNameReceived);
            _ea.GetEvent<UpdatePatientInfoInTitleEvent>().Subscribe(PatientInfoReceived);
            _ea.GetEvent<UpdateUserInTitleEvent>().Subscribe(UserReceived);
        }

        private void UserReceived(string user)
        {
            User = user;
        }

        private void PatientInfoReceived(string patientInfo)
        {
            PatientInfo = patientInfo;
        }

        private void ViewNameReceived(string viewName)
        {
            ViewName = viewName;
        }

    }
}
