using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Job { get; set; }
        public string Address { get; set; }
        public DateTime HireDate { get; set; }
        public double Salary { get; set; }
        public int Office_Id { get; set; }
        [ForeignKey("Office_Id")]
        public virtual MedicalOffice MedicalOffice { get; set; }


    }
}
