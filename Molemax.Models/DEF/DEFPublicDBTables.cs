using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Molemax.Models
{
    //for patient search
    [Table("DEFPublicDBTables")]
    public class DEFPublicDBTables
    {
        //key
        public int id { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        //table name
        public string table { get; set; }
        //present name in textbox "Main Categories"
        [Column(TypeName = "nvarchar(30)")]
        public string? represented { get; set; }
        //enable/disable "add new" button
        public bool existance { get; set; }
    }
}
