using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Chat
    {

        public int ChatId { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual Doctor Doctor { get; set; }
        [ForeignKey("Doctor")]
        public string DoctorId { get; set; }
        public virtual Patient Patient { get; set; }
        [ForeignKey("Patient")]
        public string PatientId { get; set; }

    }
}
