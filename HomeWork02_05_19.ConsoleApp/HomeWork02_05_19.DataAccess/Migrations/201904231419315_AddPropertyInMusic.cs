namespace HomeWork02_05_19.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropertyInMusic : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Musics", "Band_Id", "dbo.Bands");
            DropIndex("dbo.Musics", new[] { "Band_Id" });
            AddColumn("dbo.Musics", "Band_Id1", c => c.Guid());
            AlterColumn("dbo.Musics", "Band_Id", c => c.Guid(nullable: false));
            CreateIndex("dbo.Musics", "Band_Id1");
            AddForeignKey("dbo.Musics", "Band_Id1", "dbo.Bands", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Musics", "Band_Id1", "dbo.Bands");
            DropIndex("dbo.Musics", new[] { "Band_Id1" });
            AlterColumn("dbo.Musics", "Band_Id", c => c.Guid());
            DropColumn("dbo.Musics", "Band_Id1");
            CreateIndex("dbo.Musics", "Band_Id");
            AddForeignKey("dbo.Musics", "Band_Id", "dbo.Bands", "Id");
        }
    }
}
