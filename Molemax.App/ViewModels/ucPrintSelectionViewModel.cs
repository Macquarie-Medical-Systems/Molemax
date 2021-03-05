using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
    public class ucPrintSelectionViewModel : BindableBase, IRegionMemberLifetime, INavigationAware
    {
        private IRegionManager _regionManager;
        private IMolemaxRepository _repository;
        private IAppSettings _applicationSetting;
        private string fromForm;
        private List<SelectionImage> selectionImageList;
        private List<SelectionImage> displayImageList;
        private ImageHandler _selectedImage;
        private KIND_ENUM _selectedImageKind;
        private KIND_ENUM _imageOrderByKind;
        private int _iStartIndex = 0;
        private int _iMakroImageCount = 0;
        private int _iMikroImageCount = 0;
        private int _iCloseUpImageCount = 0;
        private List<SelectionImage> _selectedImageList;
        private int imageIndex = 0;

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
        public string _macroButtonContent;
        public string MacroButtonContent
        {
            get { return _macroButtonContent; }
            set { SetProperty(ref _macroButtonContent, value); }
        }

        public string _closeUpButtonContent;
        public string CloseUpButtonContent
        {
            get { return _closeUpButtonContent; }
            set { SetProperty(ref _closeUpButtonContent, value); }
        }

        public string _microButtonContent;
        public string MicroUpButtonContent
        {
            get { return _microButtonContent; }
            set { SetProperty(ref _microButtonContent, value); }
        }

        private ObservableCollection<ImageHandler> _imageHistoryList;
        public ObservableCollection<ImageHandler> ImageHistoryList
        {
            get { return _imageHistoryList; }
            set { SetProperty(ref _imageHistoryList, value); }
        }

        #region Image00
        public string _image00Title;
        public string Image00Title
        {
            get { return _image00Title; }
            set { SetProperty(ref _image00Title, value); }
        }

        public BitmapImage _image00;
        public BitmapImage Image00
        {
            get { return _image00; }
            set { SetProperty(ref _image00, value); }
        }

        public string _image00Loctext;
        public string Image00Loctext
        {
            get { return _image00Loctext; }
            set { SetProperty(ref _image00Loctext, value); }
        }

        private double _image00RectangleX;
        public double Image00RectangleX
        {
            get { return _image00RectangleX; }
            set { SetProperty(ref _image00RectangleX, value); }
        }

        private double _image00RectangleY;
        public double Image00RectangleY
        {
            get { return _image00RectangleY; }
            set { SetProperty(ref _image00RectangleY, value); }
        }

        private double _image00RectangleWidth;
        public double Image00RectangleWidth
        {
            get { return _image00RectangleWidth; }
            set { SetProperty(ref _image00RectangleWidth, value); }
        }

        private double _image00RectangleHeight;
        public double Image00RectangleHeight
        {
            get { return _image00RectangleHeight; }
            set { SetProperty(ref _image00RectangleHeight, value); }
        }

        //point X on dummy image
        private double _image00PointX;
        public double Image00PointX
        {
            get { return _image00PointX; }
            set { SetProperty(ref _image00PointX, value); }
        }

        //point Y on dummy image
        private double _image00PointY;
        public double Image00PointY
        {
            get { return _image00PointY; }
            set { SetProperty(ref _image00PointY, value); }
        }

        //show point on dummy image
        private Visibility _image00PointVisible;
        public Visibility Image00PointVisible
        {
            get { return _image00PointVisible; }
            set { SetProperty(ref _image00PointVisible, value); }
        }

        private Visibility _image00RectangleVisible;
        public Visibility Image00RectangleVisible
        {
            get { return _image00RectangleVisible; }
            set { SetProperty(ref _image00RectangleVisible, value); }
        }

        public Brush _image00TextBackground;
        public Brush Image00TextBackground
        {
            get { return _image00TextBackground; }
            set { SetProperty(ref _image00TextBackground, value); }
        }
        #endregion

        #region Image01
        public string _image01Title;
        public string Image01Title
        {
            get { return _image01Title; }
            set { SetProperty(ref _image01Title, value); }
        }

        public BitmapImage _image01;
        public BitmapImage Image01
        {
            get { return _image01; }
            set { SetProperty(ref _image01, value); }
        }

        public string _image01Loctext;
        public string Image01Loctext
        {
            get { return _image01Loctext; }
            set { SetProperty(ref _image01Loctext, value); }
        }

        //point X on dummy image
        private double _image01PointX;
        public double Image01PointX
        {
            get { return _image01PointX; }
            set { SetProperty(ref _image01PointX, value); }
        }

        //point Y on dummy image
        private double _image01PointY;
        public double Image01PointY
        {
            get { return _image01PointY; }
            set { SetProperty(ref _image01PointY, value); }
        }

        //show point on dummy image
        private Visibility _image01PointVisible;
        public Visibility Image01PointVisible
        {
            get { return _image01PointVisible; }
            set { SetProperty(ref _image01PointVisible, value); }
        }

        public Brush _image01TextBackground;
        public Brush Image01TextBackground
        {
            get { return _image01TextBackground; }
            set { SetProperty(ref _image01TextBackground, value); }
        }
        #endregion

        #region Image02
        public string _image02Title;
        public string Image02Title
        {
            get { return _image02Title; }
            set { SetProperty(ref _image02Title, value); }
        }

        public BitmapImage _image02;
        public BitmapImage Image02
        {
            get { return _image02; }
            set { SetProperty(ref _image02, value); }
        }

        public string _image02Loctext;
        public string Image02Loctext
        {
            get { return _image02Loctext; }
            set { SetProperty(ref _image02Loctext, value); }
        }

        public Brush _image02TextBackground;
        public Brush Image02TextBackground
        {
            get { return _image02TextBackground; }
            set { SetProperty(ref _image02TextBackground, value); }
        }
        #endregion

        #region Image10
        public string _image10Title;
        public string Image10Title
        {
            get { return _image10Title; }
            set { SetProperty(ref _image10Title, value); }
        }

        public BitmapImage _image10;
        public BitmapImage Image10
        {
            get { return _image10; }
            set { SetProperty(ref _image10, value); }
        }

        public string _image10Loctext;
        public string Image10Loctext
        {
            get { return _image10Loctext; }
            set { SetProperty(ref _image10Loctext, value); }
        }

        private double _image10RectangleX;
        public double Image10RectangleX
        {
            get { return _image10RectangleX; }
            set { SetProperty(ref _image10RectangleX, value); }
        }

        private double _image10RectangleY;
        public double Image10RectangleY
        {
            get { return _image10RectangleY; }
            set { SetProperty(ref _image10RectangleY, value); }
        }

        private double _image10RectangleWidth;
        public double Image10RectangleWidth
        {
            get { return _image10RectangleWidth; }
            set { SetProperty(ref _image10RectangleWidth, value); }
        }

        private double _image10RectangleHeight;
        public double Image10RectangleHeight
        {
            get { return _image10RectangleHeight; }
            set { SetProperty(ref _image10RectangleHeight, value); }
        }

        //point X on dummy image
        private double _image10PointX;
        public double Image10PointX
        {
            get { return _image10PointX; }
            set { SetProperty(ref _image10PointX, value); }
        }

        //point Y on dummy image
        private double _image10PointY;
        public double Image10PointY
        {
            get { return _image10PointY; }
            set { SetProperty(ref _image10PointY, value); }
        }

        //show point on dummy image
        private Visibility _image10PointVisible;
        public Visibility Image10PointVisible
        {
            get { return _image10PointVisible; }
            set { SetProperty(ref _image10PointVisible, value); }
        }

        private Visibility _image10RectangleVisible;
        public Visibility Image10RectangleVisible
        {
            get { return _image10RectangleVisible; }
            set { SetProperty(ref _image10RectangleVisible, value); }
        }

        public Brush _image10TextBackground;
        public Brush Image10TextBackground
        {
            get { return _image10TextBackground; }
            set { SetProperty(ref _image10TextBackground, value); }
        }
        #endregion

        #region Image11
        public string _image11Title;
        public string Image11Title
        {
            get { return _image11Title; }
            set { SetProperty(ref _image11Title, value); }
        }

        public BitmapImage _image11;
        public BitmapImage Image11
        {
            get { return _image11; }
            set { SetProperty(ref _image11, value); }
        }

        public string _image11Loctext;
        public string Image11Loctext
        {
            get { return _image11Loctext; }
            set { SetProperty(ref _image11Loctext, value); }
        }

        //point X on dummy image
        private double _image11PointX;
        public double Image11PointX
        {
            get { return _image11PointX; }
            set { SetProperty(ref _image11PointX, value); }
        }

        //point Y on dummy image
        private double _image11PointY;
        public double Image11PointY
        {
            get { return _image11PointY; }
            set { SetProperty(ref _image11PointY, value); }
        }

        //show point on dummy image
        private Visibility _image11PointVisible;
        public Visibility Image11PointVisible
        {
            get { return _image11PointVisible; }
            set { SetProperty(ref _image11PointVisible, value); }
        }

        public Brush _image11TextBackground;
        public Brush Image11TextBackground
        {
            get { return _image11TextBackground; }
            set { SetProperty(ref _image11TextBackground, value); }
        }
        #endregion

        #region Image12
        public string _image12Title;
        public string Image12Title
        {
            get { return _image12Title; }
            set { SetProperty(ref _image12Title, value); }
        }

        public BitmapImage _image12;
        public BitmapImage Image12
        {
            get { return _image12; }
            set { SetProperty(ref _image12, value); }
        }

        public string _image12Loctext;
        public string Image12Loctext
        {
            get { return _image12Loctext; }
            set { SetProperty(ref _image12Loctext, value); }
        }

        public Brush _image12TextBackground;
        public Brush Image12TextBackground
        {
            get { return _image12TextBackground; }
            set { SetProperty(ref _image12TextBackground, value); }
        }
        #endregion

        #region Image20
        public string _image20Title;
        public string Image20Title
        {
            get { return _image20Title; }
            set { SetProperty(ref _image20Title, value); }
        }

        public BitmapImage _image20;
        public BitmapImage Image20
        {
            get { return _image20; }
            set { SetProperty(ref _image20, value); }
        }

        public string _image20Loctext;
        public string Image20Loctext
        {
            get { return _image20Loctext; }
            set { SetProperty(ref _image20Loctext, value); }
        }

        private double _image20RectangleX;
        public double Image20RectangleX
        {
            get { return _image20RectangleX; }
            set { SetProperty(ref _image20RectangleX, value); }
        }

        private double _image20RectangleY;
        public double Image20RectangleY
        {
            get { return _image20RectangleY; }
            set { SetProperty(ref _image20RectangleY, value); }
        }

        private double _image20RectangleWidth;
        public double Image20RectangleWidth
        {
            get { return _image20RectangleWidth; }
            set { SetProperty(ref _image20RectangleWidth, value); }
        }

        private double _image20RectangleHeight;
        public double Image20RectangleHeight
        {
            get { return _image20RectangleHeight; }
            set { SetProperty(ref _image20RectangleHeight, value); }
        }

        //point X on dummy image
        private double _image20PointX;
        public double Image20PointX
        {
            get { return _image20PointX; }
            set { SetProperty(ref _image20PointX, value); }
        }

        //point Y on dummy image
        private double _image20PointY;
        public double Image20PointY
        {
            get { return _image20PointY; }
            set { SetProperty(ref _image20PointY, value); }
        }

        //show point on dummy image
        private Visibility _image20PointVisible;
        public Visibility Image20PointVisible
        {
            get { return _image20PointVisible; }
            set { SetProperty(ref _image20PointVisible, value); }
        }

        private Visibility _image20RectangleVisible;
        public Visibility Image20RectangleVisible
        {
            get { return _image20RectangleVisible; }
            set { SetProperty(ref _image20RectangleVisible, value); }
        }

        public Brush _image20TextBackground;
        public Brush Image20TextBackground
        {
            get { return _image20TextBackground; }
            set { SetProperty(ref _image20TextBackground, value); }
        }
        #endregion

        #region Image21
        public string _image21Title;
        public string Image21Title
        {
            get { return _image21Title; }
            set { SetProperty(ref _image21Title, value); }
        }

        public BitmapImage _image21;
        public BitmapImage Image21
        {
            get { return _image21; }
            set { SetProperty(ref _image21, value); }
        }

        public string _image21Loctext;
        public string Image21Loctext
        {
            get { return _image21Loctext; }
            set { SetProperty(ref _image21Loctext, value); }
        }

        //point X on dummy image
        private double _image21PointX;
        public double Image21PointX
        {
            get { return _image21PointX; }
            set { SetProperty(ref _image21PointX, value); }
        }

        //point Y on dummy image
        private double _image21PointY;
        public double Image21PointY
        {
            get { return _image21PointY; }
            set { SetProperty(ref _image21PointY, value); }
        }

        //show point on dummy image
        private Visibility _image21PointVisible;
        public Visibility Image21PointVisible
        {
            get { return _image21PointVisible; }
            set { SetProperty(ref _image21PointVisible, value); }
        }

        public Brush _image21TextBackground;
        public Brush Image21TextBackground
        {
            get { return _image21TextBackground; }
            set { SetProperty(ref _image21TextBackground, value); }
        }

        #endregion

        #region Image22
        public string _image22Title;
        public string Image22Title
        {
            get { return _image22Title; }
            set { SetProperty(ref _image22Title, value); }
        }

        public BitmapImage _image22;
        public BitmapImage Image22
        {
            get { return _image22; }
            set { SetProperty(ref _image22, value); }
        }

        public string _image22Loctext;
        public string Image22Loctext
        {
            get { return _image22Loctext; }
            set { SetProperty(ref _image22Loctext, value); }
        }

        public Brush _image22TextBackground;
        public Brush Image22TextBackground
        {
            get { return _image22TextBackground; }
            set { SetProperty(ref _image22TextBackground, value); }
        }
        #endregion
        #endregion

        #region Command
        public DelegateCommand GoMacroCommand { get; set; }
        public DelegateCommand GoCloseUpCommand { get; set; }
        public DelegateCommand GoMicroCommand { get; set; }
        public DelegateCommand GoNextCommand { get; set; }
        public DelegateCommand GoPreviousCommand { get; set; }
        public DelegateCommand GoPrintCommand { get; set; }
        public DelegateCommand GoDetailsCommand { get; set; }

        public DelegateCommand GoBackCommand { get; set; }
        public DelegateCommand Go33Command { get; set; }
        public DelegateCommand<object> GoImageHistoryMouseLeftButtonDownCommand { get; set; }
        public DelegateCommand<object> GoImageMouseLeftButtonDownCommand { get; set; }
        #endregion

        private bool _keepLive = false;
        public bool KeepAlive
        {
            get { return _keepLive; }
        }

        public ucPrintSelectionViewModel(IRegionManager regionManager, IMolemaxRepository molemaxRepository, IAppSettings applicationSetting)
        {
            _regionManager = regionManager;
            _repository = molemaxRepository;
            _applicationSetting = applicationSetting;
            _applicationSetting.LoadSettings();
            GoMacroCommand = new DelegateCommand(GoMacro);
            GoCloseUpCommand = new DelegateCommand(GoCloseUp);
            GoMicroCommand = new DelegateCommand(GoMicro);
            GoNextCommand = new DelegateCommand(GoNext);
            GoPreviousCommand = new DelegateCommand(GoPrevious);
            GoDetailsCommand = new DelegateCommand(GoDetails);
            GoBackCommand = new DelegateCommand(GoBack);
            Go33Command = new DelegateCommand(Go33);
            GoPrintCommand = new DelegateCommand(GoPrint);
            GoImageHistoryMouseLeftButtonDownCommand = new DelegateCommand<object>(GoImageHistoryMouseLeftButtonDown);
            GoImageMouseLeftButtonDownCommand = new DelegateCommand<object>(GoImageMouseLeftButtonDown);
            //prepare selection images
            selectionImageList = new List<SelectionImage>();
            //store selected images
            _selectedImageList = new List<SelectionImage>();

            Image00TextBackground = Brushes.Transparent;
            Image01TextBackground = Brushes.Transparent;
            Image02TextBackground = Brushes.Transparent;
            Image10TextBackground = Brushes.Transparent;
            Image11TextBackground = Brushes.Transparent;
            Image12TextBackground = Brushes.Transparent;
            Image20TextBackground = Brushes.Transparent;
            Image21TextBackground = Brushes.Transparent;
            Image22TextBackground = Brushes.Transparent;

            Initialize();
        }


        private void Initialize()
        {
            ImageHistoryList = new ObservableCollection<ImageHandler>();

            _imageOrderByKind = KIND_ENUM.KIND_MAKRO;
            _iStartIndex = 0;
            LoadSession();
        }

        private void LoadSession()
        {
            FillSessionArrays();
        }

        private void FillSessionArrays()
        {
            GetSession();

            MacroButtonContent = _iMakroImageCount.ToString() + " X Macro";
            CloseUpButtonContent = _iCloseUpImageCount.ToString() + " X Close Up";
            MicroUpButtonContent = _iMikroImageCount.ToString() + " X ELM";
        }

        private void GetSession()
        {
            int length = 0;

            selectionImageList = CreateImageArray();

            if (_iStartIndex + 3 > selectionImageList.Count)
                length = selectionImageList.Count - _iStartIndex;
            else
                length = 3;

            switch(_imageOrderByKind)
            {
                case KIND_ENUM.KIND_MAKRO:
                    displayImageList = selectionImageList.OrderByDescending(i=>i.Makro.Id).ThenByDescending(i=>i.CloseUp.Id).ThenByDescending(i=>i.Mikro.Id).Skip(_iStartIndex).Take(length).ToList();
                    break;
                case KIND_ENUM.KIND_CLOSEUP:
                    displayImageList = selectionImageList.OrderByDescending(i => i.CloseUp.Id).ThenByDescending(i => i.Makro.Id).ThenByDescending(i => i.Mikro.Id).Skip(_iStartIndex).Take(length).ToList();
                    break;
                case KIND_ENUM.KIND_MIKRO:
                    displayImageList = selectionImageList.OrderByDescending(i => i.Mikro.Id).ThenByDescending(i => i.Makro.Id).ThenByDescending(i => i.Mikro.Id).Skip(_iStartIndex).Take(length).ToList();
                    break;
            }

            int index = 0;
            foreach (var item in displayImageList)
            {
                if (index == 0)
                {
                    Image00Title = item.Makro.ImageId.ToString();
                    Image00Loctext = item.Makro.Loctext;
                    Image00 = item.Makro.Image;

                    Image01Title = item.CloseUp.ImageId.ToString();
                    Image01Loctext = item.CloseUp.Loctext;
                    Image01 = item.CloseUp.Image;

                    Image02Title = item.Mikro.ImageId.ToString();
                    Image02Loctext = item.Mikro.Loctext;
                    Image02 = item.Mikro.Image;
                }

                if (index == 1)
                {
                    Image10Title = item.Makro.ImageId.ToString();
                    Image10Loctext = item.Makro.Loctext;
                    Image10 = item.Makro.Image;

                    Image11Title = item.CloseUp.ImageId.ToString();
                    Image11Loctext = item.CloseUp.Loctext;
                    Image11 = item.CloseUp.Image;

                    Image12Title = item.Mikro.ImageId.ToString();
                    Image12Loctext = item.Mikro.Loctext;
                    Image12 = item.Mikro.Image;
                }

                if (index == 2)
                {
                    Image20Title = item.Makro.ImageId.ToString();
                    Image20Loctext = item.Makro.Loctext;
                    Image20 = item.Makro.Image;

                    Image21Title = item.CloseUp.ImageId.ToString();
                    Image21Loctext = item.CloseUp.Loctext;
                    Image21 = item.CloseUp.Image;

                    Image22Title = item.Mikro.ImageId.ToString();
                    Image22Loctext = item.Mikro.Loctext;
                    Image22 = item.Mikro.Image;
                }

                index++;
            };
        }

        private List<SelectionImage> CreateImageArray()
        {
            SelectionImage si;
            List<SelectionImage> returnList = new List<SelectionImage>();

            //get Max fup id and relative image id from fup and image table
            var maxfupList = _dbFups.Join(_dbImages, fup => fup.imageId, image => image.id, (fup, image) => new { fup, image })
                           .Where(item => item.image.patientId == GlobalValue.Instance.CurrentPatient.id)
                           .GroupBy(item => item.fup.imageId).Select(item => new
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
            //final mikro list
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

                si.Dummy = new ImageHandler();
                si.Dummy.Id = item.makro.image.kenpos;
                si.Dummy.Image = new BitmapImage(new Uri($"pack://application:,,,/Images/Dummy/Ken/{si.Dummy.Id}.bmp"));

                si.Makro = new ImageHandler();
                si.Makro.Id = item.makro.makro.id;
                si.Makro.ImageId = item.makro.makro.imageId;
                si.Makro.Loctext = item.makro.image.loctext;
                si.Makro.Kenpos = item.makro.image.kenpos;
                si.Makro.Image = new BitmapImage(new Uri(item.makro.image.defpath + "\\" + item.makro.image.imgname));
                si.Makro.FullPicRectangleX = item.makro.makro.X1 / 1000;
                si.Makro.FullPicRectangleY = item.makro.makro.Y1 / 1000;
                si.Makro.FullPicRectangleWidth = item.makro.makro.X2 / 1000;
                si.Makro.FullPicRectangleHeight = item.makro.makro.Y2 / 1000;

                si.CloseUp = new ImageHandler();
                si.CloseUp.Id = item.closeup.closeup.id;
                si.CloseUp.ImageId = item.closeup.closeup.imageId;
                si.CloseUp.Loctext = item.closeup.image.loctext;
                si.CloseUp.Kenpos = item.closeup.image.kenpos;
                si.CloseUp.Image = new BitmapImage(new Uri(item.closeup.image.defpath + "\\" + item.closeup.image.imgname));
                si.CloseUp.ImageAndRectangleXRatio = (double)item.closeup.closeup.X1 / (double)1000;
                si.CloseUp.ImageAndRectangleYRatio = (double)item.closeup.closeup.Y1 / (double)1000;
                si.CloseUp.ImageAndRectangleWidthRatio = (double)item.closeup.closeup.X2 / (double)1000;
                si.CloseUp.ImageAndRectangleHeightRatio = (double)item.closeup.closeup.Y2 / (double)1000;
                si.CloseUp.ContainerImageKind = KIND_ENUM.KIND_MAKRO;


                si.Mikro = new ImageHandler();
                si.Mikro.Id = item.mikro.mikro.id;
                si.Mikro.ImageId = item.mikro.mikro.imageId;
                si.Mikro.Loctext = item.mikro.image.loctext;
                si.Mikro.Kenpos = item.mikro.image.kenpos;
                si.Mikro.Image = new BitmapImage(new Uri(item.mikro.image.defpath + "\\" + item.mikro.image.imgname));
                si.Mikro.FullPicPointX = item.mikro.mikro.X / 1000;
                si.Mikro.FullPicPointY = item.mikro.mikro.Y / 1000;
                si.Mikro.ImageAndRectangleXRatio = (double)item.mikro.mikro.X_Pic / (double)1000;
                si.Mikro.ImageAndRectangleYRatio = (double)item.mikro.mikro.Y_Pic / (double)1000;
                si.Mikro.ContainerImageKind = KIND_ENUM.KIND_CLOSEUP;

                si.Treatment = item.mikro.image.treatment.Value;
                returnList.Add(si);
            }

            foreach (var item in mamiList)
            {
                si = new SelectionImage();

                si.Dummy = new ImageHandler();
                si.Dummy.Id = item.makro.image.kenpos;
                si.Dummy.Image = new BitmapImage(new Uri($"pack://application:,,,/Images/Dummy/Ken/{si.Dummy.Id}.bmp"));

                si.Makro = new ImageHandler();
                si.Makro.Id = item.makro.makro.id;
                si.Makro.ImageId = item.makro.makro.imageId;
                si.Makro.Loctext = item.makro.image.loctext;
                si.Makro.Kenpos = item.makro.image.kenpos;
                si.Makro.Image = new BitmapImage(new Uri(item.makro.image.defpath + "\\" + item.makro.image.imgname));
                si.Makro.FullPicRectangleX = item.makro.makro.X1 / 1000;
                si.Makro.FullPicRectangleY = item.makro.makro.Y1 / 1000;
                si.Makro.FullPicRectangleWidth = item.makro.makro.X2 / 1000;
                si.Makro.FullPicRectangleHeight = item.makro.makro.Y2 / 1000;

                si.Mikro = new ImageHandler();
                si.Mikro.Id = item.mikro.mikro.id;
                si.Mikro.ImageId = item.mikro.mikro.imageId;
                si.Mikro.Loctext = item.mikro.image.loctext;
                si.Mikro.Kenpos = item.mikro.image.kenpos;
                si.Mikro.Image = new BitmapImage(new Uri(item.mikro.image.defpath + "\\" + item.mikro.image.imgname));
                si.Mikro.FullPicPointX = item.mikro.mikro.X / 1000;
                si.Mikro.FullPicPointY = item.mikro.mikro.Y / 1000;
                si.Mikro.ImageAndRectangleXRatio = (double)item.mikro.mikro.X_Pic / (double)1000;
                si.Mikro.ImageAndRectangleYRatio = (double)item.mikro.mikro.Y_Pic / (double)1000;
                si.Mikro.ContainerImageKind = KIND_ENUM.KIND_MAKRO;

                si.Treatment = item.mikro.image.treatment.Value;
                returnList.Add(si);
            }

            foreach (var item in macuList)
            {
                si = new SelectionImage();

                si.Dummy = new ImageHandler();
                si.Dummy.Id = item.makro.image.kenpos;
                si.Dummy.Image = new BitmapImage(new Uri($"pack://application:,,,/Images/Dummy/Ken/{si.Dummy.Id}.bmp"));

                si.Makro = new ImageHandler();
                si.Makro.Id = item.makro.makro.id;
                si.Makro.ImageId = item.makro.makro.imageId;
                si.Makro.Loctext = item.makro.image.loctext;
                si.Makro.Kenpos = item.makro.image.kenpos;
                si.Makro.Image = new BitmapImage(new Uri(item.makro.image.defpath + "\\" + item.makro.image.imgname));
                si.Makro.FullPicRectangleX = item.makro.makro.X1 / 1000;
                si.Makro.FullPicRectangleY = item.makro.makro.Y1 / 1000;
                si.Makro.FullPicRectangleWidth = item.makro.makro.X2 / 1000;
                si.Makro.FullPicRectangleHeight = item.makro.makro.Y2 / 1000;

                si.CloseUp = new ImageHandler();
                si.CloseUp.Id = item.closeup.closeup.id;
                si.CloseUp.ImageId = item.closeup.closeup.imageId;
                si.CloseUp.Loctext = item.closeup.image.loctext;
                si.CloseUp.Kenpos = item.closeup.image.kenpos;
                si.CloseUp.Image = new BitmapImage(new Uri(item.closeup.image.defpath + "\\" + item.closeup.image.imgname));
                si.CloseUp.ImageAndRectangleXRatio = (double)item.closeup.closeup.X1 / (double)1000;
                si.CloseUp.ImageAndRectangleYRatio = (double)item.closeup.closeup.Y1 / (double)1000;
                si.CloseUp.ImageAndRectangleWidthRatio = (double)item.closeup.closeup.X2 / (double)1000;
                si.CloseUp.ImageAndRectangleHeightRatio = (double)item.closeup.closeup.Y2 / (double)1000;
                si.CloseUp.ContainerImageKind = KIND_ENUM.KIND_MAKRO;

                si.Treatment = item.closeup.image.treatment.Value;

                returnList.Add(si);
            }

            foreach (var item in maList)
            {
                si = new SelectionImage();

                si.Dummy = new ImageHandler();
                si.Dummy.Id = item.image.kenpos;
                si.Dummy.Image = new BitmapImage(new Uri($"pack://application:,,,/Images/Dummy/Ken/{si.Dummy.Id}.bmp"));

                si.Makro = new ImageHandler();
                si.Makro.Id = item.makro.id;
                si.Makro.ImageId = item.makro.imageId;
                si.Makro.Loctext = item.image.loctext;
                si.Makro.Kenpos = item.image.kenpos;
                si.Makro.Image = new BitmapImage(new Uri(item.image.defpath + "\\" + item.image.imgname));
                si.Makro.FullPicRectangleX = item.makro.X1 / 1000;
                si.Makro.FullPicRectangleY = item.makro.Y1 / 1000;
                si.Makro.FullPicRectangleWidth = item.makro.X2 / 1000;
                si.Makro.FullPicRectangleHeight = item.makro.Y2 / 1000;

                si.Treatment = item.makro.image.treatment.Value;

                returnList.Add(si);
            }

            foreach (var item in miList)
            {
                si = new SelectionImage();

                si.Dummy = new ImageHandler();
                si.Dummy.Id = item.image.kenpos;
                si.Dummy.Image = new BitmapImage(new Uri($"pack://application:,,,/Images/Dummy/Ken/{si.Dummy.Id}.bmp"));

                si.Mikro = new ImageHandler();
                si.Mikro.Id = item.mikro.id;
                si.Mikro.ImageId = item.mikro.imageId;
                si.Mikro.Loctext = item.image.loctext;
                si.Mikro.Kenpos = item.image.kenpos;
                si.Mikro.Image = new BitmapImage(new Uri(item.image.defpath + "\\" + item.image.imgname));
                si.Mikro.FullPicPointX = item.mikro.X / 1000;
                si.Mikro.FullPicPointY = item.mikro.Y / 1000;
                si.Mikro.ImageAndRectangleXRatio = (double)item.mikro.X_Pic / (double)1000;
                si.Mikro.ImageAndRectangleYRatio = (double)item.mikro.Y_Pic / (double)1000;

                si.Treatment = item.mikro.image.treatment.Value;
                returnList.Add(si);
            }

            return returnList.OrderByDescending(i => i.Makro.Id).ThenByDescending(i => i.CloseUp).ThenByDescending(i => i.Mikro).ToList<SelectionImage>();
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
        private void GoImageHistoryMouseLeftButtonDown(object obj)
        {
            var historyImageHandler = obj as ImageHandler;
            var temp = ImageHistoryList.Where(i => 1 == 1).ToList();
            if (temp[ImageHistoryList.IndexOf(historyImageHandler)].ImageHistoryTextBackground == Brushes.Transparent)
            {
                temp[ImageHistoryList.IndexOf(historyImageHandler)].ImageHistoryTextBackground = Brushes.Red;
                switch (imageIndex)
                {
                    case 0:
                        if (displayImageList[0].Makro.SelectedHistoryImageList == null)
                            displayImageList[0].Makro.SelectedHistoryImageList = new List<ImageHandler>();
                        if (displayImageList[0].Makro.SelectedHistoryImageList.FindIndex(i=>i.ImageId == historyImageHandler.ImageId)==-1)
                            displayImageList[0].Makro.SelectedHistoryImageList.Add(historyImageHandler);
                        if (!displayImageList[0].IsMakroSelected)
                        {
                            ChangeSelectedAndTextBackGround(0, displayImageList[0], Brushes.Red, true);
                        }
                        break;
                    case 1:
                        if (displayImageList[0].CloseUp.SelectedHistoryImageList == null)
                            displayImageList[0].CloseUp.SelectedHistoryImageList = new List<ImageHandler>();
                        if (displayImageList[0].CloseUp.SelectedHistoryImageList.FindIndex(i => i.ImageId == historyImageHandler.ImageId) == -1)
                            displayImageList[0].CloseUp.SelectedHistoryImageList.Add(historyImageHandler);
                        if (!displayImageList[0].IsCloseUpSelected)
                        {
                            ChangeSelectedAndTextBackGround(1, displayImageList[0], Brushes.Red, true);
                        }
                        break;
                    case 2:
                        if (displayImageList[0].Mikro.SelectedHistoryImageList == null)
                            displayImageList[0].Mikro.SelectedHistoryImageList = new List<ImageHandler>();
                        if (displayImageList[0].Mikro.SelectedHistoryImageList.FindIndex(i => i.ImageId == historyImageHandler.ImageId) == -1)
                            displayImageList[0].Mikro.SelectedHistoryImageList.Add(historyImageHandler);
                        if (!displayImageList[0].IsMikroSelected)
                        {
                            ChangeSelectedAndTextBackGround(2, displayImageList[0], Brushes.Red, true);
                        }
                        break;
                    case 3:
                        if (displayImageList[1].Makro.SelectedHistoryImageList == null)
                            displayImageList[1].Makro.SelectedHistoryImageList = new List<ImageHandler>();
                        if (displayImageList[1].Makro.SelectedHistoryImageList.FindIndex(i => i.ImageId == historyImageHandler.ImageId) == -1)
                            displayImageList[1].Makro.SelectedHistoryImageList.Add(historyImageHandler);
                        if (!displayImageList[1].IsMakroSelected)
                        {
                            ChangeSelectedAndTextBackGround(3, displayImageList[1], Brushes.Red, true);
                        }
                        break;
                    case 4:
                        if (displayImageList[1].CloseUp.SelectedHistoryImageList == null)
                            displayImageList[1].CloseUp.SelectedHistoryImageList = new List<ImageHandler>();
                        if (displayImageList[1].CloseUp.SelectedHistoryImageList.FindIndex(i => i.ImageId == historyImageHandler.ImageId) == -1)
                            displayImageList[1].CloseUp.SelectedHistoryImageList.Add(historyImageHandler);
                        if (!displayImageList[1].IsCloseUpSelected)
                        {
                            ChangeSelectedAndTextBackGround(4, displayImageList[1], Brushes.Red, true);
                        }
                        break;
                    case 5:
                        if (displayImageList[1].Mikro.SelectedHistoryImageList == null)
                            displayImageList[1].Mikro.SelectedHistoryImageList = new List<ImageHandler>();
                        if (displayImageList[1].Mikro.SelectedHistoryImageList.FindIndex(i => i.ImageId == historyImageHandler.ImageId) == -1)
                            displayImageList[1].Mikro.SelectedHistoryImageList.Add(historyImageHandler);
                        if (!displayImageList[1].IsMikroSelected)
                        {
                            ChangeSelectedAndTextBackGround(5, displayImageList[1], Brushes.Red, true);
                        }
                        break;
                    case 6:
                        if (displayImageList[2].Makro.SelectedHistoryImageList == null)
                            displayImageList[2].Makro.SelectedHistoryImageList = new List<ImageHandler>();
                        if (displayImageList[2].Makro.SelectedHistoryImageList.FindIndex(i => i.ImageId == historyImageHandler.ImageId) == -1)
                            displayImageList[2].Makro.SelectedHistoryImageList.Add(historyImageHandler);
                        if (!displayImageList[2].IsMakroSelected)
                        {
                            ChangeSelectedAndTextBackGround(6, displayImageList[2], Brushes.Red, true);
                        }
                        break;
                    case 7:
                        if (displayImageList[2].CloseUp.SelectedHistoryImageList == null)
                            displayImageList[2].CloseUp.SelectedHistoryImageList = new List<ImageHandler>();
                        if (displayImageList[2].CloseUp.SelectedHistoryImageList.FindIndex(i => i.ImageId == historyImageHandler.ImageId) == -1)
                            displayImageList[2].CloseUp.SelectedHistoryImageList.Add(historyImageHandler);
                        if (!displayImageList[2].IsCloseUpSelected)
                        {
                            ChangeSelectedAndTextBackGround(7, displayImageList[2], Brushes.Red, true);
                        }
                        break;
                    case 8:
                        if (displayImageList[2].Mikro.SelectedHistoryImageList == null)
                            displayImageList[2].Mikro.SelectedHistoryImageList = new List<ImageHandler>();
                        if (displayImageList[2].Mikro.SelectedHistoryImageList.FindIndex(i => i.ImageId == historyImageHandler.ImageId) == -1)
                            displayImageList[2].Mikro.SelectedHistoryImageList.Add(historyImageHandler);
                        if (!displayImageList[2].IsMikroSelected)
                        {
                            ChangeSelectedAndTextBackGround(8, displayImageList[2], Brushes.Red, true);
                        }
                        break;
                }
            }
            else
            {
                temp[ImageHistoryList.IndexOf(historyImageHandler)].ImageHistoryTextBackground = Brushes.Transparent;
                int index;
                switch (imageIndex)
                {
                    case 0:
                        index = displayImageList[0].Makro.SelectedHistoryImageList.FindIndex(i => i.ImageId == historyImageHandler.ImageId);
                        displayImageList[0].Makro.SelectedHistoryImageList.RemoveAt(index);
                        if (displayImageList[0].Makro.SelectedHistoryImageList.Count == 0)
                        {
                            ChangeSelectedAndTextBackGround(0, displayImageList[0], Brushes.Transparent, false);
                        }
                        break;
                    case 1:
                        index = displayImageList[0].CloseUp.SelectedHistoryImageList.FindIndex(i => i.ImageId == historyImageHandler.ImageId);
                        displayImageList[0].CloseUp.SelectedHistoryImageList.RemoveAt(index);
                        if (displayImageList[0].CloseUp.SelectedHistoryImageList.Count == 0)
                        {
                            ChangeSelectedAndTextBackGround(1, displayImageList[0], Brushes.Transparent, false);
                        }
                        break;
                    case 2:
                        index = displayImageList[0].Mikro.SelectedHistoryImageList.FindIndex(i => i.ImageId == historyImageHandler.ImageId);
                        displayImageList[0].Mikro.SelectedHistoryImageList.RemoveAt(index);
                        if (displayImageList[0].Mikro.SelectedHistoryImageList.Count == 0)
                        {
                            ChangeSelectedAndTextBackGround(2, displayImageList[0], Brushes.Transparent, false);
                        }
                        break;
                    case 3:
                        index = displayImageList[1].Makro.SelectedHistoryImageList.FindIndex(i => i.ImageId == historyImageHandler.ImageId);
                        displayImageList[1].Makro.SelectedHistoryImageList.RemoveAt(index);
                        if (displayImageList[1].Makro.SelectedHistoryImageList.Count == 0)
                        {
                            ChangeSelectedAndTextBackGround(3, displayImageList[1], Brushes.Transparent, false);
                        }
                        break;
                    case 4:
                        index = displayImageList[1].CloseUp.SelectedHistoryImageList.FindIndex(i => i.ImageId == historyImageHandler.ImageId);
                        displayImageList[1].CloseUp.SelectedHistoryImageList.RemoveAt(index);
                        if (displayImageList[1].CloseUp.SelectedHistoryImageList.Count == 0)
                        {
                            ChangeSelectedAndTextBackGround(4, displayImageList[1], Brushes.Transparent, false);
                        }
                        break;
                    case 5:
                        index = displayImageList[1].Mikro.SelectedHistoryImageList.FindIndex(i => i.ImageId == historyImageHandler.ImageId);
                        displayImageList[1].Mikro.SelectedHistoryImageList.RemoveAt(index);
                        if (displayImageList[1].Mikro.SelectedHistoryImageList.Count == 0)
                        {
                            ChangeSelectedAndTextBackGround(5, displayImageList[1], Brushes.Transparent, false);
                        }
                        break;
                    case 6:
                        index = displayImageList[2].Makro.SelectedHistoryImageList.FindIndex(i => i.ImageId == historyImageHandler.ImageId);
                        displayImageList[2].Makro.SelectedHistoryImageList.RemoveAt(index);
                        if (displayImageList[2].Makro.SelectedHistoryImageList.Count == 0)
                        {
                            ChangeSelectedAndTextBackGround(6, displayImageList[2], Brushes.Transparent, false);
                        }
                        break;
                    case 7:
                        index = displayImageList[2].CloseUp.SelectedHistoryImageList.FindIndex(i => i.ImageId == historyImageHandler.ImageId);
                        displayImageList[2].CloseUp.SelectedHistoryImageList.RemoveAt(index);
                        if (displayImageList[2].CloseUp.SelectedHistoryImageList.Count == 0)
                        {
                            ChangeSelectedAndTextBackGround(7, displayImageList[2], Brushes.Transparent, false);
                        }
                        break;
                    case 8:
                        index = displayImageList[2].Mikro.SelectedHistoryImageList.FindIndex(i => i.ImageId == historyImageHandler.ImageId);
                        displayImageList[2].Mikro.SelectedHistoryImageList.RemoveAt(index);
                        if (displayImageList[2].Mikro.SelectedHistoryImageList.Count == 0)
                        {
                            ChangeSelectedAndTextBackGround(8, displayImageList[2], Brushes.Transparent, false);
                        }
                        break;
                }
            }
            ImageHistoryList = new ObservableCollection<ImageHandler>(temp);
        }


        private void GoImageMouseLeftButtonDown(object obj)
        {
            SelectionImage si = new SelectionImage();
            imageIndex = Convert.ToInt32(obj);

            //image00 image01 image02 --> 0  1  2 -->selectionImageList[0]
            //image10 image11 image12 --> 3  4  5 -->selectionImageList[1]
            //image20 image21 image22 --> 6  7  8 -->selectionImageList[2]

            switch (imageIndex)
            {
                case 0:
                case 1:
                case 2:
                    si = displayImageList[0];
                    if (!si.IsMakroSelected)
                        ChangeSelectedAndTextBackGround(imageIndex, si, Brushes.Red, true);
                    break;
                case 3:
                case 4:
                case 5:
                    si = displayImageList[1];
                    if(!si.IsCloseUpSelected)
                        ChangeSelectedAndTextBackGround(imageIndex, si, Brushes.Red, true);
                    break;
                case 6:
                case 7:
                case 8:
                    si = displayImageList[2];
                    if(!si.IsMikroSelected)
                        ChangeSelectedAndTextBackGround(imageIndex, si, Brushes.Red, true);
                    break;
            }


            //mouse click on Makro images
            if (imageIndex == 0 || imageIndex == 3 || imageIndex == 6)
            {
                if (si.Makro.Id == 0)
                    return;

                int? t_fupId = _dbMakros.Where(m => m.id == si.Makro.Id).SingleOrDefault().fupId;
                int? t_imageId = _dbMakros.Where(m => m.id == si.Makro.Id).SingleOrDefault().imageId;
                int fupId = t_fupId.HasValue ? t_fupId.Value : 0;
                int curentImageId = t_imageId.HasValue ? t_imageId.Value : 0;
                _selectedImage = si.Makro;
                _selectedImageKind = KIND_ENUM.KIND_MAKRO;

                if ( fupId != 0)
                {
                    //get image Id that beginning of history
                    var firstHisImageId = _dbFups.Where(f => f.id == fupId).SingleOrDefault().imageId;
                    //get all fups belong to the first image
                    var fupList = _dbFups.Where(f => f.imageId == firstHisImageId).Select(i => i.id);//.ToList().Remove(fupId);
                    //get all makro image id belong to the fist image
                    var hisImageIdList = _dbMakros.Where(i => fupList.Contains(i.fupId.Value)).Select(i=>i.imageId).ToList();
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
                            ImageHistoryTextBackground = Brushes.Transparent,
                        }).ToList();


                    if (si.Makro.SelectedHistoryImageList == null || si.Makro.SelectedHistoryImageList.Count ==0)
                    {
                        si.Makro.SelectedHistoryImageList = new List<ImageHandler>();
                        tempImageList[0].ImageHistoryTextBackground = Brushes.Red;
                        si.Makro.SelectedHistoryImageList.Add(tempImageList[0]);
                    }
                    else
                    {
                        foreach (var shi in si.Makro.SelectedHistoryImageList)
                        {
                            foreach (var im in tempImageList)
                            {
                                if (shi.ImageId == im.ImageId)
                                {
                                    im.ImageHistoryTextBackground = Brushes.Red;
                                    break;
                                }
                            }
                        }
                    }

                    ImageHistoryList = new ObservableCollection<ImageHandler>(tempImageList);
                }
                else
                {
                    ImageHistoryList = new ObservableCollection<ImageHandler>(); ;
                }

                if (_selectedImageList.IndexOf(si)<0)
                    _selectedImageList.Add(si);
            }

            //mouse click on Closeup images
            if (imageIndex == 1 || imageIndex == 4 || imageIndex == 7)
            {
                if (si.CloseUp.Id == 0)
                    return;

                int? t_fupId = _dbCloseups.Where(c => c.id == si.CloseUp.Id).SingleOrDefault().fupId;
                int? t_imageId = _dbCloseups.Where(c => c.id == si.CloseUp.Id).SingleOrDefault().imageId;
                int fupId = t_fupId.HasValue ? t_fupId.Value : 0;
                int curentImageId = t_imageId.HasValue ? t_imageId.Value : 0;
                _selectedImage = si.CloseUp;
                _selectedImageKind = KIND_ENUM.KIND_CLOSEUP;

                if (fupId != 0)
                {
                    //get image Id that beginning of history
                    var firstHisImageId = _dbFups.Where(f => f.id == fupId).SingleOrDefault().imageId;
                    //get all fups belong to the first image
                    var fupList = _dbFups.Where(f => f.imageId == firstHisImageId).Select(i => i.id);//.ToList().Remove(fupId);
                    //get all closeup image id belong to the fist image
                    var hisImageIdList = _dbCloseups.Where(i => fupList.Contains(i.fupId.Value)).Select(i => i.imageId).ToList();
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
                        }).ToList();

                    if (si.CloseUp.SelectedHistoryImageList == null || si.CloseUp.SelectedHistoryImageList.Count == 0)
                    {
                        si.CloseUp.SelectedHistoryImageList = new List<ImageHandler>();
                        tempImageList[0].ImageHistoryTextBackground = Brushes.Red;
                        si.CloseUp.SelectedHistoryImageList.Add(tempImageList[0]);
                    }
                    else
                    {
                        foreach (var shi in si.CloseUp.SelectedHistoryImageList)
                        {
                            foreach (var im in tempImageList)
                            {
                                if (shi.ImageId == im.ImageId)
                                {
                                    im.ImageHistoryTextBackground = Brushes.Red;
                                    break;
                                }
                            }
                        }
                    }

                    ImageHistoryList = new ObservableCollection<ImageHandler>(tempImageList);
                }
                else
                {
                    ImageHistoryList = new ObservableCollection<ImageHandler>(); ;
                }

                if (_selectedImageList.IndexOf(si) < 0)
                    _selectedImageList.Add(si);
            }

            //mouse click on Closeup images
            if (imageIndex == 2 || imageIndex == 5 || imageIndex == 8)
            {
                if (si.Mikro.Id == 0)
                    return;

                //switch (index)
                //{
                //    case 2:
                //        Image02TextVisible = Image02TextVisible == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
                //        break;
                //    case 5:
                //        Image12TextVisible = Image12TextVisible == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
                //        break;
                //    case 8:
                //        Image22TextVisible = Image22TextVisible == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
                //        break;
                //}

                int? t_fupId = _dbMikros.Where(mi => mi.id == si.Mikro.Id).SingleOrDefault().fupId;
                int? t_imageId = _dbMikros.Where(mi => mi.id == si.Mikro.Id).SingleOrDefault().imageId;
                int fupId = t_fupId.HasValue ? t_fupId.Value : 0;
                int curentImageId = t_imageId.HasValue ? t_imageId.Value : 0;
                _selectedImage = si.Mikro;
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
                        }).ToList();

                    if (si.Mikro.SelectedHistoryImageList == null || si.Mikro.SelectedHistoryImageList.Count ==0)
                    {
                        si.Mikro.SelectedHistoryImageList = new List<ImageHandler>();
                        tempImageList[0].ImageHistoryTextBackground = Brushes.Red;
                        si.Mikro.SelectedHistoryImageList.Add(tempImageList[0]);
                    }
                    else
                    {
                        foreach (var shi in si.Mikro.SelectedHistoryImageList)
                        {
                            foreach (var im in tempImageList)
                            {
                                if (shi.ImageId == im.ImageId)
                                {
                                    im.ImageHistoryTextBackground = Brushes.Red;
                                    break;
                                }
                            }
                        }
                    }

                    ImageHistoryList = new ObservableCollection<ImageHandler>(tempImageList);
                }
                else
                {
                    ImageHistoryList = new ObservableCollection<ImageHandler>(); ;
                }

                if (_selectedImageList.IndexOf(si) < 0)
                    _selectedImageList.Add(si);
            }
        }

        private void ChangeSelectedAndTextBackGround(int index, SelectionImage si, Brush colour, bool isSelected)
        {
            switch (index)
            {
                case 0:
                    si.IsMakroSelected = isSelected;
                    Image00TextBackground = colour;
                    break;
                case 1:
                    si.IsCloseUpSelected = isSelected;
                    Image01TextBackground = colour;
                    break;
                case 2:
                    si.IsMikroSelected = isSelected;
                    Image02TextBackground = colour;
                    break;
                case 3:
                    si.IsMakroSelected = isSelected;
                    Image10TextBackground = colour;
                    break;
                case 4:
                    si.IsCloseUpSelected = isSelected;
                    Image11TextBackground = colour;
                    break;
                case 5:
                    si.IsMikroSelected = isSelected;
                    Image12TextBackground = colour;
                    break;
                case 6:
                    si.IsMakroSelected = isSelected;
                    Image20TextBackground = colour;
                    break;
                case 7:
                    si.IsCloseUpSelected = isSelected;
                    Image21TextBackground = colour;
                    break;
                case 8:
                    si.IsMikroSelected = isSelected;
                    Image22TextBackground = colour;
                    break;
            }
        }

        private void GoPrint()
        {
            var navigationParameters = new NavigationParameters();
            List<ImageHandler> makroHistoryList;
            List<ImageHandler> mikroHistoryList;
            List<ImageHandler> closeupHistoryList;
            List<string> pdfList = new List<string>();
            string sDestPDFFullPath = Path.Combine(_applicationSetting.Temp, "TEST.PDF");
            string sOutputImageDir = Path.Combine(_applicationSetting.Temp, Guid.NewGuid().ToString());

            foreach (var si in _selectedImageList)
            {
                mikroHistoryList = si.Mikro.SelectedHistoryImageList;
                makroHistoryList = si.Makro.SelectedHistoryImageList;
                closeupHistoryList = si.CloseUp.SelectedHistoryImageList;
                if (si.IsMakroSelected && si.IsCloseUpSelected && si.IsMikroSelected)
                {
                    if (si.Mikro.SelectedHistoryImageList != null && si.Mikro.SelectedHistoryImageList.Count > 0)
                    {
                        string sMikroHtmlFullPath = GenerateHtml(si, mikroHistoryList, KIND_ENUM.KIND_MIKRO, "008.dat");
                        pdfList.Add(sMikroHtmlFullPath);
                    }

                    if (si.CloseUp.SelectedHistoryImageList != null && si.CloseUp.SelectedHistoryImageList.Count > 0)
                    {
                        string sCloseUpHtmlFullPath = GenerateHtml(si, closeupHistoryList, KIND_ENUM.KIND_CLOSEUP, "008.dat");
                        pdfList.Add(sCloseUpHtmlFullPath);

                    }

                    if (si.Makro.SelectedHistoryImageList != null && si.Makro.SelectedHistoryImageList.Count > 0)
                    {
                        string sMakroHtmlFullPath = GenerateHtml(si, makroHistoryList, KIND_ENUM.KIND_MAKRO, "008.dat");
                        pdfList.Add(sMakroHtmlFullPath);
                    }


                }


                if (si.IsMakroSelected && si.IsCloseUpSelected && !si.IsMikroSelected)
                {
                    if (si.CloseUp.SelectedHistoryImageList != null && si.CloseUp.SelectedHistoryImageList.Count > 0)
                    {
                        string sCloseUpHtmlFullPath = GenerateHtml(si, closeupHistoryList, KIND_ENUM.KIND_CLOSEUP, "008.dat");
                        pdfList.Add(sCloseUpHtmlFullPath);

                    }

                    if (si.Makro.SelectedHistoryImageList != null && si.Makro.SelectedHistoryImageList.Count > 0)
                    {
                        string sMakroHtmlFullPath = GenerateHtml(si, makroHistoryList, KIND_ENUM.KIND_MAKRO, "008.dat");
                        pdfList.Add(sMakroHtmlFullPath);
                    }
                }

                if (si.IsMakroSelected && !si.IsCloseUpSelected && si.IsMikroSelected)
                {
                    if (si.Mikro.SelectedHistoryImageList != null && si.Mikro.SelectedHistoryImageList.Count > 0)
                    {
                        string sMikroHtmlFullPath = GenerateHtml(si, mikroHistoryList, KIND_ENUM.KIND_MIKRO, "008.dat");
                        pdfList.Add(sMikroHtmlFullPath);
                    }

                    if (si.Makro.SelectedHistoryImageList != null && si.Makro.SelectedHistoryImageList.Count > 0)
                    {
                        string sMakroHtmlFullPath = GenerateHtml(si, makroHistoryList, KIND_ENUM.KIND_MAKRO, "008.dat");
                        pdfList.Add(sMakroHtmlFullPath);

                    }
                }

                if (si.IsMakroSelected && !si.IsCloseUpSelected && !si.IsMikroSelected)
                {
                    if (si.Makro.SelectedHistoryImageList != null && si.Makro.SelectedHistoryImageList.Count > 0)
                    {
                        string sMakroHtmlFullPath = GenerateHtml(si, makroHistoryList, KIND_ENUM.KIND_MAKRO, "008.dat");
                        pdfList.Add(sMakroHtmlFullPath);

                    }
                }

                if (!si.IsMakroSelected && !si.IsCloseUpSelected && si.IsMikroSelected)
                {
                    if (si.Mikro.SelectedHistoryImageList != null && si.Mikro.SelectedHistoryImageList.Count > 0)
                    {
                        string sMikroHtmlFullPath = GenerateHtml(si, mikroHistoryList, KIND_ENUM.KIND_MIKRO, "008.dat");
                        pdfList.Add(sMikroHtmlFullPath);
                    }
                }

            }

            if (pdfList.Count > 0)
                PDFHandler.MergeHtmlsToPDF(pdfList.ToArray(), sDestPDFFullPath);

            if (!Directory.Exists(sOutputImageDir))
                Directory.CreateDirectory(sOutputImageDir);

            PDFHandler.ConvertPDFToImage(sDestPDFFullPath, sOutputImageDir);

            if (Directory.Exists(sOutputImageDir))
            {
                DirectoryInfo di = new DirectoryInfo(sOutputImageDir);
                FileInfo[] pdfImageList = di.GetFiles();
                if (pdfImageList.Count() > 0)
                {
                    navigationParameters.Add(Constants.ParaFile, sDestPDFFullPath);
                    navigationParameters.Add(Constants.ParaImageList, pdfImageList);
                    navigationParameters.Add(Constants.FromForm, UserControlNames.PMSSelect);
                    _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.Print, navigationParameters);
                }
            }
        }

        private string GenerateHtml(SelectionImage si, List<ImageHandler> historyList, KIND_ENUM imageKind, string sTemplateFile = "001.dat")
        {
            string sContent;

            var sfileId = (Guid.NewGuid()).ToString();
            var shtmlFile = $"{sfileId}.html";
            var spdfFils = $"{sfileId}.pdf";
            var shtmlFileFullPath = Path.Combine(_applicationSetting.Temp, shtmlFile);
            //var spdfFilsFullPath = Path.Combine(_applicationSetting.Temp, spdfFils);

            if (File.Exists(shtmlFileFullPath))
                File.Delete(shtmlFileFullPath);
            File.Copy(@"C:\Projects\Molemax\Molemax.App\Templates\008.dat", shtmlFileFullPath);

            sContent = File.ReadAllText(shtmlFileFullPath);

            sContent = UpdateFields(sContent, "%%APP_TITLE%%", "MoleMax HD");
            sContent = AddPatientInfoToHTML(sContent);
            sContent = UpdateFields(sContent, "%%CLINIC%%", "Sydney skin cancer practice");
            sContent = UpdateFields(sContent, "%%CLINICADDRESS%%", "Test address (Sydney Skin Cancer Practice");
            sContent = UpdateFields(sContent, "%%PHONE%%", "Phone: " + "Test phone (02 93456678)");
            sContent = UpdateFields(sContent, "%%EMAIL%%", "Mail: " + "Test mail (skinhealth@sydney.com.au)");
            sContent = UpdateFields(sContent, "%%WEB%%", "Web: " + "Test web (www.skinhealth.com.au");
            sContent = UpdateFields(sContent, "%%BUSINESSNAME%%", "Test (ANB 41 824753 556)");


            sContent = AddImgInfo2HTML(sContent, si, historyList, imageKind);

            sContent = UpdateFields(sContent, "%%PAGE_TITLE%%", $"{GlobalValue.Instance.CurrentPatient.firstname} {GlobalValue.Instance.CurrentPatient.lastname}");
            sContent = UpdateFields(sContent, "%%DATE%%", $"{DateTime.Now.ToString("MM/dd/yyyy")}");

            sContent = UpdateFields(sContent, "%%HEADER_1%%", $"{GlobalValue.Instance.CurrentPatient.firstname} {GlobalValue.Instance.CurrentPatient.lastname}");
            sContent = UpdateFields(sContent, "%%NAME%%", "g_tApp.Printing.strName");
            sContent = UpdateFields(sContent, "%%ADDRESS%%", "g_tApp.Printing.strAddress");

            sContent = UpdateFields(sContent, "%%PAGE_NO%%", "1");
            sContent = UpdateFields(sContent, "%%TOTAL_PAGES%%", "7");
            File.WriteAllText(shtmlFileFullPath, sContent);

            return shtmlFileFullPath;
        }

        private string AddPatientInfoToHTML(string sContent)
        {
            //calculate patient age
            var birthdate = GlobalValue.Instance.CurrentPatient.birthdate;
            var today = DateTime.Today;
            var age = today.Year - birthdate.Year;
            if (birthdate.Date > today.AddYears(-age))
            {
                age--;
            }

            sContent = UpdateFields(sContent, "%%REPDATE%%", DateTime.Today.ToString("MM/dd/yyyy"));
            sContent = UpdateFields(sContent, "%%USER%%", "Test (Dr John Smith)");
            sContent = UpdateFields(sContent, "%%CLINIC%%", "Test (Sydney skin cancer Practice");
            sContent = UpdateFields(sContent, "%%PATNAME%%", $"{GlobalValue.Instance.CurrentPatient.title} {GlobalValue.Instance.CurrentPatient.lastname} {GlobalValue.Instance.CurrentPatient.firstname}");
            sContent = UpdateFields(sContent, "%%PATAGE%%", age.ToString());
            sContent = UpdateFields(sContent, "%%PATDOB%%", GlobalValue.Instance.CurrentPatient.birthdate.ToString("MM/dd/yyyy"));
            sContent = UpdateFields(sContent, "%%PATSEX%%", GlobalValue.Instance.CurrentPatient.sex);
            sContent = UpdateFields(sContent, "%%PATREC%%", GlobalValue.Instance.CurrentPatient.id.ToString());
            sContent = UpdateFields(sContent, "%%PATLVD%%", "Test (30/01/2021)");
            sContent = UpdateFields(sContent, "%%PATFUP%%", "---");
            return sContent;
        }

        private string AddImgInfo2HTML(string sContent, SelectionImage si, List<ImageHandler> historyList, KIND_ENUM imageKind)
        {
            string strDummyHTML;
            string strMakroHTML;
            string strCloseupHTML;
            string strMikroHTML;
            string originalImage;
            FileInfo fi;
            string newImage;
            System.Drawing.Image image;

            switch (imageKind)
            {
                case KIND_ENUM.KIND_MIKRO:
                    if (si.Makro != null)
                    {
                        originalImage = @"C:/Projects/Molemax/Molemax.App/Images/Dummy/Ken/" + si.Dummy.Id + ".bmp";
                        fi = new FileInfo(originalImage);
                        newImage = _applicationSetting.Temp + "\\" + fi.Name;
                        image = System.Drawing.Image.FromFile(originalImage);
                        //ImageHelpers.AddRectangleOrPoint(originalImage, newImage, true, (int)(si.Makro.FullPicRectangleX), (int)(si.Makro.FullPicRectangleY), (int)(si.Makro.FullPicRectangleWidth), (int)(si.Makro.FullPicRectangleHeight));
                        ImageHelpers.AddRectangleOrPoint(originalImage, newImage, true, 50, 50, 100, 100);
                        strDummyHTML = "<img src=" + newImage + " width =300 height=150 alt=''>";
                        sContent = UpdateFields(sContent, "%%IMGTAG01%%", strDummyHTML);
                        sContent = UpdateFields(sContent, "%%IMGDAT01%%", "Date: test date");

                        if (si.Mikro.ContainerImageKind == KIND_ENUM.KIND_MAKRO)
                        {
                            originalImage = si.Makro.Image.UriSource.AbsolutePath;
                            fi = new FileInfo(originalImage);
                            newImage = _applicationSetting.Temp + "\\" + fi.Name;
                            image = System.Drawing.Image.FromFile(originalImage);
                            ImageHelpers.AddRectangleOrPoint(originalImage, newImage, false, (int)(si.Mikro.ImageAndRectangleXRatio * image.Width), (int)(si.Mikro.ImageAndRectangleYRatio * image.Height));
                            strMakroHTML = "<img src=" + newImage + " width=300 height=150 alt=''>";
                        }
                        else if (si.Mikro.ContainerImageKind == KIND_ENUM.KIND_CLOSEUP)
                        {
                            originalImage = si.Makro.Image.UriSource.AbsolutePath;
                            fi = new FileInfo(originalImage);
                            newImage = _applicationSetting.Temp + "\\" + fi.Name;
                            image = System.Drawing.Image.FromFile(originalImage);
                            ImageHelpers.AddRectangleOrPoint(originalImage, newImage, true, (int)(si.CloseUp.ImageAndRectangleXRatio * image.Width), (int)(si.CloseUp.ImageAndRectangleYRatio * image.Height), (int)(si.CloseUp.ImageAndRectangleWidthRatio * image.Width), (int)(si.CloseUp.ImageAndRectangleHeightRatio * image.Height));
                            strMakroHTML = "<img src=" + newImage + " width=300 height=150 alt=''>";
                        }
                        else
                        {
                            strMakroHTML = "<img src=" + si.Makro.Image.UriSource.AbsolutePath + " width=300 height=150 alt=''>";

                        }
                        sContent = UpdateFields(sContent, "%%IMGTAG11%%", strMakroHTML);
                        sContent = UpdateFields(sContent, "%%IMGDAT11%%", "");
                    }
                    else
                    {
                        originalImage = @"C:/Projects/Molemax/Molemax.App/Images/Dummy/Ken/" + si.Dummy.Id + ".bmp";
                        fi = new FileInfo(originalImage);
                        newImage = _applicationSetting.Temp + "\\" + fi.Name;
                        image = System.Drawing.Image.FromFile(originalImage);
                        //ImageHelpers.AddRectangleOrPoint(originalImage, newImage, false, (int)(si.Mikro.FullPicPointX), (int)(si.Mikro.FullPicPointY));
                        ImageHelpers.AddRectangleOrPoint(originalImage, newImage, true, 50, 50, 100, 100);
                        strDummyHTML = "<img src=" + newImage + " width =300 height=150 alt=''>";
                        sContent = UpdateFields(sContent, "%%IMGTAG01%%", strDummyHTML);
                        sContent = UpdateFields(sContent, "%%IMGDAT01%%", "Date: test date");
                    }

                    if (si.CloseUp != null)
                    {

                        originalImage = si.CloseUp.Image.UriSource.AbsolutePath;
                        fi = new FileInfo(si.CloseUp.Image.UriSource.AbsolutePath);
                        newImage = _applicationSetting.Temp + "\\" + fi.Name;
                        image = System.Drawing.Image.FromFile(originalImage);
                        ImageHelpers.AddRectangleOrPoint(originalImage, newImage, false, (int)(si.Mikro.ImageAndRectangleXRatio * image.Width), (int)(si.Mikro.ImageAndRectangleYRatio * image.Height));
                        strCloseupHTML = "<img src=" + newImage + " width=300 height=150 alt=''>";

                        sContent = UpdateFields(sContent, "%%IMGTAG21%%", strCloseupHTML);
                        sContent = UpdateFields(sContent, "%%IMGDAT21%%", "");
                    }

                    strMikroHTML = "<img src=" + si.Mikro.Image.UriSource.AbsolutePath + " width=300 height=150 alt=''>";
                    sContent = UpdateFields(sContent, "%%IMGTAG02%%", strMikroHTML);
                    sContent = UpdateFields(sContent, "%%IMGDAT02%%", "");

                    if (historyList != null && historyList.Count > 1)
                    {
                        var strMikroFollowUp1HTML = "<img src=" + historyList[1].Image.UriSource.AbsolutePath + " width=300 height=150 alt=''>";
                        sContent = UpdateFields(sContent, "%%IMGTAG12%%", strMikroFollowUp1HTML);
                        sContent = UpdateFields(sContent, "%%IMGDAT12%%", "");

                        if (historyList.Count > 2)
                        {
                            var strMikroFollowUp2HTML = "<img src=" + historyList[2].Image.UriSource.AbsolutePath + " width=300 height=150 alt=''>";
                            sContent = UpdateFields(sContent, "%%IMGTAG22%%", strMikroFollowUp2HTML);
                            sContent = UpdateFields(sContent, "%%IMGDAT22%%", "");
                        }
                    }
                    break;
                case KIND_ENUM.KIND_CLOSEUP:
                    originalImage = @"C:/Projects/Molemax/Molemax.App/Images/Dummy/Ken/" + si.Dummy.Id + ".bmp";
                    fi = new FileInfo(originalImage);
                    newImage = _applicationSetting.Temp + "\\" + fi.Name;
                    image = System.Drawing.Image.FromFile(originalImage);
                    //ImageHelpers.AddRectangleOrPoint(originalImage, newImage, true, (int)(si.Makro.FullPicRectangleX), (int)(si.Makro.FullPicRectangleY), (int)(si.Makro.FullPicRectangleWidth), (int)(si.Makro.FullPicRectangleHeight));
                    ImageHelpers.AddRectangleOrPoint(originalImage, newImage, true, 50, 50, 100, 100);
                    strDummyHTML = "<img src=" + newImage + " width =300 height=150 alt=''>";
                    sContent = UpdateFields(sContent, "%%IMGTAG01%%", strDummyHTML);
                    sContent = UpdateFields(sContent, "%%IMGDAT01%%", "Date: test date");


                    originalImage = si.Makro.Image.UriSource.AbsolutePath;
                    fi = new FileInfo(originalImage);
                    newImage = _applicationSetting.Temp + "\\" + fi.Name;
                    image = System.Drawing.Image.FromFile(originalImage);
                    ImageHelpers.AddRectangleOrPoint(originalImage, newImage, true, (int)(si.CloseUp.ImageAndRectangleXRatio * image.Width), (int)(si.CloseUp.ImageAndRectangleYRatio * image.Height), (int)(si.CloseUp.ImageAndRectangleWidthRatio * image.Width), (int)(si.CloseUp.ImageAndRectangleHeightRatio * image.Height));
                    strMakroHTML = "<img src=" + newImage + " width=300 height=150 alt=''>";


                    sContent = UpdateFields(sContent, "%%IMGTAG11%%", strMakroHTML);
                    sContent = UpdateFields(sContent, "%%IMGDAT11%%", "");


                    strCloseupHTML = "<img src=" + si.CloseUp.Image.UriSource.AbsolutePath + " width=300 height=150 alt=''>";
                    sContent = UpdateFields(sContent, "%%IMGTAG02%%", strCloseupHTML);
                    sContent = UpdateFields(sContent, "%%IMGDAT02%%", "");

                    if (historyList != null && historyList.Count > 1)
                    {
                        var strCloseupFollowUp1HTML = "<img src=" + historyList[1].Image.UriSource.AbsolutePath + " width=300 height=150 alt=''>";
                        sContent = UpdateFields(sContent, "%%IMGTAG12%%", strCloseupFollowUp1HTML);
                        sContent = UpdateFields(sContent, "%%IMGDAT12%%", "");

                        if (historyList.Count > 2)
                        {
                            var strCloseupFollowUp2HTML = "<img src=" + historyList[2].Image.UriSource.AbsolutePath + " width=300 height=150 alt=''>";
                            sContent = UpdateFields(sContent, "%%IMGTAG22%%", strCloseupFollowUp2HTML);
                            sContent = UpdateFields(sContent, "%%IMGDAT22%%", "");
                        }
                    }
                    break;
                case KIND_ENUM.KIND_MAKRO:
                    originalImage = @"C:/Projects/Molemax/Molemax.App/Images/Dummy/Ken/" + si.Dummy.Id + ".bmp";
                    fi = new FileInfo(originalImage);
                    newImage = _applicationSetting.Temp + "\\" + fi.Name;
                    image = System.Drawing.Image.FromFile(originalImage);
                    //ImageHelpers.AddRectangleOrPoint(originalImage, newImage, true, (int)(si.Makro.FullPicRectangleX), (int)(si.Makro.FullPicRectangleY), (int)(si.Makro.FullPicRectangleWidth), (int)(si.Makro.FullPicRectangleHeight));
                    ImageHelpers.AddRectangleOrPoint(originalImage, newImage, true, 50, 50, 100, 100);
                    strDummyHTML = "<img src=" + newImage + " width =300 height=150 alt=''>";
                    sContent = UpdateFields(sContent, "%%IMGTAG01%%", strDummyHTML);
                    sContent = UpdateFields(sContent, "%%IMGDAT01%%", "Date: test date");

                    strMakroHTML = "<img src=" + si.Makro.Image.UriSource.AbsolutePath + " width=300 height=150 alt=''>";
                    sContent = UpdateFields(sContent, "%%IMGTAG02%%", strMakroHTML);
                    sContent = UpdateFields(sContent, "%%IMGDAT02%%", "");

                    if (historyList != null && historyList.Count > 1)
                    {
                        var strMakroFollowUp1HTML = "<img src=" + historyList[1].Image.UriSource.AbsolutePath + " width=300 height=150 alt=''>";
                        sContent = UpdateFields(sContent, "%%IMGTAG12%%", strMakroFollowUp1HTML);
                        sContent = UpdateFields(sContent, "%%IMGDAT12%%", "");

                        if (historyList.Count > 2)
                        {
                            var strMakroFollowUp2HTML = "<img src=" + historyList[2].Image.UriSource.AbsolutePath + " width=300 height=150 alt=''>";
                            sContent = UpdateFields(sContent, "%%IMGTAG22%%", strMakroFollowUp2HTML);
                            sContent = UpdateFields(sContent, "%%IMGDAT22%%", "");
                        }
                    }
                    break;
            }


            return sContent;
        }
        private string UpdateFields(string sContent, string sFieldCode, string sValue)
        {
            return sContent.Replace(sFieldCode, sValue);
        }

        private void Go33()
        {
            throw new NotImplementedException();
        }

        private void GoBack()
        {
            _keepLive = false;

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

        private void GoPrevious()
        {
            if (_iStartIndex - 3 < 0)
            {
                _iStartIndex = selectionImageList.Count - 3;
            }
            else
            {
                _iStartIndex -= 3;
            }
        }

        private void GoNext()
        {
            if (_iStartIndex + 3 >= selectionImageList.Count)
            {
                _iStartIndex = 0;
            }
            else
            {
                _iStartIndex += 3;
            }
        }

        private void GoMicro()
        {
            _imageOrderByKind = KIND_ENUM.KIND_MIKRO;
            _iStartIndex = 0;
            LoadSession();
        }

        private void GoCloseUp()
        {
            _imageOrderByKind = KIND_ENUM.KIND_CLOSEUP;
            _iStartIndex = 0;
            LoadSession();
        }

        private void GoMacro()
        {
            _imageOrderByKind = KIND_ENUM.KIND_MAKRO;
            _iStartIndex = 0;
            LoadSession();
        }
        #endregion
    }
}
