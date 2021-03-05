using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Molemax.Models
{
    //7 points check result
    [Table("S7p")]

    public class S7p
    {
        //key
        public int id { get; set; }
        //foreign key, mikro table
        public int mikroId { get; set; }
        //public int mikro_id { get; set; }
        //value of radio box "Pigment_Network"
        public int atypical_pigment_network { get; set; }
        //value of radio box "GrayBlueArea"
        public int gray_blue_areas { get; set; }
        //value of radio box "Vascular pattern"
        public int atypical_vascular_pattern { get; set; }
        //value of radio box "Streak"
        public int streaks { get; set; }
        //value of radio box "Blotches"
        public int blotches { get; set; }
        //value of radio box "Dots_Globules"
        public int dots_globules { get; set; }
        //value of radio box "regression pattern"
        public int regression_pattern { get; set; }
        //value of text box "Score"
        public float score { get; set; }
    }
}
