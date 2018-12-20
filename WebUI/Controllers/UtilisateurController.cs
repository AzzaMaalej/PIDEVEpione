using Data;
using Domain;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Service;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using WebUI.Models.Analytics;
using static WebUI.Models.AccountViewModels;
using System.Web;
using Microsoft.Owin.Security;
using WebUI.Models;
using ServicePattern;
using Domain;
using Service.Identity;
using System.IO;

namespace WebUI.Controllers
{
    public class UtilisateurController : Controller
    {

        IServicesUser us = new ServicesUser();


        public ActionResult GetUsers()
        {
            IList<UserModel> lcm = new List<UserModel>();
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

                return Json(lcm, JsonRequestBehavior.AllowGet);


        }


        // GET: /Account/Login
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        public static String UserCoUserName;
        //
        // POST: /Account/Login







    }
}
