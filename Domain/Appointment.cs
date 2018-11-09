using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public enum State
    {
        Cancelled,
        Completed,
        In_Progress
    }
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public State AppointmentState { get; set; }
        public virtual Doctor Doctor { get; set; }
        [ForeignKey("Doctor")]
        public string DoctorId { get; set; }
        public virtual Patient Patient { get; set; }
        [ForeignKey("Patient")]
        public string PatientId { get; set; }
    }
}
