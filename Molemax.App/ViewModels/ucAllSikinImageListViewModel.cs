using Molemax.App.Core;
using Molemax.App.Core.TreeViewDiseaseExplorer;
using Molemax.App.Core.TreeViewDiseaseExplorer.Enums;
using Molemax.Models;
using Molemax.Repository;
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
    public class ucAllSikinImageListViewModel : BindableBase, IRegionMemberLifetime
    {
        private IRegionManager _regionManager;
        private IMolemaxRepository _repository;
        private IAppSettings _applicationSetting;
        private IEnumerable<DEFAllSkin> _dbAllSkins
        {
            get { return _repository.DEFAllSkins.Get(); }
        }

        public ObservableCollection<DiseaseItem> _selectedDisease;
        public ObservableCollection<DiseaseItem> SelectedDiseases
        {
            get { return _selectedDisease; }
            set { SetProperty(ref _selectedDisease, value); }
        }

        public ObservableCollection<DiseaseItemViewModel> _items;
        public ObservableCollection<DiseaseItemViewModel> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }
        public bool KeepAlive => true;

        public ucAllSikinImageListViewModel(IRegionManager regionManager, IMolemaxRepository molemaxRepository, IAppSettings applicationSetting)
        {
            _regionManager = regionManager;
            _repository = molemaxRepository;
            _applicationSetting = applicationSetting;

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

        public void UpdateImagePathFromSelected(object sender, DiseaseItemEventArgs e)
        {
            var type = e.DiseaseType;
            SelectedDiseases = e.DiseaseList;
            foreach (var i in SelectedDiseases)
            {
                i.DiseaseImage = new BitmapImage(new Uri($"pack://application:,,,/Images/AllSkin/{i.ImageId}"));
            }

            _regionManager.RequestNavigate(RegionNames.AllSkinContentRegion, UserControlNames.AllSikinImageList);
        }
    }

}
