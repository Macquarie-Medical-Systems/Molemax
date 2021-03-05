using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Molemax.Models;

namespace Molemax.Repository.Sql
{
    public class SqlDEFMakroLokalRepository : IRepository<DEFMakroLokal>
    {
        private readonly MolemaxContext _db;
        public DbSet<DEFMakroLokal> Table { get { return _db.DbSetDEFMakroLokal; } }

        public SqlDEFMakroLokalRepository(MolemaxContext db)
        {
            _db = db;
        }

        public void Delete(int id)
        {

        }

        public IEnumerable<DEFMakroLokal> Get()
        {
            return _db.DbSetDEFMakroLokal.ToList();
        }

        public DEFMakroLokal Get(int id)
        {
            return _db.DbSetDEFMakroLokal.FirstOrDefault(e => e.id == id);
        }


        public DEFMakroLokal Upsert(DEFMakroLokal defMakroLokal)
        {
            return null;
        }

        public IEnumerable<DEFMakroLokal> Upsert(IEnumerable<DEFMakroLokal> item)
        {
            throw new System.NotImplementedException();
        }
    }
}
