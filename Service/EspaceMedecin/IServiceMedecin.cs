using Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.EspaceMedecin
{
    public interface IServiceMedecin : IService<Doctor>
    {
        IEnumerable<Doctor> getDoctorByUserName(string username);
        IEnumerable<Doctor> getDoctorById(string id);
        //void editDoctor(Doctor d);
    }
}
