using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Molemax.Models
{
    [Table("DEFLocalTxt")]
    public class DEFLocalTxt
    {
        //key
        public int id { get; set; }
        //position number
        public int? TxtPos { get; set; }
        //position description
        [Column(TypeName = "nvarchar(255)")]
        public string? TxtLokal { get; set; }

    }
}
