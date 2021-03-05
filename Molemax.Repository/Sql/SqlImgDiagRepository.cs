using Microsoft.EntityFrameworkCore;
using Molemax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molemax.Repository.Sql
{
    public class SqlImgDiagRepository : IRepository<ImgDiag>
    {
        private readonly MolemaxContext _db;
        public DbSet<ImgDiag> Table { get { return _db.DbSetImgDiag; } }

        public SqlImgDiagRepository(MolemaxContext db)
        {
            _db = db;
        }

        public void Delete(int id)
        {
            var imgDiag = _db.DbSetImgDiag.FirstOrDefault(e => e.id == id);
            if (null != imgDiag)
            {
                _db.DbSetImgDiag.Remove(imgDiag);
                _db.SaveChanges();
            }
        }

        public IEnumerable<ImgDiag> Get()
        {
            return _db.DbSetImgDiag.ToList();
        }

        public ImgDiag Get(int id)
        {
            return _db.DbSetImgDiag.FirstOrDefault(e => e.id == id);
        }


        public ImgDiag Upsert(ImgDiag imgDiag)
        {
            var current = _db.DbSetImgDiag.FirstOrDefault(e => e.id == imgDiag.id);
            if (null == current)
            {
                _db.DbSetImgDiag.Add(imgDiag);
            }
            else
            {
                _db.Entry(current).CurrentValues.SetValues(imgDiag);
            }
            _db.SaveChanges();
            return imgDiag;
        }

        public IEnumerable<ImgDiag> Upsert(IEnumerable<ImgDiag> item)
        {
            throw new NotImplementedException();
        }
    }
}
