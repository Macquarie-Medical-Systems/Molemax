using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Molemax.Models
{
    [Table("Makro")]

    public class Makro
    {
        //key
        public int id { get; set; }
        //foreign key, images table
        public int imageId { get; set; }
        public Image image { get; set; }
        //public int img_id { get; set; }
        //select area X1
        public int X1 { get; set; }
        //select area Y1
        public int Y1 { get; set; }
        //select area X2
        public int X2 { get; set; }
        //select area Y2
        public int Y2 { get; set; }
        //bodymap position
        public int? bmpos { get; set; }
        //follow up id
        public int? fupId { get; set; }
        //bodymap session id
        public int? bms_id { get; set; }
        //height adjustment (+/-)
        public int? atbadjustment { get; set; }
    }
}
