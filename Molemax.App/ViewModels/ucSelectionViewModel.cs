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
    public class ucSelectionViewModel : BindableBase, IRegionMemberLifetime, INavigationAware
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
        private Visibility __image00PointVisible;
        public Visibility Image00PointVisible
        {
            get { return __image00PointVisible; }
            set { SetProperty(ref __image00PointVisible, value); }
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
        public DelegateCommand<object> GoFollowUpCommand { get; set; }
        public DelegateCommand GoTrendingCommand { get; set; }
        public DelegateCommand GoDetailsCommand { get; set; }
        public DelegateCommand GoImageFileImportCommand { get; set; }
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

        public ucSelectionViewModel(IRegionManager regionManager, IMolemaxRepository molemaxRepository, IAppSettings applicationSetting)
        {
            _regionManager = regionManager;
            _repository = molemaxRepository;
            _applicationSetting = applicationSetting;
            GoMacroCommand = new DelegateCommand(GoMacro);
            GoCloseUpCommand = new DelegateCommand(GoCloseUp);
            GoMicroCommand = new DelegateCommand(GoMicro);
            GoNextCommand = new DelegateCommand(GoNext);
            GoPreviousCommand = new DelegateCommand(GoPrevious);
            GoFollowUpCommand = new DelegateCommand<object>(GoFollowUp);
            GoTrendingCommand = new DelegateCommand(GoTrending);
            GoDetailsCommand = new DelegateCommand(GoDetails);
            GoImageFileImportCommand = new DelegateCommand(GoImageFileImport);
            GoBackCommand = new DelegateCommand(GoBack);
            Go33Command = new DelegateCommand(Go33);
            GoImageHistoryMouseLeftButtonDownCommand = new DelegateCommand<object>(GoImageHistoryMouseLeftButtonDown);
            GoImageMouseLeftButtonDownCommand = new DelegateCommand<object>(GoImageMouseLeftButtonDown);

            selectionImageList = new List<SelectionImage>();

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
            _iMakroImageCount = makroList.Count;

            //final closeup list
            var closeupList = closeupWithNoFupList.Concat(closeupWithFupList).OrderByDescending(item => item.image.tsId).ToList();
            _iCloseUpImageCount = closeupList.Count;
            //final closeup list
            var mikroList = mikroWithNoFupList.Concat(mikroWithFupList).OrderByDescending(item => item.image.tsId).ToList();
            _iMikroImageCount = mikroList.Count;


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
            int index = Convert.ToInt32(obj);


            //image00 image01 image02 --> 0  1  2 -->selectionImageList[0]
            //image10 image11 image12 --> 3  4  5 -->selectionImageList[1]
            //image20 image21 image22 --> 6  7  8 -->selectionImageList[2]

            switch (index)
            {
                case 0:
                case 1:
                case 2:
                    si = displayImageList[0];
                    ChangeTextBackGround(index);
                    break;
                case 3:
                case 4:
                case 5:
                    si = displayImageList[1];
                    ChangeTextBackGround(index);
                    break;
                case 6:
                case 7:
                case 8:
                    si = displayImageList[2];
                    ChangeTextBackGround(index);
                    break;
            }


            //mouse click on Makro images
            if (index == 0 || index == 3 || index == 6)
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
                            ImageHistoryTextBackground = Brushes.Transparent
                        }); ;

                    ImageHistoryList = new ObservableCollection<ImageHandler>(tempImageList);
                }
                else
                {
                    ImageHistoryList = new ObservableCollection<ImageHandler>(); ;
                }
            }

            //mouse click on Closeup images
            if (index == 1 || index == 4 || index == 7)
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
                        });

                    ImageHistoryList = new ObservableCollection<ImageHandler>(tempImageList);
                }
                else
                {
                    ImageHistoryList = new ObservableCollection<ImageHandler>(); ;
                }
            }

            //mouse click on mikro images
            if (index == 2 || index == 5 || index == 8)
            {
                if (si.Mikro.Id == 0)
                    return;

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
                        });

                    ImageHistoryList = new ObservableCollection<ImageHandler>(tempImageList);
                }
                else
                {
                    ImageHistoryList = new ObservableCollection<ImageHandler>(); ;
                }
            }
        }

        private void ChangeTextBackGround(int index)
        {
            switch (index)
            {
                case 0:
                    Image00TextBackground = Brushes.Red;
                    Image01TextBackground = Brushes.Transparent;
                    Image02TextBackground = Brushes.Transparent;
                    Image10TextBackground = Brushes.Transparent;
                    Image11TextBackground = Brushes.Transparent;
                    Image12TextBackground = Brushes.Transparent;
                    Image20TextBackground = Brushes.Transparent;
                    Image21TextBackground = Brushes.Transparent;
                    Image22TextBackground = Brushes.Transparent;
                    break;
                case 1:
                    Image00TextBackground = Brushes.Transparent;
                    Image01TextBackground = Brushes.Red;
                    Image02TextBackground = Brushes.Transparent;
                    Image10TextBackground = Brushes.Transparent;
                    Image11TextBackground = Brushes.Transparent;
                    Image12TextBackground = Brushes.Transparent;
                    Image20TextBackground = Brushes.Transparent;
                    Image21TextBackground = Brushes.Transparent;
                    Image22TextBackground = Brushes.Transparent;
                    break;
                case 2:
                    Image00TextBackground = Brushes.Transparent;
                    Image01TextBackground = Brushes.Transparent;
                    Image02TextBackground = Brushes.Red;
                    Image10TextBackground = Brushes.Transparent;
                    Image11TextBackground = Brushes.Transparent;
                    Image12TextBackground = Brushes.Transparent;
                    Image20TextBackground = Brushes.Transparent;
                    Image21TextBackground = Brushes.Transparent;
                    Image22TextBackground = Brushes.Transparent;
                    break;
                case 3:
                    Image00TextBackground = Brushes.Transparent;
                    Image01TextBackground = Brushes.Transparent;
                    Image02TextBackground = Brushes.Transparent;
                    Image10TextBackground = Brushes.Red;
                    Image11TextBackground = Brushes.Transparent;
                    Image12TextBackground = Brushes.Transparent;
                    Image20TextBackground = Brushes.Transparent;
                    Image21TextBackground = Brushes.Transparent;
                    Image22TextBackground = Brushes.Transparent;
                    break;
                case 4:
                    Image00TextBackground = Brushes.Transparent;
                    Image01TextBackground = Brushes.Transparent;
                    Image02TextBackground = Brushes.Transparent;
                    Image10TextBackground = Brushes.Transparent;
                    Image11TextBackground = Brushes.Red;
                    Image12TextBackground = Brushes.Transparent;
                    Image20TextBackground = Brushes.Transparent;
                    Image21TextBackground = Brushes.Transparent;
                    Image22TextBackground = Brushes.Transparent;
                    break;
                case 5:
                    Image00TextBackground = Brushes.Transparent;
                    Image01TextBackground = Brushes.Transparent;
                    Image02TextBackground = Brushes.Transparent;
                    Image10TextBackground = Brushes.Transparent;
                    Image11TextBackground = Brushes.Transparent;
                    Image12TextBackground = Brushes.Red;
                    Image20TextBackground = Brushes.Transparent;
                    Image21TextBackground = Brushes.Transparent;
                    Image22TextBackground = Brushes.Transparent;
                    break;
                case 6:
                    Image00TextBackground = Brushes.Transparent;
                    Image01TextBackground = Brushes.Transparent;
                    Image02TextBackground = Brushes.Transparent;
                    Image10TextBackground = Brushes.Transparent;
                    Image11TextBackground = Brushes.Transparent;
                    Image12TextBackground = Brushes.Transparent;
                    Image20TextBackground = Brushes.Red;
                    Image21TextBackground = Brushes.Transparent;
                    Image22TextBackground = Brushes.Transparent;
                    break;
                case 7:
                    Image00TextBackground = Brushes.Transparent;
                    Image01TextBackground = Brushes.Transparent;
                    Image02TextBackground = Brushes.Transparent;
                    Image10TextBackground = Brushes.Transparent;
                    Image11TextBackground = Brushes.Transparent;
                    Image12TextBackground = Brushes.Transparent;
                    Image20TextBackground = Brushes.Transparent;
                    Image21TextBackground = Brushes.Red;
                    Image22TextBackground = Brushes.Transparent;
                    break;
                case 8:
                    Image00TextBackground = Brushes.Transparent;
                    Image01TextBackground = Brushes.Transparent;
                    Image02TextBackground = Brushes.Transparent;
                    Image10TextBackground = Brushes.Transparent;
                    Image11TextBackground = Brushes.Transparent;
                    Image12TextBackground = Brushes.Transparent;
                    Image20TextBackground = Brushes.Transparent;
                    Image21TextBackground = Brushes.Transparent;
                    Image22TextBackground = Brushes.Red;
                    break;
            }
        }

        private void Go33()
        {
            throw new NotImplementedException();
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
