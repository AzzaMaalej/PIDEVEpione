using Service.EspacePatient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models.Analytics;
using WebUI.Models.EspacePatient;

namespace WebUI.Controllers.Analytics
{
    public class DisponibiltyAPIController : Controller
    {
        ServiceAppointment us = new ServiceAppointment();


        public ActionResult GetApps()
        {
            var wsu = us.GetAll();
            IList<AppointmentModel> lis = new List<AppointmentModel>();
            foreach (var item in wsu)
            {
                AppointmentModel ap = new AppointmentModel();
                ap.Date = item.Date;
                ap.Location = item.Location;
                lis.Add(ap);
            }
            return Json(lis, JsonRequestBehavior.AllowGet);


        }
    }
}