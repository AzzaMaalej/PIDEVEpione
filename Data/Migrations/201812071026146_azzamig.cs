namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class azzamig : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.MedicalPaths", new[] { "PathId" });
            AddColumn("dbo.AspNetUsers", "PathId", c => c.String(maxLength: 128));
            AddColumn("dbo.MedicalPaths", "Description", c => c.String());
            AddColumn("dbo.MedicalPaths", "RecommandationDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.MedicalPaths", "ValidatedSteps", c => c.Boolean(nullable: false));
            CreateIndex("dbo.AspNetUsers", "PathId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.AspNetUsers", new[] { "PathId" });
            AlterColumn("dbo.MedicalPaths", "ValidatedSteps", c => c.Int(nullable: false));
            DropColumn("dbo.MedicalPaths", "RecommandationDate");
            DropColumn("dbo.MedicalPaths", "Description");
            DropColumn("dbo.AspNetUsers", "PathId");
            CreateIndex("dbo.MedicalPaths", "PathId");
        }
    }
}
