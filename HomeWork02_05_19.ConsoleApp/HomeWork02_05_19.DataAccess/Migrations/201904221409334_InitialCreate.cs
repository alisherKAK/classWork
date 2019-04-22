namespace HomeWork02_05_19.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bands",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Musics",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Lyrics = c.String(),
                        SongDurationInSeconds = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                        Band_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bands", t => t.Band_Id)
                .Index(t => t.Band_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Musics", "Band_Id", "dbo.Bands");
            DropIndex("dbo.Musics", new[] { "Band_Id" });
            DropTable("dbo.Musics");
            DropTable("dbo.Bands");
        }
    }
}
