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
using System.Windows;
using System.Windows.Media.Imaging;

namespace Molemax.App.ViewModels
{
    public class ucFupLocalizationViewModel : BindableBase, IRegionMemberLifetime, INavigationAware, IMouseCaptureProxy
    {
        private IRegionManager _regionManager;
        private IMolemaxRepository _repository;
        private IAppSettings _applicationSetting;
        private string fromForm;
        private IEnumerable<DEFMakroLokal> _defMakroLokals
        {
            get { return _repository.DEFMakroLokals.Get(); }
        }
        private IEnumerable<DEFMikroLokal> _defMikroLokals
        {
            get { return _repository.DEFMikroLokals.Get(); }
        }
        private IEnumerable<DEFLocalTxt> _defLocalTxts
        {
            get { return _repository.DEFLocalTxts.Get(); }
        }
        private IEnumerable<Diagsource> _dbDiagsources
        {
            get { return _repository.Diagsources.Get(); }
        }
        private IEnumerable<Diagnose> _dbDiagnoses
        {
            get { return _repository.Diagnoses.Get(); }
        }
        private IEnumerable<Image> _dbImages
        {
            get { return _repository.Images.Get(); }
        }
        private IEnumerable<ImgDiag> _dbImgDiags
        {
            get { return _repository.ImgDiags.Get(); }
        }
        private IEnumerable<Timestamp> _dbTimestamps
        {
            get { return _repository.Timestamps.Get(); }
        }
        private IEnumerable<Makro> _dbMakros
        {
            get { return _repository.Makros.Get(); }
        }
        private IEnumerable<Closeup> _dbCloseups
        {
            get { return _repository.Closeups.Get(); }
        }

        private IEnumerable<Mikro> _dbMikros
        {
            get { return _repository.Mikros.Get(); }
        }

        private IEnumerable<Fup> _dbFups
        {
            get { return _repository.Fups.Get(); }
        }

        private ImageHandler _originalImage;
        private Image originalImageModel;
        private Image fupImageModel;
        private Makro originalMakroModel;
        private Makro fupMakroModel;
        private Closeup originalCloseupModel;
        private Closeup fupCloseupModel;
        private Mikro originalMikroModel;
        private Mikro fupMikroModel;
        private ImgDiag imgDiagModel;
        private int dummyImageIndex;
        private KIND_ENUM imageKind;
        private IMAGING_SOURCES_INDEX imageSource;
        private bool bShowFavoriteList = false;
        private bool bShowRecentList = false;
        private bool bShowAllList = false;

        private double fullPicRectangleX;
        private double fullPicRectangleY;
        private double fullPicRectangleWidth;
        private double fullPicRectangleHeight;

        private double fullPicPointX;
        private double fullPicPointY;

        private bool bPointOnDummyImage = false;
        private bool bPointOnMakroImage = false;
        private bool bPointOnCloseUpImage = false;

        private double makroOrCloseUpListImageWidth;
        private double makroOrCloseUpListImageHeight;

        private int selectedDummyImageIndex;
        public event EventHandler Capture;
        public event EventHandler Release;

        #region Property
        private double _rectangleX;
        public double RectangleX
        {
            get { return _rectangleX; }
            set { SetProperty(ref _rectangleX, value); }
        }

        private double _rectangleY;
        public double RectangleY
        {
            get { return _rectangleY; }
            set { SetProperty(ref _rectangleY, value); }
        }

        private double _rectangleWidth;
        public double RectangleWidth
        {
            get { return _rectangleWidth; }
            set { SetProperty(ref _rectangleWidth, value); }
        }

        private double _rectangleHeight;
        public double RectangleHeight
        {
            get { return _rectangleHeight; }
            set { SetProperty(ref _rectangleHeight, value); }
        }

        //point X on dummy image
        private double _pointX;
        public double PointX
        {
            get { return _pointX; }
            set { SetProperty(ref _pointX, value); }
        }

        //point Y on dummy image
        private double _pointY;
        public double PointY
        {
            get { return _pointY; }
            set { SetProperty(ref _pointY, value); }
        }

        //show point on dummy image
        private Visibility _pointVisible;
        public Visibility PointVisible
        {
            get { return _pointVisible; }
            set { SetProperty(ref _pointVisible, value); }
        }

        private Visibility _rectangleVisible;
        public Visibility RectangleVisible
        {
            get { return _rectangleVisible; }
            set { SetProperty(ref _rectangleVisible, value); }
        }

        private BitmapSource _locImage;
        public BitmapSource LocImage
        {
            get { return _locImage; }
            set { SetProperty(ref _locImage, value); }
        }

        private BitmapSource _dummyImage;
        public BitmapSource DummyImage
        {
            get { return _dummyImage; }
            set { SetProperty(ref _dummyImage, value); }
        }

        private BitmapSource _dummyColorImage;
        public BitmapSource DummyColorImage
        {
            get { return _dummyColorImage; }
            set { SetProperty(ref _dummyColorImage, value); }
        }

        private string _imageDate;
        public string ImageDate
        {
            get { return _imageDate; }
            set { SetProperty(ref _imageDate, value); }
        }

        private int _zIndex;
        public int ZIndex
        {
            get { return _zIndex; }
            set { SetProperty(ref _zIndex, value); }
        }

        private Visibility _gridVisibility;
        public Visibility GridVisibility
        {
            get { return _gridVisibility; }
            set { SetProperty(ref _gridVisibility, value); }
        }

        private int _macroAndCloseupListZIndex;
        public int MacroAndCloseupListZIndex
        {
            get { return _macroAndCloseupListZIndex; }
            set { SetProperty(ref _macroAndCloseupListZIndex, value); }
        }

        private Visibility _macroAndCloseupListVisibility;
        public Visibility MacroAndCloseupListVisibility
        {
            get { return _macroAndCloseupListVisibility; }
            set { SetProperty(ref _macroAndCloseupListVisibility, value); }
        }

        private string _myDiagnosis;
        public string MyDiagnosis
        {
            get { return _myDiagnosis; }
            set { SetProperty(ref _myDiagnosis, value); }
        }

        private string _comment;
        public string Comment
        {
            get { return _comment; }
            set { SetProperty(ref _comment, value); }
        }

        private string _dummyLocation;
        public string DummyLocation
        {
            get { return _dummyLocation; }
            set { SetProperty(ref _dummyLocation, value); }
        }

        private ObservableCollection<string> _followUpDataList;
        public ObservableCollection<string> FollowUpDataList
        {
            get { return _followUpDataList; }
            set { SetProperty(ref _followUpDataList, value); }
        }

        private bool _dermaNet;
        public bool DermaNet
        {
            get { return _dermaNet; }
            set { SetProperty(ref _dermaNet, value); }
        }

        private bool _highRisk;
        public bool HighRisk
        {
            get { return _highRisk; }
            set { SetProperty(ref _highRisk, value); }
        }

