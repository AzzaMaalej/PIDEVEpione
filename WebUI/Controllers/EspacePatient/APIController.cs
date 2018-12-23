using Domain;
using Microsoft.AspNet.Identity;
using Service.EspacePatient;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace WebUI.Controllers
{

    public class APIController : ApiController
    {
       
        ServiceAppointment sp = new ServiceAppointment();
        [Route("API/AppointmentsList")]
        [HttpGet]
      
        public IHttpActionResult Index()
        {

            var ap = sp.GetMany();
            return Ok(ap);

        }
        [Route("api/appointmentDetails/{id}")]
        [HttpGet]
        public IHttpActionResult Details(String id)
        {
            Appointment ap = sp.GetById(id);
           
            return Ok(ap);

        }
        [Route("api/appointmentAdd")]
        [HttpGet]
        public IHttpActionResult Add(Appointment ap)
        {
                 sp.Add(ap);

            return Ok();

        }

        [Route("api/appointmentDelete/{id}")]
        [HttpPost]
        public IHttpActionResult Delete(String id, Appointment a)
        {

            var req = sp.GetMany().Where(b => b.AppointmentId.Equals(id)).FirstOrDefault();
            sp.Delete(req);
            sp.Commit();
            return Ok();
        }

       

    }
    }

