﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyClinic.Logic.Interfaces;
using MyClinic.Logic.DTO;
using MyClinic.WEB.Models;

namespace MyClinic.WEB.Controllers
{
    public class SignController : Controller
    {
        IDoctorService DoctorRepository;

        public SignController(IDoctorService docrepo)
        {
            DoctorRepository = docrepo;
        }

        public ActionResult Index()
        {
            List<DoctorViewModel> viewlist = new List<DoctorViewModel>();

            IEnumerable<DoctorDTO> doctors = DoctorRepository.GetAll();

            foreach (var doc in doctors)
            {
                List<ReceiptTimeViewModel> timelist = new List<ReceiptTimeViewModel>();

                foreach (var time in doc.Times)
                {
                    timelist.Add(new ReceiptTimeViewModel { ReceiptTime = time.ReceiptTime });
                }

                viewlist.Add(new DoctorViewModel { Id = doc.Id, FirstName = doc.FirstName, LastName = doc.LastName, Times = timelist });
            }
            return View(viewlist);
        }

        public PartialViewResult GetSchedule(int docid)
        {
            var schedule = DoctorRepository.GetScheduleForDoctor(docid);
            List<ScheduleViewModel> models = new List<ScheduleViewModel>();
            
            foreach(var item in schedule)
            {
                models.Add(new ScheduleViewModel {DoctorId = item.DoctorId, Date = item.Date, Times = item.Times });
            }         
              
            return PartialView(models);
        }
    }
}