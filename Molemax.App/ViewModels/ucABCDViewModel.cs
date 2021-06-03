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
using static Molemax.App.ViewModels.ABCD;

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
        private const int PART_A = 0;
        private const int PART_B = 1;
        private const int PART_C = 2;
        private const int PART_D = 3;
        private List<ExpertizerABCD> tABCD_A;
        private List<ExpertizerABCD> tABCD_B;
        private List<ExpertizerABCD> tABCD_C;
        private List<ExpertizerABCD> tABCD_D;
        private ExpertizerABCD[] m_tABCD;
        private LanguageLibrary langLib;
        private ABCD_VALUES abcd_values;
        private int iCheckCounter;
        private ABCD _ABCD;

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

        private string _resultDescription;
        public string ResultDescription
        {
            get { return _resultDescription; }
            set { SetProperty(ref _resultDescription, value); }
        }

        private string _ABCDScore;
        public string ABCDScore
        {
            get { return _ABCDScore; }
            set { SetProperty(ref _ABCDScore, value); }
        }

        private string _resultABCDScore;
        public string ResultABCDScore
        {
            get { return _resultABCDScore; }
            set { SetProperty(ref _resultABCDScore, value); }
        }

        private string _resultABCDEScore;
        public string ResultABCDEScore
        {
            get { return _resultABCDEScore; }
            set { SetProperty(ref _resultABCDEScore, value); }
        }

        private string _resultInformation;
        public string ResultInformation
        {
            get { return _resultInformation; }
            set { SetProperty(ref _resultInformation, value); }
        }

        private string _malignantPSLText;
        public string MalignantPSLText
        {
            get { return _malignantPSLText; }
            set { SetProperty(ref _malignantPSLText, value); }
        }

        private string _suspectedPSLText;
        public string SuspectedPSLText
        {
            get { return _suspectedPSLText; }
            set { SetProperty(ref _suspectedPSLText, value); }
        }

        private string _benignPSLText;
        public string BenignPSLText
        {
            get { return _benignPSLText; }
            set { SetProperty(ref _benignPSLText, value); }
        }

        private BitmapSource _ABCDResultImage;
        public BitmapSource ABCDResultImage
        {
            get { return _ABCDResultImage; }
            set { SetProperty(ref _ABCDResultImage, value); }
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

        private int _resultBlockRowNumber;
        public int ResultBlockRowNumber
        {
            get { return _resultBlockRowNumber; }
            set { SetProperty(ref _resultBlockRowNumber, value); }
        }

        private int _resultBlockRowSpanNumber;
        public int ResultBlockRowSpanNumber
        {
            get { return _resultBlockRowSpanNumber; }
            set { SetProperty(ref _resultBlockRowSpanNumber, value); }
        }
        #endregion

        #region Command
        public DelegateCommand GoCancelCommand { get; set; }
        public DelegateCommand GoOKCommand { get; set; }
        public DelegateCommand<object> SelectAsymmetryGroupCommand { get; set; }
        public DelegateCommand<object> SelectPatternGroupCommand { get; set; }
        public DelegateCommand<object> SelectColorGroupCommand { get; set; }
        public DelegateCommand<object> SelectStructuralGroupCommand { get; set; }
        #endregion

        public bool KeepAlive => false;

        public ucABCDViewModel(IRegionManager regionManager, IMolemaxRepository molemaxRepository, IAppSettings applicationSetting)
        {
            langLib = new LanguageLibrary(@".\LanguageDLLS\language module (english).dll");

            string sABCDImageID;
            int iA = 0;
            int iB = 0;
            int iC = 0;
            int iD = 0;
            int iDiag = 0;
            iCheckCounter = 1;

            abcd_values = new ABCD_VALUES();
            _ABCD = new ABCD();

            _regionManager = regionManager;
            _repository = molemaxRepository;
            _applicationSetting = applicationSetting;
            _applicationSetting.LoadSettings();
            GoCancelCommand = new DelegateCommand(GoCancel);
            GoOKCommand = new DelegateCommand(GoOK);
            SelectAsymmetryGroupCommand = new DelegateCommand<object>(SelectAsymmetryGroup);
            SelectPatternGroupCommand = new DelegateCommand<object>(SelectPatternGroup);
            SelectColorGroupCommand = new DelegateCommand<object>(SelectColorGroup);
            SelectStructuralGroupCommand = new DelegateCommand<object>(SelectStructuralGroup);

            //default is "n/a"
            ResultABCDEScore = GetString(2045);
            //default is "Malignant PSL n>5.45"
            MalignantPSLText = GetString(2042);
            //default is "Suspected PSL n4.8 - 5.45"
            SuspectedPSLText = GetString(2043);
            //default is "Benign PSL n1.0 - 4.75"
            BenignPSLText = GetString(2044);

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

            if (File.Exists(@".\Resources\derma_ref.txt"))
                ResultInformation = ReadTextFile(@".\Resources\derma_ref.txt");
            else
                ResultInformation = GetString(2085);

            ABCDResultImage = new BitmapImage(new Uri($"pack://application:,,,/Resources/ABCD_Graph.jpg"));

            ResultBlockRowNumber = 60;
            ResultBlockRowSpanNumber = 40;
        }

        private void GoOK()
        {
            if (iCheckCounter == 5)
            {

            }
            else
            {
                switch (iCheckCounter)
                {
                    //check if checkbox is selected
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;

                }

                iCheckCounter++;

                //change button text
                if (iCheckCounter == 5)
                {

                }
                else
                {

                }
                ShowCheckPanel(iCheckCounter);

                switch (iCheckCounter)
                {
                    //check if checkbox is selected
                    case 1:
                        Panel1Visibility = Visibility.Visible;
                        Panel2Visibility = Visibility.Collapsed;
                        Panel3Visibility = Visibility.Collapsed;
                        Panel4Visibility = Visibility.Collapsed;
                        PanelResultVisibility = Visibility.Collapsed;
                        PanelDiagnosisVisibility = Visibility.Visible;
                        PanelResultImageVisibility = Visibility.Collapsed;
                        break;
                    case 2:
                        Panel1Visibility = Visibility.Collapsed;
                        Panel2Visibility = Visibility.Visible;
                        Panel3Visibility = Visibility.Collapsed;
                        Panel4Visibility = Visibility.Collapsed;
                        PanelResultVisibility = Visibility.Collapsed;
                        PanelDiagnosisVisibility = Visibility.Visible;
                        PanelResultImageVisibility = Visibility.Collapsed;
                        break;
                    case 3:
                        Panel1Visibility = Visibility.Collapsed;
                        Panel2Visibility = Visibility.Collapsed;
                        Panel3Visibility = Visibility.Visible;
                        Panel4Visibility = Visibility.Collapsed;
                        PanelResultVisibility = Visibility.Collapsed;
                        PanelDiagnosisVisibility = Visibility.Visible;
                        PanelResultImageVisibility = Visibility.Collapsed;
                        break;
                    case 4:
                        Panel1Visibility = Visibility.Collapsed;
                        Panel2Visibility = Visibility.Collapsed;
                        Panel3Visibility = Visibility.Collapsed;
                        Panel4Visibility = Visibility.Visible;
                        PanelResultVisibility = Visibility.Collapsed;
                        PanelDiagnosisVisibility = Visibility.Visible;
                        PanelResultImageVisibility = Visibility.Collapsed;
                        break;
                    case 5:
                        Panel1Visibility = Visibility.Collapsed;
                        Panel2Visibility = Visibility.Collapsed;
                        Panel3Visibility = Visibility.Collapsed;
                        Panel4Visibility = Visibility.Collapsed;
                        PanelResultVisibility = Visibility.Visible;
                        PanelDiagnosisVisibility = Visibility.Collapsed;
                        PanelResultImageVisibility = Visibility.Visible;

                        ResultImageVisibility = Visibility.Visible;
                        ResultInformationVisibility = Visibility.Collapsed;
                        break;

                }

            }
        }

        private string ReadTextFile(string filePath)
        {
            string content;
            StreamReader sr = new StreamReader(filePath, Encoding.UTF8);
            content = sr.ReadToEnd();
            sr.Close();
            return content;
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
                                strDescription = strDescription + " " + strC[i] + " " + GetString(2077);
                            else
                                strDescription = strDescription + " " + GetString(2078) + " " + strC[i] + " " + GetString(2079);
                            bExit = true;
                            break;
                        default:
                            if (k == j)
                                strDescription = strDescription + " " + strC[i];
                            else
                                strDescription = strDescription + ", " + strC[i];
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
            for (int i = 0; i < intD.ToString().Length; i++)
            {
                if (intD.ToString().Substring(i, 1) == "1")
                {
                    switch (k)
                    {
                        case 1:
                            if (j == 1)
                                strDescription = strDescription + " " + strD[i] + ".";
                            else
                                strDescription = strDescription + " " + GetString(2080) + " " + strD[i] + ".";
                            bExit = true;
                            break;
                        default:
                            if (k == j)
                                strDescription = strDescription + " " + strD[i];
                            else
                                strDescription = strDescription + ", " + strD[i];
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
            try
            {
                DiagnosisImage = new BitmapImage(new Uri($"pack://application:,,,/Images/Expertizer/{sABCDImageID}"));
            }
            catch
            {
                DiagnosisImage = new BitmapImage(new Uri($"pack://application:,,,/Images/Expertizer/ABCD/ImageMissing.bmp"));
            }
        }

        private string FindABCD(int ABCDPart, int A_Val = -1, int B_Val = -1, int C_Val = -1, int D_Val = -1)
        {
            string sImageID = string.Empty;
            switch (ABCDPart)
            {
                case PART_A:
                    sImageID = SearchABCD(ABCDPart, tABCD_A, A_Val, B_Val, C_Val, D_Val);
                    break;
                case PART_B:
                    sImageID = SearchABCD(ABCDPart, tABCD_B, A_Val, B_Val, C_Val, D_Val);
                    break;
                case PART_C:
                    sImageID = SearchABCD(ABCDPart, tABCD_C, A_Val, B_Val, C_Val, D_Val);
                    break;
                case PART_D:
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
                    if (CountSet(ValC) > 0)
                    {
                        for (int j = 0; j < ValC.ToString().Length; j++)
                        {
                            if (ValC.ToString().Substring(j, 1) == "1")
                            {
                                if (sCVal.Substring(j, 1) == "1")
                                {
                                    if (ABCDPart == PART_C)
                                    {
                                        dblWeightList[i] = dblWeightList[i] + 100 / CountSet(ValC);
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
                for (int j = i + 1; j < dblWeightList.Length; j++)
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
            return iValue.ToString().Replace("9", "").Length;
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
            Panel1Visibility = Visibility.Visible;
            Panel2Visibility = Visibility.Collapsed;
            Panel3Visibility = Visibility.Collapsed;
            Panel4Visibility = Visibility.Collapsed;

            PanelResultVisibility = Visibility.Collapsed;

            PanelDiagnosisVisibility = Visibility.Visible;

            PanelResultImageVisibility = Visibility.Collapsed;
            ResultImageVisibility = Visibility.Collapsed;
            ResultInformationVisibility = Visibility.Collapsed;
        }

        private void SelectStructuralGroup(object obj)
        {
            char[] svalue;
            string sSelectedIndex = (string)obj;

            if (abcd_values.intD == -1)
            {
                svalue = new char[] { '9', '9', '9', '9', '9' };
            }
            else
            {
                svalue = abcd_values.intD.ToString().ToArray<char>();
            }

            abcd_values.intD = CreateCDVal(int.Parse(obj.ToString()), svalue);
            ShowCheckPanel(iCheckCounter);
        }

        private void SelectColorGroup(object obj)
        {
            char[] svalue;
            string sSelectedIndex = (string)obj;

            if (abcd_values.intC == -1)
            {
                svalue = new char[] { '9', '9', '9', '9', '9', '9' };
            }
            else
            {
                svalue = abcd_values.intC.ToString().ToArray<char>();
            }
            abcd_values.intC = CreateCDVal(int.Parse(obj.ToString()), svalue);
            ShowCheckPanel(iCheckCounter);
        }

        private void SelectPatternGroup(object obj)
        {
            string sSelectedIndex = (string)obj;
            abcd_values.intB = int.Parse(obj.ToString());
            ShowCheckPanel(iCheckCounter);
        }

        private void SelectAsymmetryGroup(object obj)
        {
            string sSelectedIndex = (string)obj;
            abcd_values.intA = int.Parse(obj.ToString());
            ShowCheckPanel(iCheckCounter);
        }

        private int CreateCDVal(int obj, char[] sValue)
        {

            sValue[obj] = sValue[obj] == '9' ? '1' : '9';

            return int.Parse(string.Join("", sValue));
        }

        private void ShowCheckPanel(int Nr)
        {
            string sABCDImageID;
            int iA = 0;
            int iB = 0;
            int iC = 0;
            int iD = 0;
            int iDiag = 0;
            string[] result;

            switch (Nr)
            {
                case 1:
                    sABCDImageID = FindABCD(PART_A, abcd_values.intA, abcd_values.intB, abcd_values.intC, abcd_values.intD);
                    LoadABCDImage(sABCDImageID);

                    WeightListItemABCD(0, ref iA, ref iB, ref iC, ref iD, ref iDiag);

                    result = CreateImageDescription(iA, iB, iC, iD);
                    ABCDScore = result[0];
                    ImageDescription = result[1];

                    DiagnosisName = CreateImageDescriptionShort(iDiag);
                    break;
                case 2:
                    sABCDImageID = FindABCD(PART_B, abcd_values.intA, abcd_values.intB, abcd_values.intC, abcd_values.intD);
                    LoadABCDImage(sABCDImageID);

                    WeightListItemABCD(0, ref iA, ref iB, ref iC, ref iD, ref iDiag);

                    result = CreateImageDescription(iA, iB, iC, iD);
                    ABCDScore = result[0];
                    ImageDescription = result[1];

                    DiagnosisName = CreateImageDescriptionShort(iDiag);
                    break;
                case 3:
                    sABCDImageID = FindABCD(PART_C, abcd_values.intA, abcd_values.intB, abcd_values.intC, abcd_values.intD);
                    LoadABCDImage(sABCDImageID);

                    WeightListItemABCD(0, ref iA, ref iB, ref iC, ref iD, ref iDiag);

                    result = CreateImageDescription(iA, iB, iC, iD);
                    ABCDScore = result[0];
                    ImageDescription = result[1];

                    DiagnosisName = CreateImageDescriptionShort(iDiag);
                    break;
                case 4:
                    sABCDImageID = FindABCD(PART_D, abcd_values.intA, abcd_values.intB, abcd_values.intC, abcd_values.intD);
                    LoadABCDImage(sABCDImageID);

                    WeightListItemABCD(0, ref iA, ref iB, ref iC, ref iD, ref iDiag);

                    result = CreateImageDescription(iA, iB, iC, iD);
                    ABCDScore = result[0];
                    ImageDescription = result[1];

                    DiagnosisName = CreateImageDescriptionShort(iDiag);
                    break;
                case 5:
                    ShowResult();
                    break;
            }
        }

        private void ShowResult()
        {
            FillABCDObject();
            ResultABCDScore = _ABCD.Score.ToString("0.00");
            ResultDescription = CreateImageDescription(abcd_values.intA, abcd_values.intB, abcd_values.intC, abcd_values.intD)[1];
        }

        private void FillABCDObject()
        {
            int j = 0;
            int k = 0;
            int intColorEnumVal = 0;
            int intStructEnumVal = 0;

            for (int i = 0; i < abcd_values.intC.ToString().Length; i++)
            {
                if (abcd_values.intC.ToString().Substring(i, 1) == "1")
                {
                    j++;
                    switch (i)
                    {
                        case 0:
                            intColorEnumVal += 1;
                            break;
                        case 1:
                            intColorEnumVal += 2;
                            break;
                        case 2:
                            intColorEnumVal += 4;
                            break;
                        case 3:
                            intColorEnumVal += 8;
                            break;
                        case 4:
                            intColorEnumVal += 16;
                            break;
                        case 5:
                            intColorEnumVal += 32;
                            break;
                    }
                }
            }
            k = j;
            j = 0;
            for (int i = 0; i < abcd_values.intD.ToString().Length; i++)
            {
                if (abcd_values.intD.ToString().Substring(i, 1) == "1")
                {
                    j++;
                    switch (i)
                    {
                        case 0:
                            intStructEnumVal += 1;
                            break;
                        case 1:
                            intStructEnumVal += 2;
                            break;
                        case 2:
                            intStructEnumVal += 4;
                            break;
                        case 3:
                            intStructEnumVal += 8;
                            break;
                        case 4:
                            intStructEnumVal += 16;
                            break;
                    }
                }
            }

            _ABCD.Assymetry = (ABCD_ASSYMETRY)abcd_values.intA;
            _ABCD.Segments = abcd_values.intB;
            _ABCD.Specific_Color = (ABCD_COLOR)intColorEnumVal;
            _ABCD.Structural_Component = (ABCD_STRUCTURAL_COMPONENTS)intStructEnumVal;
            _ABCD.Nevus = ABCD_CHANGE_NEVUS.NEVUS_NOT_SPECIFIED;
            _ABCD.Score = abcd_values.intA * 1.3 + abcd_values.intB * 0.1 + k * 0.5 + j * 0.5;
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

    public class ABCD_VALUES
    {
        public int intA = -1;
        public int intB = -1;
        public int intC = -1;
        public int intD = -1;
    }


    public class ABCD
    {
        public enum ABCD_ASSYMETRY
        {
            NOT_DEFINED_ASSYMETRY = -1,
            NONE_ASSYMETRY = 0,
            ONE_AXIS_ASSYMETRY = 1,
            BOTH_AXIS_ASSYMETRY = 2
        }

        public enum ABCD_COLOR
        {
            ABCD_COLOR_NOT_DEFINED = -1,
            ABCD_COLOR_WHITE = 1,
            ABCD_COLOR_LIGHTBROWN = 2,
            ABCD_COLOR_DARKBROWN = 4,
            ABCD_COLOR_BLUEGREY = 8,
            ABCD_COLOR_BLACK = 16,
            ABCD_COLOR_RED = 32
        }

        public enum ABCD_STRUCTURAL_COMPONENTS
        {
            COMPONENT_NOT_DEFINED = -1,
            COMPONENT_HOMOGENOUS_AREA = 1,
            COMPONENT_PIGMENT_NETWORK = 2,
            COMPONENT_STREAKS = 4,
            COMPONENT_DOTS = 8,
            COMPONENT_GLOBULES = 16
        }

        public enum ABCD_CHANGE_NEVUS
        {
            NEVUS_NOT_SPECIFIED = 0,
            NEVUS_YES = 1,
            NEVUS_NONE = 2
        }

        public long MikroID { get; set; }
        public ABCD_ASSYMETRY Assymetry { get; set; }
        public int Segments { get; set; }
        public ABCD_COLOR Specific_Color { get; set; }
        public ABCD_STRUCTURAL_COMPONENTS Structural_Component { get; set; }
        public ABCD_CHANGE_NEVUS Nevus { get; set; }
        public double Score { get; set; }
        public double ScoreE { get; set; }
    }
}
