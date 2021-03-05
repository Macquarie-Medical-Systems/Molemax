using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Molemax.Models
{
    [Table("Diagsource")]

    public class Diagsource
    {
        public Diagsource()
        {
        }
        //key
        public int id { get; set; }
        public int origin_id { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        //short name
        public string? shortname { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        //full name
        //value of txtDiag
        public string fullname { get; set; }
        [Column(TypeName = "nvarchar(2)")]
        //risk level
        //check value of txtDiag in frmLocation
        //if find key word "melanom" or "dyspl" then risk="MR" 
        //otherwise risk = "S"
        public string risk { get; set; }
        //0-None 1-ELM 2-Macro 3-Histo
        public int? favorite { get; set; }
        //  -1 is category
        public int? category { get; set; }
        //parent category id, -1 is no parent category
        public int? parent_id { get; set; }
    }
}
