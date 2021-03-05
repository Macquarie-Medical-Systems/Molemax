using Microsoft.EntityFrameworkCore;
using Molemax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molemax.Repository.Sql
{
    public class SqlSkinColorRepository : IRepository<SkinColor>
    {
        private readonly MolemaxContext _db;
        public DbSet<SkinColor> Table { get { return _db.DbSetSkinColor; } }

        public SqlSkinColorRepository(MolemaxContext db)
        {
            _db = db;
        }

        public void Delete(int id)
        {
            var skinColor = _db.DbSetSkinColor.FirstOrDefault(e => e.ID == id);
            if (null != skinColor)
            {
                _db.DbSetSkinColor.Remove(skinColor);
                _db.SaveChanges();
            }
        }

        public IEnumerable<SkinColor> Get()
        {
            return _db.DbSetSkinColor.ToList();
        }

        public SkinColor Get(int id)
        {
            return _db.DbSetSkinColor.FirstOrDefault(e => e.ID == id);
        }


        public SkinColor Upsert(SkinColor skinColor)
        {
            var current = _db.DbSetSkinColor.FirstOrDefault(e => e.ID == skinColor.ID);
            if (null == current)
            {
                _db.DbSetSkinColor.Add(skinColor);
            }
            else
            {
                _db.Entry(current).CurrentValues.SetValues(skinColor);
            }
            _db.SaveChanges();
            return skinColor;
        }

        public IEnumerable<SkinColor> Upsert(IEnumerable<SkinColor> item)
        {
            throw new NotImplementedException();
        }
    }
}
