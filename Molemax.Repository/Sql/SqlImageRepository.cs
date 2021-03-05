using Microsoft.EntityFrameworkCore;
using Molemax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molemax.Repository.Sql
{
    public class SqlImageRepository : IRepository<Image>
    {
        private readonly MolemaxContext _db;
        public DbSet<Image> Table { get { return _db.DbSetImages; } }

        public SqlImageRepository(MolemaxContext db)
        {
            _db = db;
        }

        public void Delete(int id)
        {
            var image = _db.DbSetImages.FirstOrDefault(e => e.id == id);
            if (null != image)
            {
                _db.DbSetImages.Remove(image);
                _db.SaveChanges();
            }
        }

        public IEnumerable<Image> Get()
        {
            return _db.DbSetImages.ToList();
        }

        public Image Get(int id)
        {
            return _db.DbSetImages.FirstOrDefault(e => e.id == id);
        }


        public Image Upsert(Image image)
        {
            var current = _db.DbSetImages.FirstOrDefault(e => e.id == image.id);
            if (null == current)
            {
                _db.DbSetImages.Add(image);
            }
            else
            {
                _db.Entry(current).CurrentValues.SetValues(image);
            }
            _db.SaveChanges();
            return image;
        }

        public IEnumerable<Image> Upsert(IEnumerable<Image> item)
        {
            throw new NotImplementedException();
        }
    }
}
