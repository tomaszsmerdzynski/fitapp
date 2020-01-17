namespace fitapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UserData_Age", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "UserData_BMR", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "UserData_BMR");
            DropColumn("dbo.AspNetUsers", "UserData_Age");
        }
    }
}
