using Microsoft.EntityFrameworkCore;
using Molemax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molemax.Repository.Sql
{
    public class SqlExpertizerABCDRepository : IRepository<ExpertizerABCD>
    {
        private readonly MolemaxContext _db;
        public DbSet<ExpertizerABCD> Table { get { return _db.DbSetExpertizerABCD; } }

        public SqlExpertizerABCDRepository(MolemaxContext db)
        {
            _db = db;
        }

        public void Delete(int id)
        {
            var expertizerABCD = _db.DbSetExpertizerABCD.FirstOrDefault(e => e.ID == id);
            if (null != expertizerABCD)
            {
                _db.DbSetExpertizerABCD.Remove(expertizerABCD);
                _db.SaveChanges();
            }
        }

        public IEnumerable<ExpertizerABCD> Get()
        {
            return _db.DbSetExpertizerABCD.ToList();
        }

        public ExpertizerABCD Get(int id)
        {
            return _db.DbSetExpertizerABCD.FirstOrDefault(e => e.ID == id);
        }


        public ExpertizerABCD Upsert(ExpertizerABCD expertizerABCD)
        {
            var current = _db.DbSetExpertizerABCD.FirstOrDefault(e => e.ID == expertizerABCD.ID);
            if (null == current)
            {
                _db.DbSetExpertizerABCD.Add(expertizerABCD);
            }
            else
            {
                _db.Entry(current).CurrentValues.SetValues(expertizerABCD);
            }
            _db.SaveChanges();
            return expertizerABCD;
        }

        public IEnumerable<ExpertizerABCD> Upsert(IEnumerable<ExpertizerABCD> expertizerABCDs)
        {
            List<ExpertizerABCD> returnList = new List<ExpertizerABCD>();

            if (expertizerABCDs != null && expertizerABCDs.Count() > 0)
            {
                foreach (var expertizerABCD in expertizerABCDs)
                {
                    var current = _db.DbSetExpertizerABCD.FirstOrDefault(e => e.ID == expertizerABCD.ID);
                    if (null == current)
                    {
                        _db.DbSetExpertizerABCD.Add(expertizerABCD);
                    }
                    else
                    {
                        _db.Entry(current).CurrentValues.SetValues(expertizerABCD);
                    }
                    returnList.Add(expertizerABCD);
                }
                _db.SaveChanges();
            }
            return returnList;
        }
    }
}
