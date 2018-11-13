using Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Analytics
{
    public interface IServiceDashboard2 : IService<Patient>
    {
        IEnumerable<Patient> getAllPatients();
        IEnumerable<Patient> getAllPatientsTreated();
    }
}
