namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modif_medicalpath : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MedicalPaths", "PathId", "dbo.AspNetUsers");
            DropIndex("dbo.MedicalPaths", new[] { "PathId" });
            AddColumn("dbo.MedicalPaths", "Patient_id", c => c.String(maxLength: 128));
            CreateIndex("dbo.MedicalPaths", "Patient_id");
            AddForeignKey("dbo.MedicalPaths", "Patient_id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.AspNetUsers", "PathId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "PathId", c => c.String());
            DropForeignKey("dbo.MedicalPaths", "Patient_id", "dbo.AspNetUsers");
            DropIndex("dbo.MedicalPaths", new[] { "Patient_id" });
            DropColumn("dbo.MedicalPaths", "Patient_id");
            CreateIndex("dbo.MedicalPaths", "PathId");
            AddForeignKey("dbo.MedicalPaths", "PathId", "dbo.AspNetUsers", "Id");
        }
    }
}
