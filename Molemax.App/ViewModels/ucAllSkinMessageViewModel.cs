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
    public class ucAllSkinMessageViewModel : BindableBase, IRegionMemberLifetime, INavigationAware
    {
        public string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public bool KeepAlive => true;

        public ucAllSkinMessageViewModel()
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
                Message = (string)navigationContext.Parameters[Constants.ParaObject];
            }
        }
    }

}
