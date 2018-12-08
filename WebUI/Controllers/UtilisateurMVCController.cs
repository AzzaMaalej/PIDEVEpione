using Data;
using Domain;
using Microsoft.AspNet.Identity;
using Service;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebUI.Models.Analytics;

namespace WebUI.Controllers
{
    public class UtilisateurMVCController : Controller
    {

        IServicesUser us = new ServicesUser();
        UserManager<User, string> _userManager = new UserManager<User, string>(new ApplicationUserStore(new PiContext()));
        // GET: UtilisateurMVC
        public ActionResult getUsers()
        {
            List<UserModel> lcm = new List<UserModel>();
            foreach (var item in us.getAll())
            {
                UserModel cm = new UserModel();
                cm.Id = item.Id;
                cm.FirstName = item.FirstName;
                cm.Email = item.Email;
                cm.PhoneNumber = item.PhoneNumber;
                cm.UserName = item.UserName;
                cm.BirthDate = item.BirthDate;
                cm.Gender = item.Gender.Value.ToString();
                cm.Address = item.Address;
                cm.ImageName = item.ImageName;
                lcm.Add(cm);
            }
            return View(lcm);
        }
    }
}