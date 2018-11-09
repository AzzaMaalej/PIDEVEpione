using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class MedicalPath
    {
        [Key]
        [ForeignKey("Patient")]
        public string PathId { get; set; }
        public string RecommendedSpeciality { get; set; }
        public int ValidatedSteps { get; set; }
        public string Justification { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
