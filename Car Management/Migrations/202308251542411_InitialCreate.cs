namespace Car_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Brand = c.String(nullable: false),
                        Class = c.String(nullable: false),
                        ModelName = c.String(nullable: false),
                        ModelCode = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Features = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateOfManufacturing = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        SortOrder = c.Int(nullable: false),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CarModels");
        }
    }
}
