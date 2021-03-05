using Molemax.App.Core;
using Molemax.App.Core.TreeViewFileExplorer;
using Molemax.App.Core.TreeViewFileExplorer.Enums;
using Molemax.Models;
using Molemax.Repository;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Molemax.App.ViewModels
{
    public class ucImageImportViewModel : BindableBase, IRegionMemberLifetime, INavigationAware
    {
        private string fromForm;
        private string fromControl;
        private IRegionManager _regionManager;
        private IMolemaxRepository _repository;
        private Patient patientModel;
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
        #region Property
        public BitmapSource _selectedImage;
        public BitmapSource SelectedImage
        {
            get { return _selectedImage; }
            set { SetProperty(ref _selectedImage, value); }
        }

        public ObservableCollection<BitmapSource> _imagesInSelectedFolder;
        public ObservableCollection<BitmapSource> ImagesInSelectedFolder
        {
            get { return _imagesInSelectedFolder; }
            set { SetProperty(ref _imagesInSelectedFolder, value); }
        }

        public string _folderName;
        public string FolderName
        {
            get { return _folderName; }
            set { SetProperty(ref _folderName, value); }
        }

        public bool _isCloseupButtomEnabled;
        public bool IsCloseupButtomEnabled
        {
            get { return _isCloseupButtomEnabled; }
            set { SetProperty(ref _isCloseupButtomEnabled, value); }
        }

        public ObservableCollection<DataItemViewModel> _items;
        public ObservableCollection<DataItemViewModel> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }

        #endregion

        #region Command
        public DelegateCommand GoImportMacroCommand { get; set; }
        public DelegateCommand GoImportCloseUpCommand { get; set; }
        public DelegateCommand GoImportMicroCommand { get; set; }
        public DelegateCommand GoBackCommand { get; set; }
        #endregion

        private bool _keepLive = false;
        public bool KeepAlive
        {
            get { return _keepLive; }
        }

        public ucImageImportViewModel(IRegionManager regionManager, IMolemaxRepository molemaxRepository)
        {
            _regionManager = regionManager;
            _repository = molemaxRepository;
            GoImportMacroCommand = new DelegateCommand(GoImportMacro);
            GoImportMicroCommand = new DelegateCommand(GoImportMicro);
            GoImportCloseUpCommand = new DelegateCommand(GoImportCloseUp, GoImportCloseUpCanExecute)
                .ObservesProperty(() => IsCloseupButtomEnabled);
            GoBackCommand = new DelegateCommand(GoBack);

            var children = DirectoryStructure.GetLogicalDrives();

            Items = new ObservableCollection<DataItemViewModel>(children.Select(drive => 
            {
                var dateItemVM =  new DataItemViewModel(drive.FullPath, DataType.Drive);
                dateItemVM.UpdateImagePath += UpdateImagePathFromSelected;
                return dateItemVM;
            }
            ));

        }

        private bool GoImportCloseUpCanExecute()
        {
            return IsCloseupButtomEnabled;
        }

        private void GoImportCloseUp()
        {
            if (SelectedImage == null)
                return;

            _keepLive = true;
            var navigationParameters = new NavigationParameters();

            navigationParameters.Add(Constants.ParaImage, SelectedImage);
            navigationParameters.Add(Constants.ImageKind, KIND_ENUM.KIND_CLOSEUP);
            navigationParameters.Add(Constants.ImageSource, IMAGING_SOURCES_INDEX.SOURCE_FILEIMPORT);
            _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.Localization, navigationParameters);
        }

        private void GoImportMicro()
        {
            if (SelectedImage == null)
                return;

            _keepLive = true;
            var navigationParameters = new NavigationParameters();

            navigationParameters.Add(Constants.ParaImage, SelectedImage);
            navigationParameters.Add(Constants.ImageKind, KIND_ENUM.KIND_MIKRO);
            navigationParameters.Add(Constants.ImageSource, IMAGING_SOURCES_INDEX.SOURCE_FILEIMPORT);
            _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.Localization, navigationParameters);
        }

        private void GoBack()
        {
            _keepLive = false;
            var navigationParameters = new NavigationParameters();
            navigationParameters.Add(Constants.FromForm, UserControlNames.ImageImport);
            switch (fromForm)
            {
                case UserControlNames.Patient:
                    switch (fromControl)
                    {
                        case Constants.FaceImageFileImport:
                            _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.Patient,navigationParameters);
                            break;
                        case Constants.ImportSourceFileImport:
                            _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.PatientMenu, navigationParameters);
                            break;
                    }
                    break;
                case UserControlNames.Localization:
                case UserControlNames.PatientMenu:
                    _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.PatientMenu, navigationParameters);
                    break;
            }
        }

        private void GoImportMacro()
        {
            if (SelectedImage == null)
                return;

            _keepLive = true;
            var navigationParameters = new NavigationParameters();

            navigationParameters.Add(Constants.ParaImage, SelectedImage);
            navigationParameters.Add(Constants.ImageKind, KIND_ENUM.KIND_MAKRO);
            navigationParameters.Add(Constants.ImageSource, IMAGING_SOURCES_INDEX.SOURCE_FILEIMPORT);
            _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.Localization, navigationParameters);
        }

        public void UpdateImagePathFromSelected(object sender, ObservableCollection<string> e)
        {
            ImagesInSelectedFolder = new ObservableCollection<BitmapSource>();
            foreach(var item in e)
            {
                ImagesInSelectedFolder.Add(new BitmapImage(new Uri(item)));
            }
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext.Parameters[Constants.FromForm] != null)
                fromForm = (string)navigationContext.Parameters[Constants.FromForm];

            if (navigationContext.Parameters[Constants.FromControl] != null)
                fromControl = (string)navigationContext.Parameters[Constants.FromControl];

            if (GlobalValue.Instance.CurrentPatient != null)
            {
                IsCloseupButtomEnabled = IsMakroImageExist();
            }
            
        }

        private bool IsMakroImageExist()
        {
            var makroList = _dbImages.Join(_dbMakros, im => im.id, ma => ma.imageId, (image, makro) => new { image, makro }).Join(_dbTimestamps, i => i.image.tsId, ts => ts.id, (imageAndMakro, ts) => new { imageAndMakro, ts })
                                      .Where(item => item.imageAndMakro.makro.fupId == 0 && item.imageAndMakro.image.kind == 1 && item.imageAndMakro.image.patientId == GlobalValue.Instance.CurrentPatient.id)
                                      .OrderByDescending(item => item.imageAndMakro.image.tsId)
                                      .Select(m => new ImageHandler
                                      {
                                          ImageId = m.imageAndMakro.image.id,
                                          ContainerImageId = m.imageAndMakro.image.id,
                                          Kenpos = m.imageAndMakro.image.kenpos,
                                          Loctext = m.imageAndMakro.image.loctext,
                                          CreateDate = m.ts.date_created.ToString("d"),
                                          Image = new BitmapImage(new Uri(m.imageAndMakro.image.defpath + "\\" + m.imageAndMakro.image.imgname)),
                                          SmallKen = new BitmapImage(new Uri($"pack://application:,,,/Images/Dummy/SmallKen/{m.imageAndMakro.image.kenpos}.bmp"))
                                      }).ToList();
            return makroList.Count > 0;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }
    }
}
