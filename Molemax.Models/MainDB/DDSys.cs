using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Molemax.Models
{
    [Table("DDSys")]
    public class DDSys
    {
		public int ID { get; set; }
		[Column(TypeName = "nvarchar(10)")]
		//Host
		public string? host { get; set; }
		[Column(TypeName = "nvarchar(10)")]
		//Host version
		public string? hostver { get; set; }
		//db version
		[Column(TypeName = "nvarchar(10)")]
		public string? dbver { get; set; }
		[Column(TypeName = "nvarchar(15)")]
		//  'definition of LogSet string:
		//'Character 1: limit action log flag
		//'          2: by number flag
		//'        3-9: number
		//'         10: by date flag
		//'      11-14: date period counter
		//'         15: period identifier(y,m,w,d)
		public string? Reserved1 { get; set; }
		//control display user info
		[Column(TypeName = "nvarchar(25)")]
		public string? Reserved2 { get; set; }
		//don't know
		[Column(TypeName = "nvarchar(25)")]
		public string? Reserved3 { get; set; }
		[Column(TypeName = "nvarchar(25)")]
		//control Authorization
		public string? Reserved4 { get; set; }
		//control to add cloumn to Histo table
		[Column(TypeName = "nvarchar(25)")]
		public string? Reserved5 { get; set; }

	}
}
