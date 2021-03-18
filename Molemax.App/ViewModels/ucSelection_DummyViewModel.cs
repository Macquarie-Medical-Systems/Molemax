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
        private ObservableCollection<ImageHandler> _imageHistoryList;
        public ObservableCollection<ImageHandler> ImageHistoryList
        {
            get { return _imageHistoryList; }
            set { SetProperty(ref _imageHistoryList, value); }
        }

        #endregion

        #region Command
        public DelegateCommand<object> GoFollowUpCommand { get; set; }
        public DelegateCommand GoTrendingCommand { get; set; }
        public DelegateCommand GoDetailsCommand { get; set; }
        public DelegateCommand GoImageFileImportCommand { get; set; }
        public DelegateCommand GoBackCommand { get; set; }
        public DelegateCommand<object> GoImageHistoryMouseLeftButtonDownCommand { get; set; }
        public DelegateCommand<object> GoImageMouseLeftButtonDownCommand { get; set; }
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
            GoFollowUpCommand = new DelegateCommand<object>(GoFollowUp);
            GoTrendingCommand = new DelegateCommand(GoTrending);
            GoDetailsCommand = new DelegateCommand(GoDetails);
            GoImageFileImportCommand = new DelegateCommand(GoImageFileImport);
            GoBackCommand = new DelegateCommand(GoBack);
            GoImageHistoryMouseLeftButtonDownCommand = new DelegateCommand<object>(GoImageHistoryMouseLeftButtonDown);
            GoImageMouseLeftButtonDownCommand = new DelegateCommand<object>(GoImageMouseLeftButtonDown);

            selectionImageList = new List<SelectionImage>();

            Initialize();
        }

        private void Initialize()
        {
            ImageHistoryList = new ObservableCollection<ImageHandler>();

            _imageOrderByKind = KIND_ENUM.KIND_MAKRO;
            _iStartIndex = 0;
            //LoadSession();
        }

        private void LoadSession()
        {
            FillSessionArrays();
        }

        private void FillSessionArrays()
        {
            GetSession();
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
                   break;
                case 3:
                case 4:
                case 5:
                    si = displayImageList[1];
                    break;
                case 6:
                case 7:
                case 8:
                    si = displayImageList[2];
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

            //mouse click on Closeup images
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

        #endregion
    }


}
