using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Question
    {
        [Key]
        public int IdQuestion { get; set; }
        public String LaQuestion { get; set; }
        public Patient Patient { get; set; }
        public virtual ICollection<Commentaire> Commentaires { get; set; }

    }
}






