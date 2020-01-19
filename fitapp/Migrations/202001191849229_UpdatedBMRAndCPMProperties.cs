namespace fitapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedBMRAndCPMProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UserData_CPM", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "UserData_CPM");
        }
    }
}
