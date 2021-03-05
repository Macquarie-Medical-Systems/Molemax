using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molemax.App.Core.MouseCapture
{
    public class MouseCaptureArgs
    {
        public object AssociatedObject { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public bool LeftButton { get; set; }
        public bool RightButton { get; set; }
    }
}
