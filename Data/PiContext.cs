using Domain;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using Data.CustomConventions;

namespace Data
{
    //   [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class PiContext : IdentityDbContext<User>
    {
        
        public PiContext() : base("PIDB")
        {
            Database.SetInitializer(new ContexInit());
        }


        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<MedicalPath> MedicalPaths { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Repport> Repports { get; set; }
        public DbSet<Rate> Ratings { get; set; }
        public DbSet<Disponibility> Disponibilities { get; set; }


        public static PiContext Create()
        {
            return new PiContext();
        }



    }
    public class ContexInit : DropCreateDatabaseIfModelChanges<PiContext>
    {
        protected override void Seed(PiContext context)
        {
         /*   List<Patient> patients = new List<Patient>() {
                new Patient {PatientId=1
                            }
               
            };
            context.Patients.AddRange(patients);
            context.SaveChanges();*/
        }
    }
}
