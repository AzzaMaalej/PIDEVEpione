﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Patient : User
    {
        //public int Insuranceid { get; set; }
        //public virtual Course course { get; set; }
        public virtual ICollection<Chat> Conversations { get; set; }
       public virtual ICollection<Appointment> Appointments { get; set; }
        //public String PathId { get; set; }
        //[ForeignKey("PathId")]
        //public virtual MedicalPath MedicalPath { get; set; }
        public int Poids { get; set; }
        public int Taille { get; set; }
        public int Age { get; set; }
        public String Traitements { get; set; }
        
    }
}
