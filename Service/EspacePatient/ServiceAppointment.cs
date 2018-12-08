using Data.Infrastructure;
using Domain;
using Infrastructure;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.EspacePatient
{
    public class ServiceAppointment : Service<Appointment>,IServiceAppointment
    {
        static IDatabaseFactory dbf = new DatabaseFactory();

        static IUnitOfWork uof = new UnitOfWork(dbf);

        public ServiceAppointment():base(uof)
        {

        }
        public List<User> GetUsers()
        {

            return dbf.DataContext.Users.ToList();
        }
        public virtual void AddAppointment(Appointment ap)
        {
            ap.AppointmentState = StateEnum.In_Progress;
            ////_repository.Add(entity);
            uof.getRepository<Appointment>().Add(ap);
        }

    }
}
