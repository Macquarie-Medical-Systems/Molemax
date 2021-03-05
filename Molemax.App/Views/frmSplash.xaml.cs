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
    /// Interaction logic for SplashScreenWindow.xaml
    /// </summary>
    public partial class frmSplash : Window
    {
        public frmSplash()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.WindowStyle = WindowStyle.None;
            InitializeComponent();
        }
        public string Version
        {
            get { return tbVersion.Text; }
            set { tbVersion.Text = value; }
        }
        public string Status
        {
            get { return tbStatus.Text; }
            set { tbStatus.Text = value; }
        }
    }
}
