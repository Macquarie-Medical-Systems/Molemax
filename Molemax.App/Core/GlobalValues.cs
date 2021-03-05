using Molemax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molemax.App.Core
{
    public sealed class GlobalValue
    {
        private GlobalValue()
        {
        }

        private static GlobalValue instance = null;

        public static GlobalValue Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GlobalValue();
                }
                return instance;
            }
        }

        public int UserID { get; set; }

        public Patient CurrentPatient { get; set; }

        public bool IsNewPatient { get; set; }
    }
}
