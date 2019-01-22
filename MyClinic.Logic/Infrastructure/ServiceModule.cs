using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using MyClinic.Domain.Interfaces;
using MyClinic.Domain.Repositories;

namespace MyClinic.Logic.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private string connectionString;

        public ServiceModule(string connection)
        {
            connectionString = connection;
        }
        public override void Load()
        {
            Bind<IDoctorRepository>().To<DoctorRepository>().WithConstructorArgument(connectionString);            
        }
    }
}
