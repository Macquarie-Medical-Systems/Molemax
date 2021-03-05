using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Molemax.Models
{
    //we don't use it
    [Table("Trichoscan")]
    public class Trichoscan
    {
        public int id { get; set; }
        public int mikroId { get; set; }
        public Mikro mikro { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        public string? version { get; set; }
        public float? haircount { get; set; }
        public float hairdensity { get; set; }
        public float area { get; set; }
        public float? telogen { get; set; }
        public float? anagen { get; set; }
        public float? velluscount { get; set; }
        public float? terminalcount { get; set; }
        public float? vellusdensity { get; set; }
        public float? terminaldensity { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string? mode_ { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string? haircount_ { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string? hairdensity_ { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string? area_ { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string? anakm_ { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string? telokm_ { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string? anakmdensity_ { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string? ratiovell_ { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string? ratioterm_ { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string? densityvell_ { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string? densityterm_ { get; set; }
    }
}
