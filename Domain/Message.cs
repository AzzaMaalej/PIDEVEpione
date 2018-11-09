using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Message
    {
        public int MessageId { get; set; }
        public String Content { get; set; }
        public virtual int sender { get; set; }
        public virtual int receiver { get; set; }
        //public virtual Chat chat { get; set; }

    }
}
