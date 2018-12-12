using Service.EspacePatient;
using Service.ParcoursPatient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers.EspacePatient
{
    public class PatientController : Controller
    {
        IServiceMedicalPath sm = new ServiceMedicalPath();
        //ServiceSpeciality ss = new ServiceSpeciality();
        IServiceProfil_Patient sp = new ServiceProfil_Patient();
        public ActionResult Index()
        {
            var patients = sp.GetMany();

            return View(patients);
        }
        [HttpPost]
        public ActionResult Index(string searchString)
        {
            // var ProductSearched = sp.GetMany(p=>p.Name== searchString);
            var PatientSearched = sp.GetMany(p => p.UserName.Contains(searchString));

            return View(PatientSearched);
        }

        // GET: Patient/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Patient/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patient/Create
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

        // GET: Patient/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Patient/Edit/5
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

        // GET: Patient/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Patient/Delete/5
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
        //[HttpGet]
        public ActionResult AjouterParcour(string id)
        {

            return RedirectToAction("Create", "MedicalPath", new { Id = id });

        }
        public ActionResult AfficherParcour(string id)
        {

            return RedirectToAction("Index", "MedicalPath", new { Id = id });

        }

    }
     

    }

