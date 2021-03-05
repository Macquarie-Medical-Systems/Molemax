using Microsoft.EntityFrameworkCore;
using Molemax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molemax.Repository.Sql
{
    public class SqlTimestampRepository : IRepository<Timestamp>
    {
        private readonly MolemaxContext _db;

        public SqlTimestampRepository(MolemaxContext db)
        {
            _db = db;
        }

        public DbSet<Timestamp> Table { get { return _db.DbSetTimestamps; } }

        public void Delete(int id)
        {
            var timestamp = _db.DbSetTimestamps.FirstOrDefault(e => e.id == id);
            if (null != timestamp)
            {
                _db.DbSetTimestamps.Remove(timestamp);
                _db.SaveChanges();
            }
        }

        public IEnumerable<Timestamp> Get()
        {
            return _db.DbSetTimestamps.ToList();
        }

        public Timestamp Get(int id)
        {
            return _db.DbSetTimestamps.FirstOrDefault(e => e.id == id);
        }


        public Timestamp Upsert(Timestamp timestamp)
        {
            var current = _db.DbSetTimestamps.FirstOrDefault(e => e.id == timestamp.id);
            if (null == current)
            {
                _db.DbSetTimestamps.Add(timestamp);
            }
            else
            {
                _db.Entry(current).CurrentValues.SetValues(timestamp);
            }
            _db.SaveChanges();
            return timestamp;
        }

        public IEnumerable<Timestamp> Upsert(IEnumerable<Timestamp> item)
        {
            throw new NotImplementedException();
        }
    }
}
