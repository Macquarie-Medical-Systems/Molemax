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
    public class ucFupImageImportViewModel : BindableBase, IRegionMemberLifetime, INavigationAware
    {
        private KIND_ENUM _imageKind;
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

        public ImageHandler _paraImage;
        public ImageHandler ParaImage
        {
            get { return _paraImage; }
            set { SetProperty(ref _paraImage, value); }
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

        public bool _isMikroButtomEnabled;
        public bool IsMikroButtomEnabled
        {
            get { return _isMikroButtomEnabled; }
            set { SetProperty(ref _isMikroButtomEnabled, value); }
        }

        public bool _isMakroButtomEnabled;
        public bool IsMakroButtomEnabled
        {
            get { return _isMakroButtomEnabled; }
            set { SetProperty(ref _isMakroButtomEnabled, value); }
        }

        public ObservableCollection<DataItemViewModel> _items;
        public ObservableCollection<DataItemViewModel> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }

        #endregion

        private bool _keepLive = false;
        public bool KeepAlive
        {
            get { return _keepLive; }
        }

        #region Command
        public DelegateCommand GoImportMacroCommand { get; set; }
        public DelegateCommand GoImportCloseUpCommand { get; set; }
        public DelegateCommand GoImportMicroCommand { get; set; }
        public DelegateCommand GoBackCommand { get; set; }
        #endregion
        public ucFupImageImportViewModel(IRegionManager regionManager, IMolemaxRepository molemaxRepository)
        {
            _regionManager = regionManager;
            _repository = molemaxRepository;
            GoImportMacroCommand = new DelegateCommand(GoImportMacro).ObservesCanExecute(() => IsMakroButtomEnabled);
            GoImportMicroCommand = new DelegateCommand(GoImportMicro).ObservesCanExecute(() => IsMikroButtomEnabled);
            GoImportCloseUpCommand = new DelegateCommand(GoImportCloseUp).ObservesCanExecute(() => IsCloseupButtomEnabled);
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

        private void GoImportCloseUp()
        {
            var navigationParameters = new NavigationParameters();

            navigationParameters.Add(Constants.FromForm, UserControlNames.FupImageImport);
            navigationParameters.Add(Constants.FupImage, SelectedImage);
            navigationParameters.Add(Constants.OriginalImage, ParaImage);
            navigationParameters.Add(Constants.ImageKind, KIND_ENUM.KIND_CLOSEUP);
            navigationParameters.Add(Constants.ImageSource, IMAGING_SOURCES_INDEX.SOURCE_FILEIMPORT);
            _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.FupLocalization, navigationParameters);
        }

        private void GoImportMicro()
        {
            var navigationParameters = new NavigationParameters();

            navigationParameters.Add(Constants.FromForm, UserControlNames.FupImageImport);
            navigationParameters.Add(Constants.FupImage, SelectedImage);
            navigationParameters.Add(Constants.OriginalImage, ParaImage);
            navigationParameters.Add(Constants.ImageKind, KIND_ENUM.KIND_MIKRO);
            navigationParameters.Add(Constants.ImageSource, IMAGING_SOURCES_INDEX.SOURCE_FILEIMPORT);
            _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.FupLocalization, navigationParameters);
        }

        private void GoBack()
        {
            var navigationParameters = new NavigationParameters();
            navigationParameters.Add(Constants.FromForm, UserControlNames.FupImageImport);
            _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.Selection, navigationParameters);
        }

        private void GoImportMacro()
        {
            var navigationParameters = new NavigationParameters();

            navigationParameters.Add(Constants.FromForm, UserControlNames.FupImageImport);
            navigationParameters.Add(Constants.FupImage, SelectedImage);
            navigationParameters.Add(Constants.OriginalImage, ParaImage);
            navigationParameters.Add(Constants.ImageKind, KIND_ENUM.KIND_MAKRO);
            navigationParameters.Add(Constants.ImageSource, IMAGING_SOURCES_INDEX.SOURCE_FILEIMPORT);
            _regionManager.RequestNavigate(RegionNames.ContentRegion, UserControlNames.FupLocalization, navigationParameters);
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
            if (navigationContext.Parameters[Constants.ParaImage] != null)
                ParaImage = (ImageHandler)navigationContext.Parameters[Constants.ParaImage];
            else
                ParaImage = null;

            if (navigationContext.Parameters[Constants.ImageKind] != null)
            {
                _imageKind = (KIND_ENUM)Enum.Parse(typeof(KIND_ENUM), navigationContext.Parameters[Constants.ImageKind].ToString());
                switch (_imageKind)
                {
                    case KIND_ENUM.KIND_MIKRO:
                        IsMikroButtomEnabled = true;
                        IsMakroButtomEnabled = false;
                        IsCloseupButtomEnabled = false;
                        break;
                    case KIND_ENUM.KIND_MAKRO:
                        IsMikroButtomEnabled = false;
                        IsMakroButtomEnabled = true;
                        IsCloseupButtomEnabled = false;
                        break;
                    case KIND_ENUM.KIND_CLOSEUP:
                        IsMikroButtomEnabled = false;
                        IsMakroButtomEnabled = false;
                        IsCloseupButtomEnabled = true;
                        break;
                }
            }
          
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
