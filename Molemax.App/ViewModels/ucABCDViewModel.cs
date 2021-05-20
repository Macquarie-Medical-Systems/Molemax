using Microsoft.EntityFrameworkCore;
using Molemax.App.Core;
using Molemax.App.Core.MouseCapture;
using Molemax.Models;
using Molemax.Repository;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
//using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Molemax.App.ViewModels
{
    public class ucABCDViewModel : BindableBase, IRegionMemberLifetime, INavigationAware
    {
        private IRegionManager _regionManager;
        private IMolemaxRepository _repository;
        private IAppSettings _applicationSetting;
        private string fromForm;

        #region Property
        private BitmapSource _ABCDImage;
        public BitmapSource ABCDImage
        {
            get { return _ABCDImage; }
            set { SetProperty(ref _ABCDImage, value); }
        }

        private Visibility _panel1Visibility;
        public Visibility Panel1Visibility
        {
            get { return _panel1Visibility; }
            set { SetProperty(ref _panel1Visibility, value); }
        }

        private Visibility _panel2Visibility;
        public Visibility Panel2Visibility
        {
            get { return _panel2Visibility; }
            set { SetProperty(ref _panel2Visibility, value); }
        }

        private Visibility _panel3Visibility;
        public Visibility Panel3Visibility
        {
            get { return _panel3Visibility; }
            set { SetProperty(ref _panel3Visibility, value); }
        }

        private Visibility _panel4Visibility;
        public Visibility Panel4Visibility
        {
            get { return _panel4Visibility; }
            set { SetProperty(ref _panel4Visibility, value); }
        }

        private Visibility _panelResultVisibility;
        public Visibility PanelResultVisibility
        {
            get { return _panelResultVisibility; }
            set { SetProperty(ref _panelResultVisibility, value); }
        }


        private Visibility _panelDiagnosisVisibility;
        public Visibility PanelDiagnosisVisibility
        {
            get { return _panelDiagnosisVisibility; }
            set { SetProperty(ref _panelDiagnosisVisibility, value); }
        }

        private Visibility _panelResultImageVisibility;
        public Visibility PanelResultImageVisibility
        {
            get { return _panelResultImageVisibility; }
            set { SetProperty(ref _panelResultImageVisibility, value); }
        }

        private Visibility _resultImageVisibility;
        public Visibility ResultImageVisibility
        {
            get { return _resultImageVisibility; }
            set { SetProperty(ref _resultImageVisibility, value); }
        }

        private Visibility _resultInformationVisibility;
        public Visibility ResultInformationVisibility
        {
            get { return _resultInformationVisibility; }
            set { SetProperty(ref _resultInformationVisibility, value); }
        }
        #endregion

        #region Command
        public DelegateCommand GoManualCommand { get; set; }
        public DelegateCommand GoABCDCommand { get; set; }
        public DelegateCommand GoCancelCommand { get; set; }
        public DelegateCommand<object> SelectAsymmetryGroupCommand { get; set; }
        public DelegateCommand<object> SelectPatternGroupCommand { get; set; }
        public DelegateCommand<object> SelectColorGroupCommand { get; set; }
        public DelegateCommand<object> SelectStructuralGroupCommand { get; set; }
        #endregion

        public bool KeepAlive => false;

        public ucABCDViewModel(IRegionManager regionManager, IMolemaxRepository molemaxRepository, IAppSettings applicationSetting)
        {
            _regionManager = regionManager;
            _repository = molemaxRepository;
            _applicationSetting = applicationSetting;
            GoManualCommand = new DelegateCommand(GoManual);
            GoABCDCommand = new DelegateCommand(GoABCD);
            GoCancelCommand = new DelegateCommand(GoCancel);
            SelectAsymmetryGroupCommand = new DelegateCommand<object>(SelectAsymmetryGroup);
            SelectPatternGroupCommand = new DelegateCommand<object>(SelectPatternGroup);
            SelectColorGroupCommand = new DelegateCommand<object>(SelectColorGroup);
            SelectStructuralGroupCommand = new DelegateCommand<object>(SelectStructuralGroup);

            Panel1Visibility = Visibility.Collapsed;
            Panel2Visibility = Visibility.Collapsed;
            Panel3Visibility = Visibility.Collapsed;
            Panel4Visibility = Visibility.Visible;

            PanelResultVisibility = Visibility.Collapsed;

            PanelDiagnosisVisibility = Visibility.Visible;

            PanelResultImageVisibility = Visibility.Collapsed;
            ResultImageVisibility = Visibility.Collapsed;
            ResultInformationVisibility = Visibility.Visible;

        }

        private void SelectStructuralGroup(object obj)
        {
            string sSelectedIndex = (string)obj;
        }

        private void SelectColorGroup(object obj)
        {
            string sSelectedIndex = (string)obj;
        }

        private void SelectPatternGroup(object obj)
        {
            string sSelectedIndex = (string)obj;
        }

        private void SelectAsymmetryGroup(object obj)
        {
            string sSelectedIndex = (string)obj;
        }

        private void GoABCD()
        {
            throw new NotImplementedException();
        }

        private void GoManual()
        {
            //var navigationParameters = new NavigationParameters();
            //navigationParameters.Add(Constants.FromForm, UserControlNames.Segmentation);
            //navigationParameters.Add(Constants.ParaImage, SegmentationImage);
            //_regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.FullPic_Segmentation, navigationParameters);

        }

        private void GoCancel()
        {
            var navigationParameters = new NavigationParameters();
            _regionManager.RequestNavigate(RegionNames.ContentRegion, fromForm, navigationParameters);

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
            if (navigationContext.Parameters[Constants.ParaImage] != null)
                ABCDImage = (BitmapSource)navigationContext.Parameters[Constants.ParaImage];

            if (navigationContext.Parameters[Constants.FromForm] != null)
                fromForm = (string)navigationContext.Parameters[Constants.FromForm];


        }

    }

}
