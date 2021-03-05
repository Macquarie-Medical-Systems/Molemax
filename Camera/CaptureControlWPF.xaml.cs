using System;
using System.Collections.Generic;
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

namespace Camera
{
    /// <summary>
    /// Interaction logic for CaptureControlWPF.xaml
    /// </summary>
    public partial class CaptureControlWPF : UserControl
    {
        public CaptureControlWPF()
        {
            InitializeComponent();
        }

        public CaptureControl CaptureControl
        {
            get { return (CaptureControl)FormsHost.Child; }
            set { FormsHost.Child = value; }
        }

        
    }
}
