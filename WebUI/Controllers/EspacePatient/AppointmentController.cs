using Service.EspacePatient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServicePattern;
using WebUI.Models.EspacePatient;

using Data;
using System.Data.Entity;
using Domain;
using Microsoft.AspNet.Identity;

namespace WebUI.Controllers.EspacePatient
{
    //[Authorize]
    public class AppointmentController : Controller
    {
        ServiceAppointment SA = new ServiceAppointment();


        public ActionResult IndexWS()
        { return View(SA.GetAll());
        }
        // GET: Appointment
        public ActionResult Index()
        {
            var Appointments = SA.GetMany();
           
            return View(Appointments);
        }
        [HttpPost]
        public ActionResult Index(DateTime SearchDate)
        {
            var AppointmentsSearched = SA.GetMany(a => a.Date == SearchDate);
           
            return View(AppointmentsSearched);
        }

        // GET: Appointment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Appointment/Create
        public ActionResult Create()
        {
            AppointmentModel ap = new AppointmentModel();
            ap.Doctors = SA.GetMany().
                Select(c => new SelectListItem
                {
                    Text = c.Doctor.UserName,
                    Value = c.DoctorId
                });
            

            return View(ap);
        }

        // POST: Appointment/Create
        [HttpPost]
        public ActionResult Create(AppointmentModel am)
        {
            
            String currentUserId = User.Identity.GetUserId();
            List<User> GetUsers = SA.GetUsers();
            var user = GetUsers.FirstOrDefault(u => u.Id == currentUserId);
            try
            {
                Appointment a = new Appointment()
                {
                   
                    Specialities = am.Specialities,
                    Date = am.Date,
                    Location = am.Location,
                    DoctorId = am.Doctor.Id,
                    PatientId = currentUserId};
                SA.AddAppointment(a);
                SA.Commit();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Appointment/Edit/5
        public ActionResult Edit(int id)
        {
            var appointment = SA.GetById(id);
            return View(appointment);
            
        }
        PiContext pi = new PiContext();
        // POST: Appointment/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "AppointmentId,Date,Location,AppointmentState, Doctor,DoctorId,Patient, PatientId")]  Appointment ap)
        {
            if (ModelState.IsValid)
            {
                var appointment = SA.GetMany().Single(a => a.AppointmentId == ap.AppointmentId);
                ap.AppointmentState = appointment.AppointmentState;
                ap.Date = appointment.Date;
                ap.Location = ap.Location;
                ap.Doctor = ap.Doctor;
                pi.Entry(ap).State = EntityState.Modified;
                pi.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ap);
           
        }

        // GET: Appointment/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Appointment/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Appointment ap)
        {
            try
            {
                var req = SA.GetMany().Where(a => a.AppointmentId.Equals(id)).FirstOrDefault();
                SA.Delete(req);
                SA.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
