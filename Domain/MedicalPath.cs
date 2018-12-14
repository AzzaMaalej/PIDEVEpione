﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class MedicalPath
    {
        [Key]
        //[ForeignKey("Patient")]
        public String PathId { get; set; }
        public string RecommendedSpeciality { get; set; }
        public  bool ValidatedSteps { get; set; }
        public string Justification { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime RecommandationDate { get; set; }
        public String Patient_id { get; set; }
        [ForeignKey("Patient_id")]
        public virtual Patient Patient { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
