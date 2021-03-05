using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
    public class ucStiWiaViewModel : BindableBase, INavigationAware, IRegionMemberLifetime
    {
        private IRegionManager _regionManager;
        private IMolemaxRepository _repository;
        private IAppSettings _applicationSetting;
        private List<ExpressImage> _expressImageList;
        private List<string> _removedImageList;
        private IEnumerable<ExpressImage> _dbExpressImages
        {
            get { return _repository.ExpressImages.Get(); }
        }

        #region Property
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
        #endregion

        public ObservableCollection<ImageHandler> _imageDataList;
        public ObservableCollection<ImageHandler> ImageDataList
        {
            get { return _imageDataList; }
            set { SetProperty(ref _imageDataList, value); }
        }

        public ImageHandler _selectedImage;
        public ImageHandler SelectedImage
        {
            get { return _selectedImage; }
            set { SetProperty(ref _selectedImage, value); }
        }

        
        #endregion

        #region Command
        public DelegateCommand GoLocalizeCommand { get; set; }
        public DelegateCommand GoFullPictureCommand { get; set; }
        public DelegateCommand GoRemoveCommand { get; set; }
        public DelegateCommand GoBackCommand { get; set; }

        public bool KeepAlive => false;
        #endregion

        public ucStiWiaViewModel(IRegionManager regionManager, IMolemaxRepository molemaxRepository, IAppSettings applicationSetting)
        {
            _regionManager = regionManager;
            _repository = molemaxRepository;
            _applicationSetting = applicationSetting;
            _applicationSetting.LoadSettings();
            _removedImageList = new List<string>();
            GoLocalizeCommand = new DelegateCommand(GoLocalize);
            GoFullPictureCommand = new DelegateCommand(GoFullPicture);
            GoRemoveCommand = new DelegateCommand(GoRemove);
            GoBackCommand = new DelegateCommand(GoBack);
            FillSessionArrays();
        }

        private void GoFullPicture()
        {
            var navigationParameters = new NavigationParameters();

            navigationParameters.Add(Constants.ParaImage, SelectedImage.Image);
            _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.ImagePreview, navigationParameters);
        }

        private BitmapImage LoadImage(string filename)
        {
            return new BitmapImage(new Uri("pack://application:,,,/Images/Dummy/Ken/" + filename));
        }

        private void GoRemove()
        {
            if (SelectedImage != null)
            {
                var selectImageName = _expressImageList.Where(i => i.id == SelectedImage.Id).FirstOrDefault<ExpressImage>().imgname;
                _removedImageList.Add(selectImageName);
                //delete record 
                _repository.ExpressImages.Delete(SelectedImage.Id);
                ImageDataList = new ObservableCollection<ImageHandler>();
                FillSessionArrays();
            }
        }

        private void GoLocalize()
        {
            if (SelectedImage == null)
                return;

            var navigationParameters = new NavigationParameters();
            navigationParameters.Add(Constants.ucStiWia_Para, SelectedImage);
            navigationParameters.Add(Constants.ImageKind, KIND_ENUM.KIND_MIKRO);
            navigationParameters.Add(Constants.ImageSource, IMAGING_SOURCES_INDEX.SOURCE_LIVEVIDEO);
            navigationParameters.Add(Constants.FromForm, UserControlNames.StiWia);
            _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.Localization, navigationParameters);
        }

        private void FillSessionArrays()
        {
            _expressImageList = CreateImageArray();
            ImageDataList = new ObservableCollection<ImageHandler>(_expressImageList.Select(i => new ImageHandler
            {
                Id = i.id,
                Title = i.imgname.Split('_')[0].ToUpper(),
                Image = new BitmapImage(new Uri(GetFullPathForImage(i.imgname)))
            }));

        }

        private List<ExpressImage> CreateImageArray()
        {
            return _dbExpressImages.Where(i => i.patientId == GlobalValue.Instance.CurrentPatient.id).ToList<ExpressImage>();
        }

        private string GetFullPathForImage(string name)
        {
            return _applicationSetting.UnlocalizedImages + "\\" + name;
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
            //if (navigationContext.Parameters[Constants.FromForm] != null)
            //    fromForm = (string)navigationContext.Parameters[Constants.FromForm];
        }

        #region command functions
        private void GoBack()
        {
            var navigationParameters = new NavigationParameters();
            navigationParameters.Add(Constants.ParaImageList, _removedImageList);
            navigationParameters.Add(Constants.FromForm, UserControlNames.StiWia);
            _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.PatientMenu, navigationParameters);

            //_keepLive = false;

            //if (fromForm == UserControlNames.FupImageImport || fromForm == UserControlNames.FupLiveVideo || fromForm == UserControlNames.FupLocalization)
            //    _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.PatientMenu);
            //else
            //    _regionManager.RequestNavigate(RegionNames.ContentRegion, fromForm);
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

        }

        private void GoPrevious()
        {
            //if (_iStartIndex - 3 < 0)
            //{
            //    _iStartIndex = selectionImageList.Count - 3;
            //}
            //else
            //{
            //    _iStartIndex -= 3;
            //}
        }

        private void GoNext()
        {
            //if (_iStartIndex + 3 >= selectionImageList.Count)
            //{
            //    _iStartIndex = 0;
            //}
            //else
            //{
            //    _iStartIndex += 3;
            //}
        }



        #endregion
    }
}
