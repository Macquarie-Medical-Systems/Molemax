using Microsoft.EntityFrameworkCore;
using Molemax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molemax.Repository.Sql
{
    public class SqlExpressImageRepository : IRepository<ExpressImage>
    {
        private readonly MolemaxContext _db;
        public DbSet<ExpressImage> Table { get { return _db.DbSetExpressImage; } }

        public SqlExpressImageRepository(MolemaxContext db)
        {
            _db = db;
        }

        public void Delete(int id)
        {
            var expressImage = _db.DbSetExpressImage.FirstOrDefault(e => e.id == id);
            if (null != expressImage)
            {
                _db.DbSetExpressImage.Remove(expressImage);
                _db.SaveChanges();
            }
        }

        public IEnumerable<ExpressImage> Get()
        {
            return _db.DbSetExpressImage.ToList();
        }

        public ExpressImage Get(int id)
        {
            return _db.DbSetExpressImage.FirstOrDefault(e => e.id == id);
        }


        public ExpressImage Upsert(ExpressImage expressImage)
        {
            var current = _db.DbSetExpressImage.FirstOrDefault(e => e.id == expressImage.id);
            if (null == current)
            {
                _db.DbSetExpressImage.Add(expressImage);
            }
            else
            {
                _db.Entry(current).CurrentValues.SetValues(expressImage);
            }
            _db.SaveChanges();
            return expressImage;
        }

        public IEnumerable<ExpressImage> Upsert(IEnumerable<ExpressImage> expressImages)
        {
            List<ExpressImage> returnList = new List<ExpressImage>();

            if (expressImages != null && expressImages.Count() > 0)
            {
                foreach (var expressImage in expressImages)
                {
                    var current = _db.DbSetExpressImage.FirstOrDefault(e => e.id == expressImage.id);
                    if (null == current)
                    {
                        _db.DbSetExpressImage.Add(expressImage);
                    }
                    else
                    {
                        _db.Entry(current).CurrentValues.SetValues(expressImage);
                    }
                    returnList.Add(expressImage);
                }
                _db.SaveChanges();
            }
            return returnList;
        }
    }
}
