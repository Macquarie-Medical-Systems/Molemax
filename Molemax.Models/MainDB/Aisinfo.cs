using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Molemax.Models
{
    //To save AIS information
    [Table("Aisinfo")]
    //artificial inteligence service info for one patient
    public partial class Aisinfo
    {
        public int id { get; set; }
        public int patientId { get; set; }
        public Patient patient { get; set; }
        //public int pat_id { get; set; }
        public int? family { get; set; }
        public int? personal { get; set; }
        public int? nevus { get; set; }
        public int? uv { get; set; }
        public int? skin { get; set; }
        public int? dns { get; set; }
    }
}
