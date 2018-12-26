namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VOIRs : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.Disponibilities", "DoctorId", c => c.String(maxLength: 128));
            //CreateIndex("dbo.Disponibilities", "DoctorId");
            //AddForeignKey("dbo.Disponibilities", "DoctorId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.Disponibilities", "DoctorId", "dbo.AspNetUsers");
            //DropIndex("dbo.Disponibilities", new[] { "DoctorId" });
            //DropColumn("dbo.Disponibilities", "DoctorId");
        }
    }
}
