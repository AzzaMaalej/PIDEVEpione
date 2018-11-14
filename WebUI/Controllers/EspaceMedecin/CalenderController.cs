using DHTMLX.Scheduler.Data;
using DHTMLX.Common;
using DHTMLX.Scheduler;
using DHTMLX.Scheduler.Data;
using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;
using Service.EspaceMedecin;
using DHTMLX.Scheduler.Controls;
using System.Collections;

namespace WebUI.Controllers.EspaceMedecin
{
    public class CalenderController : Controller
    {

        ServiceMedecin sm = new ServiceMedecin();
        // GET: Calender
        ServiceDisponibility sd = new ServiceDisponibility();
      
        public ActionResult Index()
        {
            var scheduler = new DHXScheduler(this);
            
           
             scheduler.Lightbox.Name = "Disponibility";
         
           
            //scheduler.Lightbox.Add(check);
            scheduler.TimeSpans.Add(new DHXMarkTime()
            {

                Day = DayOfWeek.Sunday,
                CssClass = "green_section",
                SpanType = DHXTimeSpan.Type.BlockEvents
            });
            scheduler.TimeSpans.Add(new DHXMarkTime()
            {
                FullWeek = false,
                Day = DayOfWeek.Saturday,
                CssClass = "red_section",// apply this css class to the section
                HTML = "LockTime", // inner html of the section
                Zones = new List<Zone>() { new Zone { Start = 15 * 60, End = 20 * 60 } },
                SpanType = DHXTimeSpan.Type.BlockEvents//if specified - user can't create event in this area
            });
            scheduler.Skin = DHXScheduler.Skins.Flat;
            scheduler.Config.first_hour = 8;
            scheduler.Config.last_hour = 20;
            scheduler.Config.time_step = 15;
           
            scheduler.EnableDynamicLoading(SchedulerDataLoader.DynamicalLoadingMode.Month);
            scheduler.LoadData = true;
            scheduler.EnableDataprocessor = true;
            //scheduler.filter_timeline = function(id, event){ return false; }
            
            return View(scheduler);
        }
        PiContext db = new PiContext();
        public ContentResult Data(DateTime from, DateTime to)
        {
            var apps = db.Disponibilities.Where(e => e.StartDate < to && e.EndDate >= from).ToList();
            return new SchedulerAjaxData(apps);
        }
        public ActionResult Save(int? id, FormCollection actionValues)
        {
            
            var action = new DataAction(actionValues);
            
            var medecin = sm.getDoctorByUserName(AccountController.UserCoUserName);
            
            try
            {
                var changedEvent = DHXEventsHelper.Bind<Disponibility>(actionValues);
                changedEvent.DoctorId = medecin.Single().Id;

                switch (action.Type)
                {
                    case DataActionTypes.Insert:
                        {
                            changedEvent.Description = "Disponible";
                            db.Disponibilities.Add(changedEvent);
                        }
                        break;
                    case DataActionTypes.Delete:
                        db.Entry(changedEvent).State = EntityState.Deleted;
                        break;
                    default:// "update"  
                        db.Entry(changedEvent).State = EntityState.Modified;
                        break;
                }
                db.SaveChanges();
                action.TargetId = changedEvent.Id;
            }
            catch (Exception a)
            {
                action.Type = DataActionTypes.Error;
            }

            return (new AjaxSaveResponse(action));
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}