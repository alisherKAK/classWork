namespace HomeWork28_04_19.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeIdTypeFromIntToGuid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ledgers", "Person_Id", "dbo.People");
            DropIndex("dbo.Ledgers", new[] { "Person_Id" });
            DropColumn("dbo.Ledgers", "PersonId");
            RenameColumn(table: "dbo.Ledgers", name: "Person_Id", newName: "PersonId");
            AlterColumn("dbo.Ledgers", "PersonId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Ledgers", "PersonId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Ledgers", "PersonId");
            AddForeignKey("dbo.Ledgers", "PersonId", "dbo.People", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ledgers", "PersonId", "dbo.People");
            DropIndex("dbo.Ledgers", new[] { "PersonId" });
            AlterColumn("dbo.Ledgers", "PersonId", c => c.Guid());
            AlterColumn("dbo.Ledgers", "PersonId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Ledgers", name: "PersonId", newName: "Person_Id");
            AddColumn("dbo.Ledgers", "PersonId", c => c.Int(nullable: false));
            CreateIndex("dbo.Ledgers", "Person_Id");
            AddForeignKey("dbo.Ledgers", "Person_Id", "dbo.People", "Id");
        }
    }
}
