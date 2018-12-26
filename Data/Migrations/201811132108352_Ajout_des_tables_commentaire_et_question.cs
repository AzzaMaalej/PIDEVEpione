namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ajout_des_tables_commentaire_et_question : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Commentaires",
                c => new
                    {
                        IdCommentaire = c.Int(nullable: false, identity: true),
                        LaCommentaire = c.String(),
                        Question_IdQuestion = c.Int(),
                    })
                .PrimaryKey(t => t.IdCommentaire)
                .ForeignKey("dbo.Questions", t => t.Question_IdQuestion)
                .Index(t => t.Question_IdQuestion);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        IdQuestion = c.Int(nullable: false, identity: true),
                        LaQuestion = c.String(),
                        Patient_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IdQuestion)
                .ForeignKey("dbo.AspNetUsers", t => t.Patient_Id)
                .Index(t => t.Patient_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "Patient_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Commentaires", "Question_IdQuestion", "dbo.Questions");
            DropIndex("dbo.Questions", new[] { "Patient_Id" });
            DropIndex("dbo.Commentaires", new[] { "Question_IdQuestion" });
            DropTable("dbo.Questions");
            DropTable("dbo.Commentaires");
        }
    }
}
