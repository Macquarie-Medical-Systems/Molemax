using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Molemax.Models
{
    [Table("ExpertizerS7")]
    public class ExpertizerS7
    {
        //key
        public int ID { get; set; }
        //41500|41501|41502|41503
        //show description at textbox "Diagnosis"
        public int? Diagnosis { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        //image path
        public string? ImageID { get; set; }
        //condition
        public int? S1 { get; set; }
        public int? S2 { get; set; }
        public int? S3 { get; set; }
        public int? S4 { get; set; }
        public int? S5 { get; set; }
        public int? S6 { get; set; }
        public int? S7 { get; set; }
    }
}
