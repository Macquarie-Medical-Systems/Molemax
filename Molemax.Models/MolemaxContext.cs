using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Molemax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molemax.Models
{
    public class MolemaxContext : DbContext
    {
        /// <summary>
        /// Creates a new Contoso DbContext.
        /// </summary>
        public MolemaxContext() : base() { }

        public MolemaxContext(DbContextOptions<MolemaxContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseMySQL(@"Server=localhost;Database=MolemaxDB;user=Admin;password=p@ssw0rd");
            optionsBuilder
                .UseLoggerFactory(ConsoleLoggerFactory)
                .UseSqlServer(@"Server=localhost\SQLEXPRESS; Database=MolemaxDB; Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ExpertizerABCDSeed.GenerateSeed(modelBuilder);
            
            ExpertizerMainSeed.GenerateSeed(modelBuilder);

            ExpertizerS7Seed.GenerateSeed(modelBuilder);

            ExpertizerSelfSeed.GenerateSeed(modelBuilder);

            DEFBodymapPositionSeed.GenerateSeed(modelBuilder);

            DEFDiagnosisSeed.GenerateSeed(modelBuilder);

            DEFLocalTxtSeed.GenerateSeed(modelBuilder);

            DEFMakroLokalSeed.GenerateSeed(modelBuilder);

            DEFMikroLokalSeed.GenerateSeed(modelBuilder);

            DEFPublicDBFieldsSeed.GenerateSeed(modelBuilder);

            DEFPublicDBItemsSeed.GenerateSeed(modelBuilder);

            DEFPublicDBTablesSeed.GenerateSeed(modelBuilder);

            DEFAllSkinSeed.GenerateSeed(modelBuilder);

            EthnicgroupSeed.GenerateSeed(modelBuilder);

            EyeColorSeed.GenerateSeed(modelBuilder);

            ComplexionSeed.GenerateSeed(modelBuilder);

            HairColorSeed.GenerateSeed(modelBuilder);
            SkinColorSeed.GenerateSeed(modelBuilder);
            CountrySeed.GenerateSeed(modelBuilder);
            #region Index
            //modelBuilder.Entity<ABCD>().HasIndex(b => b.mikro_id).IsUnique();
            //modelBuilder.Entity<Aisinfo>().HasIndex(b => b.pat_id).IsUnique();
            //modelBuilder.Entity<Camset>().HasIndex(b => b.img_id).IsUnique();
            #endregion
        }
        /// <summary>
        /// Gets Expertizer DbSet.
        /// </summary>
        #region DBSet Expertizer
        public DbSet<ExpertizerABCD> DbSetExpertizerABCD { get; set; } = null!;
        public DbSet<ExpertizerMain> DbSetExpertizerMain { get; set; } = null!;
        public DbSet<ExpertizerS7> DbSetExpertizerS7 { get; set; } = null!;
        public DbSet<ExpertizerSelf> DbSetExpertizerSelf { get; set; } = null!;
        #endregion

        #region DBSet DEF
        public DbSet<DEFBodymapPosition> DbSetDEFBodymapPosition { get; set; } = null!;
        public DbSet<DEFDiagnoses> DbSetDEFDiagnosis { get; set; } = null!;
        public DbSet<DEFPublicDBFields> DbSetDEFPublicDBFields { get; set; } = null!;
        public DbSet<DEFPublicDBItems> DbSetDEFPublicDBItems { get; set; } = null!;
        public DbSet<DEFPublicDBTables> DbSetDEFPublicDBTables { get; set; } = null!;
        public DbSet<DEFSys> DbSetDEFSys { get; set; } = null!;
        public DbSet<DEFKen> DbSetDEFKen { get; set; } = null!;
        public DbSet<DEFLocalTxt> DbSetDEFLocalTxt { get; set; } = null!;
        public DbSet<DEFMakroKen> DbSetDEFMakroKen { get; set; } = null!;
        public DbSet<DEFMakroLokal> DbSetDEFMakroLokal { get; set; } = null!;
        public DbSet<DEFMikroKen> DbSetDEFMikroKen { get; set; } = null!;
        public DbSet<DEFMikroLokal> DbSetDEFMikroLokal { get; set; } = null!;
        public DbSet<DEFSelectKen> DbSetDEFSelectKen { get; set; } = null!;
        public DbSet<DEFSmallKen> DbSetDEFSmallKen { get; set; } = null!;
        public DbSet<DEFAllSkin> DbSetDEFAllSkin { get; set; } = null!;

        #endregion

        #region DBSet DB
        public DbSet<ABCD> DbSetABCD { get; set; } = null!;
        public DbSet<Aisinfo> DbSetAisinfo { get; set; } = null!;
        public DbSet<Bodymap> DbSetBodymaps { get; set; } = null!;
        public DbSet<Camset> DbSetCamset { get; set; } = null!;
        public DbSet<ChangedLoc> DbSetChangedLoc { get; set; } = null!;
        public DbSet<Closeup> DbSetCloseup { get; set; } = null!;
        public DbSet<Cosmetic> DbSetCosmetic { get; set; } = null!;
        public DbSet<Diagnose> DbSetDiagnoses { get; set; } = null!;
        public DbSet<Diagsource> DbSetDiagsource { get; set; } = null!;
        public DbSet<Document> DbSetDocuments { get; set; } = null!;
        public DbSet<DocumentsHisto> DbSetDocumentsHisto { get; set; } = null!;
        public DbSet<Fup> DbSetFup { get; set; } = null!;
        public DbSet<Histo> DbSetHistos { get; set; } = null!;
        public DbSet<Image> DbSetImages { get; set; } = null!;
        public DbSet<ImgDiag> DbSetImgDiag { get; set; } = null!;
        public DbSet<Makro> DbSetMakro { get; set; } = null!;
        public DbSet<Mee> DbSetMee { get; set; } = null!;
        public DbSet<Mem> DbSetMem { get; set; } = null!;
        public DbSet<Memc> DbSetMemc { get; set; } = null!;
        public DbSet<Mikro> DbSetMikro { get; set; } = null!;
        public DbSet<Patient> DbSetPatients { get; set; } = null!;
        public DbSet<S7p> DbSetS7p { get; set; } = null!;
        public DbSet<Sender> DbSetSender { get; set; } = null!;
        public DbSet<Timestamp> DbSetTimestamps { get; set; } = null!;
        public DbSet<Trichoscan> DbSetTrichoscan { get; set; } = null!;
        public DbSet<User> DbSetUsers { get; set; } = null!;
        public DbSet<ActionLog> DbSetActionLog { get; set; } = null!;
        public DbSet<Complexion> DbSetComplexion { get; set; } = null!;
        public DbSet<DDSys> DbSetDDSys { get; set; } = null!;
        public DbSet<Ethnicgroup> DbSetEthnicgroup { get; set; } = null!;
        public DbSet<ExpressImage> DbSetExpressImage { get; set; } = null!;
        public DbSet<EyeColor> DbSetEyeColor { get; set; } = null!;
        public DbSet<HairColor> DbSetHairColor { get; set; } = null!;
        public DbSet<SkinColor> DbSetSkinColor { get; set; } = null!;
        public DbSet<Country> DbSetCountry { get; set; } = null!;
        #endregion

        public static readonly ILoggerFactory ConsoleLoggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddFilter((category, level) =>
                    category == DbLoggerCategory.Database.Command.Name
                    && level == LogLevel.Information).AddConsole();
        });
    }
}
