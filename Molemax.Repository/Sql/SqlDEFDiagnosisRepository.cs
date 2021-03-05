using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Molemax.Models;

namespace Molemax.Repository.Sql
{
    public class SqlDEFDiagnosisRepository : IRepository<DEFDiagnoses>
    {
        private readonly MolemaxContext _db;
        public DbSet<DEFDiagnoses> Table { get { return _db.DbSetDEFDiagnosis; } }

        public SqlDEFDiagnosisRepository(MolemaxContext db)
        {
            _db = db;
        }

        public void Delete(int id)
        {
        }

        public IEnumerable<DEFDiagnoses> Get()
        {
            return _db.DbSetDEFDiagnosis.ToList();
        }

        public DEFDiagnoses Get(int id)
        {
            return _db.DbSetDEFDiagnosis.FirstOrDefault(e => e.id == id);
        }


        public DEFDiagnoses Upsert(DEFDiagnoses defDiagnosis)
        {
            return null;
        }

        public IEnumerable<DEFDiagnoses> Upsert(IEnumerable<DEFDiagnoses> item)
        {
            throw new System.NotImplementedException();
        }
    }
}
