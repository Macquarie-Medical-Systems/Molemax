using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Molemax.Models
{
    public class SkinColorSeed
    {
        public static void GenerateSeed(ModelBuilder modelBuilder)
        {
            #region SkinColorSeed
            modelBuilder.Entity<SkinColor>().HasData(new SkinColor { ID = 1, info = "Brown" });
            modelBuilder.Entity<SkinColor>().HasData(new SkinColor { ID = 2, info = "Olive" });
            modelBuilder.Entity<SkinColor>().HasData(new SkinColor { ID = 3, info = "Tan" });
            modelBuilder.Entity<SkinColor>().HasData(new SkinColor { ID = 4, info = "White" });
            #endregion
        }
    }
}
                


