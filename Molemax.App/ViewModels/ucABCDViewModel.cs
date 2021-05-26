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
        private ExpertizerABCD[] m_tABCD;
        private LanguageLibrary langLib;


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

        private string _diagnosisName;
        public string DiagnosisName
        {
            get { return _diagnosisName; }
            set { SetProperty(ref _diagnosisName, value); }
        }
        

        private string _imageDescription;
        public string ImageDescription
        {
            get { return _imageDescription; }
            set { SetProperty(ref _imageDescription, value); }
        }

        private string _ABCDScore;
        public string ABCDScore
        {
            get { return _ABCDScore; }
            set { SetProperty(ref _ABCDScore, value); }
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
        public DelegateCommand GoCancelCommand { get; set; }
        public DelegateCommand<object> SelectAsymmetryGroupCommand { get; set; }
        public DelegateCommand<object> SelectPatternGroupCommand { get; set; }
        public DelegateCommand<object> SelectColorGroupCommand { get; set; }
        public DelegateCommand<object> SelectStructuralGroupCommand { get; set; }
        #endregion

        public bool KeepAlive => false;

        public ucABCDViewModel(IRegionManager regionManager, IMolemaxRepository molemaxRepository, IAppSettings applicationSetting)
        {
            int iA = 0;
            int iB = 0;
            int iC = 0;
            int iD = 0;
            int iDiag = 0;
            langLib = new LanguageLibrary(@".\LanguageDLLS\language module (english).dll");

            _regionManager = regionManager;
            _repository = molemaxRepository;
            _applicationSetting = applicationSetting;
            _applicationSetting.LoadSettings();
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

            WeightListItemABCD(0, ref iA, ref iB, ref iC, ref iD, ref iDiag);

            string[] result = CreateImageDescription(iA, iB, iC, iD);
            ABCDScore = result[0];
            ImageDescription = result[1];

            DiagnosisName = CreateImageDescriptionShort(iDiag);

        }

        private string CreateImageDescriptionShort(int iDiag)
        {
            string strDiag = null;
            switch (iDiag)
            {
                case 41500:
                    strDiag = GetString(2081);
                    break;
                case 41501:
                    strDiag = GetString(2082);
                    break;
                case 41502:
                    strDiag = GetString(2083);
                    break;
                case 41503:
                    strDiag = GetString(2084);
                    break;
            }
            return strDiag;
        }

        private string GetString(uint uiStringID)
        {
            return langLib.GetString(uiStringID);
        }
        private string[] CreateImageDescription(int intA, int intB, int intC, int intD)
        {
            string score;
            string[] strC = new string[6];
            string[] strD = new string[5];
            string strBase = GetString(2051);
            string strA0 = GetString(2052);
            string strA1 = GetString(2053);
            string strA2 = GetString(2054);
            string strB0 = GetString(2055);
            string strB1 = GetString(2056);
            string strB2 = GetString(2057);
            string strB3 = GetString(2058);
            string strB4 = GetString(2059);
            string strB5 = GetString(2060);
            string strB6 = GetString(2061);
            string strB7 = GetString(2062);
            string strB8 = GetString(2063);
            string strCBase = GetString(2064);
            strC[0] = GetString(2065);
            strC[1] = GetString(2066);
            strC[2] = GetString(2067);
            strC[3] = GetString(2068);
            strC[4] = GetString(2069);
            strC[5] = GetString(2070);
            string strDBase = GetString(2071);
            strD[0] = GetString(2072);
            strD[1] = GetString(2073);
            strD[2] = GetString(2074);
            strD[3] = GetString(2075);
            strD[4] = GetString(2076);

            //    'construct description
            string strDescription = strBase;

            //    'A
            switch (intA)
            {
                case 0:
                    strDescription = strDescription + " " + strA0;
                    break;
                case 1:
                    strDescription = strDescription + " " + strA1;
                    break;
                case 2:
                    strDescription = strDescription + " " + strA2;
                    break;
            }

            //    'B
            switch (intB)
            {
                case 0:
                        strDescription = strDescription + " " + strB0;
                    break;
                case 1:
                        strDescription = strDescription + " " + strB1;
                    break;
                case 2:
                        strDescription = strDescription + " " + strB2;
                    break;
                case 3:
                        strDescription = strDescription + " " + strB3;
                    break;
                case 4:
                        strDescription = strDescription + " " + strB4;
                    break;
                case 5:
                        strDescription = strDescription + " " + strB5;
                    break;
                case 6:
                        strDescription = strDescription + " " + strB6;
                    break;
                case 7:
                        strDescription = strDescription + " " + strB7;
                    break;
                case 8:
                        strDescription = strDescription + " " + strB8;
                    break;
            }

            //    'C

            strDescription = strDescription + " " + strCBase;
            int j = 0;
            j = CountSet(intC);


            int k = j;
            int l = j;
            bool bExit = false;
            for (int i = 0; i < intC.ToString().Length; i++)
            {
                if (intC.ToString().Substring(i, 1) == "1")
                {
                    switch (k)
                    {
                        case 1:
                            if (j == 1)
                                strDescription = strDescription + " " + strC[i - 1] + " " + GetString(2077);
                            else
                                strDescription = strDescription + " " + GetString(2078) + " " + strC[i - 1] + " " + GetString(2079);
                            bExit = true;
                            break;
                        default:
                            if (k == j)
                                strDescription = strDescription + " " + strC[i - 1];
                            else
                                strDescription = strDescription + ", " + strC[i - 1];
                            k -= 1;
                            break;
                    }
                }

                if (bExit)
                    break;
            }

            //    'D
            strDescription = strDescription + " " + strDBase;
            j = CountSet(intD);
            k = j;
            bExit = false;
            for (int i=0; i< intD.ToString().Length; i++)
            {
                if (intD.ToString().Substring(i, 1) == "1")
                {
                    switch (k)
                    {
                        case 1:
                            if (j == 1)
                                strDescription = strDescription + " " + strD[i - 1] + ".";
                            else
                                strDescription = strDescription + " " + GetString(2080) + " " + strD[i - 1] + ".";
                            bExit = true;
                            break;
                        default:
                            if (k == j)
                                strDescription = strDescription + " " + strC[i - 1];
                            else
                                strDescription = strDescription + ", " + strC[i - 1];
                            k -= 1;
                            break;
                    }
                }

                if (bExit)
                    break;
            }

            score = (intA * 1.3 + intB * 0.1 + l * 0.5 + j * 0.5).ToString("0.00");

            return new string[] { score, strDescription };
        }

        private string WeightListItemABCD(int iNumber, ref int iA, ref int iB, ref int iC, ref int iD, ref int iDiag)
        {
            if (iA != -1)
                iA = m_tABCD[iNumber].A_Score.Value;

            if (iB != -1)
                iB = m_tABCD[iNumber].B_Score.Value;

            if (iC != -1)
                iC = m_tABCD[iNumber].C_Score.Value;

            if (iD != -1)
                iD = m_tABCD[iNumber].D_Score.Value;

            if (iDiag != -1)
                iDiag = m_tABCD[iNumber].Diagnosis.Value;

            return m_tABCD[iNumber].ImageID;
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
            m_tABCD = new ExpertizerABCD[searchArray.Count];
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
            return iValue.ToString().Replace("9","").Length;
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
