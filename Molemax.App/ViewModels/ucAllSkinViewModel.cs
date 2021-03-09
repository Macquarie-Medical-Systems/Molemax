using Molemax.App.Core;
using Molemax.App.Core.TreeViewDiseaseExplorer;
using Molemax.App.Core.TreeViewDiseaseExplorer.Enums;
using Molemax.Models;
using Molemax.Repository;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Molemax.App.ViewModels
{
    public class ucAllSkinViewModel : BindableBase, IRegionMemberLifetime, INavigationAware
    {
        private IRegionManager _regionManager;
        private IMolemaxRepository _repository;
        private IAppSettings _applicationSetting;
        private string fromForm;
        private string selectedDiseaseName;
        private IEnumerable<DEFAllSkin> _dbAllSkins
        {
            get { return _repository.DEFAllSkins.Get(); }
        }

        #region command
        public DelegateCommand GoExitCommand { get; set; }
        public DelegateCommand GoSelectAndExitCommand { get; set; }
        public DelegateCommand GoFindCommand { get; set; }
        #endregion

        public ObservableCollection<DiseaseItemViewModel> _items;
        public ObservableCollection<DiseaseItemViewModel> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }
        public bool KeepAlive => true;

        public ucAllSkinViewModel(IRegionManager regionManager, IMolemaxRepository molemaxRepository, IAppSettings applicationSetting)
        {
            _regionManager = regionManager;
            _repository = molemaxRepository;
            _applicationSetting = applicationSetting;

            GoExitCommand = new DelegateCommand(GoExit);
            GoSelectAndExitCommand = new DelegateCommand(GoSelectAndExit);
            GoFindCommand = new DelegateCommand(GoFind);

            DiseaseStructure.molemaxRepository = molemaxRepository;
            var children = DiseaseStructure.GetFirstLevelCategories();

            Items = new ObservableCollection<DiseaseItemViewModel>(children.Select(i =>
            {
                var dateItemVM = new DiseaseItemViewModel(i.DiseaseName,i.CategoryOrImageId, i.Type);
                dateItemVM.UpdateImagePath += UpdateImagePathFromSelected;
                return dateItemVM;
            }
            ));
        }

        private void GoFind()
        {
            throw new NotImplementedException();
        }

        private void GoSelectAndExit()
        {
            var navigationParameters = new NavigationParameters();
            navigationParameters.Add(Constants.FromForm, UserControlNames.Localization);
            navigationParameters.Add(Constants.ParaDiseaseName, selectedDiseaseName);

            _regionManager.RequestNavigate(RegionNames.ContentRegion, fromForm, navigationParameters);

        }

        private void GoExit()
        {
            var navigationParameters = new NavigationParameters();
            navigationParameters.Add(Constants.FromForm, UserControlNames.Localization);

            _regionManager.RequestNavigate(RegionNames.ContentRegion, fromForm, navigationParameters);
        }

        public void UpdateImagePathFromSelected(object sender, DiseaseItemEventArgs e)
        {
            NavigationParameters nav = new NavigationParameters();
            var type = e.DiseaseType;
            selectedDiseaseName = e.DiseaseName;
            foreach (var i in e.DiseaseList)
            {
                i.DiseaseImage = new BitmapImage(new Uri($"pack://application:,,,/Images/AllSkin/{i.ImageId}"));
            }


            if (e.DiseaseList.Count == 0)
            {
                string sMessage;
                if (e.DiseaseType == DataType.Pending)
                    sMessage = "Diagnosis pending. There is no preview image.";
                else
                    sMessage = "Please select category, subcategory or image on the left side.";

                nav.Add(Constants.ParaObject, sMessage);
                _regionManager.RequestNavigate(RegionNames.AllSkinContentRegion, UserControlNames.AllSkinMessage, nav);
            }
            else
            {
                nav.Add(Constants.ParaObject, e);

                if (type == DataType.Disease)
                {
                    _regionManager.RequestNavigate(RegionNames.AllSkinContentRegion, UserControlNames.AllSkinDiseaseDetail, nav);
                }
                else
                {
                    _regionManager.RequestNavigate(RegionNames.AllSkinContentRegion, UserControlNames.AllSkinImageList, nav);
                }
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext.Parameters[Constants.FromForm] != null)
                fromForm = (string)navigationContext.Parameters[Constants.FromForm];
        }
    }

}
