using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Molemax.Models
{
    [Table("DEFBodymapPosition")]
    public class DEFBodymapPosition
    {
        public int id { get; set; }
        public int? body_pos_id { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string? position_text { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string? location_text { get; set; }
        public int? dummy_position { get; set; }
        public int? X1 { get; set; }
        public int? Y1 { get; set; }
        public int? X2 { get; set; }
        public int? Y2 { get; set; }
        public byte? body_type { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string? bar_location_text { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string? light_intensity_text { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string? other_instruction_text { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string? remark_text { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string? hint_text { get; set; }
    }
}
