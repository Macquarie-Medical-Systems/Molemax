using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Molemax.Models
{
    [Table("DEFPublicDBItems")]

    public class DEFPublicDBItems
    {
        public int id { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string object_name { get; set; }
        [Column(TypeName = "nvarchar(3)")]
        public string? obj_identifier { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string? tbl { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string? represented_string { get; set; }
        public int? represented_name { get; set; }
        public bool is_table { get; set; }
        public int? data_format { get; set; }
    }
}
