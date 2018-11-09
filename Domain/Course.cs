using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Course
    {
       // [Key]
       // [ForeignKey("Patient")]
        public int CourseId { get; set; }
        //public ICollection<Appointment> Visits { get; set; }
        //   public virtual Patient patient { get; set; }
        // public virtual Patient Patient { get; set; }
        // [Key]
        // [ForeignKey("Patient")]
        //public virtual Patient patient { get; set; }
    }
}
