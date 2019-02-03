using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClinic.Domain.Entities;
using MyClinic.Domain.Interfaces;
using MyClinic.Logic.Interfaces;
using MyClinic.Logic.DTO;
using MyClinic.Logic.Classes;


namespace MyClinic.Logic.Services
{
    public class DoctorService : IDoctorService
    {
        IDoctorRepository docrepository;

        public DoctorService(IDoctorRepository repo)
        {
            docrepository = repo;
        }

        public IEnumerable<DoctorDTO> GetAll()
        {
            var doctors = docrepository.GetAll();
            List<DoctorDTO> dtolist = new List<DoctorDTO>();

            foreach(var doc in doctors)
            {
                List<TimeDTO> timedto = new List<TimeDTO>();
                foreach(var time in doc.Times)
                {
                    timedto.Add(new TimeDTO { Id = time.Id, ReceiptTime = time.ReceiptTime });
                }
                dtolist.Add(new DoctorDTO { Id = doc.Id, FirstName = doc.FirstName, LastName = doc.LastName, Times = timedto });
            }

            return dtolist;
        }

        public IEnumerable<ScheduleForDate> GetScheduleForDoctor(int docid)
        {
            List<ScheduleForDate> schedule = new List<ScheduleForDate>();
            DateTime currentdate = DateTime.Now.AddDays(1);
            var doctor = docrepository.GetDoctor(docid);

            while(schedule.Count < 6)
            {
                if(currentdate.DayOfWeek != DayOfWeek.Saturday && currentdate.DayOfWeek != DayOfWeek.Sunday)
                {
                    schedule.Add(new ScheduleForDate {DoctorId = doctor.Id, Date = currentdate, Times = GettingTimes(doctor.Id, currentdate) });                    
                }
                currentdate = currentdate.AddDays(1);
            }

            return schedule;
        }

        private IEnumerable<DateTime> GettingTimes(int docid, DateTime date) 
        {
            var doctor = docrepository.GetDoctor(docid);
            List<DateTime> timelist = new List<DateTime>();

            foreach(var time in doctor.Times)
            {
                timelist.Add(time.ReceiptTime);
            }
            return timelist;
        }
    }
}
