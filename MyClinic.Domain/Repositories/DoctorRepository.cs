using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClinic.Domain.Entities;
using MyClinic.Domain.EFContext;
using MyClinic.Domain.Interfaces;
using System.Data.Entity;

namespace MyClinic.Domain.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private ClinicContext db;

        public DoctorRepository(string ConnectionString)
        {
            db = new ClinicContext(ConnectionString);
        }

        public IEnumerable<Doctor> GetAll()
        {
            return db.Doctors.Include(x => x.Times).ToList();
        }
    }
}
