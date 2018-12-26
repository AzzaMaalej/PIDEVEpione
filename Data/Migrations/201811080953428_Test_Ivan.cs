namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test_Ivan : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chats",
                c => new
                    {
                        ChatId = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        patient_Id = c.String(maxLength: 128),
                        doctor_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ChatId)
                .ForeignKey("dbo.AspNetUsers", t => t.patient_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.doctor_Id)
                .Index(t => t.patient_Id)
                .Index(t => t.doctor_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        firstName = c.String(),
                        lastName = c.String(),
                        birthDate = c.DateTime(),
                        adress = c.String(),
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
                        speciality = c.Int(),
                        Insuranceid = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        course_CourseId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.course_CourseId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.course_CourseId);
            
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        AppointmentId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Disease = c.String(),
                        state = c.Int(nullable: false),
                        course_CourseId = c.Int(),
                        doctor_Id = c.String(maxLength: 128),
                        patient_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.AppointmentId)
                .ForeignKey("dbo.Courses", t => t.course_CourseId)
                .ForeignKey("dbo.AspNetUsers", t => t.doctor_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.patient_Id)
                .Index(t => t.course_CourseId)
                .Index(t => t.doctor_Id)
                .Index(t => t.patient_Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.CourseId);
            
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
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        sender = c.Int(nullable: false),
                        receiver = c.Int(nullable: false),
                        chat_ChatId = c.Int(),
                    })
                .PrimaryKey(t => t.MessageId)
                .ForeignKey("dbo.Chats", t => t.chat_ChatId)
                .Index(t => t.chat_ChatId);
            
            CreateTable(
                "dbo.Debreifs",
                c => new
                    {
                        DebreifId = c.Int(nullable: false, identity: true),
                        FinalDisease = c.String(),
                        Description = c.String(),
                        appointment_AppointmentId = c.Int(),
                    })
                .PrimaryKey(t => t.DebreifId)
                .ForeignKey("dbo.Appointments", t => t.appointment_AppointmentId)
                .Index(t => t.appointment_AppointmentId);
            
            CreateTable(
                "dbo.Rates",
                c => new
                    {
                        RateId = c.Int(nullable: false, identity: true),
                        Note = c.Single(nullable: false),
                        appointment_AppointmentId = c.Int(),
                        patient_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RateId)
                .ForeignKey("dbo.Appointments", t => t.appointment_AppointmentId)
                .ForeignKey("dbo.AspNetUsers", t => t.patient_Id)
                .Index(t => t.appointment_AppointmentId)
                .Index(t => t.patient_Id);
            
            CreateTable(
                "dbo.Repports",
                c => new
                    {
                        RepportId = c.Int(nullable: false, identity: true),
                        ReppotName = c.String(),
                        course_CourseId = c.Int(),
                    })
                .PrimaryKey(t => t.RepportId)
                .ForeignKey("dbo.Courses", t => t.course_CourseId)
                .Index(t => t.course_CourseId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Repports", "course_CourseId", "dbo.Courses");
            DropForeignKey("dbo.Rates", "patient_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Rates", "appointment_AppointmentId", "dbo.Appointments");
            DropForeignKey("dbo.Debreifs", "appointment_AppointmentId", "dbo.Appointments");
            DropForeignKey("dbo.Messages", "chat_ChatId", "dbo.Chats");
            DropForeignKey("dbo.Chats", "doctor_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "course_CourseId", "dbo.Courses");
            DropForeignKey("dbo.Chats", "patient_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Appointments", "patient_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Appointments", "doctor_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Appointments", "course_CourseId", "dbo.Courses");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Repports", new[] { "course_CourseId" });
            DropIndex("dbo.Rates", new[] { "patient_Id" });
            DropIndex("dbo.Rates", new[] { "appointment_AppointmentId" });
            DropIndex("dbo.Debreifs", new[] { "appointment_AppointmentId" });
            DropIndex("dbo.Messages", new[] { "chat_ChatId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.Appointments", new[] { "patient_Id" });
            DropIndex("dbo.Appointments", new[] { "doctor_Id" });
            DropIndex("dbo.Appointments", new[] { "course_CourseId" });
            DropIndex("dbo.AspNetUsers", new[] { "course_CourseId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Chats", new[] { "doctor_Id" });
            DropIndex("dbo.Chats", new[] { "patient_Id" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Repports");
            DropTable("dbo.Rates");
            DropTable("dbo.Debreifs");
            DropTable("dbo.Messages");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.Courses");
            DropTable("dbo.Appointments");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Chats");
        }
    }
}
