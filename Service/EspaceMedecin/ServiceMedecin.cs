using Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;
using Infrastructure;

namespace Service.EspaceMedecin
{
    public class ServiceMedecin : Service<Doctor>, IServiceMedecin
    {
        static IDatabaseFactory dbf = new DatabaseFactory();

        static IUnitOfWork uow = new UnitOfWork(dbf);
        public ServiceMedecin() : base(uow)
        {
        }

       

        public IEnumerable<Doctor> getDoctorById(string id)
        {
            var req = from Doctor
                        in GetMany()
                      where Doctor.Id == id
                      select Doctor;
            return req;
        }

        public IEnumerable<Doctor> getDoctorByUserName(string username)
        {
            var req = from Doctor
                        in GetMany()
                      where Doctor.UserName == username
                      select Doctor;
            return req;
        }
    }
}
