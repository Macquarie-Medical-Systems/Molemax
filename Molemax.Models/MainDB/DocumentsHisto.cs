using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Molemax.Models
{
    //to save Histopathology images attachments
    [Table("DocumentsHisto")]

    public class DocumentsHisto
    {
        public int id { get; set; }
        //public int case_id { get; set; }
        public int histoId { get; set; }
        public Histo histo { get; set; }
        //public int histo_id { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        //full name of documents 
        public string docname { get; set; }
        //user id
        public int userId { get; set; }
    }
}
