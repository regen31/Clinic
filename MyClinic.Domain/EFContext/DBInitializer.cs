using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MyClinic.Domain.Entities;

namespace MyClinic.Domain.EFContext
{
    class DBInitializer : DropCreateDatabaseAlways<ClinicContext>
    {
        protected override void Seed(ClinicContext context)
        {

            Doctor d1 = new Doctor() { FirstName = "Иван", LastName = "Иванов", };
            Doctor d2 = new Doctor() { FirstName = "Петр", LastName = "Петров", };
            Doctor d3 = new Doctor() { FirstName = "Павел", LastName = "Павлов", };           

            Time t1 = new Time { ReceiptTime = new DateTime (2019, 1, 19, 11, 0, 0), Doctor = d1 };
            Time t2 = new Time { ReceiptTime = new DateTime(2019, 1, 19, 11, 0, 0), Doctor = d1 };
            Time t3 = new Time { ReceiptTime = new DateTime(2019, 1, 19, 11, 0, 0), Doctor = d2 };
            Time t4 = new Time { ReceiptTime = new DateTime(2019, 1, 19, 11, 0, 0), Doctor = d3 };

            context.Doctors.Add(d1);
            context.Doctors.Add(d2);
            context.Doctors.Add(d3);
            context.Times.Add(t1);
            context.Times.Add(t2);
            context.Times.Add(t3);
            context.Times.Add(t4);

            context.SaveChanges();
        }
    }
}
