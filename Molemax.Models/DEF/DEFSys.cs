using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Molemax.Models
{
	//we don't use
	[Table("DEFSys")]
	public class DEFSys
    {
        public int id { get; set; }
		[Column(TypeName = "nvarchar(50)")]
		public string? language { get; set; }
		[Column(TypeName = "nvarchar(50)")]
		public string? country { get; set; }
		[Column(TypeName = "nvarchar(50)")]
		public string? prefix { get; set; }
		[Column(TypeName = "nvarchar(50)")]
		public string? codepage { get; set; }
		[Column(TypeName = "nvarchar(50)")]
		public string? description { get; set; }
		[Column(TypeName = "nvarchar(50)")]
		public string? version { get; set; }
		[Column(TypeName = "nvarchar(50)")]
		public string? compatibility { get; set; }
	}
}
