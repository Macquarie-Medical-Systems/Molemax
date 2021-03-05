using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Molemax.Models
{
    //for MoleCount or Molescore, we don't use it
    [Table("Mee")]
    public class Mee
    {
        public int id{ get; set; }
        public int mikroId { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        public string? version { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string? symmetry { get; set; }
        public int? color { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string? diameter { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string? area { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string? score { get; set; }
    }
}
