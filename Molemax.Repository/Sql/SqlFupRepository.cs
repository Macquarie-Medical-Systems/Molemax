using Microsoft.EntityFrameworkCore;
using Molemax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molemax.Repository.Sql
{
    public class SqlFupRepository : IRepository<Fup>
    {
        private readonly MolemaxContext _db;
        public DbSet<Fup> Table { get { return _db.DbSetFup; } }

        public SqlFupRepository(MolemaxContext db)
        {
            _db = db;
        }

        public void Delete(int id)
        {
            var fup = _db.DbSetFup.FirstOrDefault(e => e.id == id);
            if (null != fup)
            {
                _db.DbSetFup.Remove(fup);
                _db.SaveChanges();
            }
        }

        public IEnumerable<Fup> Get()
        {
            return _db.DbSetFup.ToList();
        }

        public Fup Get(int id)
        {
            return _db.DbSetFup.FirstOrDefault(e => e.id == id);
        }


        public Fup Upsert(Fup fup)
        {
            var current = _db.DbSetFup.FirstOrDefault(e => e.id == fup.id);
            if (null == current)
            {
                _db.DbSetFup.Add(fup);
            }
            else
            {
                _db.Entry(current).CurrentValues.SetValues(fup);
            }
            _db.SaveChanges();
            return fup;
        }

        public IEnumerable<Fup> Upsert(IEnumerable<Fup> item)
        {
            throw new NotImplementedException();
        }
    }
}
