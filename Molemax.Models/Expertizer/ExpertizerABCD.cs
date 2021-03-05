using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Molemax.Models
{
    [Table("ExpertizerABCD")]
    public class ExpertizerABCD
    {
        public int ID { get; set; }
        public int? Diagnosis { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string? ImageID { get; set; }
        public int? A_Score { get; set; }
        public int? B_Score { get; set; }
        public int? C_Score { get; set; }
        public int? D_Score { get; set; }
    }
}
