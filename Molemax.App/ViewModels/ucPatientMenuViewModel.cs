using Molemax.App.Core;
using Molemax.Models;
using Molemax.Repository;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Molemax.App.ViewModels
{
    public class ucPatientMenuViewModel: BindableBase, IRegionMemberLifetime, INavigationAware
    {
        private IRegionManager _regionManager;
        private IDialogService _dialogService;
        private IAppSettings _applicationSetting;
        private string fromForm;
        private string Title;
        private IMolemaxRepository _repository;
        private List<string> _removedImageList;
        private IEnumerable<ExpressImage> _dbExpressImages
        {
            get { return _repository.ExpressImages.Get(); }
        }

        public DelegateCommand GoBackCommand { get; set; }
        public DelegateCommand<object> GoSelectionCommand { get; set; }
        public DelegateCommand GoFollowUpCommand { get; set; }
        public DelegateCommand GoReportCommand { get; set; }
        public DelegateCommand GoExpressSessionImagesCommand { get; set; }
        public bool KeepAlive => false;

        #region property
        private Visibility _expressSessionButtonVisibility;
        public Visibility ExpressSessionButtonVisibility
        {
            get { return _expressSessionButtonVisibility; }
            set { SetProperty(ref _expressSessionButtonVisibility, value); }
        }
        #endregion
        
        public ucPatientMenuViewModel(IRegionManager regionManager, IDialogService dialogService, IMolemaxRepository molemaxRepository, IAppSettings applicationSetting)
        {
            _regionManager = regionManager;
            _dialogService = dialogService;
            _repository = molemaxRepository;
            _applicationSetting = applicationSetting;
            _applicationSetting.LoadSettings();

            GoBackCommand = new DelegateCommand(GoBack);
            GoSelectionCommand = new DelegateCommand<object>(GoSelection);
            GoFollowUpCommand = new DelegateCommand(GoFollowUp);
            GoReportCommand = new DelegateCommand(GoReport);
            GoExpressSessionImagesCommand = new DelegateCommand(GoExpressSessionImages);

            if (CheckIfExpressSessionImagesExist())
                ExpressSessionButtonVisibility = Visibility.Visible;
            else
                ExpressSessionButtonVisibility = Visibility.Collapsed;
        }

        private bool CheckIfExpressSessionImagesExist()
        {
            return _dbExpressImages.Where(i => i.patientId == GlobalValue.Instance.CurrentPatient.id).Count() > 0;
               
        }

        private void GoExpressSessionImages()
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.StiWia);
        }

        private void GoReport()
        {
            var navigationParameters = new NavigationParameters();
            navigationParameters.Add(Constants.FromForm, UserControlNames.PatientMenu);
            _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.PMSSelect, navigationParameters);
            //_regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.PrintSelection, navigationParameters);

            //var message = "This is a message that should be shown in the dialog .";

            ////using the dialog service as-is
            //_dialogService.ShowDialog("ucPMSSelect", new DialogParameters($"message={message}"), r =>
            //{
            //    if (r.Result == ButtonResult.None)
            //        Title = "Result is None";
            //    else if (r.Result == ButtonResult.OK)
            //        Title = "Result is OK";
            //    else if (r.Result == ButtonResult.Cancel)
            //        Title = "Result is Cancel";
            //    else
            //        Title = "I Don't know what you did!?";
            //});

        }

        private void GoFollowUp()
        {
            var navigationParameters = new NavigationParameters();
            navigationParameters.Add(Constants.FromForm, UserControlNames.PatientMenu);
            _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.Selection, navigationParameters);
        }

        private void GoSelection(object sender)
        {
            var navigationParameters = new NavigationParameters();
            navigationParameters.Add(Constants.FromForm, UserControlNames.PatientMenu);

            switch (((System.Windows.Controls.ComboBoxItem)sender).Name)
            {
                case Constants.ImportSourceLiveVideo:
                    _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.LiveVideo, navigationParameters);
                    break;
                case Constants.ImportSourceFileImport:
                    _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.ImageImport, navigationParameters);
                    break;
            }
        }

        private void GoBack()
        {
            if (GlobalValue.Instance.IsNewPatient)
                _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.MainMenu);
            else
                _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.PatientSearch);
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext.Parameters[Constants.FromForm] != null)
                fromForm = (string)navigationContext.Parameters[Constants.FromForm];

            if (navigationContext.Parameters[Constants.ParaImageList] != null)
            {
                _removedImageList = (List<string>)navigationContext.Parameters[Constants.ParaImageList];
            }
        }

        private string GetFullPathForImage(string name)
        {
            return _applicationSetting.UnlocalizedImages + "\\" + name;
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
