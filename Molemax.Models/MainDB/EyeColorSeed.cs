using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Molemax.Models
{
    public class EyeColorSeed
    {
        public static void GenerateSeed(ModelBuilder modelBuilder)
        {
            #region EyeColorSeed
            modelBuilder.Entity<EyeColor>().HasData(new EyeColor { ID = 1, info = "Blue" });
            modelBuilder.Entity<EyeColor>().HasData(new EyeColor { ID = 2, info = "Brown" });
            modelBuilder.Entity<EyeColor>().HasData(new EyeColor { ID = 3, info = "Green" });
            modelBuilder.Entity<EyeColor>().HasData(new EyeColor { ID = 4, info = "Hazel" });
            #endregion
        }
    }
}
