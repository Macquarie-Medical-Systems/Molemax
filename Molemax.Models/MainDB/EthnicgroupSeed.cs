using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Molemax.Models
{
    public class EthnicgroupSeed
    {
        public static void GenerateSeed(ModelBuilder modelBuilder)
        {
            #region EthnicgroupSeed
            modelBuilder.Entity<Ethnicgroup>().HasData(new Ethnicgroup { ID = 1, info = "Asian" });
            modelBuilder.Entity<Ethnicgroup>().HasData(new Ethnicgroup { ID = 2, info = "Black" });
            modelBuilder.Entity<Ethnicgroup>().HasData(new Ethnicgroup { ID = 3, info = "Hispanic" });
            modelBuilder.Entity<Ethnicgroup>().HasData(new Ethnicgroup { ID = 4, info = "White" });
            #endregion

        }
    }
}
