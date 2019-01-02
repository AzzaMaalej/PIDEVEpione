using Domain;
using Microsoft.AspNet.Identity.Owin;
using Service.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using static WebUI.Models.AccountViewModels;

namespace WebUI.Controllers.Users
{
    public class AccountController : ApiController
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // POST: /Account/Login

        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        [ValidateAntiForgeryToken]
        [System.Web.Http.Route("api/Login")]
        public async Task<IHttpActionResult> Login(LoginViewModell model)
        {
            var result = await SignInManager.PasswordSignInAsync(model.Username, model.PasswordHash, model.RememberMe, shouldLockout: false);
            switch (result)
            {

                case SignInStatus.Success:
                    return Ok("ConnexionSuccess");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return Ok("ConnexionFailed");
            }
        }



        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        [ValidateAntiForgeryToken]
        [System.Web.Http.Route("api/Register")]
        public async Task<IHttpActionResult> Register(RegisterViewModell model)
        {
            // return Ok(model.AccountType);
            switch (model.AccountType)
            {

                case EAccountType.Patient:
                    {
                        Patient v = new Patient
                        {
                            UserName = (model.UserName),
                            Email = model.Email,
                            Address = model.Address,
                            FirstName = model.FirstName,
                            LastName = model.LastName,
                            BirthDate = model.BirthDate,
                            ImageName = model.ImageName,
                            PhoneNumber = model.PhoneNumber,
                            Gender = model.Gender,

                        };
                        var results = await UserManager.CreateAsync(v, model.PasswordHash);
                        if (results.Succeeded)
                        {
                            //result = await UserManager.AddToRoleAsync(user.Id, model.Cv);
                            await SignInManager.SignInAsync(v, isPersistent: false, rememberBrowser: false);
                            return Ok("Patient added !");
                        }
                    }
                    break;
                case EAccountType.Doctor:
                    {
                        Doctor res = new Doctor
                        {
                            UserName = model.UserName,
                            Email = model.Email,
                            Address = model.Address,
                            FirstName = model.FirstName,
                            LastName = model.LastName,
                            BirthDate = model.BirthDate,
                            ImageName = model.ImageName,
                            PhoneNumber = model.PhoneNumber,
                            Gender = model.Gender,
                            Speciality = model.Speciality

                        };
                        if (res.ImageName == null) { res.ImageName = "default-user-image.png"; }
                        var results = await UserManager.CreateAsync(res, model.PasswordHash);
                        if (results.Succeeded)
                        {
                            //result = await UserManager.AddToRoleAsync(user.Id, model.Cv);
                            await SignInManager.SignInAsync(res, isPersistent: false, rememberBrowser: false);
                            return Ok("Docteur added !");
                        }

                    }
                    break;
            }

            return Ok("Fail !");

        }

    }
}
