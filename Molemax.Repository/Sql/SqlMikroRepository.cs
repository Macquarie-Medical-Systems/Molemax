using Microsoft.EntityFrameworkCore;
using Molemax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molemax.Repository.Sql
{
    public class SqlMikroRepository : IRepository<Mikro>
    {
        private readonly MolemaxContext _db;
        public DbSet<Mikro> Table { get { return _db.DbSetMikro; } }

        public SqlMikroRepository(MolemaxContext db)
        {
            _db = db;
        }

        public void Delete(int id)
        {
            var mikro = _db.DbSetMikro.FirstOrDefault(e => e.id == id);
            if (null != mikro)
            {
                _db.DbSetMikro.Remove(mikro);
                _db.SaveChanges();
            }
        }

        public IEnumerable<Mikro> Get()
        {
            return _db.DbSetMikro.ToList();
        }

        public Mikro Get(int id)
        {
            return _db.DbSetMikro.FirstOrDefault(e => e.id == id);
        }


        public Mikro Upsert(Mikro mikro)
        {
            var current = _db.DbSetMikro.FirstOrDefault(e => e.id == mikro.id);
            if (null == current)
            {
                _db.DbSetMikro.Add(mikro);
            }
            else
            {
                _db.Entry(current).CurrentValues.SetValues(mikro);
            }
            _db.SaveChanges();
            return mikro;
        }

        public IEnumerable<Mikro> Upsert(IEnumerable<Mikro> mikros)
        {
            List<Mikro> returnList = new List<Mikro>();

            if (mikros != null && mikros.Count() > 0)
            {
                foreach (var mikro in mikros)
                {
                    var current = _db.DbSetMikro.FirstOrDefault(e => e.id == mikro.id);
                    if (null == current)
                    {
                        _db.DbSetMikro.Add(mikro);
                    }
                    else
                    {
                        _db.Entry(current).CurrentValues.SetValues(mikro);
                    }
                    returnList.Add(mikro);
                }
                _db.SaveChanges();
            }

            return returnList;
        }
    }
}
