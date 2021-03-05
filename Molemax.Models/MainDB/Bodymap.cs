using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Molemax.Models
{
    //To save body maps data
    [Table("Bodymaps")]
    public class Bodymap
    {
        //key
        public int id { get; set; }
        //foreign key, Patients table id
        public int patientId { get; set; }
        public Patient patient { get; set; }
        //public int pat_id { get; set; }
        //body map session type. 0->10 images, 1->33 images
        public int bms_type { get; set; }
        //foreign key, Timestamps table id
        public int tsId { get; set; }
    }
}
