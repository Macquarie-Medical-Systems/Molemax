using Microsoft.EntityFrameworkCore;
using Molemax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molemax.Repository.Sql
{
    public class SqlMolemaxRepository : IMolemaxRepository
    {
        private readonly DbContextOptions<MolemaxContext> _dbOptions;

        public SqlMolemaxRepository(DbContextOptionsBuilder<MolemaxContext>
            dbOptionsBuilder)
        {
            _dbOptions = dbOptionsBuilder.Options;
            using (var db = new MolemaxContext(_dbOptions))
            {
                //db.Database.Migrate();
                //db.Database.EnsureCreated();
            }
        }

        public IRepository<Patient> Patients => new SqlPatientRepository(new MolemaxContext(_dbOptions));
        public IRepository<Ethnicgroup> Ethnicgroups => new SqlEthnicgroupRepository(new MolemaxContext(_dbOptions));
        public IRepository<EyeColor> EyeColors => new SqlEyeColorRepository(new MolemaxContext(_dbOptions));
        public IRepository<Complexion> Complexions => new SqlComplexionRepository(new MolemaxContext(_dbOptions));
        public IRepository<HairColor> HairColors => new SqlHairColorRepository(new MolemaxContext(_dbOptions));
        public IRepository<SkinColor> SkinColors => new SqlSkinColorRepository(new MolemaxContext(_dbOptions));
        public IRepository<Country> Countrys => new SqlCountryRepository(new MolemaxContext(_dbOptions));
        public IRepository<DEFMakroLokal> DEFMakroLokals => new SqlDEFMakroLokalRepository(new MolemaxContext(_dbOptions));
        public IRepository<DEFMikroLokal> DEFMikroLokals => new SqlDEFMikroLokalRepository(new MolemaxContext(_dbOptions));
        public IRepository<DEFLocalTxt> DEFLocalTxts => new SqlDEFLocalTxtRepository(new MolemaxContext(_dbOptions));
        public IRepository<Diagsource> Diagsources => new SqlDiagsourceRepository(new MolemaxContext(_dbOptions));
        public IRepository<DEFDiagnoses> DEFDiagnoses => new SqlDEFDiagnosisRepository(new MolemaxContext(_dbOptions));
        public IRepository<Diagnose> Diagnoses => new SqlDiagnoseRepository(new MolemaxContext(_dbOptions));
        public IRepository<Timestamp> Timestamps => new SqlTimestampRepository(new MolemaxContext(_dbOptions));
        public IRepository<Image> Images => new SqlImageRepository(new MolemaxContext(_dbOptions));
        public IRepository<Makro> Makros => new SqlMakroRepository(new MolemaxContext(_dbOptions));
        public IRepository<Closeup> Closeups => new SqlCloseupRepository(new MolemaxContext(_dbOptions));
        public IRepository<ImgDiag> ImgDiags => new SqlImgDiagRepository(new MolemaxContext(_dbOptions));
        public IRepository<Mikro> Mikros => new SqlMikroRepository(new MolemaxContext(_dbOptions));
        public IRepository<Fup> Fups => new SqlFupRepository(new MolemaxContext(_dbOptions));
        public IRepository<ExpressImage> ExpressImages => new SqlExpressImageRepository(new MolemaxContext(_dbOptions));
        public IRepository<DEFAllSkin> DEFAllSkins => new SqlDEFAllSkinRepository(new MolemaxContext(_dbOptions));
        public IRepository<User> Users => new SqlUserRepository(new MolemaxContext(_dbOptions));
        public IRepository<ExpertizerABCD> ExpertizerABCDs => new SqlExpertizerABCDRepository(new MolemaxContext(_dbOptions));
    }
}
