using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Molemax.Models
{
    //we don't use it
    [Table("Mem")]

    public class Mem
    {
        public int id { get; set; }
        public int makroId { get; set; }
        public int fupId { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        public string? version { get; set; }
        public int sensitivity { get; set; }
        public int count { get; set; }
        public int naevi_good { get; set; }
        public int naevi_middle { get; set; }
        public int naevi_bad { get; set; }
        public int preceding_id { get; set; }
    }
}
