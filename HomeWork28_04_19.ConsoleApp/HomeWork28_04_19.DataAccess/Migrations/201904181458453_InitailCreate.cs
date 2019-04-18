namespace HomeWork28_04_19.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitailCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ledgers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        EnterTime = c.DateTime(nullable: false),
                        ExitTime = c.DateTime(),
                        PersonId = c.Int(nullable: false),
                        VisitPurpose = c.String(),
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
                        CertificateNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ledgers", "Person_Id", "dbo.People");
            DropIndex("dbo.Ledgers", new[] { "Person_Id" });
            DropTable("dbo.People");
            DropTable("dbo.Ledgers");
        }
    }
}
