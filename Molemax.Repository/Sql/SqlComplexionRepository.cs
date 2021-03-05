using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Molemax.Models;

namespace Molemax.Repository.Sql
{
    public class SqlComplexionRepository : IRepository<Complexion>
    {
        private readonly MolemaxContext _db;
        public DbSet<Complexion> Table { get { return _db.DbSetComplexion; } }

        public SqlComplexionRepository(MolemaxContext db)
        {
            _db = db;
        }

        public void Delete(int id)
        {
            var complexion = _db.DbSetComplexion.FirstOrDefault(e => e.ID == id);
            if (null != complexion)
            {
                _db.DbSetComplexion.Remove(complexion);
                _db.SaveChanges();
            }
        }

        public IEnumerable<Complexion> Get()
        {
            return _db.DbSetComplexion.ToList();
        }

        public Complexion Get(int id)
        {
            return _db.DbSetComplexion.FirstOrDefault(e => e.ID == id);
        }


        public Complexion Upsert(Complexion complexion)
        {
            var current = _db.DbSetComplexion.FirstOrDefault(e => e.ID == complexion.ID);
            if (null == current)
            {
                _db.DbSetComplexion.Add(complexion);
            }
            else
            {
                _db.Entry(current).CurrentValues.SetValues(complexion);
            }
            _db.SaveChanges();
            return complexion;
        }


        public IEnumerable<Complexion> Upsert(IEnumerable<Complexion> complexions)
        {
            throw new System.NotImplementedException();
        }
    }
}
