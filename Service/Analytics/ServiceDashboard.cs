using Data.Infrastructure;
using Domain;
using Infrastructure;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Analytics
{
    public class ServiceDashboard : Service<Doctor>, IServiceDashboard
    {
        static IDatabaseFactory dbf = new DatabaseFactory();

        static IUnitOfWork uow = new UnitOfWork(dbf);

        public ServiceDashboard() : base(uow)
        {
        }

        public Doctor getDoctorByName(string name)
        {

            return Get(a => a.UserName == name);
        }
    }
}
