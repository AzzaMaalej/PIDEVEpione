namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modif_repport : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Repports", new[] { "doctor_Id" });
            AddColumn("dbo.Repports", "RepportName", c => c.String());
            AddColumn("dbo.Repports", "RepportDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2", defaultValue: DateTime.Now));
            AddColumn("dbo.Repports", "PatientName", c => c.String());
            AddColumn("dbo.Repports", "DiseaseDeclared", c => c.String());
            AddColumn("dbo.Repports", "Symptoms", c => c.String());
            AddColumn("dbo.Repports", "Abnormalities", c => c.String());
            AddColumn("dbo.Repports", "ImageDisease", c => c.String());
            AddColumn("dbo.Repports", "RepportContent", c => c.String());
            AddColumn("dbo.Repports", "Diagnostic", c => c.String());
            AddColumn("dbo.Repports", "ReferentDoctor", c => c.String());
            CreateIndex("dbo.Repports", "Doctor_Id");
            DropColumn("dbo.Repports", "ReppotName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Repports", "ReppotName", c => c.String());
            DropIndex("dbo.Repports", new[] { "Doctor_Id" });
            DropColumn("dbo.Repports", "ReferentDoctor");
            DropColumn("dbo.Repports", "Diagnostic");
            DropColumn("dbo.Repports", "RepportContent");
            DropColumn("dbo.Repports", "ImageDisease");
            DropColumn("dbo.Repports", "Abnormalities");
            DropColumn("dbo.Repports", "Symptoms");
            DropColumn("dbo.Repports", "DiseaseDeclared");
            DropColumn("dbo.Repports", "PatientName");
            DropColumn("dbo.Repports", "RepportDate");
            DropColumn("dbo.Repports", "RepportName");
            CreateIndex("dbo.Repports", "doctor_Id");
        }
    }
}
