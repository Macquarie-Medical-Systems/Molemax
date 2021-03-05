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
    public class ucAllSkinDiseaseDetailViewModel : BindableBase, IRegionMemberLifetime, INavigationAware
    {
        public BitmapImage _diseaseImage;
        public BitmapImage DiseaseImage
        {
            get { return _diseaseImage; }
            set { SetProperty(ref _diseaseImage, value); }
        }

        public string _description;
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        public string _category;
        public string Category
        {
            get { return _category; }
            set { SetProperty(ref _category, value); }
        }

        public bool KeepAlive => true;

        public ucAllSkinDiseaseDetailViewModel()
        {

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
            if (navigationContext.Parameters[Constants.ParaObject] != null)
            {
                var type = ((DiseaseItemEventArgs)navigationContext.Parameters[Constants.ParaObject]).DiseaseType;
                ObservableCollection<DiseaseItem> _selectedDisease = ((DiseaseItemEventArgs)navigationContext.Parameters[Constants.ParaObject]).DiseaseList;
                DiseaseImage = _selectedDisease[0].DiseaseImage;
                Category = _selectedDisease[0].Category;
                Description = _selectedDisease[0].Description;
            }
        }
    }

}
