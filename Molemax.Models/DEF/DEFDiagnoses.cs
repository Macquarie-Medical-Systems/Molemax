using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Molemax.Models
{
    [Table("DEFDiagnoses")]
    public class DEFDiagnoses
    {
        //key
        public int id { get; set; }
        public int origin_id { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        //short name
        public string? shortname { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        //full name
        public string fullname { get; set; }
        [Column(TypeName = "nvarchar(2)")]
        //risk level
        public string? risk { get; set; }
        //0-None 1-ELM 2-Macro 3-Histo
        public int? favorite { get; set; }
        //  -1 is category
        public int? category { get; set; }
        //parent category id, -1 is no parent category
        public int? parent_id { get; set; }
    }
}
