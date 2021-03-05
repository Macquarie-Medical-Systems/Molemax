using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Molemax.Models
{
    //To save customer location information
    [Table("ChangedLoc")]

    public class ChangedLoc
    {
        public int id { get; set; }
        //related location number
        public int PosNr { get; set; }

        //new location text
        [Column(TypeName = "nvarchar(255)")]
        public string LocText { get; set; }
    }
}
