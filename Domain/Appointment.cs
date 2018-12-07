using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public enum StateEnum
    {
        Cancelled,
        In_Progress,
        Completed,
        Postponed
    };
    public class Appointment
    {
        public int AppointmentId { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public StateEnum AppointmentState { get; set; }
        public SpecialityEnum Specialities { get; set; }
        
        public virtual Doctor Doctor { get; set; }
        
        public string DoctorId { get; set; }
        public virtual Patient Patient { get; set; }
        
        public string PatientId { get; set; }
    }
}
