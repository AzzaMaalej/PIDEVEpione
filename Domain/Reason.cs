using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Reason
    {
        public int ReasonId { get; set; }
        public string ReasonContent { get; set; }
        public float Prix { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}
