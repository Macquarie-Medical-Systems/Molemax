using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Molemax.Models
{
    [Table("Images")]

    public class Image
    {
        public Image()
        {
            Camsets = new List<Camset>();
            Makros = new List<Makro>();
            Documents = new List<Document>();
            Fups = new List<Fup>();
            Closeups = new List<Closeup>();
            ImgDiags = new List<ImgDiag>();
    }
        //key
        public int id { get; set; }
        //patient id
        public int patientId { get; set; }
        public Patient patient { get; set; }
        //public int pat_id { get; set; }

        //Public Enum KIND_ENUM
        //KIND_UNDEFINED = 0
        //KIND_MAKRO = 1
        //KIND_MIKRO = 2
        //KIND_CLOSEUP = 3
        //KIND_HISTOPAT = 4
        //KIND_COSMAX = 5
        public int kind { get; set; }

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
        public int origin { get; set; }
        //ken image id
        public int kenpos { get; set; }
        //value of txtLocation in frmLocalization ("left hand")
        [Column(TypeName = "nvarchar(200)")]
        public string loctext { get; set; }
        //value of txtMemo in frmLocalization
        [Column(TypeName = "nvarchar(max)")]
        public string? remarks { get; set; }
        //image name without path
        [Column(TypeName = "nvarchar(30)")]
        public string imgname { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        //store drive label
        public string? deflabel { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        //store drive path
        public string? defpath { get; set; }
        //store image drive type
        public int? drivetype { get; set; }
        //user id
        public int userId { get; set; }
        //don't know
        public int? sender_id { get; set; }
        //timestamp id
        public int tsId { get; set; }
        //value of txtDate in frmLocalization (today)
        public DateTime? treatment { get; set; }
        public int? crc { get; set; }
        //value of checkbox dermanet
        public bool dermanet { get; set; }
        //Public Enum SCIENTIFIC_OPTION
        //    SC_IMAGE_NONE = 0
        //    SC_IMAGE_ONLY = 1
        //    SC_IMAGE_DATA = 2
        //    SC_IMAGE_PAT = 4
        //    SC_IMAGE_FUP = 8
        //End Enum
        public int? scoption { get; set; }
        public double? scdate { get; set; }
        //don't know
        public bool attention { get; set; }
        //value of chkAttention in frmLocalization "3,2,1"
        public int? irisk { get; set; }
        //don't know
        public bool newloc { get; set; }
        public List<Camset> Camsets { get; set; }
        public List<Makro> Makros { get; set; }
        public List<Mikro> Mikros { get; set; }
        public List<Document> Documents { get; set; }
        public List<Fup> Fups { get; set; }
        public List<Closeup> Closeups { get; set; }
        public List<ImgDiag> ImgDiags { get; set; }
    }
}
