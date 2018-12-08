using Data;
using Domain;
using Microsoft.AspNet.Identity;
using Service;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using WebUI.Models.Analytics;

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


        //public UtilisateurController() { }
        //IServicesUser us = new ServicesUser();
        //UserManager<User, string> _userManager = new UserManager<User, string>(new ApplicationUserStore(new PiContext()));

        //[Route("api/useradd")]
        //[HttpPost]
        //public IHttpActionResult Create(UserModel clt)
        //{
        //    User c = new User();
        //    c.FirstName = clt.FirstName;

        //    c.PhoneNumber = clt.PhoneNumber;
        //    //c.StreetName = clt.StreetName;
        //    //c.City = clt.City;
        //    //c.Country = clt.Country;
        //    //c.Type = clt.Type;
        //    //c.Categorie = clt.Categorie;
        //    //c.Logo = "Client.jpg";
        //    //c.role = "Client";

        //    //var mp = RandomStringGenerator();
        //    //c.password = mp;
        //    //c.PasswordHash = _userManager.PasswordHasher.HashPassword(mp);
        //    //c.LockoutEnabled = true;
        //    //c.SecurityStamp = Guid.NewGuid().ToString();
        //    ///****Mail****/
        //    //try
        //    //{
        //    //    MailMessage message = new MailMessage("maryemboujmil@gmail.com", clt.Email, "Hello", "Compte créé votre mail est : " + clt.Email + ", Votre mp est: " + mp);
        //    //    message.IsBodyHtml = true;
        //    //    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
        //    //    client.EnableSsl = true;
        //    //    client.Credentials = new System.Net.NetworkCredential("maryemboujmil@gmail.com", "0720MB2326");
        //    //    client.Send(message);
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    Console.WriteLine(ex.StackTrace);
        //    //}

        //    /****Mail****/

        //    us.Add(c);
        //    us.Commit();
        //    return Ok();

        //}

        //[Route("api/utilisateur")]
        //[HttpGet]
        //public IHttpActionResult getAllUsers()
        //{
        //    IList<UserModel> lcm = new List<UserModel>();
        //    foreach (var item in us.getAll())
        //    {
        //        UserModel cm = new UserModel();
        //        cm.Id = item.Id;
        //        cm.FirstName = item.FirstName;
        //        cm.Email = item.Email;
        //        cm.PhoneNumber = item.PhoneNumber;
        //        cm.UserName = item.UserName;
        //        cm.BirthDate = item.BirthDate;
        //        cm.Gender = item.Gender.Value.ToString();
        //        cm.Address = item.Address;
        //        cm.ImageName = item.ImageName;
        //        lcm.Add(cm);
        //    }
        //    if (lcm.Count == 0)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(lcm);
        //}
    }
}
