using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class MedicalOffice
    {
        [Key]
        public int OfficeId { get; set; }
        public string NameOffice { get; set; }
        public DateTime CreationDate { get; set; }
        public string Doctor_Id { get; set; }
        [ForeignKey("Doctor_Id")]
        public virtual Doctor Doctor { get; set; }

    }
}
