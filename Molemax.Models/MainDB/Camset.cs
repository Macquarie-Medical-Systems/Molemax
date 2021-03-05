using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Molemax.Models
{
    //To save camera setting
    [Table("Camset")]
    public class Camset
    {
        public int id { get; set; }
        public int imageId { get; set; }
        public Image image { get; set; }
        public int? quality { get; set; }
        public int? strobe { get; set; }
        public int? exposure_mode { get; set; }
        public int? image_mode { get; set; }
        public int? white_balance { get; set; }
        public int? contrast { get; set; }
        public int? color_gain { get; set; }
        public int? sharpness { get; set; }
        public int? iso { get; set; }
        public int? av { get; set; }
        public int? tv { get; set; }
        public int? exposure_comp { get; set; }
        public int? zoompos { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string? camera { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string? reserved1 { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string? reserved2 { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string? reserved3 { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string? reserved4 { get; set; }
    }
}
