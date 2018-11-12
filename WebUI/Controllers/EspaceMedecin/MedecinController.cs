using Data;
using Domain;
using Newtonsoft.Json.Linq;
using Service.EspaceMedecin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers.EspaceMedecin
{

    public class MedecinController : Controller

    {
       
        ServiceMedecin sm = new ServiceMedecin();
        
        // GET: Medecin
        public ActionResult Index()
        {
            //var medecin= new IEnumerable<Doctor>();
            if (AccountController.UserCoUserName == null)
            {
               var  medecin2 = sm.GetMany().ToList();
                return View(medecin2);
            }
             var medecin = sm.getDoctorByUserName(AccountController.UserCoUserName);
            //if (medecin.First().ImageName == null)
            //{
            //    medecin.First().ImageName = "default-user-image.png";
            //}
            return View(medecin);
        }

        // GET: Medecin/Details/5
        public ActionResult Details(string id)
        {
            var medecin = sm.GetById(id);
            return View(medecin);
        }

        // GET: Medecin/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Medecin/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Medecin/Edit/5
        public ActionResult Edit(String id)
        {
            var doctor = sm.GetById(id);
            return View(doctor);
        }
        PiContext pi = new PiContext();
        // POST: Medecin/Edit/5
        [HttpPost]

        public ActionResult Edit([Bind(Include = "Id,Email,SecurityStamp,PhoneNumber, LockoutEndDateUtc,AccessFailedCount,UserName, FirstName,LastName,birthDate,Address,ImageName,Gender,Speciality")] Doctor d, HttpPostedFileBase Image)
        {

            //Doctor do= new Doctor();

            // TODO: Add update logic here

            if (ModelState.IsValid)
            {
                String fileName = Path.GetFileName(Image.FileName);
                d.ImageName = fileName;
                var doctor = sm.GetMany().Single(em => em.Id == d.Id);
                d.PasswordHash = doctor.PasswordHash;
                d.SecurityStamp = doctor.SecurityStamp;
               // d.ImageName = Image.FileName;
                pi.Entry(d).State = EntityState.Modified;
                pi.SaveChanges();
                //var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image.FileName);
               // Image.SaveAs(path);

                //  ds.Update(d);
                //  ds.Commit();
                return RedirectToAction("Index");
            }
            //  return RedirectToAction("Index");


            return View(d);

        }

        // GET: Medecin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Medecin/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var req = sm.GetMany().Where(a => a.Id.Equals(id)).FirstOrDefault();
                sm.Delete(req);
                sm.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
