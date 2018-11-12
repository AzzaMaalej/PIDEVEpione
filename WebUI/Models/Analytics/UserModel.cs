using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebUI.Models.Analytics
{
    public enum Gender { male, female }

    public enum EAccountType
    {
        Patient,
        Doctor,
        Administrator
    }
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
    }

    public class UserModel : IdentityUser
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public String Address { get; set; }
        public String ImageName { get; set; }
        public Gender? Gender { get; set; }
        public SpecialityEnum Speciality { get; set; }
    }
}