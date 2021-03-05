using Microsoft.EntityFrameworkCore;
using Molemax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molemax.Repository.Sql
{
    public class SqlHairColorRepository : IRepository<HairColor>
    {
        private readonly MolemaxContext _db;
        public DbSet<HairColor> Table { get { return _db.DbSetHairColor; } }

        public SqlHairColorRepository(MolemaxContext db)
        {
            _db = db;
        }

        public void Delete(int id)
        {
            var hairColor = _db.DbSetHairColor.FirstOrDefault(e => e.ID == id);
            if (null != hairColor)
            {
                _db.DbSetHairColor.Remove(hairColor);
                _db.SaveChanges();
            }
        }

        public IEnumerable<HairColor> Get()
        {
            return _db.DbSetHairColor.ToList();
        }

        public HairColor Get(int id)
        {
            return _db.DbSetHairColor.FirstOrDefault(e => e.ID == id);
        }


        public HairColor Upsert(HairColor hairColor)
        {
            var current = _db.DbSetHairColor.FirstOrDefault(e => e.ID == hairColor.ID);
            if (null == current)
            {
                _db.DbSetHairColor.Add(hairColor);
            }
            else
            {
                _db.Entry(current).CurrentValues.SetValues(hairColor);
            }
            _db.SaveChanges();
            return hairColor;
        }

        public IEnumerable<HairColor> Upsert(IEnumerable<HairColor> item)
        {
            throw new NotImplementedException();
        }
    }
}
