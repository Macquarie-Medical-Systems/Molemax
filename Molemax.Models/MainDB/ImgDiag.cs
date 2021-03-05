using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Molemax.Models
{
    [Table("ImgDiag")]

    public class ImgDiag
    {
        //key
        public int id { get; set; }
        //foreign key, image table
        public int imageId { get; set; }
        public Image image { get; set; }
        //public int img_id { get; set; }

        //foreign key, diagnoses
        public int diagnoseId { get; set; }
        //public int diag_id { get; set; }
    }
}
