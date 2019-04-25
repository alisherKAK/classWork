namespace HomeWork05_05_19.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        CityPhoneCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CityPhoneNumbers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Number = c.String(),
                        Username = c.String(),
                        City_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.City_Id)
                .Index(t => t.City_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CityPhoneNumbers", "City_Id", "dbo.Cities");
            DropIndex("dbo.CityPhoneNumbers", new[] { "City_Id" });
            DropTable("dbo.CityPhoneNumbers");
            DropTable("dbo.Cities");
        }
    }
}
