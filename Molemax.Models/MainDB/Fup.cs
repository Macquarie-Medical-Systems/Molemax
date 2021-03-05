using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Molemax.Models
{
    [Table("Fup")]

    public class Fup
    {
        //key
        public int id { get; set; }
        //foreign key, image table
        public int imageId { get; set; }
        public Image image { get; set; }
        //public int origin_id { get; set; }
    }
}
