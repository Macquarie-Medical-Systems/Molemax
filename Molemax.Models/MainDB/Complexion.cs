using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Molemax.Models
{
    [Table("Complexion")]
    public class Complexion
    {
        //key
        public int ID { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        //value of select box Complexion at patient form
        public string? info { get; set; }
    }
}
