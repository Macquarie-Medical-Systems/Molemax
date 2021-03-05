using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Molemax.Models;

namespace Molemax.Repository.Sql
{
    public class SqlDiagnoseRepository : IRepository<Diagnose>
    {
        private readonly MolemaxContext _db;
        public DbSet<Diagnose> Table { get { return _db.DbSetDiagnoses; } }

        public SqlDiagnoseRepository(MolemaxContext db)
        {
            _db = db;
        }

        public void Delete(int id)
        {
            var diagsource = _db.DbSetDiagnoses.FirstOrDefault(e => e.id == id);
            if (null != diagsource)
            {
                _db.DbSetDiagnoses.Remove(diagsource);
                _db.SaveChanges();
            }
        }

        public IEnumerable<Diagnose> Get()
        {
            return _db.DbSetDiagnoses.ToList();
        }

        public Diagnose Get(int id)
        {
            return _db.DbSetDiagnoses.FirstOrDefault(e => e.id == id);
        }


        public Diagnose Upsert(Diagnose diagnose)
        {
            var current = _db.DbSetDiagnoses.FirstOrDefault(e => e.id == diagnose.id);
            if (null == current)
            {
                _db.DbSetDiagnoses.Add(diagnose);
            }
            else
            {
                _db.Entry(current).CurrentValues.SetValues(diagnose);
            }
            _db.SaveChanges();
            return diagnose;
        }

        public IEnumerable<Diagnose> Upsert(IEnumerable<Diagnose> item)
        {
            throw new System.NotImplementedException();
        }
    }
}
