using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyClinic.WEB.Models
{
    public class ScheduleViewModel
    {
        public int DoctorId { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<DateTime> Times { get; set; }
    }
}