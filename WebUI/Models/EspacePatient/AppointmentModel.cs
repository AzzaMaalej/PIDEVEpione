using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Models.EspacePatient
{
   
    public class AppointmentModel
    {
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string Location { get; set; }
        [Column(TypeName = "nvarchar(24)")]
        public SpecialityEnum Specialities { get; set; }
        //[Column(TypeName = "nvarchar(24)")]
        //public State AppointmentState { get; set; }
        public virtual Patient Patient { get; set; }
        [ForeignKey("Patient")]
        public string PatientId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public int? DoctorId { get; set; }
        public IEnumerable<SelectListItem> Doctors { get; set; }
       

    }
}