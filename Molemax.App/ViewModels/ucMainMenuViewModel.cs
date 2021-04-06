using Molemax.App.Core;
using Molemax.App.Views;
using Molemax.Models;
using Molemax.Repository;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Molemax.App.ViewModels
{
    public class ucMainMenuViewModel : BindableBase, IRegionMemberLifetime
    {
        private IEventAggregator _ea;
        private int userId;
        private IRegionManager _regionManager;
        private IMolemaxRepository _repository;

        public DelegateCommand NewPatientCommand { get; set; }
        public DelegateCommand ExpressSessionCommand { get; set; }
        public DelegateCommand AdministrationCommand { get; set; }
        public DelegateCommand GoPatientSearchCommand { get; set; }
        public DelegateCommand GoServicesCommand { get; set; }
        public bool KeepAlive => false;

        public ucMainMenuViewModel(IRegionManager regionManager, IMolemaxRepository molemaxRepository, IEventAggregator ea)
        {
            _regionManager = regionManager;
            _repository = molemaxRepository;
            NewPatientCommand = new DelegateCommand(GoNewPatient);
            ExpressSessionCommand = new DelegateCommand(GoExpressSession);
            AdministrationCommand = new DelegateCommand(GoAdministrationMainMenu);
            GoPatientSearchCommand = new DelegateCommand(GoPatientSearch);
            GoServicesCommand = new DelegateCommand(GoServices);

            //testing code
            MessageBox.Show("Is user Admin?");
            GlobalValue.Instance.UserID = 1;

            GlobalValue.Instance.IsNewPatient = false;

            if (IsDiagSourceEmpty())
                CopyDiagList();

            _ea = ea;
            _ea.GetEvent<UpdateViewNameInTitleEvent>().Publish(Constants.Views.MainMenu);
            _ea.GetEvent<UpdatePatientInfoInTitleEvent>().Publish(Constants.DefaultPatient);

            //CleanUnlocalizedImages();
        }

        private void GoServices()
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.Selection_Dummy);
        }

        private void CopyDiagList()
        {
            List<DEFDiagnoses> defDiagnoses = _repository.DEFDiagnoses.Get().ToList();
            List<Diagsource> diagsources = defDiagnoses.Select(d => new Diagsource { origin_id = d.origin_id, shortname = d.shortname, fullname = d.fullname, risk = d.risk, favorite = d.favorite, category = d.category, parent_id = d.parent_id }).ToList();
            foreach (Diagsource diagsource in diagsources )
            {
                _repository.Diagsources.Upsert(diagsource);
            }
        }

        private bool IsDiagSourceEmpty()
        {
            try
            {
                return _repository.Diagsources.Get().Count() == 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }

        private void GoAdministrationMainMenu()
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.Administration);
        }

        private void GoExpressSession()
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.ExpressSession);
            //_regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.PatientExpress);
        }

        private void GoNewPatient()
        {
            GlobalValue.Instance.IsNewPatient = true;
            _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.Patient);
        }

        private void GoPatientSearch()
        {
            GlobalValue.Instance.IsNewPatient = false;
            _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.PatientSearch);
        }
    }
}
