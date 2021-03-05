using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Molemax.Models
{
    public class DEFPublicDBFieldsSeed
    {
        public static void GenerateSeed(ModelBuilder modelBuilder)
        {
            //should use the latest field name
            //modelBuilder.Entity<DEFPublicDBFields>().HasData(new DEFPublicDBFields { id = 2, tableid = 1, groupid = 1, field = "lastname", represented = "Lastname", representedid = 0, data = 2, valuelist = false, existance = false });
            //modelBuilder.Entity<DEFPublicDBFields>().HasData(new DEFPublicDBFields { id = 3, tableid = 1, groupid = 1, field = "firstname", represented = "Firstname", representedid = 0, data = 2, valuelist = false, existance = false });
            //modelBuilder.Entity<DEFPublicDBFields>().HasData(new DEFPublicDBFields { id = 4, tableid = 1, groupid = 1, field = "birthdate", represented = "Birthdate", representedid = 0, data = 3, valuelist = false, existance = false });
            //modelBuilder.Entity<DEFPublicDBFields>().HasData(new DEFPublicDBFields { id = 5, tableid = 1, groupid = 1, field = "sex", represented = "Sex", representedid = 0, data = 2, valuelist = true, existance = false });
            //modelBuilder.Entity<DEFPublicDBFields>().HasData(new DEFPublicDBFields { id = 6, tableid = 1, groupid = 1, field = "insnr", represented = "Insurance Number", representedid = 0, data = 2, valuelist = false, existance = false });
            //modelBuilder.Entity<DEFPublicDBFields>().HasData(new DEFPublicDBFields { id = 7, tableid = 1, groupid = 1, field = "insnr_usa", represented = "Insurance Number", representedid = 0, data = 2, valuelist = false, existance = false });
            //modelBuilder.Entity<DEFPublicDBFields>().HasData(new DEFPublicDBFields { id = 8, tableid = 1, groupid = 1, field = "insident", represented = "Insurance Identification", representedid = 0, data = 2, valuelist = false, existance = false });
            //modelBuilder.Entity<DEFPublicDBFields>().HasData(new DEFPublicDBFields { id = 9, tableid = 1, groupid = 1, field = "fup_date", represented = "Follow Up Date", representedid = 0, data = 3, valuelist = false, existance = false });
            //modelBuilder.Entity<DEFPublicDBFields>().HasData(new DEFPublicDBFields { id = 10, tableid = 1, groupid = 1, field = "address", represented = "Address", representedid = 0, data = 2, valuelist = false, existance = false });
            //modelBuilder.Entity<DEFPublicDBFields>().HasData(new DEFPublicDBFields { id = 11, tableid = 1, groupid = 1, field = "city", represented = "City", representedid = 0, data = 2, valuelist = false, existance = false });
            //modelBuilder.Entity<DEFPublicDBFields>().HasData(new DEFPublicDBFields { id = 12, tableid = 1, groupid = 1, field = "zip", represented = "Zip Code", representedid = 0, data = 2, valuelist = false, existance = false });
            //modelBuilder.Entity<DEFPublicDBFields>().HasData(new DEFPublicDBFields { id = 13, tableid = 1, groupid = 1, field = "ts_id", represented = "Patient Creation Date", representedid = 0, data = 1, valuelist = false, existance = false });
            //modelBuilder.Entity<DEFPublicDBFields>().HasData(new DEFPublicDBFields { id = 14, tableid = 1, groupid = 1, field = "pat_id", represented = "Patient ID", representedid = 0, data = 1, valuelist = false, existance = false });
            //modelBuilder.Entity<DEFPublicDBFields>().HasData(new DEFPublicDBFields { id = 15, tableid = 2, groupid = 2, field = "kind", represented = "Kind of Image", representedid = 0, data = 1, valuelist = true, existance = false });
            //modelBuilder.Entity<DEFPublicDBFields>().HasData(new DEFPublicDBFields { id = 16, tableid = 2, groupid = 2, field = "treatment", represented = "Image Creation Date", representedid = 0, data = 3, valuelist = false, existance = false });
            //modelBuilder.Entity<DEFPublicDBFields>().HasData(new DEFPublicDBFields { id = 17, tableid = 2, groupid = 2, field = "origin", represented = "Source", representedid = 0, data = 1, valuelist = true, existance = false });
            //modelBuilder.Entity<DEFPublicDBFields>().HasData(new DEFPublicDBFields { id = 18, tableid = 2, groupid = 2, field = "img_id", represented = "Image ID", representedid = 0, data = 1, valuelist = false, existance = false });
            //modelBuilder.Entity<DEFPublicDBFields>().HasData(new DEFPublicDBFields { id = 19, tableid = 3, groupid = 3, field = "fullname", represented = "Diagnosis Name", representedid = 0, data = 2, valuelist = false, existance = false });
            //modelBuilder.Entity<DEFPublicDBFields>().HasData(new DEFPublicDBFields { id = 20, tableid = 3, groupid = 3, field = "risk", represented = "Diagnosis Risk", representedid = 0, data = 2, valuelist = true, existance = false });
            //modelBuilder.Entity<DEFPublicDBFields>().HasData(new DEFPublicDBFields { id = 21, tableid = 4, groupid = 4, field = "ts_id", represented = "BMS Creation Date", representedid = 0, data = 1, valuelist = false, existance = false });
            //modelBuilder.Entity<DEFPublicDBFields>().HasData(new DEFPublicDBFields { id = 22, tableid = 4, groupid = 4, field = "bms_type", represented = "BMS Type", representedid = 0, data = 1, valuelist = true, existance = false });
            //modelBuilder.Entity<DEFPublicDBFields>().HasData(new DEFPublicDBFields { id = 23, tableid = 17, groupid = 5, field = "makro_id", represented = "MoleMap Result", representedid = 0, data = 0, valuelist = false, existance = true });
            //modelBuilder.Entity<DEFPublicDBFields>().HasData(new DEFPublicDBFields { id = 24, tableid = 5, groupid = 5, field = "fup_id", represented = "Macro Follow Ups", representedid = 0, data = 0, valuelist = false, existance = true });
            //modelBuilder.Entity<DEFPublicDBFields>().HasData(new DEFPublicDBFields { id = 25, tableid = 18, groupid = 6, field = "closeup_id", represented = "MoleMap Result", representedid = 0, data = 0, valuelist = false, existance = true });
            //modelBuilder.Entity<DEFPublicDBFields>().HasData(new DEFPublicDBFields { id = 26, tableid = 6, groupid = 6, field = "fup_id", represented = "Close Up Follow Ups", representedid = 0, data = 0, valuelist = false, existance = true });
            //modelBuilder.Entity<DEFPublicDBFields>().HasData(new DEFPublicDBFields { id = 27, tableid = 7, groupid = 7, field = "excision", represented = "Excision State", representedid = 0, data = 2, valuelist = true, existance = false });
            //modelBuilder.Entity<DEFPublicDBFields>().HasData(new DEFPublicDBFields { id = 28, tableid = 7, groupid = 7, field = "zoom", represented = "Zoom Factor", representedid = 0, data = 1, valuelist = false, existance = false });
            //modelBuilder.Entity<DEFPublicDBFields>().HasData(new DEFPublicDBFields { id = 29, tableid = 22, groupid = 7, field = "mikro_id", represented = "MoleScore Result", representedid = 0, data = 0, valuelist = false, existance = true });
            //modelBuilder.Entity<DEFPublicDBFields>().HasData(new DEFPublicDBFields { id = 30, tableid = 19, groupid = 7, field = "mikro_id", represented = "ABCD Method Result", representedid = 0, data = 0, valuelist = false, existance = true });
            //modelBuilder.Entity<DEFPublicDBFields>().HasData(new DEFPublicDBFields { id = 31, tableid = 20, groupid = 7, field = "mikro_id", represented = "7 Point Rule Result", representedid = 0, data = 0, valuelist = false, existance = true });
            //modelBuilder.Entity<DEFPublicDBFields>().HasData(new DEFPublicDBFields { id = 32, tableid = 21, groupid = 7, field = "mikro_id", represented = "Trichoscan Result", representedid = 0, data = 0, valuelist = false, existance = true });
            //modelBuilder.Entity<DEFPublicDBFields>().HasData(new DEFPublicDBFields { id = 33, tableid = 8, groupid = 8, field = "treatment_id", represented = "Kind of Treatment", representedid = 0, data = 1, valuelist = true, existance = false });
            //modelBuilder.Entity<DEFPublicDBFields>().HasData(new DEFPublicDBFields { id = 34, tableid = 8, groupid = 8, field = "ts_id", represented = "Cosmetical Image Creation Date", representedid = 0, data = 1, valuelist = false, existance = false });
            //modelBuilder.Entity<DEFPublicDBFields>().HasData(new DEFPublicDBFields { id = 35, tableid = 9, groupid = 9, field = "pat_diagnose", represented = "Histopathological Diagnose", representedid = 0, data = 2, valuelist = false, existance = false });
            //modelBuilder.Entity<DEFPublicDBFields>().HasData(new DEFPublicDBFields { id = 36, tableid = 9, groupid = 9, field = "histo_nr", represented = "Number of Report", representedid = 0, data = 2, valuelist = false, existance = false });
            //modelBuilder.Entity<DEFPublicDBFields>().HasData(new DEFPublicDBFields { id = 37, tableid = 9, groupid = 9, field = "clark", represented = "Clark Level", representedid = 0, data = 1, valuelist = true, existance = false });
            //modelBuilder.Entity<DEFPublicDBFields>().HasData(new DEFPublicDBFields { id = 38, tableid = 9, groupid = 9, field = "breslow", represented = "Breslow Value", representedid = 0, data = 2, valuelist = false, existance = false });
            //modelBuilder.Entity<DEFPublicDBFields>().HasData(new DEFPublicDBFields { id = 39, tableid = 9, groupid = 9, field = "diagdate", represented = "Histopathological Image Creation Date", representedid = 0, data = 3, valuelist = false, existance = false });
            //modelBuilder.Entity<DEFPublicDBFields>().HasData(new DEFPublicDBFields { id = 40, tableid = 10, groupid = 10, field = "docname", represented = "Name of Document", representedid = 0, data = 2, valuelist = false, existance = false });
            //modelBuilder.Entity<DEFPublicDBFields>().HasData(new DEFPublicDBFields { id = 41, tableid = 11, groupid = 11, field = "docname", represented = "Name of Histopathological Document", representedid = 0, data = 0, valuelist = false, existance = false });
            //modelBuilder.Entity<DEFPublicDBFields>().HasData(new DEFPublicDBFields { id = 42, tableid = 7, groupid = 7, field = "fup_id", represented = "ELM Follow Ups", representedid = 0, data = 0, valuelist = false, existance = true });
        }
    }
}
