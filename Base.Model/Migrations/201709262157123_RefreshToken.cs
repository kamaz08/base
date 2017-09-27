namespace Base.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefreshToken : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RefreshToken",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(nullable: false, maxLength: 256),
                        IssuedUtc = c.DateTime(nullable: false),
                        ExpiresUtc = c.DateTime(nullable: false),
                        ProtectedTicket = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RefreshToken");
        }
    }
}
