using Microsoft.EntityFrameworkCore;
using Molemax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molemax.Repository.Sql
{
    public class SqlUserRepository : IRepository<User>
    {
        private readonly MolemaxContext _db;

        public SqlUserRepository(MolemaxContext db)
        {
            _db = db;
        }

        public DbSet<User> Table { get { return _db.DbSetUsers; } }

        public void Delete(int id)
        {
            var user = _db.DbSetUsers.FirstOrDefault(e => e.id == id);
            if (null != user)
            {
                _db.DbSetUsers.Remove(user);
                _db.SaveChanges();
            }
        }

        public IEnumerable<User> Get()
        {
            return _db.DbSetUsers.ToList();
        }

        public User Get(int id)
        {
            return _db.DbSetUsers.FirstOrDefault(e => e.id == id);
        }


        public User Upsert(User user)
        {
            var current = _db.DbSetUsers.FirstOrDefault(e => e.id == user.id);
            if (null == current)
            {
                _db.DbSetUsers.Add(user);
            }
            else
            {
                _db.Entry(current).CurrentValues.SetValues(user);
            }
            _db.SaveChanges();
            return user;
        }

        public IEnumerable<User> Upsert(IEnumerable<User> item)
        {
            throw new NotImplementedException();
        }
    }
}
