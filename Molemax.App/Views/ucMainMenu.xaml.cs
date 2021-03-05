using System.Windows;
using System.Windows.Controls;

namespace Molemax.App.Views
{
    /// <summary>
    /// Interaction logic for frmMainMenu.xaml
    /// </summary>
    public partial class ucMainMenu : UserControl
    {
        public ucMainMenu()
        {
            InitializeComponent();
        }

        private void btExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }


}
