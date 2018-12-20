using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class MedicalCare
    {
        [Key]
        public int CareId { get; set; }
        public string CareName { get; set; }
        public DateTime CareDate { get; set; }
        public double Price { get; set; }
        public string Doctor_Id { get; set; }
        [ForeignKey("Doctor_Id")]
        public virtual Doctor Doctor { get; set; }
        public string Patient_Id { get; set; }
        [ForeignKey("Patient_Id")]
        public virtual Patient Patient { get; set; }
    }
}
