using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Molemax.Models
{
    [Table("ExpertizerMain")]
    public class ExpertizerMain
    {
        public int ID { get; set; }
        //Public Enum COMP_MODE
        //    MODE_ELM = 2
        //    MODE_DIAG = 1
        //End Enum
        public int? Method { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        //MainIdentifier , for example "Pigmentnetwork"
        public string? MainDX { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        //SubIdentifier, for example "DiscretePigmentnetwork"
        public string? SubDX { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        //short description
        public string? ShortDesc { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        //long description
        public string? LongDesc { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        //image path
        public string? ImageID { get; set; }
    }
}
