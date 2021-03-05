using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Molemax.Models
{
    //to save Cosmax data
    [Table("Cosmetic")]

    public class Cosmetic
    {
        public int id { get; set; }
        //patient id
        public int patientId { get; set; }
        public Patient patient { get; set; }
        //public int pat_id { get; set; }
        //Makro, mikro or close up image id
        public int related_id { get; set; }
    //    Select Case m_enContext
    //    Case DIALOG_COSMAX_CHEMICAL
    //        tTreatment = CHEMICAL_PEELING
    //    Case DIALOG_COSMAX_LASER
    //        tTreatment = LASER_SKIN_RESURFACING
    //    Case DIALOG_COSMAX_DERMA
    //        tTreatment = DERMABRASION_SANDING
    //    Case DIALOG_COSMAX_CHEEK
    //        tTreatment = CHEEK_IMPLANTS
    //    Case DIALOG_COSMAX_BOTOX
    //        tTreatment = BOTOX
    //    Case DIALOG_COSMAX_ACNE
    //        tTreatment = ACNE_TREATMENT
    //    Case DIALOG_COSMAX_MOLE
    //        tTreatment = MOLE_REMOVAL
    //    Case DIALOG_COSMAX_FAT
    //        tTreatment = LIPOSUCTION_FAT_REMOVAL
    //    Case DIALOG_COSMAX_TUMMY
    //        tTreatment = ABDOMINOPLASTY_TUMMY_TUCK
    //    Case DIALOG_COSMAX_LIP
    //        tTreatment = LIP_AUGMENTATION
    //    Case DIALOG_COSMAX_EPILATION
    //        tTreatment = EPILATION
    //    Case DIALOG_COSMAX_NOSE_FRONT
    //        tTreatment = RHINOPLASTY_FRONT
    //    Case DIALOG_COSMAX_NOSE_SIDE
    //        tTreatment = RHINOPLASTY_SIDE
    //  End Select
        public int treatment_id { get; set; }
        //image name
        [Column(TypeName = "nvarchar(30)")]
        //new cosmetic image name
        public string imgname { get; set; }
        //default to -1
        public int? effectval { get; set; }
        //external drive
        //Retrieves information about the file system and volume associated with the specified root directory.
        [Column(TypeName = "nvarchar(30)")]
        public string? deflabel { get; set; }
        //storage path
        [Column(TypeName = "nvarchar(255)")]
        public string? defpath { get; set; }
        //type of drive
        //Determines whether a disk drive is a removable, fixed, CD-ROM, RAM disk, or network drive.
        public int? drivetype { get; set; }
        //timestamp id
        public int tsId { get; set; }
        //crc check result. 
        public int? crc { get; set; }
        public int userId { get; set; }
    }
}
