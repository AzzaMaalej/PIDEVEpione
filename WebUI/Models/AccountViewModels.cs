using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class AccountViewModels
    {

        public class RegisterViewModel
        {
            [Required]
            [Display(Name = "Username")]
            public string UserName { get; set; }
            public String FirstName { get; set; }
            public String LastName { get; set; }
            [DataType(DataType.Date)]
            public DateTime BirthDate { get; set; }
            public String Address { get; set; }
            public Gender Gender { get; set; }

            public String ImageName { get; set; }
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
            public string PhoneNumber { get; set; }
            [Required]
            [Display(Name = "Account Type")]
            public EAccountType AccountType { get; set; }
            [Display(Name = "Speciality")]
            public SpecialityEnum Speciality { get; set; }
        }

        public class RegisterViewModell
        {
            [Required]
            [Display(Name = "Username")]
            public string UserName { get; set; }
            public String FirstName { get; set; }
            public String LastName { get; set; }
            [DataType(DataType.Date)]
            public DateTime BirthDate { get; set; }
            public String Address { get; set; }
            public Gender Gender { get; set; }

            public String ImageName { get; set; }
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }
            
            //[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "PasswordHash")]
            public string PasswordHash { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
            public string PhoneNumber { get; set; }
            [Required]
            [Display(Name = "Account Type")]
            public EAccountType AccountType { get; set; }
            [Display(Name = "Speciality")]
            public SpecialityEnum Speciality { get; set; }
            [Display(Name = "AccessFailedCount")]
            public int AccessFailedCount { get; set; }

        }

        public class LoginViewModel
        {
            [Required]
            [Display(Name = "UserName")]
            public string Username { get; set; }

           
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }
        public class LoginViewModell
        {
            [Required]
            [Display(Name = "UserName")]
            public string Username { get; set; }

           
            [DataType(DataType.Password)]
            [Display(Name = "PasswordHash")]
            public string PasswordHash { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }
    }
}
