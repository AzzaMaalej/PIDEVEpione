namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ajout_des_tables_medicalPath_et_chats : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Chats", name: "doctor_Id", newName: "DoctorId");
            RenameColumn(table: "dbo.Chats", name: "patient_Id", newName: "PatientId");
            RenameIndex(table: "dbo.Chats", name: "IX_doctor_Id", newName: "IX_DoctorId");
            RenameIndex(table: "dbo.Chats", name: "IX_patient_Id", newName: "IX_PatientId");
            CreateTable(
                "dbo.MedicalPaths",
                c => new
                    {
                        PathId = c.String(nullable: false, maxLength: 128),
                        RecommendedSpeciality = c.String(),
                        ValidatedSteps = c.Int(nullable: false),
                        Justification = c.String(),
                    })
                .PrimaryKey(t => t.PathId)
                .ForeignKey("dbo.AspNetUsers", t => t.PathId)
                .Index(t => t.PathId);
            
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
            
            AddColumn("dbo.Chats", "CreationDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2")
);
            DropColumn("dbo.AspNetUsers", "Insuranceid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Insuranceid", c => c.Int());
            DropForeignKey("dbo.MedicalPaths", "PathId", "dbo.AspNetUsers");
            DropForeignKey("dbo.MedicalPathDoctors", "Doctor_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.MedicalPathDoctors", "MedicalPath_PathId", "dbo.MedicalPaths");
            DropIndex("dbo.MedicalPathDoctors", new[] { "Doctor_Id" });
            DropIndex("dbo.MedicalPathDoctors", new[] { "MedicalPath_PathId" });
            DropIndex("dbo.MedicalPaths", new[] { "PathId" });
            DropColumn("dbo.Chats", "CreationDate");
            DropTable("dbo.MedicalPathDoctors");
            DropTable("dbo.MedicalPaths");
            RenameIndex(table: "dbo.Chats", name: "IX_PatientId", newName: "IX_patient_Id");
            RenameIndex(table: "dbo.Chats", name: "IX_DoctorId", newName: "IX_doctor_Id");
            RenameColumn(table: "dbo.Chats", name: "PatientId", newName: "patient_Id");
            RenameColumn(table: "dbo.Chats", name: "DoctorId", newName: "doctor_Id");
        }
    }
}