        private bool _mediumRisk;
        public bool MediumRisk
        {
            get { return _mediumRisk; }
            set { SetProperty(ref _mediumRisk, value); }
        }

        private bool _lowRisk;
        public bool LowRisk
        {
            get { return _lowRisk; }
            set { SetProperty(ref _lowRisk, value); }
        }

        private ObservableCollection<ProvisionalDiagnosis> _provisionalDiagnosisList;
        public ObservableCollection<ProvisionalDiagnosis> ProvisionalDiagnosisList
        {
            get { return _provisionalDiagnosisList; }
            set { SetProperty(ref _provisionalDiagnosisList, value); }
        }

        private ObservableCollection<ProvisionalDiagnosis> _selectedProvisionalDiagnosisList;
        public ObservableCollection<ProvisionalDiagnosis> SelectedProvisionalDiagnosisList
        {
            get { return _selectedProvisionalDiagnosisList; }
            set { SetProperty(ref _selectedProvisionalDiagnosisList, value); }
        }

        private ObservableCollection<ImageHandler> _patientMakroImageList;
        public ObservableCollection<ImageHandler> PatientMakroImageList
        {
            get { return _patientMakroImageList; }
            set { SetProperty(ref _patientMakroImageList, value); }
        }

        private ObservableCollection<ImageHandler> _patientCloseUpImageList;
        public ObservableCollection<ImageHandler> PatientCloseUpImageList
        {
            get { return _patientCloseUpImageList; }
            set { SetProperty(ref _patientCloseUpImageList, value); }
        }

        public bool _showMacroButton;
        public bool ShowMacroButton
        {
            get { return _showMacroButton; }
            set { SetProperty(ref _showMacroButton, value); }
        }

        public bool _showDummyButton;
        public bool ShowDummyButton
        {
            get { return _showDummyButton; }
            set { SetProperty(ref _showDummyButton, value); }
        }

        private bool _keepLive = false;
        public bool KeepAlive
        {
            get { return _keepLive; }
        }

        private double _dummyImageWidth;
        public double DummyImageWidth
        {
            get { return _dummyImageWidth; }
            set
            { 
                SetProperty(ref _dummyImageWidth, value); 
            }
        }

        private double _dummyImageHeight;
        public double DummyImageHeight
        {
            get { return _dummyImageHeight; }
            set 
            {
                SetProperty(ref _dummyImageHeight, value);
                DrawAreaOnImage();
            }
        }
        #endregion

        #region Command
        public DelegateCommand GoDiagnosisCommand { get; set; }
        public DelegateCommand GoFavoriteCommand { get; set; }
        public DelegateCommand GoRecentCommand { get; set; }
        public DelegateCommand GoAllCommand { get; set; }
        public DelegateCommand GoAllSkinCommand { get; set; }
        public DelegateCommand GoAddCommand { get; set; }
        public DelegateCommand GoDummyCommand { get; set; }
        public DelegateCommand GoMacroCommand { get; set; }
        public DelegateCommand GoPreviousDummyImageCommand { get; set; }
        public DelegateCommand GoNextDummyImageCommand { get; set; }
        public DelegateCommand GoAttachDocumentsCommand { get; set; }
        public DelegateCommand GoCancelCommand { get; set; }
        public DelegateCommand GoSaveDiagsourceListCommand { get; set; }
        public DelegateCommand GoSaveCommand { get; set; }
        public DelegateCommand GoWindowLoadedCommand { get; set; }
        public DelegateCommand<object> GoMakroImageMouseLeftButtonDownCommand { get; set; }
        public DelegateCommand<object> GoCloseUpImageMouseLeftButtonDownCommand { get; set; }
        public DelegateCommand<object> GoMakroAndCloseupListImageLoadedCommand { get; set; }
        #endregion

        public ucFupLocalizationViewModel(IRegionManager regionManager, IMolemaxRepository molemaxRepository, IAppSettings applicationSetting)
        {
            _regionManager = regionManager;
            _repository = molemaxRepository;
            _applicationSetting = applicationSetting;
            GoDiagnosisCommand = new DelegateCommand(GoDiagnosis);
            GoFavoriteCommand = new DelegateCommand(GoFavorite);
            GoRecentCommand = new DelegateCommand(GoRecent);
            GoAllCommand = new DelegateCommand(GoAll);
            GoAllSkinCommand = new DelegateCommand(GoAllSkin);
            GoAddCommand = new DelegateCommand(GoAdd);
            GoCancelCommand = new DelegateCommand(GoCancel);
            GoPreviousDummyImageCommand = new DelegateCommand(GoPreviousDummyImage);
            GoNextDummyImageCommand = new DelegateCommand(GoNextDummyImage);
            GoDummyCommand = new DelegateCommand(GoDummy);
            GoMacroCommand = new DelegateCommand(GoMacro);
            GoSaveDiagsourceListCommand = new DelegateCommand(GoSaveDiagsourceList);
            GoSaveCommand = new DelegateCommand(GoSave);
            GoWindowLoadedCommand = new DelegateCommand(GoWindowLoaded);
            GoMakroImageMouseLeftButtonDownCommand = new DelegateCommand<object>(GoMakroImageMouseLeftButtonDown);
            GoCloseUpImageMouseLeftButtonDownCommand = new DelegateCommand<object>(GoCloseUpImageMouseLeftButtonDown);
            GoMakroAndCloseupListImageLoadedCommand = new DelegateCommand<object>(GoMakroAndCloseupListImageLoaded);

            selectedDummyImageIndex = 0;
            dummyImageIndex = 1;
            ImageDate = DateTime.Today.ToString("dd/MM/yyyy");

            //hide diagnosis dropdown list
            GridVisibility = Visibility.Collapsed;
            ZIndex = 0;

            RectangleVisible = Visibility.Collapsed;
            PointVisible = Visibility.Collapsed;

            MyDiagnosis = "test diagnosis";

            Comment = "test comment";

            FollowUpDataList = new ObservableCollection<string>();
            FollowUpDataList.Add("No Follow Up date");
            FollowUpDataList.Add("One week");
            FollowUpDataList.Add("Two weeks");



            ProvisionalDiagnosisList = new ObservableCollection<ProvisionalDiagnosis>();
            SelectedProvisionalDiagnosisList = new ObservableCollection<ProvisionalDiagnosis>();
            PatientMakroImageList = new ObservableCollection<ImageHandler>();

            ShowMacroButton = false;
            ShowDummyButton = true;
        }

