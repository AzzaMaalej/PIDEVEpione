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
        IEnumerable<Patient> getAllPatientsByDoctor(string doctorId);
        IEnumerable<Patient> getAllPatientsTreatedByDoctor(string doctorId);
        IEnumerable<Patient> getAllPatientsNotTreatedByDoctor(string doctorId);
    }
}
