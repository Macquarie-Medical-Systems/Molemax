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
using Prism.Events;

namespace Molemax.App.ViewModels
{
    public class ucPatientViewModel : BindableBase, IRegionMemberLifetime, INavigationAware
    {
        private IEventAggregator _ea;
        private IRegionManager _regionManager;
        private IAppSettings _appSettings;
        private IMolemaxRepository _repository;
        private IEnumerable<Patient> _dbPatients
        {
            get { return _repository.Patients.Get(); }
        }

        public string InsNumber { get; set; }
        public string InsNumber_BD { get; set; }

        private Patient _currentPatient;
        public Patient CurrentPatient

        {
            get { return _currentPatient; }
            set { SetProperty(ref _currentPatient, value); }
        }

        private BitmapSource _patientFaceImage;
        public BitmapSource PatientFaceImage
        {
            get { return _patientFaceImage; }
            set { SetProperty(ref _patientFaceImage, value); }
        }
        public GENDER Gender { get; set; }
        public ObservableCollection<string> Countries { get; set; }
        public ObservableCollection<string> EthnicGroups { get; set; }
        public ObservableCollection<string> EyeColors { get; set; }
        public ObservableCollection<string> Complexions { get; set; }
        public ObservableCollection<string> HairColors { get; set; }
        public ObservableCollection<string> PatientHeight { get; set; }
        public ObservableCollection<string> SkinColors { get; set; }
        public ObservableCollection<int> PatientHeightCM { get; set; }
        public TOTAL_NEVI_COUNT Total { get; set; }
        public FRECKLE_INDEX Freckle { get; set; }
        public ATYPICAL_NEVI_COUNT Atypical { get; set; }
        public EPISODES_OF_SUNBURN Sunburn { get; set; }

        public DelegateCommand GoBackCommand { get; set; }
        public DelegateCommand GoSaveCommand { get; set; }
        public DelegateCommand<object> GoSelectionCommand { get; set; }
        public DelegateCommand GoLiveVideoCommand { get; set; }

        private bool _keepLive = false;
        public bool KeepAlive
        {
            get { return _keepLive; }
        }

        public ucPatientViewModel(IRegionManager regionManager, IMolemaxRepository molemaxRepository, IAppSettings appSettings, IEventAggregator ea)
        {
            _regionManager = regionManager;
            _repository = molemaxRepository;
            _appSettings = appSettings;
            _appSettings.LoadSettings();
            CurrentPatient = new Patient();
            CurrentPatient.birthdate = DateTime.Today;
            GoBackCommand = new DelegateCommand(GoBack);
            GoSaveCommand = new DelegateCommand(GoSave);
            GoSelectionCommand = new DelegateCommand<object>(GoSelection);
            GoLiveVideoCommand = new DelegateCommand(GoLiveVideo);
            PrepareForCombox();
            CurrentPatient.fup_date = DateTime.Today;
            _ea = ea;
            _ea.GetEvent<UpdateViewNameInTitleEvent>().Publish(Constants.Views.Patient);
            //TestingData();
        }

        private void GoLiveVideo()
        {
            if (StorePatient())
            {
                var navigationParameters = new NavigationParameters();
                navigationParameters.Add(Constants.FromForm, UserControlNames.Patient);
                _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.LiveVideo, navigationParameters);
            }
        }

