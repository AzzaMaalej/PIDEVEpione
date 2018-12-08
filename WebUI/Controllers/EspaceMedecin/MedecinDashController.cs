using Data;
using Domain;
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
    public class MedecinDashController : Controller
    {
        ServiceMedecin sm = new ServiceMedecin();
        // GET: MedecinDash
        public ActionResult DashboardMedecin()
        {
            var medecin = sm.getDoctorByUserName(AccountController.UserCoUserName);

            return View(medecin);

        }
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
                return RedirectToAction("Index","Home");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(String id)
        {
            var doctor = sm.GetById(id);
            return View(doctor);
        }
        PiContext pi = new PiContext();

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
                d.UserName = d.UserName;
                d.FirstName = d.FirstName;
                d.LastName = d.LastName;
                d.Gender = d.Gender;
                d.Speciality = d.Speciality;
                d.BirthDate = d.BirthDate;
                d.Address = d.Address;
                d.Email = d.Email;
                d.PhoneNumber = d.PhoneNumber;
                pi.Entry(d).State = EntityState.Modified;
                pi.SaveChanges();
               
                return RedirectToAction("DashboardMedecin");
            }
            //  return RedirectToAction("Index");


            return View(d);

        }

    }
}