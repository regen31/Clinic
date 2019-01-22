﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClinic.Domain.Entities;
using MyClinic.Domain.Interfaces;
using MyClinic.Logic.Interfaces;
using MyClinic.Logic.DTO;

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
    }
}