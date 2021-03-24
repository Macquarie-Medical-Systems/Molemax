using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.EntityFrameworkCore.Internal;
using Molemax.App.Core;
using Molemax.Models;
using Molemax.Repository;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace Molemax.App.ViewModels
{
    public class ucSelection_DummyViewModel : BindableBase, IRegionMemberLifetime, INavigationAware
    {
        private IRegionManager _regionManager;
        private IMolemaxRepository _repository;
        private IAppSettings _applicationSetting;
        private string fromForm;
        private List<SelectionImage> selectionImageList;

        private ImageHandler _selectedImage;
        private KIND_ENUM _selectedImageKind;

        private int selectDummyImageIndex;

        private IEnumerable<Image> _dbImages
        {
            get { return _repository.Images.Get(); }
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
        private IEnumerable<Fup> _dbFups
        {
            get { return _repository.Fups.Get(); }
        }
        private IEnumerable<Mikro> _dbMikros
        {
            get { return _repository.Mikros.Get(); }
        }

        #region Property
        private ObservableCollection<ImageHandler> _imageHistoryList;
        public ObservableCollection<ImageHandler> ImageHistoryList
        {
            get { return _imageHistoryList; }
            set { SetProperty(ref _imageHistoryList, value); }
        }

        private BitmapSource _selectedDummyImage;
        public BitmapSource SelectedDummyImage
        {
            get { return _selectedDummyImage; }
            set { SetProperty(ref _selectedDummyImage, value); }
        }

        private ObservableCollection<ImageHandler> _patientMikroImageList;
        public ObservableCollection<ImageHandler> PatientMikroImageList
        {
            get { return _patientMikroImageList; }
            set { SetProperty(ref _patientMikroImageList, value); }
        }

        #region Dummy00
        private ObservableCollection<PointItem> _dummy00_HistoryMikroPointList;
        public ObservableCollection<PointItem> Dummy00_HistoryMikroPointList
        {
            get { return _dummy00_HistoryMikroPointList; }
            set { SetProperty(ref _dummy00_HistoryMikroPointList, value); }
        }

        private Visibility __dummy00_HistoryMikroPointVisible;
        public Visibility Dummy00_HistoryMikroPointVisible
        {
            get { return __dummy00_HistoryMikroPointVisible; }
            set { SetProperty(ref __dummy00_HistoryMikroPointVisible, value); }
        }

        private double _dummy00ImageWidth;
        public double Dummy00ImageWidth
        {
            get { return _dummy00ImageWidth; }
            set
            {
                SetProperty(ref _dummy00ImageWidth, value);
            }
        }

        private double _dummy00ImageHeight;
        public double Dummy00ImageHeight
        {
            get { return _dummy00ImageHeight; }
            set
            {
                SetProperty(ref _dummy00ImageHeight, value);
                Dummy00_HistoryMikroPointList = DrawMikroHistoryPointOnDummy(_dummy00ImageWidth, _dummy00ImageHeight, 1, Dummy00_HistoryMikroPointVisible);
            }
        }
        #endregion

        #region Dummy10
        private ObservableCollection<PointItem> _dummy10_HistoryMikroPointList;
        public ObservableCollection<PointItem> Dummy10_HistoryMikroPointList
        {
            get { return _dummy10_HistoryMikroPointList; }
            set { SetProperty(ref _dummy10_HistoryMikroPointList, value); }
        }

        private Visibility __dummy10_HistoryMikroPointVisible;
        public Visibility Dummy10_HistoryMikroPointVisible
        {
            get { return __dummy10_HistoryMikroPointVisible; }
            set { SetProperty(ref __dummy10_HistoryMikroPointVisible, value); }
        }

        private double _dummy10ImageWidth;
        public double Dummy10ImageWidth
        {
            get { return _dummy10ImageWidth; }
            set
            {
                SetProperty(ref _dummy10ImageWidth, value);
            }
        }

        private double _dummy10ImageHeight;
        public double Dummy10ImageHeight
        {
            get { return _dummy10ImageHeight; }
            set
            {
                SetProperty(ref _dummy10ImageHeight, value);
                Dummy10_HistoryMikroPointList = DrawMikroHistoryPointOnDummy(_dummy10ImageWidth, _dummy10ImageHeight, 4, Dummy10_HistoryMikroPointVisible);
            }
        }
        #endregion

        #region Dummy20
        private ObservableCollection<PointItem> _dummy20_HistoryMikroPointList;
        public ObservableCollection<PointItem> Dummy20_HistoryMikroPointList
        {
            get { return _dummy20_HistoryMikroPointList; }
            set { SetProperty(ref _dummy20_HistoryMikroPointList, value); }
        }

        private Visibility __dummy20_HistoryMikroPointVisible;
        public Visibility Dummy20_HistoryMikroPointVisible
        {
            get { return __dummy20_HistoryMikroPointVisible; }
            set { SetProperty(ref __dummy20_HistoryMikroPointVisible, value); }
        }

        private double _dummy20ImageWidth;
        public double Dummy20ImageWidth
        {
            get { return _dummy20ImageWidth; }
            set
            {
                SetProperty(ref _dummy20ImageWidth, value);
            }
        }

        private double _dummy20ImageHeight;
        public double Dummy20ImageHeight
        {
            get { return _dummy20ImageHeight; }
            set
            {
                SetProperty(ref _dummy20ImageHeight, value);
                Dummy20_HistoryMikroPointList = DrawMikroHistoryPointOnDummy(_dummy20ImageWidth, _dummy20ImageHeight, 7, Dummy20_HistoryMikroPointVisible);
            }
        }
        #endregion

        #region Dummy01
        private ObservableCollection<PointItem> _dummy01_HistoryMikroPointList;
        public ObservableCollection<PointItem> Dummy01_HistoryMikroPointList
        {
            get { return _dummy01_HistoryMikroPointList; }
            set { SetProperty(ref _dummy01_HistoryMikroPointList, value); }
        }

        private Visibility __dummy01_HistoryMikroPointVisible;
        public Visibility Dummy01_HistoryMikroPointVisible
        {
            get { return __dummy01_HistoryMikroPointVisible; }
            set { SetProperty(ref __dummy01_HistoryMikroPointVisible, value); }
        }

        private double _dummy01ImageWidth;
        public double Dummy01ImageWidth
        {
            get { return _dummy01ImageWidth; }
            set
            {
                SetProperty(ref _dummy01ImageWidth, value);
            }
        }

        private double _dummy01ImageHeight;
        public double Dummy01ImageHeight
        {
            get { return _dummy01ImageHeight; }
            set
            {
                SetProperty(ref _dummy01ImageHeight, value);
                Dummy01_HistoryMikroPointList = DrawMikroHistoryPointOnDummy(_dummy01ImageWidth, _dummy01ImageHeight, 2, Dummy01_HistoryMikroPointVisible);
            }
        }
        #endregion

        #region Dummy11
        private ObservableCollection<PointItem> _dummy11_HistoryMikroPointList;
        public ObservableCollection<PointItem> Dummy11_HistoryMikroPointList
        {
            get { return _dummy11_HistoryMikroPointList; }
            set { SetProperty(ref _dummy11_HistoryMikroPointList, value); }
        }

        private Visibility __dummy11_HistoryMikroPointVisible;
        public Visibility Dummy11_HistoryMikroPointVisible
        {
            get { return __dummy11_HistoryMikroPointVisible; }
            set { SetProperty(ref __dummy11_HistoryMikroPointVisible, value); }
        }

        private double _dummy11ImageWidth;
        public double Dummy11ImageWidth
        {
            get { return _dummy11ImageWidth; }
            set
            {
                SetProperty(ref _dummy11ImageWidth, value);
            }
        }

        private double _dummy11ImageHeight;
        public double Dummy11ImageHeight
        {
            get { return _dummy11ImageHeight; }
            set
            {
                SetProperty(ref _dummy11ImageHeight, value);
                Dummy11_HistoryMikroPointList = DrawMikroHistoryPointOnDummy(_dummy11ImageWidth, _dummy11ImageHeight, 5, Dummy11_HistoryMikroPointVisible);
            }
        }
        #endregion

        #region Dummy21
        private ObservableCollection<PointItem> _dummy21_HistoryMikroPointList;
        public ObservableCollection<PointItem> Dummy21_HistoryMikroPointList
        {
            get { return _dummy21_HistoryMikroPointList; }
            set { SetProperty(ref _dummy21_HistoryMikroPointList, value); }
        }

        private Visibility __dummy21_HistoryMikroPointVisible;
        public Visibility Dummy21_HistoryMikroPointVisible
        {
            get { return __dummy21_HistoryMikroPointVisible; }
            set { SetProperty(ref __dummy20_HistoryMikroPointVisible, value); }
        }

        private double _dummy21ImageWidth;
        public double Dummy21ImageWidth
        {
            get { return _dummy21ImageWidth; }
            set
            {
                SetProperty(ref _dummy21ImageWidth, value);
            }
        }

        private double _dummy21ImageHeight;
        public double Dummy21ImageHeight
        {
            get { return _dummy21ImageHeight; }
            set
            {
                SetProperty(ref _dummy21ImageHeight, value);
                Dummy21_HistoryMikroPointList = DrawMikroHistoryPointOnDummy(_dummy21ImageWidth, _dummy21ImageHeight, 8, Dummy21_HistoryMikroPointVisible);
            }
        }
        #endregion

        #region Dummy02
        private ObservableCollection<PointItem> _dummy02_HistoryMikroPointList;
        public ObservableCollection<PointItem> Dummy02_HistoryMikroPointList
        {
            get { return _dummy02_HistoryMikroPointList; }
            set { SetProperty(ref _dummy02_HistoryMikroPointList, value); }
        }

        private Visibility __dummy02_HistoryMikroPointVisible;
        public Visibility Dummy02_HistoryMikroPointVisible
        {
            get { return __dummy02_HistoryMikroPointVisible; }
            set { SetProperty(ref __dummy02_HistoryMikroPointVisible, value); }
        }

        private double _dummy02ImageWidth;
        public double Dummy02ImageWidth
        {
            get { return _dummy02ImageWidth; }
            set
            {
                SetProperty(ref _dummy02ImageWidth, value);
            }
        }

        private double _dummy02ImageHeight;
        public double Dummy02ImageHeight
        {
            get { return _dummy02ImageHeight; }
            set
            {
                SetProperty(ref _dummy02ImageHeight, value);
                Dummy02_HistoryMikroPointList = DrawMikroHistoryPointOnDummy(_dummy02ImageWidth, _dummy02ImageHeight, 3, Dummy02_HistoryMikroPointVisible);
            }
        }
        #endregion

        #region Dummy12
        private ObservableCollection<PointItem> _dummy12_HistoryMikroPointList;
        public ObservableCollection<PointItem> Dummy12_HistoryMikroPointList
        {
            get { return _dummy12_HistoryMikroPointList; }
            set { SetProperty(ref _dummy12_HistoryMikroPointList, value); }
        }

        private Visibility __dummy12_HistoryMikroPointVisible;
        public Visibility Dummy12_HistoryMikroPointVisible
        {
            get { return __dummy12_HistoryMikroPointVisible; }
            set { SetProperty(ref __dummy12_HistoryMikroPointVisible, value); }
        }

        private double _dummy12ImageWidth;
        public double Dummy12ImageWidth
        {
            get { return _dummy12ImageWidth; }
            set
            {
                SetProperty(ref _dummy12ImageWidth, value);
            }
        }

        private double _dummy12ImageHeight;
        public double Dummy12ImageHeight
        {
            get { return _dummy12ImageHeight; }
            set
            {
                SetProperty(ref _dummy12ImageHeight, value);
                Dummy12_HistoryMikroPointList = DrawMikroHistoryPointOnDummy(_dummy12ImageWidth, _dummy12ImageHeight, 6, Dummy12_HistoryMikroPointVisible);
            }
        }
        #endregion

        #region Dummy22
        private ObservableCollection<PointItem> _dummy22_HistoryMikroPointList;
        public ObservableCollection<PointItem> Dummy22_HistoryMikroPointList
        {
            get { return _dummy22_HistoryMikroPointList; }
            set { SetProperty(ref _dummy22_HistoryMikroPointList, value); }
        }

        private Visibility __dummy22_HistoryMikroPointVisible;
        public Visibility Dummy22_HistoryMikroPointVisible
        {
            get { return __dummy22_HistoryMikroPointVisible; }
            set { SetProperty(ref __dummy22_HistoryMikroPointVisible, value); }
        }

        private double _dummy22ImageWidth;
        public double Dummy22ImageWidth
        {
            get { return _dummy22ImageWidth; }
            set
            {
                SetProperty(ref _dummy22ImageWidth, value);
            }
        }

        private double _dummy22ImageHeight;
        public double Dummy22ImageHeight
        {
            get { return _dummy22ImageHeight; }
            set
            {
                SetProperty(ref _dummy22ImageHeight, value);
                Dummy22_HistoryMikroPointList = DrawMikroHistoryPointOnDummy(_dummy22ImageWidth, _dummy22ImageHeight, 9, Dummy22_HistoryMikroPointVisible);
            }
        }
        #endregion

        #region SelectedDummy
        private ObservableCollection<PointItem> _selectedDummy_HistoryMikroPointList;
        public ObservableCollection<PointItem> SelectedDummy_HistoryMikroPointList
        {
            get { return _selectedDummy_HistoryMikroPointList; }
            set { SetProperty(ref _selectedDummy_HistoryMikroPointList, value); }
        }

        private Visibility _selectedDummy_HistoryMikroPointVisible;
        public Visibility SelectedDummy_HistoryMikroPointVisible
        {
            get { return _selectedDummy_HistoryMikroPointVisible; }
            set { SetProperty(ref _selectedDummy_HistoryMikroPointVisible, value); }
        }

        private double _selectedDummyImageWidth;
        public double SelectedDummyImageWidth
        {
            get { return _selectedDummyImageWidth; }
            set
            {
                SetProperty(ref _selectedDummyImageWidth, value);
            }
        }

        private double _selectedDummyImageHeight;
        public double SelectedDummyImageHeight
        {
            get { return _selectedDummyImageHeight; }
            set
            {
                SetProperty(ref _selectedDummyImageHeight, value);
                SelectedDummy_HistoryMikroPointList = DrawMikroHistoryPointOnDummy(_selectedDummyImageWidth, _selectedDummyImageHeight, selectDummyImageIndex, SelectedDummy_HistoryMikroPointVisible);
            }
        }
        #endregion

        #endregion

        #region Command
        public DelegateCommand<object> GoFollowUpCommand { get; set; }
        public DelegateCommand GoTrendingCommand { get; set; }
        public DelegateCommand GoDetailsCommand { get; set; }
        public DelegateCommand GoImageFileImportCommand { get; set; }
        public DelegateCommand GoBackCommand { get; set; }
        public DelegateCommand Go33Command { get; set; }
        public DelegateCommand<object> GoImageHistoryMouseLeftButtonDownCommand { get; set; }
        public DelegateCommand<object> GoImageMouseLeftButtonDownCommand { get; set; }
        public DelegateCommand<object> GoSelectedDummyClickedCommand { get; set; }
        #endregion

        private bool _keepLive = false;
        public bool KeepAlive
        {
            get { return _keepLive; }
        }

        public ucSelection_DummyViewModel(IRegionManager regionManager, IMolemaxRepository molemaxRepository, IAppSettings applicationSetting)
        {
            _regionManager = regionManager;
            _repository = molemaxRepository;
            _applicationSetting = applicationSetting;
            selectDummyImageIndex = 1;
            GoFollowUpCommand = new DelegateCommand<object>(GoFollowUp);
            GoTrendingCommand = new DelegateCommand(GoTrending);
            GoDetailsCommand = new DelegateCommand(GoDetails);
            GoImageFileImportCommand = new DelegateCommand(GoImageFileImport);
            GoBackCommand = new DelegateCommand(GoBack);
            GoImageHistoryMouseLeftButtonDownCommand = new DelegateCommand<object>(GoImageHistoryMouseLeftButtonDown);
            GoImageMouseLeftButtonDownCommand = new DelegateCommand<object>(GoImageMouseLeftButtonDown);
            GoSelectedDummyClickedCommand = new DelegateCommand<object>(GoSelectedDummyClicked);
            Go33Command = new DelegateCommand(Go33);

            SelectedDummyImage = new BitmapImage(new Uri($"pack://application:,,,/Images/Dummy/Ken/{selectDummyImageIndex}.bmp"));
            selectionImageList = new List<SelectionImage>();

            Initialize();
        }

        private void Initialize()
        {
            ImageHistoryList = new ObservableCollection<ImageHandler>();
            GetPatientMikroImages();
            //LoadHistoryMikroPoint();
        }


        private void LoadHistoryMikroPoint()
        {
            selectionImageList = CreateImageArray();
        }

        private List<SelectionImage> CreateImageArray()
        {

            SelectionImage si;
            List<SelectionImage> returnList = new List<SelectionImage>();
            //get Max fup id and relative image id from fup and image table
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



            //get closeup records that does not have fupid
            var closeupWithNoFupList = _dbCloseups.Join(_dbImages, cu => cu.imageId, image => image.id, (closeup, image) => new { closeup, image })
                .Where(item => item.image.patientId == GlobalValue.Instance.CurrentPatient.id)
                .Where(item => item.closeup.fupId == 0)
                .Where(item => !maxfupList.Any(b => b.ImageId == item.closeup.imageId)).ToList();

            //get closeup records that is in max fup list
            var closeupWithFupList = _dbCloseups.Join(_dbImages, cu => cu.imageId, image => image.id, (closeup, image) => new { closeup, image })
                .Where(item => item.image.patientId == GlobalValue.Instance.CurrentPatient.id)
                .Where(item => maxfupList.Any(b => b.MaxFup == item.closeup.fupId)).ToList();



            //get mikro records that does not have fupid
            var mikroWithNoFupList = _dbMikros.Join(_dbImages, mi => mi.imageId, image => image.id, (mikro, image) => new { mikro, image })
                .Where(item => item.image.patientId == GlobalValue.Instance.CurrentPatient.id)
                .Where(item => item.mikro.fupId == 0)
                .Where(item => !maxfupList.Any(b => b.ImageId == item.mikro.imageId)).ToList();

            //get mikro records that is in max fup list
            var mikroWithFupList = _dbMikros.Join(_dbImages, mi => mi.imageId, image => image.id, (mikro, image) => new { mikro, image })
                .Where(item => item.image.patientId == GlobalValue.Instance.CurrentPatient.id)
                .Where(item => maxfupList.Any(b => b.MaxFup == item.mikro.fupId)).ToList();

            //final makro list
            var makroList = makroWithNoFupList.Concat(makroWithFupList).OrderByDescending(item => item.image.tsId).ToList();


            //final closeup list
            var closeupList = closeupWithNoFupList.Concat(closeupWithFupList).OrderByDescending(item => item.image.tsId).ToList();

            //final closeup list
            var mikroList = mikroWithNoFupList.Concat(mikroWithFupList).OrderByDescending(item => item.image.tsId).ToList();



            var macumiList = makroList.Join(closeupList, m => m.makro.id, c => c.closeup.makroId, (x, y) => new { makro = x, closeup = y })
                                   .Join(mikroList, mc => mc.closeup.closeup.id, mi => mi.mikro.closeupId, (x, y) => new { makro = x.makro, closeup = x.closeup, mikro = y }).ToList();

            var mamiList = makroList.Join(mikroList, ma => ma.makro.id, mi => mi.mikro.makroId, (x, y) => new { makro = x, mikro = y }).ToList();

            var macuList = makroList.Join(closeupList, m => m.makro.id, c => c.closeup.makroId, (x, y) => new { makro = x, closeup = y })
                         .Where(c => !mikroList.Select(b => b.mikro.closeupId).Contains(c.closeup.closeup.id)).ToList();

            var maList = makroList.Where(c => !closeupList.Select(b => b.closeup.makroId).Contains(c.makro.id))
                                  .Where(c => !mikroList.Select(b => b.mikro.makroId).Contains(c.makro.id)).ToList();
            var miList = mikroList.Where(c => c.mikro.makroId == 0 && c.mikro.closeupId == 0).ToList();


            foreach (var item in macumiList)
            {
                si = new SelectionImage();
                si.Makro = new ImageHandler();
                si.Makro.Id = item.makro.makro.id;
                si.Makro.ImageId = item.makro.makro.imageId;
                si.Makro.Loctext = item.makro.image.loctext;
                si.Makro.Kenpos = item.makro.image.kenpos;
                si.Makro.Image = new BitmapImage(new Uri(item.makro.image.defpath + "\\" + item.makro.image.imgname));

                si.CloseUp = new ImageHandler();
                si.CloseUp.Id = item.closeup.closeup.id;
                si.CloseUp.ImageId = item.closeup.closeup.imageId;
                si.CloseUp.Loctext = item.closeup.image.loctext;
                si.CloseUp.Kenpos = item.closeup.image.kenpos;
                si.CloseUp.Image = new BitmapImage(new Uri(item.closeup.image.defpath + "\\" + item.closeup.image.imgname));

                si.Mikro = new ImageHandler();
                si.Mikro.Id = item.mikro.mikro.id;
                si.Mikro.ImageId = item.mikro.mikro.imageId;
                si.Mikro.Loctext = item.mikro.image.loctext;
                si.Mikro.Kenpos = item.mikro.image.kenpos;
                si.Mikro.Image = new BitmapImage(new Uri(item.mikro.image.defpath + "\\" + item.mikro.image.imgname));
                returnList.Add(si);
            }

            foreach (var item in mamiList)
            {
                si = new SelectionImage();
                si.Makro = new ImageHandler();
                si.Makro.Id = item.makro.makro.id;
                si.Makro.ImageId = item.makro.makro.imageId;
                si.Makro.Loctext = item.makro.image.loctext;
                si.Makro.Kenpos = item.makro.image.kenpos;
                si.Makro.Image = new BitmapImage(new Uri(item.makro.image.defpath + "\\" + item.makro.image.imgname));

                //si.CloseUp.Image = new BitmapImage(new Uri($"pack://application:,,,/Images/Dummy/Ken/{item.makro.image.kenpos}.bmp"));
                si.CloseUp = new ImageHandler();
                si.CloseUp.Image = new BitmapImage(new Uri($"pack://application:,,,/Images/black.bmp"));

                si.Mikro = new ImageHandler();
                si.Mikro.Id = item.mikro.mikro.id;
                si.Mikro.ImageId = item.mikro.mikro.imageId;
                si.Mikro.Loctext = item.mikro.image.loctext;
                si.Mikro.Kenpos = item.mikro.image.kenpos;
                si.Mikro.Image = new BitmapImage(new Uri(item.mikro.image.defpath + "\\" + item.mikro.image.imgname));
                returnList.Add(si);
            }

            foreach (var item in macuList)
            {
                si = new SelectionImage();
                si.Makro = new ImageHandler();
                si.Makro.Id = item.makro.makro.id;
                si.Makro.ImageId = item.makro.makro.imageId;
                si.Makro.Loctext = item.makro.image.loctext;
                si.Makro.Kenpos = item.makro.image.kenpos;
                si.Makro.Image = new BitmapImage(new Uri(item.makro.image.defpath + "\\" + item.makro.image.imgname));

                si.CloseUp = new ImageHandler();
                si.CloseUp.Id = item.closeup.closeup.id;
                si.CloseUp.ImageId = item.closeup.closeup.imageId;
                si.CloseUp.Loctext = item.closeup.image.loctext;
                si.CloseUp.Kenpos = item.closeup.image.kenpos;
                si.CloseUp.Image = new BitmapImage(new Uri(item.closeup.image.defpath + "\\" + item.closeup.image.imgname));

                //si.Mikro.Image = new BitmapImage(new Uri($"pack://application:,,,/Images/Dummy/Ken/{item.makro.image.kenpos}.bmp"));
                si.Mikro = new ImageHandler();
                si.Mikro.Image = new BitmapImage(new Uri($"pack://application:,,,/Images/black.bmp"));

                returnList.Add(si);
            }

            foreach (var item in maList)
            {
                si = new SelectionImage();
                si.Makro = new ImageHandler();
                si.Makro.Id = item.makro.id;
                si.Makro.ImageId = item.makro.imageId;
                si.Makro.Loctext = item.image.loctext;
                si.Makro.Kenpos = item.image.kenpos;
                si.Makro.Image = new BitmapImage(new Uri(item.image.defpath + "\\" + item.image.imgname));

                //si.CloseUp.Image = new BitmapImage(new Uri($"pack://application:,,,/Images/Dummy/Ken/{item.image.kenpos}.bmp"));
                //si.Mikro.Image = new BitmapImage(new Uri($"pack://application:,,,/Images/Dummy/Ken/{item.image.kenpos}.bmp"));
                si.CloseUp = new ImageHandler();
                si.CloseUp.Image = new BitmapImage(new Uri($"pack://application:,,,/Images/black.bmp"));

                si.Mikro = new ImageHandler();
                si.Mikro.Image = new BitmapImage(new Uri($"pack://application:,,,/Images/black.bmp"));

                returnList.Add(si);
            }

            foreach (var item in miList)
            {
                si = new SelectionImage();

                //si.Makro.Image = new BitmapImage(new Uri($"pack://application:,,,/Images/Dummy/Ken/{item.image.kenpos}.bmp"));
                //si.CloseUp.Image = new BitmapImage(new Uri($"pack://application:,,,/Images/Dummy/Ken/{item.image.kenpos}.bmp"));
                si.Makro = new ImageHandler();
                si.Makro.Image = new BitmapImage(new Uri($"pack://application:,,,/Images/black.bmp"));

                si.CloseUp = new ImageHandler();
                si.CloseUp.Image = new BitmapImage(new Uri($"pack://application:,,,/Images/black.bmp"));

                si.Mikro = new ImageHandler();
                si.Mikro.Id = item.mikro.id;
                si.Mikro.ImageId = item.mikro.imageId;
                si.Mikro.Loctext = item.image.loctext;
                si.Mikro.Kenpos = item.image.kenpos;
                si.Mikro.Image = new BitmapImage(new Uri(item.image.defpath + "\\" + item.image.imgname));
                returnList.Add(si);
            }

            return returnList;
        }

        private ObservableCollection<PointItem> DrawMikroHistoryPointOnDummy(double DummyImageWidth, double DummyImageHeight, int dummyImageIndex, Visibility HistoryMikroPointVisible)
        {
            if (DummyImageWidth == 0 || DummyImageHeight == 0)
                return null;

            ObservableCollection<PointItem> HistoryMikroPointList = new ObservableCollection<PointItem>();
            //draw history points on dummy image

            if (PatientMikroImageList.Count>0)
            {
                int index = 0;
                foreach (var i in PatientMikroImageList)
                {
                    if (i.Kenpos == dummyImageIndex)
                        HistoryMikroPointList.Add(new PointItem() {MikroId=i.Id, IndexInList= index, X = i.DummyPointX * DummyImageWidth / 1000, Y = i.DummyPointY * DummyImageHeight / 1000 });
                    index++;
                }
            }

            if (HistoryMikroPointList.Count > 0)
                HistoryMikroPointVisible = Visibility.Visible;
            else
                HistoryMikroPointVisible = Visibility.Collapsed;

            return HistoryMikroPointList;
        }
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext.Parameters[Constants.FromForm] != null)
                fromForm = (string)navigationContext.Parameters[Constants.FromForm];
        }

        #region command functions
        private void GoSelectedDummyClicked(object obj)
        {
            int mikroId = ((PointItem)obj).MikroId;
            int? t_fupId = _dbMikros.Where(mi => mi.id == mikroId).SingleOrDefault().fupId;
            int? t_imageId = _dbMikros.Where(mi => mi.id == mikroId).SingleOrDefault().imageId;
            int fupId = t_fupId.HasValue ? t_fupId.Value : 0;
            int curentImageId = t_imageId.HasValue ? t_imageId.Value : 0;

            _selectedImage = PatientMikroImageList[((PointItem)obj).IndexInList];
            _selectedImageKind = KIND_ENUM.KIND_MIKRO;

            if (fupId != 0)
            {
                //get image Id that beginning of history
                var firstHisImageId = _dbFups.Where(f => f.id == fupId).SingleOrDefault().imageId;
                //get all fups belong to the first image
                var fupList = _dbFups.Where(f => f.imageId == firstHisImageId).Select(i => i.id);//.ToList().Remove(fupId);
                                                                                                 //get all closeup image id belong to the fist image
                var hisImageIdList = _dbMikros.Where(i => fupList.Contains(i.fupId.Value)).Select(i => i.imageId).ToList();
                hisImageIdList.Add(firstHisImageId);

                //get information from image table and convert it to ObservableCollection list
                var tempImageList = _dbImages.Join(_dbTimestamps, i => i.tsId, ts => ts.id, (x, y) => new { image = x, ts = y })
                    .Where(i => hisImageIdList.Contains(i.image.id))
                    .OrderByDescending(i => i.ts.id)
                    .Select(i => new ImageHandler
                    {
                        ImageId = i.image.id,
                        Loctext = i.image.loctext,
                        CreateDate = i.ts.date_created.ToString("d"),
                        Image = new BitmapImage(new Uri(i.image.defpath + "\\" + i.image.imgname)),
                        ImageHistoryTextBackground = Brushes.Transparent
                    });

                ImageHistoryList = new ObservableCollection<ImageHandler>(tempImageList);
            }
            else
            {
                var tempImageList = _dbImages.Join(_dbTimestamps, i => i.tsId, ts => ts.id, (x, y) => new { image = x, ts = y })
                    .Where(i => i.image.id == curentImageId)
                    .Select(i => new ImageHandler
                    {
                        ImageId = i.image.id,
                        Loctext = i.image.loctext,
                        CreateDate = i.ts.date_created.ToString("d"),
                        Image = new BitmapImage(new Uri(i.image.defpath + "\\" + i.image.imgname)),
                        ImageHistoryTextBackground = Brushes.Transparent
                    });

                    ImageHistoryList = new ObservableCollection<ImageHandler>(tempImageList);
            }
        }
        private void GoImageHistoryMouseLeftButtonDown(object obj)
        {
            var imageHandler = obj as ImageHandler;
            var temp = ImageHistoryList.Where(i => 1 == 1).ToList();
            if (temp[ImageHistoryList.IndexOf(imageHandler)].ImageHistoryTextBackground == Brushes.Transparent)
                temp[ImageHistoryList.IndexOf(imageHandler)].ImageHistoryTextBackground = Brushes.Red;
            else
                temp[ImageHistoryList.IndexOf(imageHandler)].ImageHistoryTextBackground = Brushes.Transparent;
            ImageHistoryList = new ObservableCollection<ImageHandler>(temp);

        }
        private void GoImageMouseLeftButtonDown(object obj)
        {
            SelectionImage si = new SelectionImage();
            selectDummyImageIndex = Convert.ToInt32(obj);

            SelectedDummyImage = new BitmapImage(new Uri($"pack://application:,,,/Images/Dummy/Ken/{selectDummyImageIndex}.bmp"));

            SelectedDummy_HistoryMikroPointList = DrawMikroHistoryPointOnDummy(_selectedDummyImageWidth, _selectedDummyImageHeight, selectDummyImageIndex, SelectedDummy_HistoryMikroPointVisible);

        }
        private void GoBack()
        {
            _keepLive = false;

            if (fromForm == UserControlNames.FupImageImport || fromForm == UserControlNames.FupLiveVideo || fromForm == UserControlNames.FupLocalization)
                _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.PatientMenu);
            else
                _regionManager.RequestNavigate(RegionNames.ContentRegion, fromForm);
        }
        private void GoImageFileImport()
        {
            throw new NotImplementedException();
        }
        private void GoDetails()
        {
            throw new NotImplementedException();
        }
        private void GoTrending()
        {
            throw new NotImplementedException();
        }
        private void GoFollowUp(object sender)
        {
            _keepLive = false;
            var navigationParameters = new NavigationParameters();
            navigationParameters.Add(Constants.ParaImage, _selectedImage);
            navigationParameters.Add(Constants.ImageKind, _selectedImageKind);
            navigationParameters.Add(Constants.FromForm, UserControlNames.Selection_Dummy);

            switch (((System.Windows.Controls.ComboBoxItem)sender).Name)
            {
                case Constants.ImportSourceLiveVideo:
                    _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.FupLiveVideo, navigationParameters);
                    break;
                case Constants.ImportSourceFileImport:
                    _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.FupImageImport, navigationParameters);
                    break;
            }
        }
        private bool GetPatientMikroImages()
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
            var mikroWithNoFupList = _dbMikros.Join(_dbImages, cu => cu.imageId, image => image.id, (mikro, image) => new { mikro, image })
                .Where(item => item.image.patientId == GlobalValue.Instance.CurrentPatient.id)
                .Where(item => item.mikro.fupId == 0)
                .Where(item => !maxfupList.Any(b => b.ImageId == item.mikro.imageId)).ToList();

            //get closeup records that is in max fup list
            var mikroWithFupList = _dbMikros.Join(_dbImages, cu => cu.imageId, image => image.id, (mikro, image) => new { mikro, image })
                .Where(item => item.image.patientId == GlobalValue.Instance.CurrentPatient.id)
                .Where(item => maxfupList.Any(b => b.MaxFup == item.mikro.fupId)).ToList();

            //final closeup list
            var mikroList = mikroWithNoFupList.Concat(mikroWithFupList).OrderByDescending(item => item.image.tsId).ToList();

            var tempList = _dbImages.Join(mikroList, im => im.id, mi => mi.mikro.imageId, (im, mi) => new { im, mi }).Join(_dbTimestamps, i => i.im.tsId, ts => ts.id, (i, ts) => new { i, ts })
                                                  .Where(item => item.i.im.kind == 2 && item.i.im.patientId == GlobalValue.Instance.CurrentPatient.id)
                                                  .OrderByDescending(item => item.i.im.tsId)
                                                  .Select(m => new ImageHandler
                                                  {
                                                      Id = m.i.mi.mikro.id,
                                                      ImageId = m.i.im.id,
                                                      ContainerImageId = m.i.mi.mikro.id,
                                                      Kenpos = m.i.im.kenpos,
                                                      Loctext = m.i.im.loctext,
                                                      CreateDate = m.ts.date_created.ToString("d"),
                                                      Image = new BitmapImage(new Uri(m.i.im.defpath + "\\" + m.i.im.imgname)),
                                                      SmallKen = new BitmapImage(new Uri($"pack://application:,,,/Images/Dummy/SmallKen/{m.i.im.kenpos}.bmp")),
                                                      DummyPointX = m.i.mi.mikro.X,
                                                      DummyPointY = m.i.mi.mikro.Y,
                                                      FullPicPointX = m.i.mi.mikro.X_Pic,
                                                      FullPicPointY = m.i.mi.mikro.Y_Pic,
                                                      LinkToMakroId = m.i.mi.mikro.makroId.HasValue ? m.i.mi.mikro.makroId.Value : 0,
                                                      LinkToCloseUpId = m.i.mi.mikro.closeupId.HasValue ? m.i.mi.mikro.closeupId.Value : 0
                                                  });

            PatientMikroImageList = new ObservableCollection<ImageHandler>(tempList);

            return PatientMikroImageList.Count() > 0;
        }
        private void Go33()
        {
            _keepLive = false;

            var navigationParameters = new NavigationParameters();
            navigationParameters.Add(Constants.FromForm, fromForm);

            _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.Selection, navigationParameters);
        }
        #endregion
    }


}
