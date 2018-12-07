using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class PatientConfiguration : EntityTypeConfiguration<Patient>
    {
        public PatientConfiguration()
        {

            HasMany(p => p.Appointments).WithRequired(a => a.Patient).HasForeignKey(a => a.PatientId).WillCascadeOnDelete(false);
            HasMany(p => p.Conversations).WithRequired(c => c.Patient).HasForeignKey(c => c.PatientId).WillCascadeOnDelete(false);
        }
    }
}
