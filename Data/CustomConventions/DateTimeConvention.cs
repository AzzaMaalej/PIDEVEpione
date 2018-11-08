using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.CustomConventions
{
    public class DateTimeConvention : Convention
    {
        public DateTimeConvention()
        {
            Properties<DateTime>().Configure(dt => dt.HasColumnType("DateTime2"));
        }
    }
}
