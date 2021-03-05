using Molemax.App.Core;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Molemax.App.Views
{
    /// <summary>
    /// Interaction logic for frmTest.xaml
    /// </summary>
    public partial class frmMainWindow : Window
    {
        public frmMainWindow(IRegionManager regionManager)
        {
            InitializeComponent();

            //WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            //this.WindowState = WindowState.Maximized;
            //this.WindowStyle = WindowStyle.None;
            regionManager.RegisterViewWithRegion(RegionNames.TitleRegion, typeof(ucTitle));
            regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(ucMainMenu));
        }
    }
}
