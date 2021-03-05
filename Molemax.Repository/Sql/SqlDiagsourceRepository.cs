using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Molemax.Models;

namespace Molemax.Repository.Sql
{
    public class SqlDiagsourceRepository : IRepository<Diagsource>
    {
        private readonly MolemaxContext _db;
        public DbSet<Diagsource> Table { get { return _db.DbSetDiagsource; } }

        public SqlDiagsourceRepository(MolemaxContext db)
        {
            _db = db;
        }

        public void Delete(int id)
        {
            var diagsource = _db.DbSetDiagsource.FirstOrDefault(e => e.id == id);
            if (null != diagsource)
            {
                _db.DbSetDiagsource.Remove(diagsource);
                _db.SaveChanges();
            }
        }

        public IEnumerable<Diagsource> Get()
        {
            return _db.DbSetDiagsource.ToList();
        }

        public Diagsource Get(int id)
        {
            return _db.DbSetDiagsource.FirstOrDefault(e => e.id == id);
        }


        public Diagsource Upsert(Diagsource diagsource)
        {
            var current = _db.DbSetDiagsource.FirstOrDefault(e => e.id == diagsource.id);
            if (null == current)
            {
                _db.DbSetDiagsource.Add(diagsource);
            }
            else
            {
                _db.Entry(current).CurrentValues.SetValues(diagsource);
            }
            _db.SaveChanges();
            return diagsource;
        }

        public IEnumerable<Diagsource> Upsert(IEnumerable<Diagsource> diagsources)
        {
            List<Diagsource> returnList = new List<Diagsource>();

            if (diagsources != null && diagsources.Count() > 0)
            {
                foreach (var diagsource in diagsources)
                {
                    var current = _db.DbSetDiagsource.FirstOrDefault(e => e.id == diagsource.id);
                    if (null == current)
                    {
                        _db.DbSetDiagsource.Add(diagsource);
                    }
                    else
                    {
                        _db.Entry(current).CurrentValues.SetValues(diagsource);
                    }
                    returnList.Add(diagsource);
                }
                throw new System.NotImplementedException();
            }

            return returnList;
        }
    }
}
