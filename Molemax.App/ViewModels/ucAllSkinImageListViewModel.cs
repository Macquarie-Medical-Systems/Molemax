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
    public class ucAllSkinImageListViewModel : BindableBase, IRegionMemberLifetime, INavigationAware
    {
        public ObservableCollection<DiseaseItem> _selectedDiseases;
        public ObservableCollection<DiseaseItem> SelectedDiseases
        {
            get { return _selectedDiseases; }
            set { SetProperty(ref _selectedDiseases, value); }
        }

        public bool KeepAlive => true;

        public ucAllSkinImageListViewModel()
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
                SelectedDiseases = ((DiseaseItemEventArgs)navigationContext.Parameters[Constants.ParaObject]).DiseaseList;
            }
        }
    }

}
