using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Molemax.Models;

namespace Molemax.Repository.Sql
{
    public class SqlDEFLocalTxtRepository : IRepository<DEFLocalTxt>
    {
        private readonly MolemaxContext _db;
        public DbSet<DEFLocalTxt> Table { get { return _db.DbSetDEFLocalTxt; } }

        public SqlDEFLocalTxtRepository(MolemaxContext db)
        {
            _db = db;
        }

        public void Delete(int id)
        {
        }

        public IEnumerable<DEFLocalTxt> Get()
        {
            return _db.DbSetDEFLocalTxt.ToList();
        }

        public DEFLocalTxt Get(int id)
        {
            return _db.DbSetDEFLocalTxt.FirstOrDefault(e => e.id == id);
        }


        public DEFLocalTxt Upsert(DEFLocalTxt defLocalTxt)
        {
            return null;
        }

        public IEnumerable<DEFLocalTxt> Upsert(IEnumerable<DEFLocalTxt> item)
        {
            throw new System.NotImplementedException();
        }
    }
}
