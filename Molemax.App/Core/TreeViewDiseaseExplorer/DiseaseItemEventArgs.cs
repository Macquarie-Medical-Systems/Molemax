using Molemax.App.Core.TreeViewDiseaseExplorer.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molemax.App.Core.TreeViewDiseaseExplorer
{
    public class DiseaseItemEventArgs: EventArgs
    {
        public ObservableCollection<DiseaseItem> DiseaseList { get; set; }
        public DataType DiseaseType { get; set; }
        public string DiseaseName { get; set; }
        public DiseaseItemEventArgs(ObservableCollection<DiseaseItem> list, DataType diseaseType, string diseaseName)
        {
            DiseaseList = list;
            DiseaseType = diseaseType;
            DiseaseName = diseaseName;
        }
    }
}
