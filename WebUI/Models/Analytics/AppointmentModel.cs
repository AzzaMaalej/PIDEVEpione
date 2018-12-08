using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebUI.Models.Analytics
{
    public class AppointmentModel
    {
        public int AppointmentId { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string Location { get; set; }
    }
}