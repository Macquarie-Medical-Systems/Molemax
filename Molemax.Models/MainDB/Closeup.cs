using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Molemax.Models
{
    [Table("Closeup")]

    public class Closeup
    {
        //key
        public int id { get; set; }
        //foreign key, images table
        public int imageId { get; set; }
        public Image image { get; set; }
        //public int img_id { get; set; }
        //foreign key, Makro table
        public int makroId { get; set; }
        //select area X1 on Makro image
        public int X1 { get; set; }
        //select area Y1 on Makro image
        public int Y1 { get; set; }
        //select area X2 on Makro image
        public int X2 { get; set; }
        //select area Y2 on Makro image
        public int Y2 { get; set; }
        //follow up id
        public int? fupId { get; set; }
        //bodymap position
        public int? bmpos { get; set; }
        //bodymap session id
        public int? bms_id { get; set; }
        //don't know
        public int? oldparent { get; set; }
    }
}
