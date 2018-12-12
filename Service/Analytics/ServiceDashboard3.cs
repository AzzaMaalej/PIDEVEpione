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
    public class ServiceDashboard3 : Service<Appointment>, IServiceDashboard3
    {
        static IDatabaseFactory dbf = new DatabaseFactory();

        static IUnitOfWork uow = new UnitOfWork(dbf);

        public ServiceDashboard3() : base(uow)
        {
        }

        public IEnumerable<Appointment> getAllAppointments()
        {
            return GetMany();
        }

        public IEnumerable<Appointment> getAllAppointmentsByDoctor(string doctorId)
        {
            return GetMany(a => a.DoctorId == doctorId);
        }
        public IEnumerable<Appointment> getAllAppointmentsCanceledByDoctor(string doctorId)
        {
            return GetMany(a => a.DoctorId == doctorId && a.AppointmentState == StateEnum.Cancelled);
        }
    }
}
