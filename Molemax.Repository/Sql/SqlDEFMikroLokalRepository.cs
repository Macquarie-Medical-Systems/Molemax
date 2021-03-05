using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Molemax.Models;

namespace Molemax.Repository.Sql
{
    public class SqlDEFMikroLokalRepository : IRepository<DEFMikroLokal>
    {
        private readonly MolemaxContext _db;
        public DbSet<DEFMikroLokal> Table { get { return _db.DbSetDEFMikroLokal; } }

        public SqlDEFMikroLokalRepository(MolemaxContext db)
        {
            _db = db;
        }

        public void Delete(int id)
        {

        }

        public IEnumerable<DEFMikroLokal> Get()
        {
            return _db.DbSetDEFMikroLokal.ToList();
        }

        public DEFMikroLokal Get(int id)
        {
            return _db.DbSetDEFMikroLokal.FirstOrDefault(e => e.id == id);
        }


        public DEFMikroLokal Upsert(DEFMikroLokal defMikroLokal)
        {
            return null;
        }

        public IEnumerable<DEFMikroLokal> Upsert(IEnumerable<DEFMikroLokal> item)
        {
            throw new System.NotImplementedException();
        }
    }
}
