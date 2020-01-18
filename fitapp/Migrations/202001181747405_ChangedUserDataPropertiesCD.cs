namespace fitapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedUserDataPropertiesCD : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UserData_PhysicalActivity", c => c.String());
            AddColumn("dbo.AspNetUsers", "UserData_Gender", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "UserData_Gender");
            DropColumn("dbo.AspNetUsers", "UserData_PhysicalActivity");
        }
    }
}
