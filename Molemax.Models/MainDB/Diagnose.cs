using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Molemax.Models
{
    [Table("Diagnoses")]

    public class Diagnose
    {
        //key
        public int id { get; set; }
        //foreign key, Diagsource table
        public int diagsourceId { get; set; }
    }
}
