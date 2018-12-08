using Domain;
using Microsoft.AspNet.Identity;
using Service.EspacePatient;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace WebUI.Controllers
{

    public class APIController : ApiController
    {
       
        ServiceAppointment sp = new ServiceAppointment();

        [System.Web.Http.HttpGet]
       // [System.Web.Http.Route("API/AffichageaPP")]
        public IHttpActionResult AffichageaPP()
        {

            List<Appointment> lists = new List<Appointment>();
            foreach (var item in sp.GetAll())
            {
                Appointment appointement = new Appointment();
                appointement.Date = item.Date;
                appointement.Location = item.Location;
                appointement.PatientId = item.PatientId;
                appointement.DoctorId = item.DoctorId;
                appointement.AppointmentState = item.AppointmentState;
                appointement.Specialities = item.Specialities;
                lists.Add(appointement);

            }

            try
            {
                // TODO: Add insert logic here
                return Ok(lists);
            }
            catch
            {
                return Ok();
            }
        }
    }
}
