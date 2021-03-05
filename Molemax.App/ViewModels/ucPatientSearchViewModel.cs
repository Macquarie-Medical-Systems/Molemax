using Molemax.App.Core;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using Molemax.Models;
using Molemax.Repository;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using System.Linq;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Documents;
using System.Globalization;
using Prism.Events;

namespace Molemax.App.ViewModels
{
    public class ucPatientSearchViewModel : BindableBase, IRegionMemberLifetime, INavigationAware
    {
        private IEventAggregator _ea;
        private IRegionManager _regionManager;
        private IAppSettings _appSettings;
        private IMolemaxRepository _repository;
        private IEnumerable<Patient> _dbPatients
        {
            get { return _repository.Patients.Get(); }
        }

        #region property
        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { SetProperty(ref _lastName, value); }
        }

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value); }
        }

        private string _birthdate;
        public string Birthdate
        {
            get { return _birthdate; }
            set { SetProperty(ref _birthdate, value); }
        }

        private string _insuranceNumber;
        public string InsuranceNumber
        {
            get { return _insuranceNumber; }
            set { SetProperty(ref _insuranceNumber, value); }
        }

        private Patient _selectedPatient;
        public Patient SelectedPatient
        {
            get { return _selectedPatient; }
            set { SetProperty(ref _selectedPatient, value); }
        }
        

        private BitmapSource _patientFaceImage;
        public BitmapSource PatientFaceImage
        {
            get { return _patientFaceImage; }
            set { SetProperty(ref _patientFaceImage, value); }
        }

        private ObservableCollection<Patient> _patientList;
        public ObservableCollection<Patient> PatientList
        {
            get { return _patientList; }
            set { SetProperty(ref _patientList, value); }
        }
        #endregion

        #region command
        public DelegateCommand GoBackCommand { get; set; }
        public DelegateCommand GoFollowUpCommand { get; set; }
        public DelegateCommand GoSelectCommand { get; set; }
        public DelegateCommand<object> GoAlphaCommand { get; set; }
        public DelegateCommand GoSearchCommand { get; set; }
        public DelegateCommand GoTableClickCommand { get; set; }
        #endregion

        private bool keepLive = false;
        public bool KeepAlive
        {
            get { return keepLive; }
        }

        public ucPatientSearchViewModel(IRegionManager regionManager, IMolemaxRepository molemaxRepository, IAppSettings appSettings, IEventAggregator ea)
        {
            _regionManager = regionManager;
            _repository = molemaxRepository;
            _ea = ea;
            _ea.GetEvent<UpdateViewNameInTitleEvent>().Publish(Constants.Views.PatientSearch);
            _appSettings = appSettings;
            _appSettings.LoadSettings();
            //PatientModle = new Patient();
            GoBackCommand = new DelegateCommand(GoBack);
            GoAlphaCommand = new DelegateCommand<object>(GoAlpha);
            GoSearchCommand = new DelegateCommand(GoSearch);
            GoTableClickCommand = new DelegateCommand(GoTableClick);
            GoSelectCommand = new DelegateCommand(GoSelect);
            GoFollowUpCommand = new DelegateCommand(GoFollowUp);
        }

        private void GoTableClick()
        {
            if (_selectedPatient!= null && !string.IsNullOrEmpty(_selectedPatient.image_path))
                PatientFaceImage = new BitmapImage(new Uri(_selectedPatient.image_path));
        }

        private void GoSearch()
        {
            List<Patient> pList = _dbPatients.ToList();

            if (pList.Count > 0)
            {
                if (!string.IsNullOrEmpty(LastName))
                    pList = pList.Where(p => p.lastname.StartsWith(LastName, true, CultureInfo.CurrentCulture)).ToList();
                if (!string.IsNullOrEmpty(FirstName))
                    pList = pList.Where(p => p.firstname.StartsWith(FirstName, true, CultureInfo.CurrentCulture)).ToList();

                DateTime bd;
                if (!string.IsNullOrEmpty(Birthdate) && DateTime.TryParse(Birthdate, out bd))
                {
                    pList = pList.Where(p => p.birthdate == bd).ToList();
                }

                if (!string.IsNullOrEmpty(InsuranceNumber))
                {
                    pList = pList.Where(p => p.insnr.StartsWith(InsuranceNumber, true, CultureInfo.CurrentCulture)).ToList();
                }

                if (pList.Count == 0)
                {
                    MessageBox.Show("No matching patients found!");
                }
                else
                {
                    pList = pList.OrderBy(p => p.lastname).ThenBy(p => p.firstname).ThenBy(p => p.birthdate).ThenBy(p => p.insnr).ToList();
                }
                PatientList = new ObservableCollection<Patient>(pList);
            }
        }

        private void GoAlpha(object obj)
        {
            string sQuery = obj as string;
            LastName = sQuery;
            var pList = _dbPatients.Where(p => p.lastname.StartsWith(sQuery,true,CultureInfo.CurrentCulture)).OrderBy(p=>p.lastname).ThenBy(p=>p.firstname).ThenBy(p => p.birthdate).ThenBy(p => p.insnr).ToList();
            PatientList = new ObservableCollection<Patient>(pList);
        }

        private void GoFollowUp()
        {
            if (_selectedPatient == null)
            {
                MessageBox.Show("Please select a patient!");
                return;
            }

            keepLive = true;
            GlobalValue.Instance.CurrentPatient = _selectedPatient;
            string patientInfo = $"{_selectedPatient.firstname}, {_selectedPatient.firstname} [last visit:][Created By:]";
            _ea.GetEvent<UpdatePatientInfoInTitleEvent>().Publish(patientInfo);

            var navigationParameters = new NavigationParameters();
            navigationParameters.Add(Constants.FromForm, UserControlNames.PatientSearch);
            _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.Selection, navigationParameters);
        }

        private void GoSelect()
        {
            if (_selectedPatient == null)
            {
                MessageBox.Show("Please select a patient!");
                return;
            }

            keepLive = true;
            GlobalValue.Instance.CurrentPatient = _selectedPatient;
            string patientInfo = $"{_selectedPatient.firstname}, {_selectedPatient.firstname} [last visit:][Created By:]";
            _ea.GetEvent<UpdatePatientInfoInTitleEvent>().Publish(patientInfo);

            var navigationParameters = new NavigationParameters();
            navigationParameters.Add(Constants.FromForm, UserControlNames.PatientSearch);
            _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.PatientMenu, navigationParameters);
        }

        private void GoBack()
        {
            keepLive = false;
            GlobalValue.Instance.CurrentPatient = null;
            _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.MainMenu);
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext.Parameters[Constants.PatientFaceImage] !=null)
                PatientFaceImage = (BitmapSource)navigationContext.Parameters[Constants.PatientFaceImage];
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