        private void GoMakroAndCloseupListImageLoaded(object obj)
        {
            var values = (object[])obj;

            if (makroOrCloseUpListImageWidth == 0)
            {
                makroOrCloseUpListImageWidth = (double)values[0];
                makroOrCloseUpListImageHeight = (double)values[1];

                if (ShowMacroButton && _originalImage != null)
                {
                    ImageHandler mi = new ImageHandler();

                    if (imageKind == KIND_ENUM.KIND_CLOSEUP)
                    {
                        if (PatientMakroImageList != null && PatientMakroImageList.Count > 0)
                        {
                            mi = PatientMakroImageList.Where(i => i.Id == originalCloseupModel.makroId).FirstOrDefault();
                            bPointOnMakroImage = true;
                            bPointOnCloseUpImage = false;
                        }

                        if (PatientCloseUpImageList != null && PatientCloseUpImageList.Count > 0)
                        {
                            mi = PatientCloseUpImageList.Where(i => i.Id == _originalImage.Id).FirstOrDefault();
                            bPointOnMakroImage = false;
                            bPointOnCloseUpImage = true;
                        }


                        double ImageAndRectangleXRatio = Convert.ToDouble(originalCloseupModel.X1) / 1000;
                        double ImageAndRectangleYRatio = Convert.ToDouble(originalCloseupModel.Y1) / 1000;
                        double ImageAndRectangleWidthRatio = Convert.ToDouble(originalCloseupModel.X2) / 1000;
                        double ImageAndRectangleHeightRatio = Convert.ToDouble(originalCloseupModel.Y2) / 1000;

                        mi.FullPicRectangleX = makroOrCloseUpListImageWidth * ImageAndRectangleXRatio;
                        mi.FullPicRectangleY = makroOrCloseUpListImageHeight * ImageAndRectangleYRatio;
                        mi.FullPicRectangleWidth = makroOrCloseUpListImageWidth * ImageAndRectangleWidthRatio;
                        mi.FullPicRectangleHeight = makroOrCloseUpListImageHeight * ImageAndRectangleHeightRatio;

                        PatientMakroImageList = new ObservableCollection<ImageHandler>(PatientMakroImageList);
                    }
                    else
                    {
                        if (PatientMakroImageList != null && PatientMakroImageList.Count > 0 && originalMikroModel.makroId>0)
                        {
                            mi = PatientMakroImageList.Where(i => i.Id == originalMikroModel.makroId).FirstOrDefault();
                            bPointOnMakroImage = true;
                            bPointOnCloseUpImage = false;

                            mi.FullPicPointX = makroOrCloseUpListImageWidth * originalMikroModel.X_Pic / 1000;
                            mi.FullPicPointY = makroOrCloseUpListImageHeight * originalMikroModel.Y_Pic /1000;
                            mi.FullPicPointVisible = Visibility.Visible;
                            PatientMakroImageList = new ObservableCollection<ImageHandler>(PatientMakroImageList);

                        }

                        if (PatientCloseUpImageList != null && PatientCloseUpImageList.Count > 0 && originalMikroModel.closeupId >0)
                        {
                            mi = PatientCloseUpImageList.Where(i => i.Id == originalMikroModel.closeupId).FirstOrDefault();
                            bPointOnMakroImage = false;
                            bPointOnCloseUpImage = true;

                            mi.FullPicPointX = makroOrCloseUpListImageWidth * originalMikroModel.X_Pic / 1000;
                            mi.FullPicPointY = makroOrCloseUpListImageHeight * originalMikroModel.Y_Pic / 1000;
                            mi.FullPicPointVisible = Visibility.Visible;
                            PatientCloseUpImageList = new ObservableCollection<ImageHandler>(PatientCloseUpImageList);
                        }
                    }

                }
            }
        }

        private void GoWindowLoaded()
        {
            _applicationSetting.LoadSettings();
            fupMakroModel = new Makro();
            fupImageModel = new Image();
            fupCloseupModel = new Closeup();
            fupMikroModel = new Mikro();
            originalImageModel = _dbImages.Where(i => i.id == _originalImage.ImageId).FirstOrDefault();

            var tempList = _dbImages.Join(_dbImgDiags, i => i.id, imdg => imdg.imageId, (image, imgdiag) => new { image, imgdiag })
                .Join(_dbDiagnoses, ii => ii.imgdiag.diagnoseId, d => d.id, (imageAndImgdiag, diagnose) => new { imageAndImgdiag, diagnose })
                .Join(_dbDiagsources, iid => iid.diagnose.diagsourceId, d => d.id, (imageAndImgdiagAnddiagnose, diagsource) => new { imageAndImgdiagAnddiagnose, diagsource })
                .Where(item => item.imageAndImgdiagAnddiagnose.imageAndImgdiag.image.id == _originalImage.ImageId)
                .Select(item => new ProvisionalDiagnosis {
                    IsChecked = true,
                    DiagsourceFullName = item.diagsource.fullname,
                    Id = item.diagsource.id,
                    OriginId = item.diagsource.origin_id,
                    diagsource = item.diagsource
                }).ToList();

            SelectedProvisionalDiagnosisList = new ObservableCollection<ProvisionalDiagnosis>(tempList);

            switch (imageKind)
            {
                case KIND_ENUM.KIND_MAKRO:
                    originalMakroModel = _dbMakros.Where(m => m.id == _originalImage.Id).FirstOrDefault();
                    break;
                case KIND_ENUM.KIND_CLOSEUP:
                    originalCloseupModel = _dbCloseups.Where(m => m.id == _originalImage.Id).FirstOrDefault();
                    break;
                case KIND_ENUM.KIND_MIKRO:
                    originalMikroModel = _dbMikros.Where(m => m.id == _originalImage.Id).FirstOrDefault();
                    break;
            }

            dummyImageIndex = originalImageModel.kenpos;
            selectedDummyImageIndex = dummyImageIndex;
            DummyLocation = originalImageModel.loctext;

            DummyImage = new BitmapImage(new Uri($"pack://application:,,,/Images/Dummy/Ken/{dummyImageIndex}.bmp"));
            if (imageKind == KIND_ENUM.KIND_MAKRO)
                DummyColorImage = new BitmapImage(new Uri($"pack://application:,,,/Images/Dummy/MakroKen/{dummyImageIndex}.bmp"));
            if (imageKind == KIND_ENUM.KIND_MIKRO)
                DummyColorImage = new BitmapImage(new Uri($"pack://application:,,,/Images/Dummy/MikroKen/{dummyImageIndex}.bmp"));


            //don't show dummy image and close up image to close up
            if (imageKind == KIND_ENUM.KIND_CLOSEUP)
            {
                ShowDummyButton = false;
                ShowMacroButton = true;
                GetPatientMakroImages();
                GoMacro();
            }

            if (imageKind == KIND_ENUM.KIND_MIKRO)
            {
                ShowDummyButton = true;
                ShowMacroButton = true;
                bPointOnDummyImage = true;
                GetPatientMakroImages();
                GetPatientCloseUpImages();
            }

        }

