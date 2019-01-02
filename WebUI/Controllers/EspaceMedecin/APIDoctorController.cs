using Data;
using Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Service.EspaceMedecin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Mvc;

namespace WebUI.Controllers.EspaceMedecin
{
    public class APIDoctorController : Controller
    {
        // GET: APIDoctor

        ServiceMedecin ds = new ServiceMedecin();

            PiContext db = new PiContext();
       
        public ActionResult GetDoctors()
        {
            IList<Doctor> lcm = new List<Doctor>();
            foreach (var item in ds.GetMany())
            {
                Doctor cm = new Doctor();
                cm.Id = item.Id;
                cm.LastName = item.LastName;
                cm.FirstName = item.FirstName;
                cm.UserName = item.UserName;
                cm.Email = item.Email;
                cm.PhoneNumber = item.PhoneNumber;
                cm.UserName = item.UserName;
                cm.BirthDate = item.BirthDate;
                cm.Gender = item.Gender;
                cm.Address = item.Address;
                cm.ImageName = item.ImageName;
                cm.Speciality = item.Speciality;
                
                lcm.Add(cm);
               
            }
           
            return Json(lcm, JsonRequestBehavior.AllowGet);


        }
     
        public ActionResult DoctorDetails(String id)
        {
            Doctor sk = ds.GetById(id);
            IList<Doctor> lcm = new List<Doctor>();
            lcm.Add(sk);

            //  var sk = ds.GetById(id);
            return Json(lcm, JsonRequestBehavior.AllowGet);

        }

       
        public ActionResult DoctorSearch(string SearchString)
        {         
            IList<Doctor> lcm = new List<Doctor>();
            foreach (var item in ds.GetMany(p => p.Address.Contains(SearchString)))
            {
                Doctor cm = new Doctor();
                cm.Id = item.Id;
                cm.LastName = item.LastName;
                cm.FirstName = item.FirstName;
                cm.UserName = item.UserName;
                cm.Email = item.Email;
                cm.PhoneNumber = item.PhoneNumber;
                cm.UserName = item.UserName;             
                cm.Gender = item.Gender;
                cm.Address = item.Address;
                cm.ImageName = item.ImageName;
                lcm.Add(cm);
            }

            return Json(lcm);

        }

        ServiceDisponibility sd = new ServiceDisponibility();
       
        public ActionResult ViewDispo(String id)
        {
            
            IList<Disponibility> lcm = new List<Disponibility>();
            foreach (var item in sd.geDispoByDoctorId(id))
            {
                Disponibility cm = new Disponibility();
                cm.Description = item.Description;
                cm.StartDate = item.StartDate;
                cm.EndDate = item.EndDate;
                cm.Doctor = item.Doctor;
                lcm.Add(cm);
            }
            return Json(lcm);
        }

        //[Route("api/doctorsList")]
        //    [HttpGet]
        //    public IHttpActionResult Index()
        //    {

        //        //var sk = ds.GetMany();
        //    IList<Doctor> lcm = new List<Doctor>();
        //    foreach (var item in ds.GetMany())
        //    {
        //        Doctor cm = new Doctor();
        //        cm.Id = item.Id;
        //        cm.FirstName = item.FirstName;
        //        cm.Email = item.Email;
        //        cm.PhoneNumber = item.PhoneNumber;
        //        cm.UserName = item.UserName;
        //        cm.BirthDate = item.BirthDate;
        //        cm.Gender = item.Gender;
        //        cm.Address = item.Address;
        //        cm.ImageName = item.ImageName;
        //        lcm.Add(cm);
        //    }
        //    return Ok(lcm);
        //  //  return Json(sk);
        //}

        //    [Route("api/docteurDetails/{id}")]
        //    [HttpGet]
        //    public IHttpActionResult Details(String id)
        //    {
        //    Doctor sk = ds.GetById(id);

        //        //  var sk = ds.GetById(id);
        //        return Ok(sk);

        //    }

        //    [Route("api/doctorDel/{id}")]
        //    [HttpPost]
        //    public IHttpActionResult Delete(String id, Doctor d)
        //    {

        //        var req = ds.GetMany().Where(a => a.Id.Equals(id)).FirstOrDefault();
        //        ds.Delete(req);
        //        ds.Commit();
        //        return Ok();
        //    }

        //    [Route("api/doctorSearch/{SearchString}")]
        //    [HttpPost]
        //    public IHttpActionResult Index(string SearchString)
        //    {

        //        var medecin2 = ds.GetMany(p => p.Address.Contains(SearchString));
        //        return Ok(medecin2);
        //    }
        //ServiceDisponibility sd = new ServiceDisponibility();
        //[Route("api/dispoByDoctor/{id}")]
        //[HttpPost]
        //public IHttpActionResult ViewDispo(String id)
        //{
        //    var dispo = sd.geDispoByDoctorId(id);

        //    return Ok(dispo);
        //}

        //[Route("api/docteurDash")]
        //[HttpGet]
        //public IHttpActionResult DashboardMedecin()
        //{
        //    var medecin = ds.getDoctorByUserName(AccountController.UserCoUserName);

        //    return Ok(medecin);

        //}
        //PiContext pi = new PiContext();



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

