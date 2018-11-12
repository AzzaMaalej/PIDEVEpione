namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class annulationcaneder : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Disponibilities");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Disponibilities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Desc = c.String(),
                        Start_date = c.DateTime(nullable: false),
                        End_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
