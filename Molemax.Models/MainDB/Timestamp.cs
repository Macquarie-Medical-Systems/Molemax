using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Molemax.Models
{
    [Table("Timestamps")]

    public class Timestamp
    {
        //key
        public int id { get; set; }
        //create time
        public DateTime date_created { get; set; }
        //access time
        public DateTime date_last_accessed { get; set; }
        //machine name
        [Column(TypeName = "nvarchar(64)")]
        public string? pcname { get; set; }
    }
}