        private void DrawAreaOnImage()
        {

            //if image is Makro, show rectangel on dummy image
            if (imageKind == KIND_ENUM.KIND_MAKRO)
            {
                ShowMacroButton = false;
                RectangleX = originalMakroModel.X1 * DummyImageWidth / 1000;
                RectangleY = originalMakroModel.Y1 * DummyImageHeight / 1000;
                RectangleWidth = originalMakroModel.X2 * DummyImageWidth / 1000;
                RectangleHeight = originalMakroModel.Y2 * DummyImageHeight / 1000;
                RectangleVisible = Visibility.Visible;
            }

            if (imageKind == KIND_ENUM.KIND_MIKRO)
            {
                PointX = originalMikroModel.X * DummyImageWidth / 1000;
                PointY = originalMikroModel.Y * DummyImageHeight / 1000;
                PointVisible = Visibility.Visible;
                bPointOnDummyImage = true;
            }
        }

        private void GoCloseUpImageMouseLeftButtonDown(object obj)
        {
            var values = (object[])obj;
            var navigationParameters = new NavigationParameters();

            var pmi = (ImageHandler)values[2];
            pmi.ContainerImageWidth = (double)values[0];
            pmi.ContainerImageHeight = (double)values[1];

            _keepLive = true;
            navigationParameters.Add(Constants.ImageKind, imageKind);
            navigationParameters.Add(Constants.ParaImage, LocImage);
            navigationParameters.Add(Constants.ContainerImage, pmi);
            navigationParameters.Add(Constants.FromForm, UserControlNames.Localization);
            navigationParameters.Add(Constants.FromControl, Constants.ContainerCloseUpImage);
            _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.FullPic, navigationParameters);
        }