        private void TestingData()
        {

            //test data
            CurrentPatient.id = 1;
            CurrentPatient.lastname = "testlastname";
            CurrentPatient.firstname = "testfirstname";
            CurrentPatient.birthdate = DateTime.Parse("01/01/2001");
            CurrentPatient.insnr = "123456";
            InsNumber = !string.IsNullOrEmpty(CurrentPatient.insnr) && CurrentPatient.insnr.Length >= 4 ? CurrentPatient.insnr.Substring(0, 4) : CurrentPatient.insnr;
            InsNumber_BD = !string.IsNullOrEmpty(CurrentPatient.insnr) && CurrentPatient.insnr.Length >= 4 ? CurrentPatient.insnr.Substring(4) : string.Empty;
            CurrentPatient.title = "Mr";
            CurrentPatient.insident = "987654321";
            CurrentPatient.sex = "F";
            Gender = (GENDER)Enum.Parse(typeof(GENDER), CurrentPatient.sex);
            CurrentPatient.country = "USA";
            CurrentPatient.address = "1 test st";
            CurrentPatient.city = "sydney";
            CurrentPatient.state = "ns";
            CurrentPatient.zip = "2000";
            CurrentPatient.phone_h = "00000000";
            CurrentPatient.phone_c = "11111111";
            CurrentPatient.phone_w = "22222222";
            CurrentPatient.e_mail = "test@email.com";
            CurrentPatient.ethnicgroup = "White";
            CurrentPatient.eyecolor = "Green";
            CurrentPatient.complexion = "Fair";
            CurrentPatient.haircolor = "Blonde";
            CurrentPatient.barcode = "middle = B";
            CurrentPatient.skincolor = "Olive";
            CurrentPatient.patheight = 61;
            CurrentPatient.fup_date = DateTime.Parse("08/01/2022");
            CurrentPatient.family = "tst fam";
            CurrentPatient.remarks = "test remark";
            CurrentPatient.risk = "2222";
            if (CurrentPatient.risk.Length == 4)
            {
                switch (CurrentPatient.risk.Substring(0, 1))
                {
                    case "0":
                        Total = TOTAL_NEVI_COUNT.UNKNOWN;
                        break;
                    case "1":
                        Total = TOTAL_NEVI_COUNT.LESSTHAN_20;
                        break;
                    case "2":
                        Total = TOTAL_NEVI_COUNT.GREATERTHAN_EQUALTO_20;
                        break;
                }

                switch (CurrentPatient.risk.Substring(1, 1))
                {
                    case "0":
                        Freckle = FRECKLE_INDEX.UNKNOWN;
                        break;
                    case "1":
                        Freckle = FRECKLE_INDEX.NONE;
                        break;
                    case "2":
                        Freckle = FRECKLE_INDEX.SOME;
                        break;
                }

                switch (CurrentPatient.risk.Substring(2, 1))
                {
                    case "0":
                        Atypical = ATYPICAL_NEVI_COUNT.UNKNOWN;
                        break;
                    case "1":
                        Atypical = ATYPICAL_NEVI_COUNT.ATYPICAL_0;
                        break;
                    case "2":
                        Atypical = ATYPICAL_NEVI_COUNT.ATYPICAL_1_TO_2;
                        break;
                    case "3":
                        Atypical = ATYPICAL_NEVI_COUNT.ATYPICAL_GREATERTHAN_3;
                        break;
                }

                switch (CurrentPatient.risk.Substring(3, 1))
                {
                    case "0":
                        Sunburn = EPISODES_OF_SUNBURN.UNKNOWN;
                        break;
                    case "1":
                        Sunburn = EPISODES_OF_SUNBURN.EPISODES_0;
                        break;
                    case "2":
                        Sunburn = EPISODES_OF_SUNBURN.EPISODES_1_TO_2;
                        break;
                    case "3":
                        Sunburn = EPISODES_OF_SUNBURN.EPISODES_GREATERTHAN_3;
                        break;
                }
            }
        }

        private void PrepareForCombox()
        {
            var ethnicgroups = _repository.Ethnicgroups.Get();
            var eyecolors = _repository.EyeColors.Get();
            var complexions = _repository.Complexions.Get();
            var haircolors = _repository.HairColors.Get();
            var skincolors = _repository.SkinColors.Get();
            var countrys = _repository.Countrys.Get();

            Countries = new ObservableCollection<string>();
            foreach (var e in countrys)
            {
                Countries.Add(e.info);
            }

            EthnicGroups = new ObservableCollection<string>();
            foreach (var e in ethnicgroups)
            {
                EthnicGroups.Add(e.info);
            }

            EyeColors = new ObservableCollection<string>();
            foreach (var e in eyecolors)
            {
                EyeColors.Add(e.info);
            }

            Complexions = new ObservableCollection<string>();
            foreach (var e in complexions)
            {
                Complexions.Add(e.info);
            }

            HairColors = new ObservableCollection<string>();
            foreach (var e in haircolors)
            {
                HairColors.Add(e.info);
            }

            SkinColors = new ObservableCollection<string>();
            foreach (var e in skincolors)
            {
                SkinColors.Add(e.info);
            }

            PatientHeight = new ObservableCollection<string>
            {
                "tall = A",
                "middle = B",
                "short = C"
            };

            PatientHeightCM = new ObservableCollection<int>
            {
                60,
                61,
                62,
                63
            };
        }

