using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyClinic.Logic.Classes
{
    public class ScheduleForDate
    {
        public int DoctorId { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<DateTime> Times { get; set; }
    }
}
