using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MyClinic.Domain.Entities;
using MyClinic.Domain.EFContext;


namespace MyClinic.Domain
{
    public class ClinicContext : DbContext
    {
        public ClinicContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer<ClinicContext>(new DBInitializer());
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Time> Times { get; set; }
    }
}
