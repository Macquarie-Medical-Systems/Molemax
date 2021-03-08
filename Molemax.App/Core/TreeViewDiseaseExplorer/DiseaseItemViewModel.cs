using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Molemax.App.Core.TreeViewDiseaseExplorer.Enums;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Prism.Commands;
using System.ComponentModel;

namespace Molemax.App.Core.TreeViewDiseaseExplorer
{
    public class DiseaseItemViewModel: BindableBase
    {
        public DataType Type { get; set; }
        public string DiseaseName { get; set; }
        public string CategoryOrImageId { get; set; }
        public string Name { get { return DiseaseName; } }

        public ObservableCollection<DiseaseItemViewModel> _children;
        public ObservableCollection<DiseaseItemViewModel> Children
        {
            get { return _children; }
            set { SetProperty(ref _children, value); }
        }

        //public ObservableCollection<DiseaseItem> _selectedDisease;
        //public ObservableCollection<DiseaseItem> SelectedDiseases
        //{
        //    get { return _selectedDisease; }
        //    set { SetProperty(ref _selectedDisease, value); }
        //}

        //public ICommand ExpandCommand { get; set; }

        public bool CanExpand
        {
            get
            {
                return Type != DataType.Disease;
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

                    if (Type == DataType.CategoryClosed)
                    {
                        Type = DataType.CategoryOpened;
                    }
                }
                else
                {
                    ClearChildren();

                    //if (Type != DataType.Drive)
                    //{
                    //    Type = DataType.FolderClosed;
                    //}
                }
            }
        }

        public bool IsSelected
        {
            set
            {
                if(value == true)
                {
                    Select();
                }
                else
                {

                }
            }
        }

        private void Select()
        {
            if (Type == DataType.CategoryClosed || Type == DataType.CategoryOpened || Type == DataType.Pending)
            {
                var children = DiseaseStructure.GetSubCategoriesAndDiseases(CategoryOrImageId);
                var diseaseChildren = children.Where(content => content.Type == DataType.Disease);
                RaiseUpdateImage(new DiseaseItemEventArgs(new ObservableCollection<DiseaseItem>(diseaseChildren), Type));
            }
            
            if (Type == DataType.Disease)
            {
                var current = DiseaseStructure.GetDisease(CategoryOrImageId);
                RaiseUpdateImage(new DiseaseItemEventArgs(new ObservableCollection<DiseaseItem>(current), Type));
            }
        }

        public event EventHandler<DiseaseItemEventArgs> UpdateImagePath;

        private void RaiseUpdateImage(DiseaseItemEventArgs e)
        {
            UpdateImagePath?.Invoke(this, e);
        }

        public DiseaseItemViewModel(string diseaseName, string id, DataType type)
        {
            Type = type;
            DiseaseName = diseaseName;
            CategoryOrImageId = id;
            //ExpandCommand =  new DelegateCommand(Expand);
            ClearChildren();
            //test
            //PropertyChanged += new PropertyChangedEventHandler(DataItemViewModel_PropertyChanged);
        }

        private void ClearChildren()
        {
            Children = new ObservableCollection<DiseaseItemViewModel>();

            if (Type != DataType.Disease)
            {
                Children.Add(null);
            }
            else
            {
                Children = new ObservableCollection<DiseaseItemViewModel>();
            }
        }

        private void Expand()
        {
            if (Type == DataType.Disease)
            {
                return;
            }

            // I want to display the drives VolumeLabel, due to the way the Model/ViewModels are setup and this is just practice...
            var children = DiseaseStructure.GetSubCategoriesAndDiseases(CategoryOrImageId);

            //var categoryChildren = children.Where(content => content.Type != DataType.Disease);
            //var diseaseChildren = children.Where(content => content.Type == DataType.Disease);


            Children = new ObservableCollection<DiseaseItemViewModel>(children.Select(i =>
            {
                var dateItemVM = new DiseaseItemViewModel(i.DiseaseName, i.CategoryOrImageId, i.Type);
                dateItemVM.UpdateImagePath += UpdateImagePathFromSelected;

                return dateItemVM;
            } ));

            //ImagesInSelectedFolder = new ObservableCollection<string>(fileChildren.Select(content => content.FullPath));
        }

        private void UpdateImagePathFromSelected(object sender, DiseaseItemEventArgs e)
        {
            RaiseUpdateImage(e);
        }
    }

}
