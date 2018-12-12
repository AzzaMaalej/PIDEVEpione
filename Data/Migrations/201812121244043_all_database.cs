namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class all_database : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        AppointmentId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Location = c.String(),
                        AppointmentState = c.Int(nullable: false),
                        Specialities = c.Int(nullable: false),
                        DoctorId = c.String(maxLength: 128),
                        PatientId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.AppointmentId)
                .ForeignKey("dbo.AspNetUsers", t => t.DoctorId)
                .ForeignKey("dbo.AspNetUsers", t => t.PatientId)
                .Index(t => t.DoctorId)
                .Index(t => t.PatientId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        BirthDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Address = c.String(),
                        Gender = c.Int(),
                        ImageName = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Speciality = c.Int(),
                        PathId = c.String(),
                        Poids = c.Int(),
                        Taille = c.Int(),
                        Age = c.Int(),
                        Traitements = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Chats",
                c => new
                    {
                        ChatId = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        DoctorId = c.String(maxLength: 128),
                        PatientId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ChatId)
                .ForeignKey("dbo.AspNetUsers", t => t.DoctorId)
                .ForeignKey("dbo.AspNetUsers", t => t.PatientId)
                .Index(t => t.DoctorId)
                .Index(t => t.PatientId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.MedicalPaths",
                c => new
                    {
                        PathId = c.String(nullable: false, maxLength: 128),
                        RecommendedSpeciality = c.String(),
                        ValidatedSteps = c.Boolean(nullable: false),
                        Justification = c.String(),
                        Description = c.String(),
                        RecommandationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PathId)
                .ForeignKey("dbo.AspNetUsers", t => t.PathId)
                .Index(t => t.PathId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Commentaires",
                c => new
                    {
                        IdCommentaire = c.Int(nullable: false, identity: true),
                        LaCommentaire = c.String(),
                        DateCommentaire = c.DateTime(nullable: false),
                        Question_IdQuestion = c.Int(),
                        user_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IdCommentaire)
                .ForeignKey("dbo.Questions", t => t.Question_IdQuestion)
                .ForeignKey("dbo.AspNetUsers", t => t.user_Id)
                .Index(t => t.Question_IdQuestion)
                .Index(t => t.user_Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        IdQuestion = c.Int(nullable: false, identity: true),
                        LaQuestion = c.String(),
                        DateQuestion = c.DateTime(nullable: false),
                        Patient_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IdQuestion)
                .ForeignKey("dbo.AspNetUsers", t => t.Patient_Id)
                .Index(t => t.Patient_Id);
            
            CreateTable(
                "dbo.Disponibilities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        DoctorId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.DoctorId)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.Rates",
                c => new
                    {
                        RateId = c.Int(nullable: false, identity: true),
                        Note = c.Single(nullable: false),
                        Appointment_AppointmentId = c.Int(),
                        Patient_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RateId)
                .ForeignKey("dbo.Appointments", t => t.Appointment_AppointmentId)
                .ForeignKey("dbo.AspNetUsers", t => t.Patient_Id)
                .Index(t => t.Appointment_AppointmentId)
                .Index(t => t.Patient_Id);
            
            CreateTable(
                "dbo.Reasons",
                c => new
                    {
                        ReasonId = c.Int(nullable: false, identity: true),
                        ReasonContent = c.String(),
                        Prix = c.Single(nullable: false),
                        Doctor_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ReasonId)
                .ForeignKey("dbo.AspNetUsers", t => t.Doctor_Id)
                .Index(t => t.Doctor_Id);
            
            CreateTable(
                "dbo.Repports",
                c => new
                    {
                        RepportId = c.Int(nullable: false, identity: true),
                        ReppotName = c.String(),
                        doctor_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RepportId)
                .ForeignKey("dbo.AspNetUsers", t => t.doctor_Id)
                .Index(t => t.doctor_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.MedicalPathDoctors",
                c => new
                    {
                        MedicalPath_PathId = c.String(nullable: false, maxLength: 128),
                        Doctor_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.MedicalPath_PathId, t.Doctor_Id })
                .ForeignKey("dbo.MedicalPaths", t => t.MedicalPath_PathId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.Doctor_Id, cascadeDelete: true)
                .Index(t => t.MedicalPath_PathId)
                .Index(t => t.Doctor_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Repports", "doctor_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Reasons", "Doctor_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Rates", "Patient_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Rates", "Appointment_AppointmentId", "dbo.Appointments");
            DropForeignKey("dbo.Disponibilities", "DoctorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Commentaires", "user_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Questions", "Patient_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Commentaires", "Question_IdQuestion", "dbo.Questions");
            DropForeignKey("dbo.Chats", "PatientId", "dbo.AspNetUsers");
            DropForeignKey("dbo.MedicalPaths", "PathId", "dbo.AspNetUsers");
            DropForeignKey("dbo.MedicalPathDoctors", "Doctor_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.MedicalPathDoctors", "MedicalPath_PathId", "dbo.MedicalPaths");
            DropForeignKey("dbo.Appointments", "PatientId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Chats", "DoctorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Appointments", "DoctorId", "dbo.AspNetUsers");
            DropIndex("dbo.MedicalPathDoctors", new[] { "Doctor_Id" });
            DropIndex("dbo.MedicalPathDoctors", new[] { "MedicalPath_PathId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Repports", new[] { "doctor_Id" });
            DropIndex("dbo.Reasons", new[] { "Doctor_Id" });
            DropIndex("dbo.Rates", new[] { "Patient_Id" });
            DropIndex("dbo.Rates", new[] { "Appointment_AppointmentId" });
            DropIndex("dbo.Disponibilities", new[] { "DoctorId" });
            DropIndex("dbo.Questions", new[] { "Patient_Id" });
            DropIndex("dbo.Commentaires", new[] { "user_Id" });
            DropIndex("dbo.Commentaires", new[] { "Question_IdQuestion" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.MedicalPaths", new[] { "PathId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.Chats", new[] { "PatientId" });
            DropIndex("dbo.Chats", new[] { "DoctorId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Appointments", new[] { "PatientId" });
            DropIndex("dbo.Appointments", new[] { "DoctorId" });
            DropTable("dbo.MedicalPathDoctors");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Repports");
            DropTable("dbo.Reasons");
            DropTable("dbo.Rates");
            DropTable("dbo.Disponibilities");
            DropTable("dbo.Questions");
            DropTable("dbo.Commentaires");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.MedicalPaths");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.Chats");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Appointments");
        }
    }
}
