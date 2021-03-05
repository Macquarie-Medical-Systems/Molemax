using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Molemax.Models
{
    public class CountrySeed
    {
        public static void GenerateSeed(ModelBuilder modelBuilder)
        {
            #region HairColorSeed
            modelBuilder.Entity<Country>().HasData(new Country { ID = 1, info = "Australia" });
            modelBuilder.Entity<Country>().HasData(new Country { ID = 2, info = "China" });
            modelBuilder.Entity<Country>().HasData(new Country { ID = 3, info = "Japan" });
            modelBuilder.Entity<Country>().HasData(new Country { ID = 4, info = "USA" });
            #endregion
        }
    }
}

                
