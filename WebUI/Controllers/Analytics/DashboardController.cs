using Service.Analytics;
using Service.EspaceMedecin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers.Analytics
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        IServiceDashboard sd = new ServiceDashboard();
        IServiceDashboard2 sd2 = new ServiceDashboard2();
        IServiceDashboard3 sd3 = new ServiceDashboard3();

        // GET: Index
        public ActionResult Index()
        {
            var medecin = sd.getDoctorByName(AccountController.UserCoUserName);
            var listAppointments = sd3.getAllAppointmentsByDoctor(medecin.Id);
            List<string> nberAppointments = new List<string>();
            var appointment_states = listAppointments.Select(a => a.AppointmentState).Distinct();
            var appointment_statesInString = new List<string>();
            foreach (var item in appointment_states)
            {
                appointment_statesInString.Add(item.ToString());
            }

            foreach (var item in appointment_states)
            {
                nberAppointments.Add(((listAppointments.Count(x => x.AppointmentState == item))*100/listAppointments.Count()).ToString()+"%");
            }

            var finalRepartitionsByAppointment = nberAppointments;
            ViewBag.STATES = appointment_statesInString;
            ViewBag.REPARTITIONS = finalRepartitionsByAppointment.ToList();
            return View(medecin);
        }

        public ActionResult PatientTreated()
        {
            var listAppointments = sd3.getAllAppointments();
            List<int> nberAppointments = new List<int>();
            var appointment_states = listAppointments.Select(a => a.AppointmentState).Distinct();
            var appointment_statesInString = new List<string>();
            foreach (var item in appointment_states)
            {
                appointment_statesInString.Add(item.ToString());
            }

            foreach (var item in appointment_states)
            {
                nberAppointments.Add(listAppointments.Count(x => x.AppointmentState == item));
            }

            var finalRepartitionsByAppointment = nberAppointments;
            ViewBag.STATES = appointment_statesInString;
            ViewBag.REPARTITIONS = finalRepartitionsByAppointment.ToList();

            return View();
        }

        // GET: Dashboard/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Dashboard/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dashboard/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Dashboard/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Dashboard/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Dashboard/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Dashboard/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
