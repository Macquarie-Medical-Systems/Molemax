﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Molemax.Models
{
    //we don't use
    [Table("DEFMakroKen")]
    public class DEFMakroKen
    {
        public int id { get; set; }
        public byte[]? bmp { get; set; }
    }
}
