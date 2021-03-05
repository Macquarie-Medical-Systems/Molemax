using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Molemax.Models
{
	[Table("DEFMikroLokal")]
	public class DEFMikroLokal
	{
		//key
		public int id { get; set; }
		//MikroKen image id
		public byte? PosMann { get; set; }
		[Column(TypeName = "nvarchar(255)")]
		//MikroKen image description
		public string? TxtMann { get; set; }
		//position number
		public int? TxtLokal { get; set; }
		//Color (RGB)
		public byte? r { get; set; }
		public byte? g { get; set; }
		public byte? b { get; set; }
		//Has related position?
		public byte? Hotspot { get; set; }
		//related position's mikro id
		public byte? Jumppos { get; set; }

	}
}
