using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Molemax.Models
{
    //to save image attachments
    [Table("Documents")]
    public class Document
    {
        public int id { get; set; }
        //foreign key, images table
        public int imageId { get; set; }
        public Image image { get; set; }
        //public int img_id { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        //full document name
        public string docname { get; set; }
        public int userId { get; set; }
    }
}
