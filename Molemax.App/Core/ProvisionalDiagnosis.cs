using Molemax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molemax.App.Core
{
    public class ProvisionalDiagnosis
    {
        public bool IsChecked { get; set; }
        public string DiagsourceFullName { get; set; }
        public int OriginId { get; set; }
        public int Id { get; set; }
        public Diagsource diagsource { get; set; }
    }
}
