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
    public class ucAllSkinViewModel : BindableBase, IRegionMemberLifetime
    {
        private IRegionManager _regionManager;
        private IMolemaxRepository _repository;
        private IAppSettings _applicationSetting;
        private IEnumerable<DEFAllSkin> _dbAllSkins
        {
            get { return _repository.DEFAllSkins.Get(); }
        }

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
            NavigationParameters nav = new NavigationParameters();
            var type = e.DiseaseType;
            foreach (var i in e.DiseaseList)
            {
                i.DiseaseImage = new BitmapImage(new Uri($"pack://application:,,,/Images/AllSkin/{i.ImageId}"));
            }

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

}
