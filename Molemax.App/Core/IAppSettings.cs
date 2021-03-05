using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molemax.App.Core
{
    public interface IAppSettings
    {
        string FollowUpLiveVideoMode { get; set; }
        string FollowUpLiveImageMode { get; set; }
        string SheetDisplayMode { get; set; }
        string SelectImageSource_LiveVideo { get; set; }
        string SelectImageSource_LiveImage { get; set; }
        string SelectImageSource_FileImport { get; set; }
        string SelectImageSource_Extern { get; set; }
        string ImagePath { get; set; }
        string Temp { get; set; }
        string UnlocalizedImages { get; set; }
        void LoadSettings();
        void SaveSettings();
    }
}
