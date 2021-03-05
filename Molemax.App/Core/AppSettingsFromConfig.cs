using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molemax.App.Core
{
    public class AppSettingsFromConfig: IAppSettings
    {
        public string FollowUpLiveVideoMode { get; set; }
        public string FollowUpLiveImageMode { get ; set ; }
        public string SheetDisplayMode { get; set; }
        public string SelectImageSource_LiveVideo { get; set; }
        public string SelectImageSource_LiveImage { get; set; }
        public string SelectImageSource_FileImport { get; set; }
        public string SelectImageSource_Extern { get; set; }
        public string ImagePath { get; set; }
        public string Temp { get; set; }
        public string UnlocalizedImages { get; set; }
        public void LoadSettings()
        {
            FollowUpLiveVideoMode = Properties.Settings.Default.FollowUpLiveVideoMode;
            FollowUpLiveImageMode = Properties.Settings.Default.FollowUpLiveImageMode;
            SheetDisplayMode = Properties.Settings.Default.SheetDisplayMode;
            SelectImageSource_LiveVideo = Properties.Settings.Default.SelectImageSource_LiveVideo;
            SelectImageSource_LiveImage = Properties.Settings.Default.SelectImageSource_LiveImage;
            SelectImageSource_FileImport = Properties.Settings.Default.SelectImageSource_FileImport;
            SelectImageSource_Extern = Properties.Settings.Default.SelectImageSource_Extern;
            ImagePath = Properties.Settings.Default.ImagePath;
            Temp = Properties.Settings.Default.Temp;
            UnlocalizedImages = Properties.Settings.Default.UnlocalizedImages;
        }

        public void SaveSettings()
        {
            Properties.Settings.Default.FollowUpLiveVideoMode = FollowUpLiveVideoMode;
            Properties.Settings.Default.FollowUpLiveImageMode = FollowUpLiveImageMode;
            Properties.Settings.Default.SheetDisplayMode = SheetDisplayMode;
            Properties.Settings.Default.SelectImageSource_LiveVideo = SelectImageSource_LiveVideo;
            Properties.Settings.Default.SelectImageSource_LiveImage = SelectImageSource_LiveImage;
            Properties.Settings.Default.SelectImageSource_FileImport = SelectImageSource_FileImport;
            Properties.Settings.Default.SelectImageSource_Extern = SelectImageSource_Extern;
            Properties.Settings.Default.ImagePath = ImagePath;
            Properties.Settings.Default.Temp = Temp;
            Properties.Settings.Default.UnlocalizedImages = UnlocalizedImages;
            Properties.Settings.Default.Save();
        }
    }
}
