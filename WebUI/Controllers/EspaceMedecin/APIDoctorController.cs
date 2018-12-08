using Data;
using Domain;
using Service.EspaceMedecin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebUI.Controllers.EspaceMedecin
{
    public class APIDoctorController : ApiController
    {
        // GET: APIDoctor

        ServiceMedecin ds = new ServiceMedecin();

            PiContext db = new PiContext();
           

            [Route("api/doctorsList")]
            [HttpGet]
            public IHttpActionResult Index()
            {
              
                var sk = ds.GetMany();
                return Ok(sk);
            }

            [Route("api/docteurDetails/{id}")]
            [HttpGet]
            public IHttpActionResult Details(String id)
            {
            Doctor sk = ds.GetById(id);
                //  var sk = ds.GetById(id);
                return Ok(sk);

            }

            [Route("api/doctorDel/{id}")]
            [HttpPost]
            public IHttpActionResult Delete(String id, Doctor d)
            {

                var req = ds.GetMany().Where(a => a.Id.Equals(id)).FirstOrDefault();
                ds.Delete(req);
                ds.Commit();
                return Ok();
            }

            [Route("api/doctorSearch/{SearchString}")]
            [HttpPost]
            public IHttpActionResult Index(string SearchString)
            {
            
                var medecin2 = ds.GetMany(p => p.Address.Contains(SearchString));
                return Ok(medecin2);
            }
        ServiceDisponibility sd = new ServiceDisponibility();
        [Route("api/dispoByDoctor/{id}")]
        [HttpPost]
        public IHttpActionResult ViewDispo(String id)
        {
            var dispo = sd.geDispoByDoctorId(id);

            return Ok(dispo);
        }

        [Route("api/docteurDash")]
        [HttpGet]
        public IHttpActionResult DashboardMedecin()
        {
            var medecin = ds.getDoctorByUserName(AccountController.UserCoUserName);

            return Ok(medecin);

        }
        PiContext pi = new PiContext();
        //[Route("api/docteurDash")]
        //[HttpPost]
        //public IHttpActionResult Edit([System.Web.Mvc.Bind(Include = "Id,Email,SecurityStamp,PhoneNumber, LockoutEndDateUtc,AccessFailedCount,UserName, FirstName,LastName,birthDate,Address,ImageName,Gender,Speciality")] Doctor d, HttpPostedFileBase Image)
        //{

        //    //Doctor do= new Doctor();

        //    // TODO: Add update logic here

        //    if (ModelState.IsValid)
        //    {
        //        String fileName = Path.GetFileName(Image.FileName);
        //        d.ImageName = fileName;
        //        var doctor = ds.GetMany().Single(em => em.Id == d.Id);
        //        d.PasswordHash = doctor.PasswordHash;
        //        d.SecurityStamp = doctor.SecurityStamp;

        //        pi.Entry(d).State = EntityState.Modified;
        //        pi.SaveChanges();

        //        return Ok();
        //    }
        //    //  return RedirectToAction("Index");


        //    return Ok(d);

        //}
    }
    }

