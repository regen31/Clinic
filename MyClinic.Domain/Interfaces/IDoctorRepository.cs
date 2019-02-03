using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClinic.Domain.Entities;
using MyClinic.Domain.Interfaces;

namespace MyClinic.Domain.Interfaces
{
    public interface IDoctorRepository
    {
        IEnumerable<Doctor> GetAll();
        Doctor GetDoctor(int id);
    }
}
