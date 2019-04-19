namespace HomeWork29_04_19.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPropertiesToRailwayCarriageAndToStateroom : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RailwayCarriages", "StateroomCount", c => c.Int(nullable: false));
            AddColumn("dbo.Staterooms", "SpotCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Staterooms", "SpotCount");
            DropColumn("dbo.RailwayCarriages", "StateroomCount");
        }
    }
}
