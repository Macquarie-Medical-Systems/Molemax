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
        private IEnumerable<ExpertizerABCD> _dbExpertizerABCDs
        {
            get { return _repository.ExpertizerABCDs.Get(); }
        }

        private string fromForm;
        private string sABCDImageID;
        private const int PART_A = 1;
        private const int PART_B = 2;
        private const int PART_C = 3;
        private const int PART_D = 4;
        private List<ExpertizerABCD> tABCD_A;
        private List<ExpertizerABCD> tABCD_B;
        private List<ExpertizerABCD> tABCD_C;
        private List<ExpertizerABCD> tABCD_D;


        #region Property
        private BitmapSource _ABCDImage;
        public BitmapSource ABCDImage
        {
            get { return _ABCDImage; }
            set { SetProperty(ref _ABCDImage, value); }
        }

        private BitmapSource _diagnosisImage;
        public BitmapSource DiagnosisImage
        {
            get { return _diagnosisImage; }
            set { SetProperty(ref _diagnosisImage, value); }
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
            _applicationSetting.LoadSettings();
            GoManualCommand = new DelegateCommand(GoManual);
            GoABCDCommand = new DelegateCommand(GoABCD);
            GoCancelCommand = new DelegateCommand(GoCancel);
            SelectAsymmetryGroupCommand = new DelegateCommand<object>(SelectAsymmetryGroup);
            SelectPatternGroupCommand = new DelegateCommand<object>(SelectPatternGroup);
            SelectColorGroupCommand = new DelegateCommand<object>(SelectColorGroup);
            SelectStructuralGroupCommand = new DelegateCommand<object>(SelectStructuralGroup);

            //initialize components visibility
            IniPanelVisibility();

            LoadABCDTables();

            sABCDImageID = FindABCD(PART_A);

            LoadABCDImage(sABCDImageID);

        }

        private void LoadABCDImage(string sABCDImageID)
        {
            DiagnosisImage = new BitmapImage(new Uri($"pack://application:,,,/Images/Expertizer/{sABCDImageID}"));
        }

        private string FindABCD(int ABCDPart, int A_Val = -1, int B_Val = -1, int C_Val = -1, int D_Val = -1)
        {
            string sImageID = string.Empty;
            switch (ABCDPart)
            {
                case 1:
                    sImageID = SearchABCD(ABCDPart, tABCD_A, A_Val, B_Val, C_Val, D_Val);
                    break;
                case 2:
                    sImageID = SearchABCD(ABCDPart, tABCD_B, A_Val, B_Val, C_Val, D_Val);
                    break;
                case 3:
                    sImageID = SearchABCD(ABCDPart, tABCD_C, A_Val, B_Val, C_Val, D_Val);
                    break;
                case 4:
                    sImageID = SearchABCD(ABCDPart, tABCD_D, A_Val, B_Val, C_Val, D_Val);
                    break;
            }
            return sImageID;
        }

        private string SearchABCD(int ABCDPart, List<ExpertizerABCD> searchArray, int ValA, int ValB, int ValC, int ValD)
        {
            double dblH;
            double[] dblWeightList = new double[searchArray.Count];
            ExpertizerABCD[] m_tABCD = new ExpertizerABCD[searchArray.Count];
            searchArray.CopyTo(m_tABCD);

            for (int i = 0; i < searchArray.Count; i++)
            {
                string sCVal = searchArray[i].C_Score.ToString();
                string sDVal = searchArray[i].D_Score.ToString();
                //calculating A weight
                if (ValA != -1)
                {
                    if (ValA == searchArray[i].A_Score)
                    {
                        if (ABCDPart == PART_A)
                            dblWeightList[i] = dblWeightList[i] + 100;
                        else
                            dblWeightList[i] = dblWeightList[i] + 10;
                    }
                }
                //calculating B weight
                if (ValB != -1)
                {
                    if (ValB <= searchArray[i].B_Score + 2 && ValB >= searchArray[i].B_Score - 2)
                    {
                        if (ABCDPart == PART_B)
                        {
                            switch (Math.Abs(searchArray[i].B_Score.Value - ValB))
                            {
                                case 0:
                                    dblWeightList[i] = dblWeightList[i] + 100;
                                    break;
                                case 1:
                                    dblWeightList[i] = dblWeightList[i] + 50;
                                    break;
                                case 2:
                                    dblWeightList[i] = dblWeightList[i] + 25;
                                    break;
                            }
                        }
                        else
                        {
                            switch (Math.Abs(searchArray[i].B_Score.Value - ValB))
                            {
                                case 0:
                                    dblWeightList[i] = dblWeightList[i] + 5;
                                    break;
                                case 1:
                                    dblWeightList[i] = dblWeightList[i] + 2.5;
                                    break;
                                case 2:
                                    dblWeightList[i] = dblWeightList[i] + 1.25;
                                    break;
                            }
                        }
                    }
                }
                //calculating C weight
                if (ValC != -1)
                {
                    if (CountSet(ValC) >0)
                    {
                        for (int j=0; j< ValC.ToString().Length; j++)
                        {
                            if (ValC.ToString().Substring(j,1) == "1")
                            {
                                if (sCVal.Substring(j,1) == "1")
                                {
                                    if (ABCDPart == PART_C)
                                    {
                                        dblWeightList[i] = dblWeightList[i] + 100/ CountSet(ValC);
                                    }
                                    else
                                    {
                                        dblWeightList[i] = dblWeightList[i] + 6 / CountSet(ValC);
                                    }
                                }

                            }
                        }
                    }
                }
                //calculating D weight
                if (ValD != -1)
                {
                    if (CountSet(ValD) > 0)
                    {
                        for (int j = 0; j < ValD.ToString().Length; j++)
                        {
                            if (ValD.ToString().Substring(j, 1) == "1")
                            {
                                if (sDVal.Substring(j, 1) == "1")
                                {
                                    if (ABCDPart == PART_D)
                                    {
                                        dblWeightList[i] = dblWeightList[i] + 100 / CountSet(ValD);
                                    }
                                    else
                                    {
                                        dblWeightList[i] = dblWeightList[i] + 6 / CountSet(ValD);
                                    }
                                }

                            }
                        }
                    }
                }
            }

            for (int i = 0; i < dblWeightList.Length; i++)
            {
                for (int j=i+1; j<dblWeightList.Length; j++)
                {
                    if (dblWeightList[j] > dblWeightList[i])
                    {
                        dblH = dblWeightList[i];
                        m_tABCD[i] = searchArray[j];
                        dblWeightList[i] = dblWeightList[j];
                        dblWeightList[j] = dblH;
                    }
                }
            }

            return m_tABCD[0].ImageID;
        }

        /// <summary>
        /// Count '1'
        /// </summary>
        /// <param name="iValue"></param>
        /// <returns></returns>
        private int CountSet(int iValue)
        {
            return iValue.ToString().Remove('9').Length;
        }

        private void LoadABCDTables()
        {
            tABCD_A = _dbExpertizerABCDs.OrderBy(i => i.A_Score).ThenBy(i => i.B_Score).ThenByDescending(i => i.C_Score).ThenByDescending(i => i.D_Score).ToList();
            tABCD_B = _dbExpertizerABCDs.OrderBy(i => i.B_Score).ThenBy(i => i.A_Score).ThenByDescending(i => i.C_Score).ThenByDescending(i => i.D_Score).ToList();
            tABCD_C = _dbExpertizerABCDs.OrderByDescending(i => i.C_Score).ThenBy(i => i.A_Score).ThenBy(i => i.B_Score).ThenByDescending(i => i.D_Score).ToList();
            tABCD_D = _dbExpertizerABCDs.OrderByDescending(i => i.D_Score).ThenBy(i => i.A_Score).ThenBy(i => i.B_Score).ThenByDescending(i => i.C_Score).ToList();
        }

        private void IniPanelVisibility()
        {
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
