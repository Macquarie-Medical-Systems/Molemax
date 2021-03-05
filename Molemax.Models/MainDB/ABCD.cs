using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Molemax.Models
{
    //To save ABCD check result
    [Table("ABCD")]
    public class ABCD
    {
        public int id { get; set; }
        //foreign key, Mikro table
        public int mikroId { get; set; }
        //public int mikro_id { get; set; }
        /*
        Public Enum ABCD_ASSYMETRY
            NOT_DEFINED_ASSYMETRY = -1
            NONE_ASSYMETRY = 0
            ONE_AXIS_ASSYMETRY = 1
            BOTH_AXIS_ASSYMETRY = 2
        End Enum
        */
        public int assymetry { get; set; }

        public int segments { get; set; }
        /*
        Public Enum ABCD_COLOR
            ABCD_COLOR_NOT_DEFINED = -1
            ABCD_COLOR_WHITE = 1
            ABCD_COLOR_LIGHTBROWN = 2
            ABCD_COLOR_DARKBROWN = 4
            ABCD_COLOR_BLUEGREY = 8
            ABCD_COLOR_BLACK = 16
            ABCD_COLOR_RED = 32
        End Enum
        */
        public int color { get; set; }

        //Public Enum ABCD_STRUCTURAL_COMPONENTS
        //    COMPONENT_NOT_DEFINED = -1
        //    COMPONENT_HOMOGENOUS_AREA = 1
        //    COMPONENT_PIGMENT_NETWORK = 2
        //    COMPONENT_STREAKS = 4
        //    COMPONENT_DOTS = 8
        //    COMPONENT_GLOBULES = 16
        //End Enum
        public int structural_components { get; set; }

        //Public Enum ABCD_CHANGE_NEVUS
        //    NEVUS_NOT_SPECIFIED = 0
        //    NEVUS_YES = 1
        //    NEVUS_NONE = 2
        //End Enum
        public int? change_nevus { get; set; }
        public float abcd_score { get; set; }
        public float? abcd_e_score { get; set; }
    }
}
