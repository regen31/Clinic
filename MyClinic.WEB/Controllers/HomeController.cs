using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyClinic.Logic.Interfaces;
using MyClinic.Logic.DTO;
using MyClinic.WEB.Models;

namespace MyClinic.WEB.Controllers
{
    public class HomeController : Controller
    {
        IDoctorService DoctorRepository;
        
        public HomeController(IDoctorService docrepo)
        {
            DoctorRepository = docrepo;
        }

        public ActionResult Index()
        {            
            return View();
        }
    }
}