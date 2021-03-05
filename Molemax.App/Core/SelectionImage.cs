using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molemax.App.Core
{
    public class SelectionImage
    {
        public ImageHandler Dummy { get; set; }
        public ImageHandler Makro { get; set; }
        public ImageHandler CloseUp { get; set; }
        public ImageHandler Mikro { get; set; }
        public DateTime Treatment { get; set; }
        public bool IsMakroSelected { get; set; }
        public bool IsCloseUpSelected { get; set; }
        public bool IsMikroSelected { get; set; }
    }
}
