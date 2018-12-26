using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using WebUI.Models;
using ServicePattern;
using Domain;
using Service.Identity;
using static WebUI.Models.AccountViewModels;
using System.IO;

namespace WebUI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        //===========================//
        //--------- MANAGERS ----------
        //===========================//

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private readonly ServiceUser _userService = new ServiceUser();
    
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
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
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }


        //===========================//
        //--------- LOGIN ----------
        //===========================//

        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        public static String UserCoUserName;
        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    { // ModelState.AddModelError("", "Connected.");
                      //return RedirectToLocal(returnUrl);
                      //return View(model);

                        UserCoUserName = model.Username;
                        return RedirectToAction("Index", "Home");
                    }
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }

        //===========================//
        //--------- LOG OUT ---------
        //===========================//

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            UserCoUserName = null;
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }






        //===========================//
        //--------- REGISTER --------
        //===========================//

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
             return View();
            //ViewBag.Roles = new SelectList(db.Roles.Where(a => !a.Name.Contains("Admins")).ToList(), "Name", "Name");
            //return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(AccountViewModels.RegisterViewModel model, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {

                IdentityResult result;
                model.ImageName = Image.FileName;


                // Switch on Selected Account type
                switch (model.AccountType)
                {
                    // Volunteer Account type selected:
                    case EAccountType.Patient:
                        {
                            // create new volunteer and map form values to the instance

                            Patient v = new Patient {
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

                            //v.Roles.Add();
                            if (v.ImageName == null) { v.ImageName = "default-user-image.png"; }                      

                            var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image.FileName);
                            Image.SaveAs(path);


                            result = await UserManager.CreateAsync(v, model.Password);
                           
                            // Add volunteer role to the new User
                            if (result.Succeeded)
                            {
                                // UserManager.AddToRole(v.Id, EAccountType.Patient.ToString());
                                await SignInManager.SignInAsync(v, isPersistent: false, rememberBrowser: false);
                                // Email confirmation here

                                UserCoUserName = null;
                                return RedirectToAction("Index", "Home");
                            }
                            AddErrors(result);
                        }
                        break;

                    // Ngo Account type selected:
                    case EAccountType.Doctor:
                        {
                            // create new Ngo and map form values to the instance

                            Doctor ngo = new Doctor {
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
                            if (ngo.ImageName == null) { ngo.ImageName = "default-user-image.png"; }

                            var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image.FileName);
                            Image.SaveAs(path);

                            result = await UserManager.CreateAsync(ngo, model.Password);
                           

                            // Add Ngo role to the new User
                            if (result.Succeeded)
                            {
                                //     UserManager.AddToRole(ngo.Id, EAccountType.Doctor.ToString());
                                await SignInManager.SignInAsync(ngo, isPersistent: false, rememberBrowser: false);
                                UserCoUserName = ngo.UserName;
                                return RedirectToAction("Index", "Home");
                            }
                            // AddErrors(result);
                        }
                        break;
                }

            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        //===========================//
        //--------- HELPERS ---------
        //===========================//


        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        // FOR REFERENCE
        // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
        // Send an email with this link
        // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
        // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
        // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");



        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        //
        //// POST: /Account/ForgotPassword
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = await UserManager.FindByNameAsync(model.Email);
        //        if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
        //        {
        //            // Don't reveal that the user does not exist or is not confirmed
        //            return View("ForgotPasswordConfirmation");
        //        }

        //        // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
        //        // Send an email with this link
        //        // string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
        //        // var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);		
        //        // await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
        //        // return RedirectToAction("ForgotPasswordConfirmation", "Account");
        //    }

        //    // If we got this far, something failed, redisplay form
        //    return View(model);





        }
    }
