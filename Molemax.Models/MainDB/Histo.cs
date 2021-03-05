using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Molemax.Models
{
    //Histopathology data
    [Table("Histos")]

    public class Histo
    {
        public Histo()
        {
            documentsHistos = new List<DocumentsHisto>();
        }
        //key
        public int id { get; set; }
        //foreign key, patients table
        public int patientId { get; set; }
        public Patient patient { get; set; }
        //public int pat_id { get; set; }
        //foreign key, mikro table
        public int mikroId { get; set; }
        //foreign key, user table
        public int userId { get; set; }
        //don't know, maybe not use in the system
        [Column(TypeName = "nvarchar(30)")]
        public string? examinator { get; set; }
        //diagsource id
        public int? diagnoseId { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        //value of textbox "histo number"
        public string? histo_nr { get; set; }
        //value of listbox "clark"
        public int? clark { get; set; }
        [Column(TypeName = "nvarchar(5)")]
        //value of textbox "breslow" 
        public string? breslow { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        //value of textbox "my comment"
        public string? remark { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        //driver label
        public string? deflabel { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        //storage path
        public string? defpath { get; set; }
        //type of drive
        public int? drivetype { get; set; }
        //timestamp id
        public int tsId { get; set; }
        //crc check
        public int? crc { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        //value of textbox "pathologic diagnose"
        public string? pat_diagnose { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        //value of textbox "histo report"
        public string? report { get; set; }
        //value of textbox "diag date"
        public DateTime? diagdate { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string? imgname { get; set; }

        public List<DocumentsHisto> documentsHistos;
    }
}
