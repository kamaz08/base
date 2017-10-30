namespace Base.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeCandidate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AppUserOrderCandidate", "OrderId", "dbo.Order");
            DropForeignKey("dbo.AppUserOrderCandidate", "AppUserId", "dbo.AspNetUsers");
            DropIndex("dbo.AppUserOrderCandidate", new[] { "AppUserId" });
            DropIndex("dbo.AppUserOrderCandidate", new[] { "OrderId" });
            AddColumn("dbo.AppUserOrderCustomer", "IsAccepted", c => c.Boolean(nullable: false));
            DropTable("dbo.AppUserOrderCandidate");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AppUserOrderCandidate",
                c => new
                    {
                        AppUserId = c.String(nullable: false, maxLength: 128),
                        OrderId = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AppUserId, t.OrderId });
            
            DropColumn("dbo.AppUserOrderCustomer", "IsAccepted");
            CreateIndex("dbo.AppUserOrderCandidate", "OrderId");
            CreateIndex("dbo.AppUserOrderCandidate", "AppUserId");
            AddForeignKey("dbo.AppUserOrderCandidate", "AppUserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AppUserOrderCandidate", "OrderId", "dbo.Order", "Id");
        }
    }
}