        private void GoSave()
        {
            _keepLive = false;
            var navigationParameters = new NavigationParameters();
            navigationParameters.Add(Constants.FromForm, UserControlNames.Patient);
            //PatientModle.insnr = InsNumber.Substring(0, 4) + InsNumber_BD;
            //PatientModle.sex = Gender.ToString();
            //PatientModle.risk = ((int)Total).ToString() + ((int)Freckle).ToString() + ((int)Atypical).ToString() + ((int)Sunburn).ToString();
            if (StorePatient())
            {
                GlobalValue.Instance.CurrentPatient = CurrentPatient;
                navigationParameters.Add(Constants.FromForm, UserControlNames.Patient);
                _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.PatientMenu, navigationParameters);
            }
        }

        private bool StorePatient()
        {
            ValidateFields();

            if (!CheckPatExistance())
            {
                AddPatient();

                UpdatePatientFaceImage();
                UpdatePatientTitle();
                return true;
            }
            else
            {
                MessageBox.Show("Patient to store already exists in database!");
                return false;
            }
        }

        private void UpdatePatientTitle()
        {
            string patientInfo = $"{CurrentPatient.firstname}, {CurrentPatient.lastname} [last visit:][Created By:]";
            _ea.GetEvent<UpdatePatientInfoInTitleEvent>().Publish(patientInfo);
        }

        private void UpdatePatientFaceImage()
        {
            if (PatientFaceImage != null)
            {
                if (!Directory.Exists(_appSettings.ImagePath))
                    Directory.CreateDirectory(_appSettings.ImagePath);
                CurrentPatient.image_path = Path.Combine(_appSettings.ImagePath, CurrentPatient.id + ".jpg");
                ImageHelpers.SaveBitmapSourceToFile(PatientFaceImage, CurrentPatient.image_path);
                CurrentPatient = _repository.Patients.Upsert(CurrentPatient);
            }
        }

        private void AddPatient()
        {
            DateTime currentTime = DateTime.Now;
            var timestamp = _repository.Timestamps.Upsert(new Timestamp {date_created = currentTime, date_last_accessed = currentTime, pcname = Environment.MachineName });
            CurrentPatient.tsId = timestamp.id;
            CurrentPatient.userId = GlobalValue.Instance.UserID;
            CurrentPatient = _repository.Patients.Upsert(CurrentPatient);
        }

        private bool CheckPatExistance()
        {
            var patient = _dbPatients.OrderBy(pa => pa.lastname).ThenBy(pa => pa.firstname).ThenBy(pa => pa.birthdate).ThenBy(pa => pa.insnr)
                    .FirstOrDefault(pa => pa.lastname == CurrentPatient.lastname && pa.firstname == CurrentPatient.firstname
                    && pa.insnr == CurrentPatient.insnr && pa.birthdate == CurrentPatient.birthdate);
            if (patient == null)
                return false;
            else
                return true;
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

        private void GoSelection(object sender)
        {
            _keepLive = false;
            var navigationParameters = new NavigationParameters();
            navigationParameters.Add(Constants.FromForm, UserControlNames.Patient);

            switch (((System.Windows.Controls.ComboBoxItem)sender).Name)
            {
                case Constants.FaceImageLiveVideo:
                    navigationParameters.Add(Constants.FromControl, Constants.FaceImageLiveVideo);
                    _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.LiveVideo, navigationParameters);
                    break;
                case Constants.ImportSourceLiveVideo:
                    if (StorePatient())
                    {
                        GlobalValue.Instance.CurrentPatient = CurrentPatient;
                        navigationParameters.Add(Constants.FromControl, Constants.ImportSourceLiveVideo);
                        _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.LiveVideo, navigationParameters);
                    }
                    break;
                case Constants.FaceImageFileImport:
                    navigationParameters.Add(Constants.FromControl, Constants.FaceImageFileImport);
                    _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.ImageImport, navigationParameters);
                    break;
                case Constants.ImportSourceFileImport:
                    if (StorePatient())
                    {
                        GlobalValue.Instance.CurrentPatient = CurrentPatient;
                        navigationParameters.Add(Constants.FromControl, Constants.ImportSourceFileImport);
                        _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.ImageImport, navigationParameters);
                    }
                    break;
            }
        }

        private void GoBack()
        {
            _keepLive = false;
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
