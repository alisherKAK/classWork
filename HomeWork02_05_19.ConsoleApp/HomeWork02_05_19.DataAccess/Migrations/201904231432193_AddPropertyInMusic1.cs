namespace HomeWork02_05_19.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropertyInMusic1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Musics", "Band_Id", "dbo.Bands");
            DropIndex("dbo.Musics", new[] { "Band_Id" });
            RenameColumn(table: "dbo.Musics", name: "Band_Id", newName: "BandId");
            AlterColumn("dbo.Musics", "BandId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Musics", "BandId");
            AddForeignKey("dbo.Musics", "BandId", "dbo.Bands", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Musics", "BandId", "dbo.Bands");
            DropIndex("dbo.Musics", new[] { "BandId" });
            AlterColumn("dbo.Musics", "BandId", c => c.Guid());
            RenameColumn(table: "dbo.Musics", name: "BandId", newName: "Band_Id");
            CreateIndex("dbo.Musics", "Band_Id");
            AddForeignKey("dbo.Musics", "Band_Id", "dbo.Bands", "Id");
        }
    }
}
