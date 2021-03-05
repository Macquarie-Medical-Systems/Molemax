using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Molemax.Models
{
    [Table("Mikro")]

    public class Mikro
    {
        public Mikro()
        {
        }
        //key
        public int id { get; set; }
        //foreign key, images table
        public int imageId { get; set; }
        public Image image { get; set; }
        //public int img_id { get; set; }
        //dummy image position x
        public int X { get; set; }
        //dummy image position Y
        public int Y { get; set; }
        //makro image position x
        public int X_Pic { get; set; }
        //makro image position y
        public int Y_Pic { get; set; }
        [Column(TypeName = "nvarchar(1)")]
        //value of checkbox excision in frmLocalization, Set it to "P" in frmHistopat, it could be "N","Y" too
        public string? excision { get; set; }
        //Excision Planned Date, if checkbox excision is checked, then it it today otherwise it is 12:00am
        public DateTime? ydate { get; set; }
        //Excision Date
        public DateTime? exdate { get; set; }
        //zoom
        public int? zoom { get; set; }
        //foreign key, Makro table
        public int? makroId { get; set; }
        //foreign key, closeup table
        public int? closeupId { get; set; }
        //foreign key, follow up table
        public int? fupId { get; set; }
        //value of checkbox "Change of nevus" in DermNET send to AIS
        public int? ais_change { get; set; }
        //value of checkbox "Change since" in DermNET send to AIS
        public int? ais_since { get; set; }
        //Threshold in ABCD/7 POINTS segmentation
        public int? treshold { get; set; }
        //Public Enum TRENDING_ACTION
        //    TA_FOLLOW_UP = 0
        //    TA_BIOPSY_REPORT_PENDING
        //    TA_BIOPSY_REPORTED_PENDING_EXCISION
        //    TA_EXCISION_REPORT_PENDING
        //    TA_PATHOLOGY_REPORT_RECEIVED
        //    TA_CASE_CLOSED
        //End Enum
        public int? trending_action { get; set; }
        //Biopsy, 
        public bool biopsy { get; set; }
        public int? oldparent { get; set; }
        //Biopsy planned date
        public DateTime? ybiopsydate { get; set; }
    }
}
