namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modification_commentaire_et_repport : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Commentaires", "user_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Repports", "doctor_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Commentaires", "user_Id");
            CreateIndex("dbo.Repports", "doctor_Id");
            AddForeignKey("dbo.Commentaires", "user_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Repports", "doctor_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Repports", "doctor_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Commentaires", "user_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Repports", new[] { "doctor_Id" });
            DropIndex("dbo.Commentaires", new[] { "user_Id" });
            DropColumn("dbo.Repports", "doctor_Id");
            DropColumn("dbo.Commentaires", "user_Id");
        }
    }
}
