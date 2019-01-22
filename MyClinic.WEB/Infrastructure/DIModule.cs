using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using MyClinic.Logic.Services;
using MyClinic.Logic.Interfaces;

namespace MyClinic.WEB.Infrastructure
{
    public class DIModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDoctorService>().To<DoctorService>();
        }
    }
}