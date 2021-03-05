using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Molemax.Models
{
    [Table("DEFMakroLokal")]
    public class DEFMakroLokal
    {
		//key
		public int id { get; set; }
		//MakroKen image id
		public byte? PosMann { get; set; }
		[Column(TypeName = "nvarchar(255)")]
		//MakroKen image description
		public string? TxtMann { get; set; }
		//position number
		public int? TxtLokal { get; set; }
		//Color (RGB)
		public byte? r { get; set; }
		public byte? g { get; set; }
		public byte? b { get; set; }
		//Has related position?
		public byte? Hotspot { get; set; }
		//related position's makro id
		public byte? Jumppos { get; set; }
		//we don't use
		public byte? Area { get; set; }
		//we don't use
		public int? PosX1 { get; set; }
		//we don't use
		public int? PosY1 { get; set; }
		//we don't use
		public int? PosX2 { get; set; }
		//we don't use
		public int? PosY2 { get; set; }
		//we don't use
		public int? Count { get; set; }
	}
}
