using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molemax.App.Core
{
    public class UserSpecifyRight
    {
        public string UserName { get; set; }
        public bool IsReadOnly { get; set; }
        public bool IsReadWrite { get; set; }
        public bool IsDelete { get; set; }
    }
}
