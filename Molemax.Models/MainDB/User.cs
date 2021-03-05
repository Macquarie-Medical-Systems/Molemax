using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Molemax.Models
{
    [Table("Users")]

    public class User
    {
        //key
        public int id { get; set; }
        //user name
        [Column(TypeName = "nvarchar(100)")]
        public string username { get; set; }
        //password
        [Column(TypeName = "nvarchar(50)")]
        public string? pwd { get; set; }
        //Public Enum USER_RIGHTS
        //    RIGHT_NONE = 0
        //    RIGHT_READ = 1
        //    RIGHT_WRITE = 2
        //    RIGHT_DELETE = 3
        //End Enum
        public short myrights { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        //rights to operate other users content
        public string? rights { get; set; }
        //timestamps
        public int tsId { get; set; }
    }
}
