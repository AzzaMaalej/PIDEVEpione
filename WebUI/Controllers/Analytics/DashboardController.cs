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
            List<double> nberAppointments = new List<double>();
            List<int> nberAppointments2 = new List<int>();
            double nberAppointmentsCanceled = new double();
            var appointment_states = listAppointments.Select(a => a.AppointmentState).Distinct();
            var appointment_statesInString = new List<string>();
            foreach (var item in appointment_states)
            {
                appointment_statesInString.Add(item.ToString());
            }

            foreach (var item in appointment_states)
            {
                //nberAppointments.Add(((listAppointments.Count(x => x.AppointmentState == item))*100/listAppointments.Count()));
                int res2 = (listAppointments.Count(x => x.AppointmentState == item));
                double res = res2 * 100 / listAppointments.Count();
                nberAppointments2.Add(res2);
                double nber = Math.Round(res, 1);
                nberAppointments.Add(nber);
                if (item == Domain.StateEnum.Cancelled)
                    nberAppointmentsCanceled = nber;
            }

            var finalRepartitionsByAppointment = nberAppointments;
            var finalRepartitionsByAppointment2 = nberAppointments2;
            var listPatients = sd2.getAllPatientsTreatedByDoctor(medecin.Id);
            var listPatients2 = sd2.getAllPatientsNotTreatedByDoctor(medecin.Id);
            var rdvCanceled = sd3.getAllAppointmentsCanceledByDoctor(medecin.Id).Count();
            var nbrePT = listPatients.Count();
            var nbrePNT = listPatients2.Count();
            var percentage = nbrePT*100/(nbrePT+nbrePNT);

            ViewBag.STATES = appointment_statesInString;
            ViewBag.REPARTITIONS = finalRepartitionsByAppointment.ToList();
            ViewBag.REPARTITIONS2 = finalRepartitionsByAppointment2.ToList();
            ViewBag.NBERPATIENT = nbrePT;
            ViewBag.RATIO = percentage;
            ViewBag.CANCELED = nberAppointmentsCanceled;
            ViewBag.RDV_CANCELED = rdvCanceled;

            return View(medecin);
        }

        public ActionResult PatientTreated()
        {
            var medecin = sd.getDoctorByName(AccountController.UserCoUserName);
            var listPatients = sd2.getAllPatientsTreatedByDoctor(medecin.Id);
            var listMonths = sd3.getAllAppointmentsByDoctor(medecin.Id).GroupBy(a => a.Date.Month.ToString());
            List<int> nberAppointments = new List<int>();
            var appointment_monthInString = new List<string>();

            foreach (var item in listMonths)
            {
                appointment_monthInString.Add(item.ToString());
            }

            foreach (var item in listMonths)
            {
                nberAppointments.Add(listMonths.Count(x => x.Any() == item.Any()));
            }

            var finalRepartitionsByAppointment = nberAppointments;
            var nbrePT = listPatients.Count();
            ViewBag.MONTHS = appointment_monthInString;
            ViewBag.NBERPATIENT = nbrePT;
            ViewBag.REPARTITION = finalRepartitionsByAppointment.ToList();

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
