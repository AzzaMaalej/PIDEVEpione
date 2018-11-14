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
            
               var  medecin2 = sm.GetMany().ToList();
                return View(medecin2);
            
            
        }
        [HttpPost]
        public ActionResult Index(string SearchString)
        {
            //var medecin= new IEnumerable<Doctor>();

            var medecin2 = sm.GetMany(p=>p.Address.Contains(SearchString));
            return View(medecin2);


        }


        // GET: Medecin/Details/5
        public ActionResult Details(string id)
        {
            var medecin = sm.GetById(id);
            return View(medecin);
        }
        ServiceDisponibility sd = new ServiceDisponibility();
        public ActionResult ViewDispo(String id)
        {
            var dispo = sd.geDispoByDoctorId(id);
            return View(dispo);
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

        PiContext pi = new PiContext();
        // POST: Medecin/Edit/5
       
        // GET: Medecin/Delete/5
       
    }
}
