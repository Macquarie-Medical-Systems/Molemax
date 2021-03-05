using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Molemax.Models;

namespace Molemax.Repository.Sql
{
    public class SqlEthnicgroupRepository : IRepository<Ethnicgroup>
    {
        private readonly MolemaxContext _db;
        public DbSet<Ethnicgroup> Table { get { return _db.DbSetEthnicgroup; } }

        public SqlEthnicgroupRepository(MolemaxContext db)
        {
            _db = db;
        }

        public void Delete(int id)
        {
            var ethnicgroup = _db.DbSetEthnicgroup.FirstOrDefault(e => e.ID == id);
            if (null != ethnicgroup)
            {
                _db.DbSetEthnicgroup.Remove(ethnicgroup);
                _db.SaveChanges();
            }
        }

        public IEnumerable<Ethnicgroup> Get()
        {
            return _db.DbSetEthnicgroup.ToList();
        }

        public Ethnicgroup Get(int id)
        {
            return _db.DbSetEthnicgroup.FirstOrDefault(e=>e.ID == id);
        }


        public Ethnicgroup Upsert(Ethnicgroup ethnicgroup)
        {
            var current = _db.DbSetEthnicgroup.FirstOrDefault(e => e.ID == ethnicgroup.ID);
            if (null == current)
            {
                _db.DbSetEthnicgroup.Add(ethnicgroup);
            }
            else
            {
                _db.Entry(current).CurrentValues.SetValues(ethnicgroup);
            }
            _db.SaveChanges();
            return ethnicgroup;
        }

        public IEnumerable<Ethnicgroup> Upsert(IEnumerable<Ethnicgroup> item)
        {
            throw new NotImplementedException();
        }
    }
}
