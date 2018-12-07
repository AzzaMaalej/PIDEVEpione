using Data;
using Domain;
using Service;
using Service.ParcoursPatient;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;
//using WebUI.Models.ParcoursPatient;

namespace WebUI.Controllers.ParcoursPatient
{
    public class MedicalPathController : Controller
    {
        ServiceMedicalPath sm = new ServiceMedicalPath();
        PiContext p = new PiContext();
        

        // GET: MedicalPath
        public ActionResult Index()
        {
           
            return View(sm.GetMany());
        }

        // GET: MedicalPath/Details/5
        public ActionResult Details(String id)
        {
            MedicalPath MedicalPaths = sm.GetMany().Where(s => s.PathId == id).FirstOrDefault() ;
            return View(MedicalPaths);
        }

        // GET: MedicalPath/Create
        public ActionResult Create()
        {
            //var medicalPaths = new MedicalPathViewModel();
           // List<string> specialities = new List<string> { "IndividualProject", "GroupProject" };
           // medicalPaths.RecommendedSpeciality = specialities.ToSelectListItems();

            return View();
        }

        // POST: MedicalPath/Create
        [HttpPost]
        public ActionResult Create(MedicalPath mdp)

        {
                MedicalPath mp = new MedicalPath
                {

                    PathId =mdp.PathId,
                    Justification = mdp.Justification,
                    RecommendedSpeciality = mdp.RecommendedSpeciality,
                    ValidatedSteps = mdp.ValidatedSteps,
                    Description = mdp.Description,
                    RecommandationDate = mdp.RecommandationDate




                };

            /****Mail****/

            try
            {
                MailMessage message = new MailMessage("rymomrani5@gmail.com", "rym.elomrani@esprit.tn", "notification de doctor", "parcour ajouté");
                message.IsBodyHtml = true;
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Credentials = new System.Net.NetworkCredential("rymomrani5@gmail.com", "11387047");
                client.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

            /****Mail****/

            sm.Add(mp);
            sm.Commit();

           
            
            return RedirectToAction("Index");

         
            }




        // GET: MedicalPath/Edit/5
        public ActionResult Edit(String id)
        {
            MedicalPath MedicalPaths = sm.GetMany().Single(s => s.PathId == id);
            return View(MedicalPaths);
        }

        // POST: MedicalPath/Edit/5
        [HttpPost]
        public ActionResult Edit(String id, MedicalPath newMedicalPath)
        {
            try
            {
                // TODO: Add update logic here
                MedicalPath oldMedicalPath = sm.GetMany().Single(s => s.PathId == id);
                oldMedicalPath.Justification = newMedicalPath.Justification;
                oldMedicalPath.Description = newMedicalPath.Description;

                oldMedicalPath.RecommendedSpeciality = newMedicalPath.RecommendedSpeciality;
                 oldMedicalPath.RecommandationDate = newMedicalPath.RecommandationDate;
                // oldMedicalPath.AdresseDotor = newMedicalPath.AdresseDotor;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: MedicalPath/Delete/5
        public ActionResult Delete(String id)
        {
            MedicalPath MedicalPaths = sm.GetMany().Single(s => s.PathId == id);




            return View(MedicalPaths);

        }

        // POST: MedicalPath/Delete/5
        [HttpPost]
        public ActionResult Delete(String id, FormCollection collection)
        {
            try
            {
                MedicalPath MedicalPaths = sm.GetMany().Single(s => s.PathId == id);
                sm.Delete(MedicalPaths);
                sm.Commit();
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
