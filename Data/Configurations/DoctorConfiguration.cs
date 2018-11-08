using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class DoctorConfiguration : EntityTypeConfiguration<Doctor>
    {
        public DoctorConfiguration()
        {


            HasMany(d => d.MedicalPaths).WithMany(mp => mp.Doctors).Map(m => {
                m.ToTable("Paths_Doctors");
                m.MapLeftKey("DoctorId");
                m.MapRightKey("PathId");
            });


            HasMany(d => d.Appointments).WithRequired(a => a.Doctor).HasForeignKey(a => a.DoctorId).WillCascadeOnDelete(false);

            HasMany(d => d.Conversations).WithRequired(c => c.Doctor).HasForeignKey(c => c.DoctorId).WillCascadeOnDelete(false);

        }
    }
}
