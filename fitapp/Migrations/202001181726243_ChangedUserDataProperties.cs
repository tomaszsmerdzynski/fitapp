namespace fitapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedUserDataProperties : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "UserData_PhysicalActivity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "UserData_PhysicalActivity", c => c.Int(nullable: false));
        }
    }
}
