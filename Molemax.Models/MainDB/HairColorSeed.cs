using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Molemax.Models
{
    public class HairColorSeed
    {
        public static void GenerateSeed(ModelBuilder modelBuilder)
        {
            #region HairColorSeed
            modelBuilder.Entity<HairColor>().HasData(new HairColor { ID = 1, info = "Black" });
            modelBuilder.Entity<HairColor>().HasData(new HairColor { ID = 2, info = "Blonde" });
            modelBuilder.Entity<HairColor>().HasData(new HairColor { ID = 3, info = "Brown" });
            modelBuilder.Entity<HairColor>().HasData(new HairColor { ID = 4, info = "Dark Brown" });
            modelBuilder.Entity<HairColor>().HasData(new HairColor { ID = 5, info = "Red" });
            modelBuilder.Entity<HairColor>().HasData(new HairColor { ID = 6, info = "White" });
            #endregion
        }
    }
}

                
