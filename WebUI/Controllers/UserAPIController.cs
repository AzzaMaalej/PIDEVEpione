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
using WebUI.Models.Analytics;

namespace WebUI.Controllers
{
    public class UserAPIController : ApiController
    {
        IServicesUser us = new ServicesUser();
        UserManager<User, string> _userManager = new UserManager<User, string>(new ApplicationUserStore(new PiContext()));

        // GET: api/UserAPI
        public IHttpActionResult Get()
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
                //cm.Gender = item.Gender.Value.ToString();
                cm.Address = item.Address;
                cm.ImageName = item.ImageName;
                lcm.Add(cm);
            }
            if (lcm.Count == 0)
            {
                return NotFound();
            }

            return Ok(lcm);
        }

        // GET: api/UserAPI/5
        public IHttpActionResult Get(string id)
        {
            User item = us.GetById(id);
            UserModel cm = new UserModel();
            cm.Id = item.Id;
            cm.FirstName = item.FirstName;
            cm.Email = item.Email;
            cm.PhoneNumber = item.PhoneNumber;
            cm.UserName = item.UserName;
            cm.BirthDate = item.BirthDate;
            //cm.Gender = item.Gender.Value.ToString();
            cm.Address = item.Address;
            cm.ImageName = item.ImageName;
            return Ok(cm);
        }

        // POST: api/UserAPI
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/UserAPI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/UserAPI/5
        public void Delete(int id)
        {
        }
    }
}
