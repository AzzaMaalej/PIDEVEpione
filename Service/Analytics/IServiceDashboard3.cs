using Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Analytics
{
    public interface IServiceDashboard3 : IService<Appointment>
    {
        IEnumerable<Appointment> getAllAppointments();
        IEnumerable<Appointment> getAllAppointmentsByDoctor(string doctorId);
    }
}
