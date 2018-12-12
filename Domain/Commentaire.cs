using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Commentaire
    {
        [Key]
        public int IdCommentaire { get; set; }
        public String LaCommentaire { get; set; }
        public DateTime DateCommentaire { get; set; }
        public Question Question { get; set; }
        public User user { get; set; }

    }
}
