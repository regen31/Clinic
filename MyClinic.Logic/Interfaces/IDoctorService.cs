using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClinic.Logic.DTO;

namespace MyClinic.Logic.Interfaces
{
    public interface IDoctorService
    {
        IEnumerable<DoctorDTO> GetAll();
    }
}
