namespace HomeWork29_04_19.DataAccess.Migrations
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
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RailwayCarriages",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SeatForTickets",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IsEngaged = c.Boolean(nullable: false),
                        RailwayCarriage_Id = c.Guid(),
                        Spot_Id = c.Guid(),
                        Stateroom_Id = c.Guid(),
                        Train_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RailwayCarriages", t => t.RailwayCarriage_Id)
                .ForeignKey("dbo.Spots", t => t.Spot_Id)
                .ForeignKey("dbo.Staterooms", t => t.Stateroom_Id)
                .ForeignKey("dbo.Trains", t => t.Train_Id)
                .Index(t => t.RailwayCarriage_Id)
                .Index(t => t.Spot_Id)
                .Index(t => t.Stateroom_Id)
                .Index(t => t.Train_Id);
            
            CreateTable(
                "dbo.Spots",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Staterooms",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Trains",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Model = c.String(),
                        RailwayCarriageCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TicketNumber = c.String(),
                        DepartureTime = c.DateTime(nullable: false),
                        TimeOfArrival = c.DateTime(nullable: false),
                        Price = c.Double(nullable: false),
                        IsBuyed = c.Boolean(nullable: false),
                        CityOfArrival_Id = c.Guid(),
                        DepartureCity_Id = c.Guid(),
                        SeatForTicket_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityOfArrival_Id)
                .ForeignKey("dbo.Cities", t => t.DepartureCity_Id)
                .ForeignKey("dbo.SeatForTickets", t => t.SeatForTicket_Id)
                .Index(t => t.CityOfArrival_Id)
                .Index(t => t.DepartureCity_Id)
                .Index(t => t.SeatForTicket_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "SeatForTicket_Id", "dbo.SeatForTickets");
            DropForeignKey("dbo.Tickets", "DepartureCity_Id", "dbo.Cities");
            DropForeignKey("dbo.Tickets", "CityOfArrival_Id", "dbo.Cities");
            DropForeignKey("dbo.SeatForTickets", "Train_Id", "dbo.Trains");
            DropForeignKey("dbo.SeatForTickets", "Stateroom_Id", "dbo.Staterooms");
            DropForeignKey("dbo.SeatForTickets", "Spot_Id", "dbo.Spots");
            DropForeignKey("dbo.SeatForTickets", "RailwayCarriage_Id", "dbo.RailwayCarriages");
            DropIndex("dbo.Tickets", new[] { "SeatForTicket_Id" });
            DropIndex("dbo.Tickets", new[] { "DepartureCity_Id" });
            DropIndex("dbo.Tickets", new[] { "CityOfArrival_Id" });
            DropIndex("dbo.SeatForTickets", new[] { "Train_Id" });
            DropIndex("dbo.SeatForTickets", new[] { "Stateroom_Id" });
            DropIndex("dbo.SeatForTickets", new[] { "Spot_Id" });
            DropIndex("dbo.SeatForTickets", new[] { "RailwayCarriage_Id" });
            DropTable("dbo.Tickets");
            DropTable("dbo.Trains");
            DropTable("dbo.Staterooms");
            DropTable("dbo.Spots");
            DropTable("dbo.SeatForTickets");
            DropTable("dbo.RailwayCarriages");
            DropTable("dbo.Cities");
        }
    }
}
