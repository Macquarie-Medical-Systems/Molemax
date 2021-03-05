using Microsoft.EntityFrameworkCore;
using Molemax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molemax.Repository.Sql
{
    public class SqlPatientRepository : IRepository<Patient>
    {
        private readonly MolemaxContext _db;
        public DbSet<Patient> Table { get { return _db.DbSetPatients; } }

        DbSet<Patient> IRepository<Patient>.Table => throw new NotImplementedException();

        public SqlPatientRepository(MolemaxContext db)
        {
            _db = db;
        }

        public void Delete(int Id)
        {
            var patient = _db.DbSetPatients.FirstOrDefault(e => e.id == Id);
            if (null != patient)
            {
                _db.DbSetPatients.Remove(patient);
                _db.SaveChanges();
            }
        }

        public IEnumerable<Patient> Get()
        {
            return _db.DbSetPatients.ToList();
        }

        public Patient Get(int id)
        {
            return _db.DbSetPatients.FirstOrDefault(e => e.id == id);
        }

        public Patient Upsert(Patient patient)
        {
            var current = _db.DbSetPatients.FirstOrDefault(e => e.id == patient.id);
            if (null == current)
            {
                _db.DbSetPatients.Add(patient);
            }
            else
            {
                _db.Entry(current).CurrentValues.SetValues(patient);
            }
            _db.SaveChanges();
            return patient;
        }

        public IEnumerable<Patient> Upsert(IEnumerable<Patient> item)
        {
            throw new NotImplementedException();
        }

    }
}
