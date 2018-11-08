namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modif_table_user : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Address", c => c.String());
            AddColumn("dbo.AspNetUsers", "Gender", c => c.Int());
            AlterColumn("dbo.AspNetUsers", "BirthDate", c => c.DateTime(nullable: true, precision: 7, storeType: "datetime2"));
            DropColumn("dbo.AspNetUsers", "adress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "adress", c => c.String());
            AlterColumn("dbo.AspNetUsers", "BirthDate", c => c.DateTime(nullable: true, precision: 7, storeType: "datetime2"));
            DropColumn("dbo.AspNetUsers", "Gender");
            DropColumn("dbo.AspNetUsers", "Address");
        }
    }
}
