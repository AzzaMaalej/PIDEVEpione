namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifClassPatientV1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "Specialities", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "Specialities");
        }
    }
}
