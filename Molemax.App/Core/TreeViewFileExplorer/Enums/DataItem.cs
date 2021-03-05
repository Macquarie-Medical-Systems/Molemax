using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molemax.App.Core.TreeViewFileExplorer.Enums
{
    public class DataItem
    {
        public DataType Type { get; set; }

        public string FullPath { get; set; }

        public string Name
        {
            get
            {
                return Type == DataType.Drive ? FullPath : DirectoryStructure.GetFileOrFolderName(FullPath);
            }
        }
    }
}
