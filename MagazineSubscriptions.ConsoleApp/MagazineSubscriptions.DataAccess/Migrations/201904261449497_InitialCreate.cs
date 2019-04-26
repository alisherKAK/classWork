namespace MagazineSubscriptions.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Magazines",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Theme = c.String(),
                        DateOfIssue = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MagazineShippings",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DeliverTime = c.DateTime(nullable: false),
                        IsDelivered = c.Boolean(nullable: false),
                        Magazine_Id = c.Guid(),
                        UsersSubscription_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Magazines", t => t.Magazine_Id)
                .ForeignKey("dbo.UsersSubscriptions", t => t.UsersSubscription_Id)
                .Index(t => t.Magazine_Id)
                .Index(t => t.UsersSubscription_Id);
            
            CreateTable(
                "dbo.UsersSubscriptions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Subscription_Id = c.Guid(),
                        User_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subscriptions", t => t.Subscription_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Subscription_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Subscriptions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Price = c.Double(nullable: false),
                        SubscriptionsTimeInMonth = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Login = c.String(),
                        Password = c.String(),
                        Person_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Person_Id)
                .Index(t => t.Person_Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Surname = c.String(),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MagazineShippings", "UsersSubscription_Id", "dbo.UsersSubscriptions");
            DropForeignKey("dbo.UsersSubscriptions", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "Person_Id", "dbo.People");
            DropForeignKey("dbo.UsersSubscriptions", "Subscription_Id", "dbo.Subscriptions");
            DropForeignKey("dbo.MagazineShippings", "Magazine_Id", "dbo.Magazines");
            DropIndex("dbo.Users", new[] { "Person_Id" });
            DropIndex("dbo.UsersSubscriptions", new[] { "User_Id" });
            DropIndex("dbo.UsersSubscriptions", new[] { "Subscription_Id" });
            DropIndex("dbo.MagazineShippings", new[] { "UsersSubscription_Id" });
            DropIndex("dbo.MagazineShippings", new[] { "Magazine_Id" });
            DropTable("dbo.People");
            DropTable("dbo.Users");
            DropTable("dbo.Subscriptions");
            DropTable("dbo.UsersSubscriptions");
            DropTable("dbo.MagazineShippings");
            DropTable("dbo.Magazines");
        }
    }
}
