using Microsoft.EntityFrameworkCore;
using Molemax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molemax.Repository.Sql
{
    public class SqlCloseupRepository : IRepository<Closeup>
    {
        private readonly MolemaxContext _db;
        public DbSet<Closeup> Table { get { return _db.DbSetCloseup; } }

        public SqlCloseupRepository(MolemaxContext db)
        {
            _db = db;
        }

        public void Delete(int id)
        {
            var closeup = _db.DbSetCloseup.FirstOrDefault(e => e.id == id);
            if (null != closeup)
            {
                _db.DbSetCloseup.Remove(closeup);
                _db.SaveChanges();
            }
        }

        public IEnumerable<Closeup> Get()
        {
            return _db.DbSetCloseup.ToList();
        }

        public Closeup Get(int id)
        {
            return _db.DbSetCloseup.FirstOrDefault(e => e.id == id);
        }


        public Closeup Upsert(Closeup closeup)
        {
            var current = _db.DbSetCloseup.FirstOrDefault(e => e.id == closeup.id);
            if (null == current)
            {
                _db.DbSetCloseup.Add(closeup);
            }
            else
            {
                _db.Entry(current).CurrentValues.SetValues(closeup);
            }
            _db.SaveChanges();
            return closeup;
        }

        public IEnumerable<Closeup> Upsert(IEnumerable<Closeup> closeups)
        {
            List<Closeup> returnList = new List<Closeup>();

            if (closeups!=null && closeups.Count() > 0)
            {
                foreach (var closeup in closeups)
                {
                    var current = _db.DbSetCloseup.FirstOrDefault(e => e.id == closeup.id);
                    if (null == current)
                    {
                        _db.DbSetCloseup.Add(closeup);
                    }
                    else
                    {
                        _db.Entry(current).CurrentValues.SetValues(closeup);
                    }
                    returnList.Add(closeup);
                }
                _db.SaveChanges();
            }
            return returnList;
        }
    }
}
