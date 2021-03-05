using Microsoft.EntityFrameworkCore;
using Molemax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molemax.Repository.Sql
{
    public class SqlMakroRepository : IRepository<Makro>
    {
        private readonly MolemaxContext _db;
        public DbSet<Makro> Table { get { return _db.DbSetMakro; } }

        public SqlMakroRepository(MolemaxContext db)
        {
            _db = db;
        }

        public void Delete(int id)
        {
            var makro = _db.DbSetMakro.FirstOrDefault(e => e.id == id);
            if (null != makro)
            {
                _db.DbSetMakro.Remove(makro);
                _db.SaveChanges();
            }
        }

        public IEnumerable<Makro> Get()
        {
            return _db.DbSetMakro.ToList();
        }

        public Makro Get(int id)
        {
            return _db.DbSetMakro.FirstOrDefault(e => e.id == id);
        }


        public Makro Upsert(Makro makro)
        {
            var current = _db.DbSetMakro.FirstOrDefault(e => e.id == makro.id);
            if (null == current)
            {
                _db.DbSetMakro.Add(makro);
            }
            else
            {
                _db.Entry(current).CurrentValues.SetValues(makro);
            }
            _db.SaveChanges();
            return makro;
        }

        public IEnumerable<Makro> Upsert(IEnumerable<Makro> item)
        {
            throw new NotImplementedException();
        }
    }
}
