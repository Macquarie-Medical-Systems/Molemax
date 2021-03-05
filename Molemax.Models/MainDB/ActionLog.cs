using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Molemax.Models
{
    //log table, we don't use it
    [Table("ActionLog")]

    public class ActionLog
    {
        //key
        public int id { get; set; }
        //action id
        public int performed_action { get; set; }
        //timestamps
        public DateTime ts { get; set; }
        //user id
        public int user_id { get; set; }
        //object id
        public int object_id { get; set; }
    }
}
