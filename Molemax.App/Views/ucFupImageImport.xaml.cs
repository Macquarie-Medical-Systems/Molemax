using Molemax.App.Core.TreeViewFileExplorer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Molemax.App.Views
{
    /// <summary>
    /// Interaction logic for ucImageImport.xaml
    /// </summary>
    public partial class ucFupImageImport : UserControl
    {
        public ucFupImageImport()
        {
            InitializeComponent();
        }

        private void btZoomIn_Click(object sender, RoutedEventArgs e)
        {
            OriginalImageZoomBorder.ZoomIn();
            SelectedImageZoomBorder.ZoomIn();
        }


        private void btZoomOut_Click(object sender, RoutedEventArgs e)
        {
            OriginalImageZoomBorder.ZoomOut();
            SelectedImageZoomBorder.ZoomOut();
        }

        private void btReset_Click(object sender, RoutedEventArgs e)
        {
            OriginalImageZoomBorder.Reset();
            SelectedImageZoomBorder.Reset();
        }
        
    }
}
