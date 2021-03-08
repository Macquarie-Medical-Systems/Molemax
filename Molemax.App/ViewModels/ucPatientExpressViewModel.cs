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
    public class ucPatientExpressViewModel : BindableBase, IRegionMemberLifetime, INavigationAware
    {
        private IRegionManager _regionManager;
        private IAppSettings _applicationSetting;
        private IMolemaxRepository _repository;
        private IEnumerable<Patient> _dbPatients
        {
            get { return _repository.Patients.Get(); }
        }
        private List<BitmapSource> _locImageList;
        private ExpressImage _expressImage;
        private Patient _newPatient;

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

        private string _newPatientLastName;
        public string NewPatientLastName
        {
            get { return _newPatientLastName; }
            set { SetProperty(ref _newPatientLastName, value); }
        }

        private string _newPatientFirstName;
        public string NewPatientFirstName
        {
            get { return _newPatientFirstName; }
            set { SetProperty(ref _newPatientFirstName, value); }
        }

        private string _newPatientBirthdate;
        public string NewPatientBirthdate
        {
            get { return _newPatientBirthdate; }
            set { SetProperty(ref _newPatientBirthdate, value); }
        }

        private string _insuranceNumber;
        public string NewPatientInsuranceNumber
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
        public DelegateCommand GoAssignToSelectedPatientCommand { get; set; }
        public DelegateCommand GoSearchPatientCommand { get; set; }
        public DelegateCommand GoAssignToNewPatientCommand { get; set; }
        #endregion

        private bool keepLive = false;
        public bool KeepAlive
        {
            get { return keepLive; }
        }

        public ucPatientExpressViewModel(IRegionManager regionManager, IMolemaxRepository molemaxRepository, IAppSettings appSettings)
        {
            _regionManager = regionManager;
            _repository = molemaxRepository;
            _applicationSetting = appSettings;
            _applicationSetting.LoadSettings();

            GoBackCommand = new DelegateCommand(GoBack);
            GoAssignToSelectedPatientCommand = new DelegateCommand(GoAssignToSelectedPatient);
            GoSearchPatientCommand = new DelegateCommand(GoSearchPatient);
            GoAssignToNewPatientCommand = new DelegateCommand(GoAssignToNewPatient);

            _expressImage = new ExpressImage();
        }

        private void GoAssignToNewPatient()
        {
            var navigationParameters = new NavigationParameters();
            navigationParameters.Add(Constants.FromForm, UserControlNames.PatientExpress);

            if (StorePatient())
            {
                if (_selectedPatient != null)
                {
                    foreach (var snapShotImage in _locImageList)
                    {
                        string imageName = CreateNameForImage();
                        string imageFullPathAndName = CreateFullPathForImage(imageName);

                        if (!Directory.Exists(_applicationSetting.ImagePath))
                            Directory.CreateDirectory(_applicationSetting.ImagePath);

                        if (File.Exists(imageFullPathAndName))
                            File.Delete(imageFullPathAndName);

                        ImageHelpers.SaveBitmapSourceToFile(snapShotImage, imageFullPathAndName);
                        if (File.Exists(imageFullPathAndName))
                        {
                            _expressImage = new ExpressImage();

                            _expressImage.patientId = _selectedPatient.id;
                            _expressImage.imgname = imageName;
                            //should be a checkbox on form
                            _expressImage.attention = false;
                            //from micro
                            _expressImage.origin = 12;
                            _expressImage.reserved1 = false;
                            _expressImage.reserved2 = false;
                            _expressImage.reserved3 = false;
                            _expressImage.reserved4 = false;
                            _repository.ExpressImages.Upsert(_expressImage);
                        }
                    }

                    _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.ExpressSession, navigationParameters);
                }
            }
        }

        private bool StorePatient()
        {
            ValidateFields();

            if (!CheckPatExistance())
            {
                AddPatient();
                return true;
            }
            else
            {
                MessageBox.Show("Patient to store already exists in database!");
                return false;
            }
        }

        private bool CheckPatExistance()
        {
            var patient = _dbPatients.OrderBy(pa => pa.lastname).ThenBy(pa => pa.firstname).ThenBy(pa => pa.birthdate).ThenBy(pa => pa.insnr)
                    .FirstOrDefault(pa => pa.lastname == NewPatientLastName && pa.firstname == NewPatientFirstName
                    && pa.insnr == NewPatientInsuranceNumber && pa.birthdate == DateTime.Parse(NewPatientBirthdate));
            if (patient == null)
                return false;
            else
                return true;
        }

        private void AddPatient()
        {
            _newPatient = new Patient();
            DateTime currentTime = DateTime.Now;
            var timestamp = _repository.Timestamps.Upsert(new Timestamp { date_created = currentTime, date_last_accessed = currentTime, pcname = Environment.MachineName });
            _newPatient.lastname = NewPatientLastName;
            _newPatient.firstname = NewPatientFirstName;
            _newPatient.birthdate = DateTime.Parse(NewPatientBirthdate);
            _newPatient.tsId = timestamp.id;
            _newPatient.userId = GlobalValue.Instance.UserID;
            _newPatient.waiting_room = true;
            _selectedPatient = _repository.Patients.Upsert(_newPatient);
        }

        private void ValidateFields()
        {
            //    ValidateLastName();
            //    ValidateFirstNasme();
            //    ValidateBirthday();
            //    ValidateInsuranceNumber();
            //    ValidateEMail();
            //    ValidateWeek();
            //    ValidateMonth();
            //    ValidateYear();
            //    ValidateRisk();
        }

        private void GoSearchPatient()
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

        private void GoAssignToSelectedPatient()
        {
            if (_selectedPatient != null)
            {
                foreach(var snapShotImage in _locImageList)
                {
                    string imageName = CreateNameForImage();
                    string imageFullPathAndName = CreateFullPathForImage(imageName);

                    if (!Directory.Exists(_applicationSetting.ImagePath))
                        Directory.CreateDirectory(_applicationSetting.ImagePath);

                    if (File.Exists(imageFullPathAndName))
                        File.Delete(imageFullPathAndName);

                    ImageHelpers.SaveBitmapSourceToFile(snapShotImage, imageFullPathAndName);
                    if (File.Exists(imageFullPathAndName))
                    {
                        _expressImage = new ExpressImage();

                        _expressImage.patientId = _selectedPatient.id;
                        _expressImage.imgname = imageName;
                        //should be a checkbox on form
                        _expressImage.attention = false;
                        //from micro
                        _expressImage.origin = 12;
                        _expressImage.reserved1 = false;
                        _expressImage.reserved2 = false;
                        _expressImage.reserved3 = false;
                        _expressImage.reserved4 = false;
                        _repository.ExpressImages.Upsert(_expressImage);
                    }
                }

                var navigationParameters = new NavigationParameters();
                navigationParameters.Add(Constants.FromForm, UserControlNames.PatientExpress);
                _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.ExpressSession, navigationParameters);
            }
        }

        private string CreateFullPathForImage(string name)
        {
            return _applicationSetting.UnlocalizedImages + "\\" + name;
        }

        private string CreateNameForImage()
        {
            string strPrefix = "ELM";

            return $"{strPrefix}_{_selectedPatient.id}_{DateTime.Now.ToString("yyyyMMdd")}_{DateTime.Now.ToString("hhmmss")}_{Guid.NewGuid()}.jpg";
        }

        private void GoBack()
        {
            keepLive = false;
            GlobalValue.Instance.CurrentPatient = null;
            _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.MainMenu);
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext.Parameters[Constants.ParaImageList] != null)
                _locImageList = (List<BitmapSource>)navigationContext.Parameters[Constants.ParaImageList];
            else
                _locImageList = null;
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
