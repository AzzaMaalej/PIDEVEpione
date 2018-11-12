namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifClassPatient : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Poids", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Taille", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Age", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Traitements", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Traitements");
            DropColumn("dbo.AspNetUsers", "Age");
            DropColumn("dbo.AspNetUsers", "Taille");
            DropColumn("dbo.AspNetUsers", "Poids");
        }
    }
}
