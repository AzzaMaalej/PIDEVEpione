using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Repport
    {
        public int RepportId { get; set; }
        public string RepportName { get; set; }
        public DateTime RepportDate { get; set; }
        public string PatientName { get; set; }
        public string DiseaseDeclared { get; set; }
        public string Symptoms { get; set; }
        public string Abnormalities { get; set; }
        public string ImageDisease { get; set; }
        public string RepportContent { get; set; }
        public string Diagnostic { get; set; }
        public string ReferentDoctor { get; set; }
        public Doctor Doctor { get; set; }
        //public virtual Course course { get; set; }

    }
}
