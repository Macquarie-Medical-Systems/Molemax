using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Molemax.Models
{
    //we don't use it
    [Table("Sender")]

    public class Sender
    {
        public int id { get; set; }
    }
}
