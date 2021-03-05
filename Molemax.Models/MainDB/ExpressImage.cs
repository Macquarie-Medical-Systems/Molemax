using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Molemax.Models
{
    //save express image data
    [Table("ExpressImage")]

    public class ExpressImage
    {
        //key
        public int id { get; set; }
        //foreign key, patient table
        public int patientId { get; set; }
        public Patient patient { get; set; }
        //public int? pat_id { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        //image name
        public string? imgname { get; set; }
        //value of checkbox attention on express image form
        public bool attention { get; set; }
        //Public Enum ORIGIN_ENUM
        //    ORIG_UNDEFINED = 0              'undefined origin
        //    ORIG_FCB_EVI_MACRO = 1          'Sony FCB camera in macro mode (without adapter)
        //    ORIG_ELM_MICRO = 2              'Sony fixed focus camera
        //    ORIG_CANON_MACRO = 3            'Canon digital photocamera in macro mode
        //    ORIG_CANON_MICRO = 4            'Canon digital photocamera in micro mode
        //    ORIG_IMPORT = 5                 'File import
        //    ORIG_TWAIN = 6                  'TWAIN import (scanner)
        //    ORIG_FCB_EVI_MICRO = 7          'Sony FCB camera in micro mode (with adapter)
        //    ORIG_DIG_IMPORT = 8             'Direct import from digital cameras
        //    ORIG_EXT_FALCON_VIDEO_1 = 9     'external video source nr.1 attached to framegrabber
        //    ORIG_EXT_FALCON_VIDEO_2 = 10    'external video source nr.2 attached to framegrabber
        //    ORIG_HD_MACRO
        //    ORIG_HD_MICRO
        //    ORIG_VITINY
        //    ORIG_WIFI
        //    ORIG_CANON_MACRO_2
        //    ORIG_IMPORT_2
        //    ORIG_TWAIN_2
        //    ORIG_DIG_IMPORT_2
        //    ORIG_DDHD_MACRO
        //    ORIG_DDHD_MICRO
        //    ORIG_SKINDOC_MICRO
        //    ORIG_3CAM_MACRO
        //    ORIG_FOTOFINDER_MACRO
        //    ORIG_FOTOFINDER_MICRO
        //End Enum
        public int? origin { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        //not use
        public string? score_abcd { get; set; }
        //not use
        [Column(TypeName = "nvarchar(255)")]
        public string? score_s7p { get; set; }
        //not use
        [Column(TypeName = "nvarchar(255)")]
        public string? score_memi { get; set; }
        //not use
        [Column(TypeName = "nvarchar(255)")]
        public string? score_mema { get; set; }
        //not use
        [Column(TypeName = "nvarchar(255)")]
        public string? score_tricho { get; set; }
        //not use
        public bool reserved1 { get; set; }
        //not use
        public bool reserved2 { get; set; }
        //not use
        public bool reserved3 { get; set; }
        //not use
        public bool reserved4 { get; set; }
        //0,20,30,40
        public double? zoom { get; set; }
        //not use
        [Column(TypeName = "nvarchar(255)")]
        public string? camname { get; set; }
        //not use
        [Column(TypeName = "nvarchar(255)")]
        public string? camsets { get; set; }
        //not use
        [Column(TypeName = "nvarchar(max)")]
        public string? remark { get; set; }
    }
}
