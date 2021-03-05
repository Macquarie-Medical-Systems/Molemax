using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Molemax.Models
{
    [Table("DEFPublicDBFields")]
    public class DEFPublicDBFields
    {
        //key
        public int id { get; set; }
        //table id
        public int tableid { get; set; }
        //table id
        public int? groupid { get; set; }
        [Column(TypeName = "nvarchar(15)")]
        //field name
        public string field { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        //show name in sub categories textbox
        public string? represented { get; set; }
        //not use
        public int? representedid { get; set; }
        //data type: 1:long 2: string 3:date 4:bool
        //to show operator
        public int data { get; set; }
        //default value, if true, show list of default value
        public bool valuelist { get; set; }
        //display|not display textbox of default value 
        public bool existance { get; set; }
    }
}
