using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{

    public enum SpecialityEnum
    {
        Cardiologist,
        Dentist,
        Dermatologist,
        Gastroenterologist,
        General,
        Gynecologist,
        Pediatrician,
        Therapist
    };
    public class Doctor : User
    {
        public SpecialityEnum Speciality { get; set; }
        public virtual ICollection<MedicalPath> MedicalPaths { get; set; }
        public virtual ICollection<Chat> Conversations { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
