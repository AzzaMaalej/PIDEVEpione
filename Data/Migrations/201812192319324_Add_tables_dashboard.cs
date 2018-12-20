namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_tables_dashboard : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assets",
                c => new
                    {
                        AssetId = c.Int(nullable: false, identity: true),
                        AssetName = c.String(),
                        AssetType = c.Int(nullable: false),
                        PurchaseDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        SaleDate = c.DateTime(nullable: true, precision: 7, storeType: "datetime2"),
                        Value = c.Double(nullable: false),
                        Office_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AssetId)
                .ForeignKey("dbo.MedicalOffices", t => t.Office_Id, cascadeDelete: true)
                .Index(t => t.Office_Id);
            
            CreateTable(
                "dbo.MedicalOffices",
                c => new
                    {
                        OfficeId = c.Int(nullable: false, identity: true),
                        NameOffice = c.String(),
                        CreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Doctor_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.OfficeId)
                .ForeignKey("dbo.AspNetUsers", t => t.Doctor_Id)
                .Index(t => t.Doctor_Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(),
                        Job = c.String(),
                        Address = c.String(),
                        HireDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Salary = c.Double(nullable: false),
                        Office_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.MedicalOffices", t => t.Office_Id, cascadeDelete: true)
                .Index(t => t.Office_Id);
            
            CreateTable(
                "dbo.MedicalCares",
                c => new
                    {
                        CareId = c.Int(nullable: false, identity: true),
                        CareName = c.String(),
                        CareDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Price = c.Double(nullable: false),
                        Doctor_Id = c.String(maxLength: 128),
                        Patient_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CareId)
                .ForeignKey("dbo.AspNetUsers", t => t.Doctor_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Patient_Id)
                .Index(t => t.Doctor_Id)
                .Index(t => t.Patient_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MedicalCares", "Patient_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.MedicalCares", "Doctor_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Employees", "Office_Id", "dbo.MedicalOffices");
            DropForeignKey("dbo.Assets", "Office_Id", "dbo.MedicalOffices");
            DropForeignKey("dbo.MedicalOffices", "Doctor_Id", "dbo.AspNetUsers");
            DropIndex("dbo.MedicalCares", new[] { "Patient_Id" });
            DropIndex("dbo.MedicalCares", new[] { "Doctor_Id" });
            DropIndex("dbo.Employees", new[] { "Office_Id" });
            DropIndex("dbo.MedicalOffices", new[] { "Doctor_Id" });
            DropIndex("dbo.Assets", new[] { "Office_Id" });
            DropTable("dbo.MedicalCares");
            DropTable("dbo.Employees");
            DropTable("dbo.MedicalOffices");
            DropTable("dbo.Assets");
        }
    }
}
