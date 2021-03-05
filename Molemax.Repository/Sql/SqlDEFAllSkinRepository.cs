using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Molemax.Models;

namespace Molemax.Repository.Sql
{
    public class SqlDEFAllSkinRepository : IRepository<DEFAllSkin>
    {
        private readonly MolemaxContext _db;
        public DbSet<DEFAllSkin> Table { get { return _db.DbSetDEFAllSkin; } }

        public SqlDEFAllSkinRepository(MolemaxContext db)
        {
            _db = db;
        }

        public void Delete(int id)
        {

        }

        public IEnumerable<DEFAllSkin> Get()
        {
            return _db.DbSetDEFAllSkin.ToList();
        }

        public DEFAllSkin Get(int id)
        {
            throw new System.NotImplementedException();
        }


        public DEFAllSkin Upsert(DEFAllSkin defAllSkin)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<DEFAllSkin> Upsert(IEnumerable<DEFAllSkin> item)
        {
            throw new System.NotImplementedException();
        }
    }
}
