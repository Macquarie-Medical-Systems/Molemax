using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Molemax.Models
{
    [Table("ExpertizerSelf")]
    public class ExpertizerSelf
    {
        public int ID { get; set; }
        public int? Diagnosis { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string? ImageID { get; set; }
        public int? Diag_Class { get; set; }
    }
}
