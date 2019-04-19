namespace EfLoadingTypesLesson.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletePropertyFromBook : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            DropIndex("dbo.Books", new[] { "AuthorId" });
            RenameColumn(table: "dbo.Books", name: "AuthorId", newName: "Author_Id");
            AlterColumn("dbo.Books", "Author_Id", c => c.Guid());
            CreateIndex("dbo.Books", "Author_Id");
            AddForeignKey("dbo.Books", "Author_Id", "dbo.Authors", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "Author_Id", "dbo.Authors");
            DropIndex("dbo.Books", new[] { "Author_Id" });
            AlterColumn("dbo.Books", "Author_Id", c => c.Guid(nullable: false));
            RenameColumn(table: "dbo.Books", name: "Author_Id", newName: "AuthorId");
            CreateIndex("dbo.Books", "AuthorId");
            AddForeignKey("dbo.Books", "AuthorId", "dbo.Authors", "Id", cascadeDelete: true);
        }
    }
}
