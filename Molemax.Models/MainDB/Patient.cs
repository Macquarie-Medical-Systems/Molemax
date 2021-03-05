using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Molemax.Models
{
    [Table("Patients")]
    public class Patient
    {
        public Patient()
        {
            Histos = new List<Histo>();
            Aisinfos = new List<Aisinfo>();
            ExpressImages = new List<ExpressImage>();
            Images = new List<Image>();
            Cosmetics = new List<Cosmetic>();
            Bodymaps = new List<Bodymap>();
        }
        //key
        public int id { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        //value of txtLastname in frmPatient
        public string lastname { get; set; }
        //value of txtFirstname in frmPatient
        [Column(TypeName = "nvarchar(30)")]
        public string firstname { get; set; }
        //value of txtTitle in frmPatient
        [Column(TypeName = "nvarchar(30)")]
        public string? title { get; set; }
        //value of txtBirthdate in frmPatient
        public DateTime birthdate { get; set; }
        [Column(TypeName = "nvarchar(1)")]
        //"M", "F"
        public string? sex { get; set; }
        //value of txtInsNr and txtInsNr_BD in frmPatient
        [Column(TypeName = "nvarchar(255)")]
        public string insnr { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        //don't know
        public string? insnr_usa { get; set; }
        //value of txtInsidentify in frmPatient
        [Column(TypeName = "nvarchar(255)")]
        public string? insident { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        //don't know
        public string? sender { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        //don't know
        public string? bdtpat_id { get; set; }
        //value of txtFamily in frmPatient
        [Column(TypeName = "nvarchar(50)")]
        public string? family { get; set; }
        //value of txtWeek and txtMonth and Year in frmPatient
        public DateTime? fup_date { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        //value of txtRemark in frmPatient
        public string? remarks { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        //value of txtAddress in frmPatient
        public string? address { get; set; }
        //value of txtCity in frmPatient
        [Column(TypeName = "nvarchar(30)")]
        public string? city { get; set; }
        //value of txtState in frmPatient
        [Column(TypeName = "nvarchar(2)")]
        public string? state { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        //value of txtZip in frmPatient
        public string? zip { get; set; }
        //value of txtPhoneH in frmPatient
        [Column(TypeName = "nvarchar(30)")]
        public string? phone_h { get; set; }
        //value of txtPhoneW in frmPatient
        [Column(TypeName = "nvarchar(30)")]
        public string? phone_w { get; set; }
        //value of txtPhoneC in frmPatient
        [Column(TypeName = "nvarchar(30)")]
        public string? phone_c { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        //value of txtMail in frmPatient
        public string? e_mail { get; set; }
        [Column(TypeName = "nvarchar(1)")]
        //don't know
        public string? sending { get; set; }
        //don't know
        public DateTime? senddate { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        //don't know
        public string? DestFTPID { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        //don't know
        public string? recipient { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        //patient image path
        public string? image_path { get; set; }
        [Column(TypeName = "nvarchar(4)")]
        //Melanoma Risk: m_intIdentify1 & m_intIdentify2 & m_intIdentify3 & m_intIdentify4
        public string? risk { get; set; }
        //don't know
        public bool waiting_room { get; set; }
        //current user id
        public int userId { get; set; }
        //timestamp id
        public int tsId { get; set; }
        //don't know
        [Column(TypeName = "nvarchar(max)")]
        public string? ca_comment { get; set; }
        //Patient height
        [Column(TypeName = "nvarchar(255)")]
        public string? barcode { get; set; }
        //don't know
        public int? barcode_type { get; set; }
        //value of Ethnic in frmPatient
        [Column(TypeName = "nvarchar(50)")]
        public string? ethnicgroup { get; set; }
        //value of Eyecolor in frmPatient
        [Column(TypeName = "nvarchar(50)")]
        public string? eyecolor { get; set; }
        //value of Haircolor in frmPatient
        [Column(TypeName = "nvarchar(50)")]
        public string? haircolor { get; set; }
        //value of Skincolor in frmPatient
        [Column(TypeName = "nvarchar(50)")]
        public string? skincolor { get; set; }
        //value of Complexion in frmPatient
        [Column(TypeName = "nvarchar(50)")]
        public string? complexion { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        //value of country
        public string? country { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        //don't know
        public string? kis { get; set; }
        //don't know
        [Column(TypeName = "nvarchar(255)")]
        public string? dicom { get; set; }
        //value of Patient height (cm)
        public int? patheight { get; set; }
        //don't know
        public int? atbmheight { get; set; }
        //don't know
        public int? pms_patient_id { get; set; }

        public List<Histo> Histos;
        public List<Aisinfo> Aisinfos;
        public List<ExpressImage> ExpressImages;
        public List<Image> Images;
        public List<Cosmetic> Cosmetics;
        public List<Bodymap> Bodymaps;
    }
}
