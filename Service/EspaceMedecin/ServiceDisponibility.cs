using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;
using Domain;
using Infrastructure;

namespace Service.EspaceMedecin
{
    public class ServiceDisponibility : Service<Disponibility>, IServiceDisponibility
    {
        static IDatabaseFactory dbf = new DatabaseFactory();

        static IUnitOfWork utwk = new UnitOfWork(dbf);

       

        public ServiceDisponibility() : base(utwk)
        {
        }

        public IEnumerable<Disponibility> geDispoByDoctorId(string id)
        {
            var req = from Disponibility
                      in GetMany()
                      where Disponibility.DoctorId == id
                      select Disponibility;
            return req;
        }
    }
}
