using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Molemax.Models;

namespace Molemax.Repository.Sql
{
    public class SqlEyeColorRepository : IRepository<EyeColor>
    {
        private readonly MolemaxContext _db;
        public DbSet<EyeColor> Table { get { return _db.DbSetEyeColor; } }

        public SqlEyeColorRepository(MolemaxContext db)
        {
            _db = db;
        }

        public void Delete(int id)
        {
            var eyeColor = _db.DbSetEyeColor.FirstOrDefault(e => e.ID == id);
            if (null != eyeColor)
            {
                _db.DbSetEyeColor.Remove(eyeColor);
                _db.SaveChanges();
            }
        }

        public IEnumerable<EyeColor> Get()
        {
            return _db.DbSetEyeColor.ToList();
        }

        public EyeColor Get(int id)
        {
            return _db.DbSetEyeColor.FirstOrDefault(e => e.ID == id);
        }


        public EyeColor Upsert(EyeColor eyeColor)
        {
            var current = _db.DbSetEyeColor.FirstOrDefault(e => e.ID == eyeColor.ID);
            if (null == current)
            {
                _db.DbSetEyeColor.Add(eyeColor);
            }
            else
            {
                _db.Entry(current).CurrentValues.SetValues(eyeColor);
            }
            _db.SaveChanges();
            return eyeColor;
        }

        public IEnumerable<EyeColor> Upsert(IEnumerable<EyeColor> item)
        {
            throw new NotImplementedException();
        }
    }
}
