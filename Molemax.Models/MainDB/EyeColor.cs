using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Molemax.Models
{
    [Table("EyeColor")]
    public class EyeColor
    {
        public int ID { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string? info { get; set; }
    }
}
