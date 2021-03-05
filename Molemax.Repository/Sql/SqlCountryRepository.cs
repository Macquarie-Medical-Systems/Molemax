using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Molemax.Models;

namespace Molemax.Repository.Sql
{
    public class SqlCountryRepository : IRepository<Country>
    {
        private readonly MolemaxContext _db;
        public DbSet<Country> Table { get { return _db.DbSetCountry; } }

        public SqlCountryRepository(MolemaxContext db)
        {
            _db = db;
        }

        public void Delete(int id)
        {
            var country = _db.DbSetCountry.FirstOrDefault(e => e.ID == id);
            if (null != country)
            {
                _db.DbSetCountry.Remove(country);
                _db.SaveChanges();
            }
        }

        public IEnumerable<Country> Get()
        {
            return _db.DbSetCountry.ToList();
        }

        public Country Get(int id)
        {
            return _db.DbSetCountry.FirstOrDefault(e => e.ID == id);
        }


        public Country Upsert(Country country)
        {
            var current = _db.DbSetCountry.FirstOrDefault(e => e.ID == country.ID);
            if (null == current)
            {
                _db.DbSetCountry.Add(country);
            }
            else
            {
                _db.Entry(current).CurrentValues.SetValues(country);
            }
            _db.SaveChanges();
            return country;
        }

        public IEnumerable<Country> Upsert(IEnumerable<Country> item)
        {
            throw new System.NotImplementedException();
        }
    }
}
