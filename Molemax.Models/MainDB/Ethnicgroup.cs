using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Molemax.Models
{
    [Table("Ethnicgroup")]
    public class Ethnicgroup
    {
        //key
        public int ID { get; set; }
        //value of select box "Ethnicgroup" at patient form
        [Column(TypeName = "nvarchar(255)")]
        public string? info { get; set; }
    }
}
