namespace HomeWork02_05_19.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletePropertyInMusic : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Musics", new[] { "Band_Id1" });
            DropColumn("dbo.Musics", "Band_Id");
            RenameColumn(table: "dbo.Musics", name: "Band_Id1", newName: "Band_Id");
            AlterColumn("dbo.Musics", "Band_Id", c => c.Guid());
            CreateIndex("dbo.Musics", "Band_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Musics", new[] { "Band_Id" });
            AlterColumn("dbo.Musics", "Band_Id", c => c.Guid(nullable: false));
            RenameColumn(table: "dbo.Musics", name: "Band_Id", newName: "Band_Id1");
            AddColumn("dbo.Musics", "Band_Id", c => c.Guid(nullable: false));
            CreateIndex("dbo.Musics", "Band_Id1");
        }
    }
}
