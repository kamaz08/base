namespace Base.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitBazydanych : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TestDb",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(maxLength: 50),
                        Opis = c.String(maxLength: 512),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TestDb");
        }
    }
}
