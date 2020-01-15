namespace fitapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                {
                    ProductId = c.Int(nullable: false, identity: true),
                    Name = c.String(maxLength: 50),
                    Kcal = c.Double(nullable: false),
                    Proteins = c.Double(nullable: false),
                    Carbohydrates = c.Double(nullable: false),
                    Fats = c.Double(nullable: false),
                })
                .PrimaryKey(t => t.ProductId);

        }

        public override void Down()
        {
            DropTable("dbo.Products");
        }
    }
}
