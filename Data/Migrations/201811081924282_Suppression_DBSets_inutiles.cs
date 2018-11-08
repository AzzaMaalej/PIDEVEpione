namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Suppression_DBSets_inutiles : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Appointments", "course_CourseId", "dbo.Courses");
            DropForeignKey("dbo.AspNetUsers", "course_CourseId", "dbo.Courses");
            DropForeignKey("dbo.Messages", "chat_ChatId", "dbo.Chats");
            DropForeignKey("dbo.Debreifs", "appointment_AppointmentId", "dbo.Appointments");
            DropForeignKey("dbo.Repports", "course_CourseId", "dbo.Courses");
            DropIndex("dbo.AspNetUsers", new[] { "course_CourseId" });
            DropIndex("dbo.Appointments", new[] { "course_CourseId" });
            DropIndex("dbo.Messages", new[] { "chat_ChatId" });
            DropIndex("dbo.Debreifs", new[] { "appointment_AppointmentId" });
            DropIndex("dbo.Repports", new[] { "course_CourseId" });
            DropColumn("dbo.AspNetUsers", "course_CourseId");
            DropColumn("dbo.Appointments", "course_CourseId");
            DropColumn("dbo.Repports", "course_CourseId");
            DropTable("dbo.Courses");
            DropTable("dbo.Messages");
            DropTable("dbo.Debreifs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Debreifs",
                c => new
                    {
                        DebreifId = c.Int(nullable: false, identity: true),
                        FinalDisease = c.String(),
                        Description = c.String(),
                        appointment_AppointmentId = c.Int(),
                    })
                .PrimaryKey(t => t.DebreifId);
            
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
                .PrimaryKey(t => t.MessageId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.CourseId);
            
            AddColumn("dbo.Repports", "course_CourseId", c => c.Int());
            AddColumn("dbo.Appointments", "course_CourseId", c => c.Int());
            AddColumn("dbo.AspNetUsers", "course_CourseId", c => c.Int());
            CreateIndex("dbo.Repports", "course_CourseId");
            CreateIndex("dbo.Debreifs", "appointment_AppointmentId");
            CreateIndex("dbo.Messages", "chat_ChatId");
            CreateIndex("dbo.Appointments", "course_CourseId");
            CreateIndex("dbo.AspNetUsers", "course_CourseId");
            AddForeignKey("dbo.Repports", "course_CourseId", "dbo.Courses", "CourseId");
            AddForeignKey("dbo.Debreifs", "appointment_AppointmentId", "dbo.Appointments", "AppointmentId");
            AddForeignKey("dbo.Messages", "chat_ChatId", "dbo.Chats", "ChatId");
            AddForeignKey("dbo.AspNetUsers", "course_CourseId", "dbo.Courses", "CourseId");
            AddForeignKey("dbo.Appointments", "course_CourseId", "dbo.Courses", "CourseId");
        }
    }
}
