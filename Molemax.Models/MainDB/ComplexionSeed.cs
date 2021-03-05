using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Molemax.Models
{
    public class ComplexionSeed
    {
        public static void GenerateSeed(ModelBuilder modelBuilder)
        {
            #region ComplexionSeed
            modelBuilder.Entity<Complexion>().HasData(new Complexion { ID = 1, info = "Dark" });
            modelBuilder.Entity<Complexion>().HasData(new Complexion { ID = 2, info = "Fair" });
            modelBuilder.Entity<Complexion>().HasData(new Complexion { ID = 3, info = "Light" });
            #endregion
        }
    }
}