        private void GoMakroImageMouseLeftButtonDown(object obj)
        {
            var values = (object[])obj;
            var navigationParameters = new NavigationParameters();

            var pmi = (ImageHandler)values[2];
            pmi.ContainerImageWidth = (double)values[0];
            pmi.ContainerImageHeight = (double)values[1];

            _keepLive = true;
            navigationParameters.Add(Constants.ImageKind, imageKind);
            navigationParameters.Add(Constants.ParaImage, LocImage);
            navigationParameters.Add(Constants.ContainerImage, pmi);
            navigationParameters.Add(Constants.FromForm, UserControlNames.Localization);
            navigationParameters.Add(Constants.FromControl, Constants.ContainerMakroImage);
            _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.FullPic, navigationParameters);

        }

        private void ClearPointOnImages()
        {
            foreach (ImageHandler i in PatientMakroImageList)
            {
                i.FullPicPointX = 0;
                i.FullPicPointY = 0;
                i.FullPicPointVisible = Visibility.Collapsed;
            }

            foreach (ImageHandler i in PatientCloseUpImageList)
            {
                i.FullPicPointX = 0;
                i.FullPicPointY = 0;
                i.FullPicPointVisible = Visibility.Collapsed;
            }
        }

        private bool GetPatientMakroImages()
        {
            var maxfupList = _dbFups.Join(_dbImages, fup => fup.imageId, image => image.id, (fup, image) => new { fup, image })
                                    .Where(item => item.image.patientId == GlobalValue.Instance.CurrentPatient.id)
                                    .GroupBy(item => item.fup.imageId)
                                    .Select(item => new
                                    {
                                        MaxFup = item.Max(i => i.fup.id),
                                        ImageId = item.Key
                                    }).ToList();

            //get makro records that does not have follow up
            var makroWithNoFupList = _dbMakros.Join(_dbImages, ma => ma.imageId, image => image.id, (makro, image) => new { makro, image })
                .Where(item => item.image.patientId == GlobalValue.Instance.CurrentPatient.id && item.makro.bms_id == 0)
                .Where(item => item.makro.fupId == 0)
                .Where(item => !maxfupList.Any(b => b.ImageId == item.makro.imageId)).ToList();

            //get makro records that has follow up
            var makroWithFupList = _dbMakros.Join(_dbImages, ma => ma.imageId, image => image.id, (makro, image) => new { makro, image })
                .Where(item => item.image.patientId == GlobalValue.Instance.CurrentPatient.id && item.makro.bms_id == 0)
                .Where(item => maxfupList.Any(b => b.MaxFup == item.makro.fupId)).ToList();

            //final makro list
            var makroList = makroWithNoFupList.Concat(makroWithFupList).OrderByDescending(item => item.image.tsId).ToList();

            var tempList = _dbImages.Join(makroList, image => image.id, makro => makro.makro.imageId, (x, y) => new { image = x, makro = y }).Join(_dbTimestamps, i => i.image.tsId, ts => ts.id, (x, y) => new { imageAndMakro = x, ts = y })
                                                  .Where(item => item.imageAndMakro.image.kind == 1 && item.imageAndMakro.image.patientId == GlobalValue.Instance.CurrentPatient.id)
                                                  .OrderByDescending(item => item.imageAndMakro.image.tsId)
                                                  .Select(m => new ImageHandler
                                                  {
                                                      Id = m.imageAndMakro.makro.makro.id,
                                                      ImageId = m.imageAndMakro.image.id,
                                                      ContainerImageId = m.imageAndMakro.makro.makro.id,
                                                      Kenpos = m.imageAndMakro.image.kenpos,
                                                      Loctext = m.imageAndMakro.image.loctext,
                                                      CreateDate = m.ts.date_created.ToString("d"),
                                                      Image = new BitmapImage(new Uri(m.imageAndMakro.image.defpath + "\\" + m.imageAndMakro.image.imgname)),
                                                      SmallKen = new BitmapImage(new Uri($"pack://application:,,,/Images/Dummy/SmallKen/{m.imageAndMakro.image.kenpos}.bmp")),
                                                      FullPicPointVisible = Visibility.Collapsed
                                                  });


            PatientMakroImageList = new ObservableCollection<ImageHandler>(tempList);

            //int index = 0;
            //foreach (ImageHandler mi in PatientMakroImageList)
            //{
            //    mi.Id = index++;
            //}
            return PatientMakroImageList.Count() > 0;
        }

        private bool GetPatientCloseUpImages()
        {
            var maxfupList = _dbFups.Join(_dbImages, fup => fup.imageId, image => image.id, (fup, image) => new { fup, image })
                        .Where(item => item.image.patientId == GlobalValue.Instance.CurrentPatient.id)
                        .GroupBy(item => item.fup.imageId)
                        .Select(item => new
                        {
                            MaxFup = item.Max(i => i.fup.id),
                            ImageId = item.Key
                        }).ToList();

            //get closeup records that does not have fupid
            var closeupWithNoFupList = _dbCloseups.Join(_dbImages, cu => cu.imageId, image => image.id, (closeup, image) => new { closeup, image })
                .Where(item => item.image.patientId == GlobalValue.Instance.CurrentPatient.id)
                .Where(item => item.closeup.fupId == 0)
                .Where(item => !maxfupList.Any(b => b.ImageId == item.closeup.imageId)).ToList();

            //get closeup records that is in max fup list
            var closeupWithFupList = _dbCloseups.Join(_dbImages, cu => cu.imageId, image => image.id, (closeup, image) => new { closeup, image })
                .Where(item => item.image.patientId == GlobalValue.Instance.CurrentPatient.id)
                .Where(item => maxfupList.Any(b => b.MaxFup == item.closeup.fupId)).ToList();

            //final closeup list
            var closeupList = closeupWithNoFupList.Concat(closeupWithFupList).OrderByDescending(item => item.image.tsId).ToList();

            var tempList = _dbImages.Join(closeupList, im => im.id, cl => cl.closeup.imageId, (im, cl) => new { im, cl }).Join(_dbTimestamps, i => i.im.tsId, ts => ts.id, (i, ts) => new { i, ts })
                                                  .Where(item => item.i.im.kind == 3 && item.i.im.patientId == GlobalValue.Instance.CurrentPatient.id)
                                                  .OrderByDescending(item => item.i.im.tsId)
                                                  .Select(m => new ImageHandler
                                                  {
                                                      Id = m.i.cl.closeup.id,
                                                      ImageId = m.i.im.id,
                                                      ContainerImageId = m.i.cl.closeup.id,
                                                      Kenpos = m.i.im.kenpos,
                                                      Loctext = m.i.im.loctext,
                                                      CreateDate = m.ts.date_created.ToString("d"),
                                                      Image = new BitmapImage(new Uri(m.i.im.defpath + "\\" + m.i.im.imgname)),
                                                      SmallKen = new BitmapImage(new Uri($"pack://application:,,,/Images/Dummy/SmallKen/{m.i.im.kenpos}.bmp")),
                                                      FullPicPointVisible = Visibility.Collapsed
                                                  }); ;

            PatientCloseUpImageList = new ObservableCollection<ImageHandler>(tempList);

            //int index = 0;
            //foreach (ImageHandler mi in PatientCloseUpImageList)
            //{
            //    mi.Id = index++;
            //}
            return PatientCloseUpImageList.Count() > 0;
        }

        //private void GetLastCreateImage()
        //{
        //    lastImageModel = _dbImages.Where(im => im.patientId == GlobalValue.Instance.CurrentPatient.id).OrderByDescending(im => im.tsId).FirstOrDefault();
        //    if (lastImageModel != null && lastImageModel.kenpos > 0)
        //        dummyImageIndex = lastImageModel.kenpos;
        //    else
        //        dummyImageIndex = 1;
        //}

        private void GoSave()
        {
            if (StoreImage())
            {
                _keepLive = false;
                var navigationParameters = new NavigationParameters();
                navigationParameters.Add(Constants.FromForm, UserControlNames.FupLocalization);

                _regionManager.RequestNavigate(RegionNames.ContentRegion, fromForm, navigationParameters);
            }
        }

        private bool StoreImage()
        {
            //ValidateDate();
            //ValidateLocation();

            //ValidateExPerform();????????
            //if (!ValidateSelectedArea())
            //{
            //    MessageBox.Show("Dummy position doesn't match ELM image");
            //    return false;
            //}

            //LocText
            fupImageModel.loctext = DummyLocation;
            //Remark
            //TreatmentDate
            //Irisk
            //Diag

            //DermaNet
            //Kenpos
            //if (Closeup or Macro or Micro) then SaveImage()


            switch (imageKind)
            {
                case KIND_ENUM.KIND_MAKRO:
                    //convert double to int
                    fupMakroModel.X1 = originalMakroModel.X1;
                    fupMakroModel.Y1 = originalMakroModel.Y1;
                    fupMakroModel.X2 = originalMakroModel.X2;
                    fupMakroModel.Y2 = originalMakroModel.Y2;
                    fupMakroModel.fupId = GetNewFup().id;
                    fupMakroModel.bms_id = 0;
                    fupImageModel.kind = (int)KIND_ENUM.KIND_MAKRO;
                    fupImageModel.kenpos = dummyImageIndex;
                    fupImageModel.userId = GlobalValue.Instance.UserID; //should get id from DB
                    break;
                case KIND_ENUM.KIND_MIKRO:
                    if (!bPointOnDummyImage)
                    {
                        MessageBox.Show("Missing point on Dummy image");
                        return false;
                    }

                    if (bPointOnMakroImage)
                    {
                        if (ShowMacroButton && _originalImage != null && PatientMakroImageList.Count > 0)
                        {
                            fupMikroModel.makroId = originalMikroModel.makroId;
                        }
                        else
                        {
                            fupMikroModel.makroId = 0;
                        }
                    }
                    else
                    {
                        fupMikroModel.makroId = 0;
                    }

                    if (bPointOnCloseUpImage)
                    {
                        if (ShowMacroButton && _originalImage != null && PatientCloseUpImageList.Count > 0)
                        {
                            fupMikroModel.closeupId = originalMikroModel.closeupId;
                        }
                        else
                        {
                            fupMikroModel.closeupId = 0;
                        }
                    }
                    else
                    {
                        fupMikroModel.closeupId = 0;
                    }

                    fupMikroModel.fupId = GetNewFup().id;
                    fupMikroModel.X = originalMikroModel.X;
                    fupMikroModel.Y = originalMikroModel.Y;

                    if (_originalImage != null)
                    {
                        fupMikroModel.X_Pic = originalMikroModel.X_Pic;
                        fupMikroModel.Y_Pic = originalMikroModel.Y_Pic;
                        fupImageModel.kenpos = _originalImage.Kenpos;
                    }
                    fupImageModel.kind = (int)KIND_ENUM.KIND_MIKRO;
                    fupImageModel.userId = GlobalValue.Instance.UserID; //should get id from DB
                    break;
                case KIND_ENUM.KIND_CLOSEUP:
                    if (ShowMacroButton && _originalImage != null && PatientMakroImageList.Count > 0)
                    {
                        fupCloseupModel.makroId = originalCloseupModel.makroId;

                        fupCloseupModel.X1 = originalCloseupModel.X1;
                        fupCloseupModel.Y1 = originalCloseupModel.Y1;
                        fupCloseupModel.X2 = originalCloseupModel.X2;
                        fupCloseupModel.Y2 = originalCloseupModel.Y2;
                        fupCloseupModel.fupId = GetNewFup().id;
                        fupImageModel.kind = (int)KIND_ENUM.KIND_CLOSEUP;
                        fupImageModel.kenpos = dummyImageIndex;
                        fupImageModel.userId = GlobalValue.Instance.UserID; //should get id from DB
                    }
                    break;
            }
            SaveImage();
            //update patient follow up date

            UpdateFupForRelativeImage();

            return true;
        }


        private bool ValidateSelectedArea()
        {
            if (bPointOnMakroImage || bPointOnCloseUpImage)
            {
                if (DummyLocation != _originalImage.Loctext)
                {
                    return false;
                }
            }

            return true;
        }

        private bool SaveImage()
        {

            //CheckDiskSpace();
            fupImageModel.defpath = _applicationSetting.ImagePath;
            fupImageModel.drivetype = 0;
            fupImageModel.deflabel = "";
            fupImageModel.imgname = "dummy";
            fupImageModel.treatment = DateTime.Today;

            //defPath
            //driveType
            //DefLabel
            //ImgName = "dummy"
            //id = patient.id
            fupImageModel.patientId = GlobalValue.Instance.CurrentPatient.id;
            //imageModel.patient = patientModel;
            //ContainerImage is Selected Macrio image
            //Image.Add()
            AddToImageTable();

            //get new image name
            //save image to new image path
            //update images table

            string imageName = CreateNameForImage();
            string imageFullPathAndName = CreateFullPathForImage(imageName);

            if (!Directory.Exists(_applicationSetting.ImagePath))
                Directory.CreateDirectory(_applicationSetting.ImagePath);

            if (File.Exists(imageFullPathAndName))
                File.Delete(imageFullPathAndName);

            //save image to local folder then update image name in DB            
            ImageHelpers.SaveBitmapSourceToFile(LocImage, imageFullPathAndName);
            if (File.Exists(imageFullPathAndName))
            {
                fupImageModel.imgname = imageName;
                fupImageModel = _repository.Images.Upsert(fupImageModel);
            }

            return true;
        }

        private string CreateFullPathForImage(string name)
        {
            return _applicationSetting.ImagePath + "\\" + name;
        }

        private string CreateNameForImage()
        {
            string strPrefix = string.Empty;
            switch (fupImageModel.kind)
            {
                case (int)KIND_ENUM.KIND_MAKRO:
                    strPrefix = "MAC";
                    break;
                case (int)KIND_ENUM.KIND_MIKRO:
                    strPrefix = "ELM";
                    break;
                case (int)KIND_ENUM.KIND_CLOSEUP:
                    strPrefix = "CUP";
                    break;
            }
            return $"{strPrefix}_{GlobalValue.Instance.CurrentPatient.id}_{fupImageModel.id}.jpg";
        }

        private void AddToImageTable()
        {
            //insert timestamps
            //get the latest timestamps id
            DateTime currentTime = DateTime.Now;
            var timestamp = _repository.Timestamps.Upsert(new Timestamp { date_created = currentTime, date_last_accessed = currentTime, pcname = Environment.MachineName });
            fupImageModel.tsId = timestamp.id;
            //insert into images table
            fupImageModel = _repository.Images.Upsert(fupImageModel);
            //get image id
            //insert to makro or closeup table
            AddTypeToTable();

            //add diagnoses into db
            //update timestamp time

            //insert diag id into imgdiag
            if (SelectedProvisionalDiagnosisList.Count != 0)
            {
                foreach (ProvisionalDiagnosis pd in SelectedProvisionalDiagnosisList)
                {
                    if (IsRecentDiag(pd))
                    {
                        //var diags = (from img in _dbImages
                        //             join imgd in _dbImgDiags on img.id equals imgd.imageId
                        //             join dg in _dbDiagnoses on imgd.diagnoseId equals dg.id
                        //             join dgs in _dbDiagsources on dg.diagsourceId equals dgs.id
                        //             where img.id == imageModel.id
                        //             select new
                        //             {
                        //                 id = dgs.id,
                        //                 origin_id = dgs.origin_id,
                        //                 shortname = dgs.shortname,
                        //                 favorite = dgs.favorite,
                        //                 risk = dgs.risk,
                        //                 parent_id = dgs.parent_id,
                        //                 category = dgs.category,
                        //                 did = dg.id
                        //             }).ToList();

                        _repository.ImgDiags.Upsert(new ImgDiag { imageId = fupImageModel.id, diagnoseId = pd.Id });
                    }
                    else
                    {
                        //var diags = (from img in _dbImages
                        //             join imgd in _dbImgDiags on img.id equals imgd.imageId
                        //             join dg in _dbDiagnoses on imgd.diagnoseId equals dg.id
                        //             join dgs in _dbDiagsources on dg.diagsourceId equals dgs.id
                        //             where img.id == imageModel.id
                        //             select new
                        //             {
                        //                 id = dgs.id,
                        //                 origin_id = dgs.origin_id,
                        //                 shortname = dgs.shortname,
                        //                 favorite = dgs.favorite,
                        //                 risk = dgs.risk,
                        //                 parent_id = dgs.parent_id,
                        //                 category = dgs.category,
                        //                 did = dg.id
                        //             }).ToList();

                        var di = _repository.Diagnoses.Upsert(new Diagnose { diagsourceId = pd.Id });
                        var imd = _repository.ImgDiags.Upsert(new ImgDiag { imageId = fupImageModel.id, diagnoseId = di.id });

                    }
                }
            }



        }

        private void AddTypeToTable()
        {
            //insert to Makro, mikro or closeup table
            switch (imageKind)
            {
                case KIND_ENUM.KIND_MAKRO:
                    fupMakroModel.imageId = fupImageModel.id;
                    //makroModel.image = imageModel;
                    fupMakroModel = _repository.Makros.Upsert(fupMakroModel);
                    //add new image to makro list
                    break;
                case KIND_ENUM.KIND_CLOSEUP:
                    fupCloseupModel.imageId = fupImageModel.id;
                    fupCloseupModel = _repository.Closeups.Upsert(fupCloseupModel);
                    break;
                case KIND_ENUM.KIND_MIKRO:
                    fupMikroModel.imageId = fupImageModel.id;
                    fupMikroModel = _repository.Mikros.Upsert(fupMikroModel);
                    break;
            }
        }

        private bool IsRecentDiag(ProvisionalDiagnosis pd)
        {
            return _dbDiagnoses.Where(di => di.diagsourceId == pd.Id).Count() > 0;
        }

        private void GoSaveDiagsourceList()
        {
            ProvisionalDiagnosisList.Where(di => di.IsChecked == true && SelectedProvisionalDiagnosisList.Count(spd => spd.Id == di.Id) == 0).ToList().ForEach(SelectedProvisionalDiagnosisList.Add);
            GoDiagnosis();
        }

        private void GoAllSkin()
        {
            throw new NotImplementedException();
        }


        private void GoMacro()
        {
            MacroAndCloseupListVisibility = Visibility.Visible;
            MacroAndCloseupListZIndex = 1;
        }

        private void GoDummy()
        {
            MacroAndCloseupListVisibility = Visibility.Collapsed;
            MacroAndCloseupListZIndex = 0;
        }

        private void GoNextDummyImage()
        {
            if (dummyImageIndex != 9)
                dummyImageIndex++;
            else
                dummyImageIndex = 1;
            DummyImage = new BitmapImage(new Uri($"pack://application:,,,/Images/Dummy/Ken/{dummyImageIndex}.bmp"));
            if (imageKind == KIND_ENUM.KIND_MAKRO)
                DummyColorImage = new BitmapImage(new Uri($"pack://application:,,,/Images/Dummy/MakroKen/{dummyImageIndex}.bmp"));
            if (imageKind == KIND_ENUM.KIND_MIKRO)
                DummyColorImage = new BitmapImage(new Uri($"pack://application:,,,/Images/Dummy/MikroKen/{dummyImageIndex}.bmp"));

            if (imageKind == KIND_ENUM.KIND_MAKRO)
            {
                if (selectedDummyImageIndex != dummyImageIndex)
                    RectangleVisible = Visibility.Collapsed;
                else
                    RectangleVisible = Visibility.Visible;
            }

            if (imageKind == KIND_ENUM.KIND_MIKRO)
            {
                if (selectedDummyImageIndex != dummyImageIndex)
                    PointVisible = Visibility.Collapsed;
                else
                    PointVisible = Visibility.Visible;
            }
        }

        private void GoPreviousDummyImage()
        {
            if (dummyImageIndex != 1)
                dummyImageIndex--;
            else
                dummyImageIndex = 9;

            DummyImage = new BitmapImage(new Uri($"pack://application:,,,/Images/Dummy/Ken/{dummyImageIndex}.bmp"));
            if (imageKind == KIND_ENUM.KIND_MAKRO)
                DummyColorImage = new BitmapImage(new Uri($"pack://application:,,,/Images/Dummy/MakroKen/{dummyImageIndex}.bmp"));
            if (imageKind == KIND_ENUM.KIND_MIKRO)
                DummyColorImage = new BitmapImage(new Uri($"pack://application:,,,/Images/Dummy/MikroKen/{dummyImageIndex}.bmp"));

            if (imageKind == KIND_ENUM.KIND_MAKRO)
            {
                if (selectedDummyImageIndex != dummyImageIndex)
                    RectangleVisible = Visibility.Collapsed;
                else
                    RectangleVisible = Visibility.Visible;
            }

            if (imageKind == KIND_ENUM.KIND_MIKRO)
            {
                if (selectedDummyImageIndex != dummyImageIndex)
                    PointVisible = Visibility.Collapsed;
                else
                    PointVisible = Visibility.Visible;
            }
        }

        private void GoAdd()
        {
            Diagsource newDiagsource = _dbDiagsources.FirstOrDefault(di => di.fullname == MyDiagnosis.Trim());
            //if not found, then create new item
            if (newDiagsource == null)
            {
                int newID = CreateDiagID();
                newDiagsource = _repository.Diagsources.Upsert(new Diagsource { origin_id = newID, fullname = MyDiagnosis.Trim(), risk = GetRiskFromDiagText(MyDiagnosis.Trim()) });
            }
            ProvisionalDiagnosisList.Clear();
            ProvisionalDiagnosisList.Add(new ProvisionalDiagnosis { IsChecked = true, DiagsourceFullName = newDiagsource.fullname, Id = newDiagsource.id, OriginId = newDiagsource.origin_id, diagsource = newDiagsource });
            GoSaveDiagsourceList();

        }

        private string GetRiskFromDiagText(string sDiag)
        {
            string sRisk = "S";
            List<string> keywords = new List<string>();
            keywords.Add("melanom");
            keywords.Add("dyspl");

            foreach (string kd in keywords)
            {
                if (sDiag.Contains(kd))
                {
                    sRisk = "MR";
                    break;
                }
            }

            return sRisk;
        }

        private int CreateDiagID()
        {
            return (int)(_dbDiagsources.OrderByDescending(di => di.origin_id).First().origin_id + 1);
        }

        private void GoCancel()
        {
            _keepLive = false;
            var navigationParameters = new NavigationParameters();
            navigationParameters.Add(Constants.FromForm, UserControlNames.FupLocalization);
            _regionManager.RequestNavigate(RegionNames.ContentRegion, fromForm, navigationParameters);
        }

        private void GoAll()
        {
            if (bShowFavoriteList || bShowRecentList)
            {
                bShowAllList = true;
                bShowFavoriteList = false;
                bShowRecentList = false;
            }
            else
            {
                bShowAllList = !bShowAllList;
                if (bShowAllList)
                {
                    GridVisibility = Visibility.Visible;
                    ZIndex = 1;
                }
                else
                {
                    GridVisibility = Visibility.Collapsed;
                    ZIndex = 0;
                }
            }

            ProvisionalDiagnosisList.Clear();
            List<Diagsource> diagsourceList = _dbDiagsources.Where(di => di.category == 0 && di.origin_id != 0).OrderBy(di => di.fullname).ToList();
            foreach (Diagsource di in diagsourceList)
            {
                ProvisionalDiagnosisList.Add(new ProvisionalDiagnosis { IsChecked = false, DiagsourceFullName = di.fullname, Id = di.id, OriginId = di.origin_id, diagsource = di });
            }
        }

        private void GoRecent()
        {
            if (bShowAllList || bShowFavoriteList)
            {
                bShowAllList = false;
                bShowFavoriteList = false;
                bShowRecentList = true;
            }
            else
            {
                bShowRecentList = !bShowRecentList;
                if (bShowRecentList)
                {
                    GridVisibility = Visibility.Visible;
                    ZIndex = 1;
                }
                else
                {
                    GridVisibility = Visibility.Collapsed;
                    ZIndex = 0;
                }
            }
            ProvisionalDiagnosisList.Clear();
            List<Diagsource> diagsourceList = _dbDiagsources.Where(di => _dbDiagnoses.Select(dg => dg.diagsourceId).ToList().Contains(di.id)).OrderBy(di => di.fullname).ToList();
            foreach (Diagsource di in diagsourceList)
            {
                ProvisionalDiagnosisList.Add(new ProvisionalDiagnosis { IsChecked = false, DiagsourceFullName = di.fullname, Id = di.id, OriginId = di.origin_id, diagsource = di });
            }
        }

        private void GoFavorite()
        {
            if (bShowAllList || bShowRecentList)
            {
                bShowAllList = false;
                bShowFavoriteList = true;
                bShowRecentList = false;
            }
            else
            {
                bShowFavoriteList = !bShowFavoriteList;
                if (bShowFavoriteList)
                {
                    GridVisibility = Visibility.Visible;
                    ZIndex = 1;
                }
                else
                {
                    GridVisibility = Visibility.Collapsed;
                    ZIndex = 0;
                }
            }
            ProvisionalDiagnosisList.Clear();
            List<Diagsource> diagsourceList = _dbDiagsources.Where(di => di.favorite == (int)imageKind).OrderBy(di => di.fullname).ToList();
            foreach (Diagsource di in diagsourceList)
            {
                ProvisionalDiagnosisList.Add(new ProvisionalDiagnosis { IsChecked = false, DiagsourceFullName = di.fullname, Id = di.id, OriginId = di.origin_id, diagsource = di });
            }
        }

        private void GoDiagnosis()
        {
            if (bShowAllList || bShowFavoriteList || bShowRecentList)
            {
                GridVisibility = Visibility.Collapsed;
                ZIndex = 0;
                bShowRecentList = false;
                bShowAllList = false;
                bShowRecentList = false;
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
            if (navigationContext.Parameters[Constants.FupImage] != null)
                LocImage = (BitmapSource)navigationContext.Parameters[Constants.FupImage];
            else
                LocImage = null;

            if (navigationContext.Parameters[Constants.ImageKind] != null)
                imageKind = (KIND_ENUM)Enum.Parse(typeof(KIND_ENUM), navigationContext.Parameters[Constants.ImageKind].ToString());

            if (navigationContext.Parameters[Constants.ImageSource] != null)
                imageSource = (IMAGING_SOURCES_INDEX)Enum.Parse(typeof(IMAGING_SOURCES_INDEX), navigationContext.Parameters[Constants.ImageSource].ToString());

            if (navigationContext.Parameters[Constants.OriginalImage] != null)
            {
                _originalImage = (ImageHandler)navigationContext.Parameters[Constants.OriginalImage];
            }
            else
            {
                _originalImage = null;
            }

            if (navigationContext.Parameters[Constants.FromForm] != null)
                fromForm = (string)navigationContext.Parameters[Constants.FromForm];
        }

        public void OnMouseDown(object sender, MouseCaptureArgs e)
        {
            MessageBox.Show("You can't not change location for a Follow Up image!");
            return;

            List<DEFMakroLokal> makroPosition;
            List<DEFMikroLokal> mikroPosition;
            List<DEFLocalTxt> txtposition;

            RectangleVisible = Visibility.Collapsed;
            PointVisible = Visibility.Collapsed;
            System.Windows.Controls.Image kenImage = e.AssociatedObject as System.Windows.Controls.Image;
            System.Drawing.Bitmap bmKenImage = new DataObject(DataFormats.Bitmap, kenImage.Source, true).GetData("System.Drawing.Bitmap") as System.Drawing.Bitmap;
            double pwWidthRate = DummyImage.PixelWidth / kenImage.ActualWidth;
            double pwHeightRate = DummyImage.PixelHeight / kenImage.ActualHeight;
            double pixWidth = e.X * pwWidthRate;
            double pixHeight = e.Y * pwHeightRate;
            System.Drawing.Color color = bmKenImage.GetPixel((int)pixWidth, (int)pixHeight);

            if (imageKind == KIND_ENUM.KIND_MAKRO)
            {
                makroPosition = _defMakroLokals.Where(po => po.PosMann == dummyImageIndex && po.PosX1 <= pixWidth && po.PosX2 >= pixWidth && po.PosY1 <= pixHeight && po.PosY2 >= pixHeight).ToList();
                if (makroPosition != null && makroPosition.Count > 0)
                {
                    txtposition = _defLocalTxts.Where(tp => tp.TxtPos == makroPosition[0].TxtLokal).ToList();
                    DummyLocation = txtposition != null && txtposition.Count > 0 ? txtposition[0].TxtLokal : string.Empty;

                    RectangleX = (double)(makroPosition[0].PosX1 / pwWidthRate);
                    RectangleY = (double)(makroPosition[0].PosY1 / pwHeightRate);
                    RectangleWidth = (double)((makroPosition[0].PosX2 - makroPosition[0].PosX1) / pwWidthRate);
                    RectangleHeight = (double)((makroPosition[0].PosY2 - makroPosition[0].PosY1) / pwHeightRate);
                    RectangleVisible = Visibility.Visible;
                }
            };

            if (imageKind == KIND_ENUM.KIND_MIKRO)
            {
                mikroPosition = _defMikroLokals.Where(po => po.PosMann == dummyImageIndex && po.r == color.R && po.g == color.G && po.b == color.B).ToList();
                if (mikroPosition != null && mikroPosition.Count > 0)
                {
                    if (mikroPosition[0].Jumppos != 0)
                    {
                        dummyImageIndex = mikroPosition[0].Jumppos.Value;
                        DummyColorImage = new BitmapImage(new Uri($"pack://application:,,,/Images/Dummy/MikroKen/{dummyImageIndex}.bmp"));
                        DummyImage = new BitmapImage(new Uri($"pack://application:,,,/Images/Dummy/Ken/{dummyImageIndex}.bmp"));
                        return;
                    }
                    txtposition = _defLocalTxts.Where(tp => tp.TxtPos == mikroPosition[0].TxtLokal).ToList();
                    DummyLocation = txtposition != null && txtposition.Count > 0 ? txtposition[0].TxtLokal : string.Empty;

                    PointX = e.X - 6;
                    PointY = e.Y - 6;
                    PointVisible = Visibility.Visible;

                    bPointOnDummyImage = true;
                }
            }
        }


        public void OnMouseMove(object sender, MouseCaptureArgs e)
        {
            //MessageBox.Show("mousemove");
        }

        public void OnMouseUp(object sender, MouseCaptureArgs e)
        {
            //MessageBox.Show("mouseup");
        }

        public Fup GetNewFup()
        {
            Fup fup;
            int? t_fupId;
            int fupId = 0;

            switch (imageKind)
            {
                case KIND_ENUM.KIND_MAKRO:
                    t_fupId = _dbMakros.Where(m => m.id == _originalImage.Id).SingleOrDefault().fupId;
                    fupId = t_fupId.HasValue ? t_fupId.Value : 0;
                    break;
                case KIND_ENUM.KIND_CLOSEUP:
                    t_fupId = _dbCloseups.Where(m => m.id == _originalImage.Id).SingleOrDefault().fupId;
                    fupId = t_fupId.HasValue ? t_fupId.Value : 0;
                    break;
                case KIND_ENUM.KIND_MIKRO:
                    t_fupId = _dbMikros.Where(m => m.id == _originalImage.Id).SingleOrDefault().fupId;
                    fupId = t_fupId.HasValue ? t_fupId.Value : 0;
                    break;
            }


            if (fupId == 0)
            {
                fup = new Fup { imageId = _originalImage.ImageId };
                fup = _repository.Fups.Upsert(fup);
            }
            else
            {
                var firstHisImageId = _dbFups.Where(f => f.id == fupId).SingleOrDefault().imageId;

                fup = new Fup { imageId = firstHisImageId };

                fup = _repository.Fups.Upsert(fup);
            }
            return fup;
        }

        private void UpdateFupForRelativeImage()
        {
            switch (imageKind)
            {
                case KIND_ENUM.KIND_MAKRO:
                    var closeupList = _dbCloseups.Where(i => i.makroId == _originalImage.Id).ToList();
                    closeupList.ForEach(i => i.makroId = fupMakroModel.id);
                    _repository.Closeups.Upsert(closeupList).ToList();

                    var mikroList = _dbMikros.Where(i => i.makroId == _originalImage.Id).ToList();
                    mikroList.ForEach(i => i.makroId = fupMakroModel.id);
                    _repository.Mikros.Upsert(mikroList).ToList();

                    break;
                case KIND_ENUM.KIND_CLOSEUP:
                    var miList = _dbMikros.Where(i => i.closeupId == _originalImage.Id).ToList();
                    miList.ForEach(i => i.closeupId = fupCloseupModel.id);
                    _repository.Mikros.Upsert(miList).ToList();
                    break;

            }
        }

    }
}
