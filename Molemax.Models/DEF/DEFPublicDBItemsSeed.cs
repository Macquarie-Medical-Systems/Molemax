using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Molemax.Models
{
    public class DEFPublicDBItemsSeed
    {
        public static void GenerateSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DEFPublicDBItems>().HasData(new DEFPublicDBItems { id = 1, object_name = "_patients", obj_identifier = "pat", tbl = null, represented_string = "Patients", represented_name = 0, is_table = true, data_format = 0 });
            modelBuilder.Entity<DEFPublicDBItems>().HasData(new DEFPublicDBItems { id = 2, object_name = "lastname", obj_identifier = "pat", tbl = "_patients", represented_string = "Lastname", represented_name = 0, is_table = false, data_format = 2 });
            modelBuilder.Entity<DEFPublicDBItems>().HasData(new DEFPublicDBItems { id = 3, object_name = "firstname", obj_identifier = "pat", tbl = "_patients", represented_string = "Firstname", represented_name = 0, is_table = false, data_format = 2 });
            modelBuilder.Entity<DEFPublicDBItems>().HasData(new DEFPublicDBItems { id = 4, object_name = "birthdate", obj_identifier = "pat", tbl = "_patients", represented_string = "Birthdate", represented_name = 0, is_table = false, data_format = 3 });
            modelBuilder.Entity<DEFPublicDBItems>().HasData(new DEFPublicDBItems { id = 5, object_name = "sex", obj_identifier = "pat", tbl = "_patients", represented_string = "Sex", represented_name = 0, is_table = false, data_format = 2 });
            modelBuilder.Entity<DEFPublicDBItems>().HasData(new DEFPublicDBItems { id = 6, object_name = "insnr", obj_identifier = "pat", tbl = "_patients", represented_string = "Insurance Number", represented_name = 0, is_table = false, data_format = 2 });
            modelBuilder.Entity<DEFPublicDBItems>().HasData(new DEFPublicDBItems { id = 7, object_name = "insnr_usa", obj_identifier = "pat", tbl = "_patients", represented_string = "Social Security Number", represented_name = 0, is_table = false, data_format = 2 });
            modelBuilder.Entity<DEFPublicDBItems>().HasData(new DEFPublicDBItems { id = 8, object_name = "insident", obj_identifier = "pat", tbl = "_patients", represented_string = "Insurance Identification", represented_name = 0, is_table = false, data_format = 2 });
            modelBuilder.Entity<DEFPublicDBItems>().HasData(new DEFPublicDBItems { id = 9, object_name = "address", obj_identifier = "pat", tbl = "_patients", represented_string = "Address", represented_name = 0, is_table = false, data_format = 2 });
            modelBuilder.Entity<DEFPublicDBItems>().HasData(new DEFPublicDBItems { id = 10, object_name = "city", obj_identifier = "pat", tbl = "_patients", represented_string = "City", represented_name = 0, is_table = false, data_format = 2 });
            modelBuilder.Entity<DEFPublicDBItems>().HasData(new DEFPublicDBItems { id = 11, object_name = "state", obj_identifier = "pat", tbl = "_patients", represented_string = "State", represented_name = 0, is_table = false, data_format = 2 });
            modelBuilder.Entity<DEFPublicDBItems>().HasData(new DEFPublicDBItems { id = 12, object_name = "e_mail", obj_identifier = "pat", tbl = "_patients", represented_string = "E-Mail", represented_name = 0, is_table = false, data_format = 2 });
            modelBuilder.Entity<DEFPublicDBItems>().HasData(new DEFPublicDBItems { id = 13, object_name = "fup_date", obj_identifier = "pat", tbl = "_patients", represented_string = "Follow Up Date", represented_name = 0, is_table = false, data_format = 3 });
            modelBuilder.Entity<DEFPublicDBItems>().HasData(new DEFPublicDBItems { id = 14, object_name = "_images", obj_identifier = "img", tbl = null, represented_string = "Images", represented_name = 0, is_table = true, data_format = 0 });
            modelBuilder.Entity<DEFPublicDBItems>().HasData(new DEFPublicDBItems { id = 15, object_name = "kind", obj_identifier = "img", tbl = "_images", represented_string = "Kind of Image", represented_name = 0, is_table = false, data_format = 1 });
            modelBuilder.Entity<DEFPublicDBItems>().HasData(new DEFPublicDBItems { id = 17, object_name = "elm", obj_identifier = "elm", tbl = "_images", represented_string = "ELM Image", represented_name = 0, is_table = true, data_format = 0 });
            modelBuilder.Entity<DEFPublicDBItems>().HasData(new DEFPublicDBItems { id = 18, object_name = "loctext", obj_identifier = "img", tbl = "_images", represented_string = "Location", represented_name = 0, is_table = false, data_format = 2 });
            modelBuilder.Entity<DEFPublicDBItems>().HasData(new DEFPublicDBItems { id = 19, object_name = "origin", obj_identifier = "img", tbl = "_images", represented_string = "Image Source", represented_name = 0, is_table = false, data_format = 1 });
            modelBuilder.Entity<DEFPublicDBItems>().HasData(new DEFPublicDBItems { id = 20, object_name = "excision", obj_identifier = "elm", tbl = "_mikro", represented_string = "Excision Status", represented_name = 0, is_table = false, data_format = 2 });
            modelBuilder.Entity<DEFPublicDBItems>().HasData(new DEFPublicDBItems { id = 21, object_name = "exdate", obj_identifier = "elm", tbl = "_mikro", represented_string = "Excision Date", represented_name = 0, is_table = false, data_format = 3 });
            modelBuilder.Entity<DEFPublicDBItems>().HasData(new DEFPublicDBItems { id = 22, object_name = "_imgdiag", obj_identifier = "dia", tbl = null, represented_string = "Diagnoses", represented_name = 0, is_table = true, data_format = 0 });
            modelBuilder.Entity<DEFPublicDBItems>().HasData(new DEFPublicDBItems { id = 23, object_name = "fullname", obj_identifier = "dia", tbl = "_diagnoses", represented_string = "Diagnosis Name", represented_name = 0, is_table = false, data_format = 2 });
            modelBuilder.Entity<DEFPublicDBItems>().HasData(new DEFPublicDBItems { id = 24, object_name = "risk", obj_identifier = "dia", tbl = "_diagnoses", represented_string = "Diagnosis Risk", represented_name = 0, is_table = false, data_format = 2 });
            modelBuilder.Entity<DEFPublicDBItems>().HasData(new DEFPublicDBItems { id = 25, object_name = "_timestamps", obj_identifier = "tim", tbl = null, represented_string = "Time", represented_name = 0, is_table = true, data_format = 0 });
            modelBuilder.Entity<DEFPublicDBItems>().HasData(new DEFPublicDBItems { id = 26, object_name = "date_created", obj_identifier = "tim", tbl = "_timestamps", represented_string = "Creation Date", represented_name = 0, is_table = false, data_format = 3 });
            modelBuilder.Entity<DEFPublicDBItems>().HasData(new DEFPublicDBItems { id = 27, object_name = "date_last_accessed", obj_identifier = "tim", tbl = "_timestamps", represented_string = "Last Accession Date", represented_name = 0, is_table = false, data_format = 3 });
            modelBuilder.Entity<DEFPublicDBItems>().HasData(new DEFPublicDBItems { id = 28, object_name = "_documents", obj_identifier = "doc", tbl = null, represented_string = "Atteched Documents", represented_name = 0, is_table = true, data_format = 0 });
            modelBuilder.Entity<DEFPublicDBItems>().HasData(new DEFPublicDBItems { id = 29, object_name = "docname", obj_identifier = "doc", tbl = "_documents", represented_string = "Document Name", represented_name = 0, is_table = false, data_format = 2 });
            modelBuilder.Entity<DEFPublicDBItems>().HasData(new DEFPublicDBItems { id = 30, object_name = "_cosmetic", obj_identifier = "cos", tbl = null, represented_string = "Cosmetical Images", represented_name = 0, is_table = true, data_format = 0 });
            modelBuilder.Entity<DEFPublicDBItems>().HasData(new DEFPublicDBItems { id = 31, object_name = "treatment_id", obj_identifier = "cos", tbl = "_cosmetic", represented_string = "Kind of Treatment", represented_name = 0, is_table = false, data_format = 1 });
            modelBuilder.Entity<DEFPublicDBItems>().HasData(new DEFPublicDBItems { id = 32, object_name = "_histos", obj_identifier = "his", tbl = null, represented_string = "Histopathological Image", represented_name = 0, is_table = true, data_format = 0 });
            modelBuilder.Entity<DEFPublicDBItems>().HasData(new DEFPublicDBItems { id = 33, object_name = "examinator", obj_identifier = "his", tbl = "_histos", represented_string = "Examinator", represented_name = 0, is_table = false, data_format = 2 });
            modelBuilder.Entity<DEFPublicDBItems>().HasData(new DEFPublicDBItems { id = 34, object_name = "diagnose", obj_identifier = "his", tbl = "_histos", represented_string = "Diagnose", represented_name = 0, is_table = false, data_format = 2 });
            modelBuilder.Entity<DEFPublicDBItems>().HasData(new DEFPublicDBItems { id = 35, object_name = "histo_nr", obj_identifier = "his", tbl = "_histos", represented_string = "Histopathological Number", represented_name = 0, is_table = false, data_format = 2 });
        }
    }
}
