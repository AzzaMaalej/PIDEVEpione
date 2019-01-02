namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Creation_Disponibilities_version2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Disponibilities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Disponibilities");
        }
    }
}
