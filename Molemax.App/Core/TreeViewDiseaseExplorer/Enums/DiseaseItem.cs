using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Molemax.App.Core.TreeViewDiseaseExplorer.Enums
{
    public class DiseaseItem
    {
        public DataType Type { get; set; }
        public string DiseaseName { get; set; }
        public string CategoryOrImageId { get; set; }
        public string ParentCategoryId { get; set; }
        public string Category { get; set; }
        public int IsFirstLevelCategory { get; set; }
        public string Description { get; set; }
        public string ImageId { get; set; }
        public BitmapImage DiseaseImage { get; set; }
    }
}
