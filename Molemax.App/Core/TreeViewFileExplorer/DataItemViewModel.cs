using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Molemax.App.Core.TreeViewFileExplorer.Enums;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Prism.Commands;
using System.ComponentModel;

namespace Molemax.App.Core.TreeViewFileExplorer
{
    public class DataItemViewModel: BindableBase
    {
        public DataType Type { get; set; }

        public string FullPath { get; set; }

        public string Name { get { return Type == DataType.Drive ? FullPath : DirectoryStructure.GetFileOrFolderName(FullPath); } }

        public ObservableCollection<DataItemViewModel> _children;
        public ObservableCollection<DataItemViewModel> Children
        {
            get { return _children; }
            set { SetProperty(ref _children, value); }
        }

        public ObservableCollection<string> _imagesInSelectedFolder;
        public ObservableCollection<string> ImagesInSelectedFolder
        {
            get { return _imagesInSelectedFolder; }
            set { SetProperty(ref _imagesInSelectedFolder, value); }
        }

        public ICommand ExpandCommand { get; set; }

        public bool CanExpand
        {
            get
            {
                return Type != DataType.File;
            }
        }

        public bool IsExpanded
        {
            get
            {
                return Children?.Count(f => f != null) > 0;
            }
            set
            {
                if (value == true)
                {
                    Expand();

                    if (Type == DataType.FolderClosed)
                    {
                        Type = DataType.FolderOpened;
                    }
                }
                else
                {
                    ClearChildren();

                    if (Type != DataType.Drive)
                    {
                        Type = DataType.FolderClosed;
                    }
                }
            }
        }

        public bool IsSelected
        {
            set
            {
               Select();
            }
        }

        private void Select()
        {
            var children = DirectoryStructure.GetDirectoryContents(FullPath);
            var imageChildren = children.Where(content => content.Type == DataType.File && content.FullPath.EndsWith(".jpg"));

            RaiseUpdateImage(new ObservableCollection<string>(imageChildren.Select(content => content.FullPath)));
        }

        public event EventHandler<ObservableCollection<string>> UpdateImagePath;

        private void RaiseUpdateImage(ObservableCollection<string> e)
        {
            UpdateImagePath?.Invoke(this, e);
        }

        public DataItemViewModel(string fullPath, DataType type)
        {
            Type = type;
            FullPath = fullPath;
            ExpandCommand =  new DelegateCommand(Expand);
            ClearChildren();

            //PropertyChanged += new PropertyChangedEventHandler(DataItemViewModel_PropertyChanged);
        }

        //private void DataItemViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //    if (string.Equals(e.PropertyName, "IsSelected", StringComparison.CurrentCultureIgnoreCase))
        //    {
        //        if (((DataItemViewModel)sender).IsSelected)
        //        {
        //            if (((DataItemViewModel)sender).FullPath.EndsWith(".jpg"))
        //            {
        //                RaiseUpdateImage(((DataItemViewModel)sender).FullPath);
        //            }
        //        }
        //    }
        //}

        private void ClearChildren()
        {
            Children = new ObservableCollection<DataItemViewModel>();

            if (Type != DataType.File)
            {
                Children.Add(null);
            }
            else
            {
                Children = new ObservableCollection<DataItemViewModel>();
            }
        }

        private void Expand()
        {
            if (Type == DataType.File)
            {
                return;
            }

            // I want to display the drives VolumeLabel, due to the way the Model/ViewModels are setup and this is just practice...
            var children = DirectoryStructure.GetDirectoryContents(FullPath);

            var folderChildren = children.Where(content => content.Type != DataType.File);
            var fileChildren = children.Where(content => content.Type == DataType.File && content.FullPath.EndsWith(".jpg"));


            Children = new ObservableCollection<DataItemViewModel>(folderChildren.Select(content =>
            {
                var dateItemVM = new DataItemViewModel(content.FullPath, content.Type);
                dateItemVM.UpdateImagePath += UpdateImagePathFromSelected;

                return dateItemVM;
            } ));

            //ImagesInSelectedFolder = new ObservableCollection<string>(fileChildren.Select(content => content.FullPath));
        }

        private void UpdateImagePathFromSelected(object sender, ObservableCollection<string> e)
        {
            RaiseUpdateImage(e);
        }
    }

}
