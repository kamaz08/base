namespace Base.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserOrderTest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppUserOrderCandidate",
                c => new
                    {
                        AppUserId = c.String(nullable: false, maxLength: 128),
                        OrderId = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AppUserId, t.OrderId })
                .ForeignKey("dbo.Order", t => t.OrderId)
                .ForeignKey("dbo.AspNetUsers", t => t.AppUserId)
                .Index(t => t.AppUserId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.AppUserOrderCustomer",
                c => new
                    {
                        AppUserId = c.String(nullable: false, maxLength: 128),
                        OrderId = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AppUserId, t.OrderId })
                .ForeignKey("dbo.Order", t => t.OrderId)
                .ForeignKey("dbo.AspNetUsers", t => t.AppUserId)
                .Index(t => t.AppUserId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.OrderDetail",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Description = c.String(),
                        ExecutionTime = c.String(),
                        Requirements = c.String(),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Order", t => t.OrderId)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AppUserOrderCustomer", "AppUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AppUserOrderCandidate", "AppUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.OrderDetail", "Id", "dbo.Order");
            DropForeignKey("dbo.AppUserOrderCustomer", "OrderId", "dbo.Order");
            DropForeignKey("dbo.AppUserOrderCandidate", "OrderId", "dbo.Order");
            DropIndex("dbo.OrderDetail", new[] { "Id" });
            DropIndex("dbo.AppUserOrderCustomer", new[] { "OrderId" });
            DropIndex("dbo.AppUserOrderCustomer", new[] { "AppUserId" });
            DropIndex("dbo.AppUserOrderCandidate", new[] { "OrderId" });
            DropIndex("dbo.AppUserOrderCandidate", new[] { "AppUserId" });
            DropTable("dbo.OrderDetail");
            DropTable("dbo.AppUserOrderCustomer");
            DropTable("dbo.AppUserOrderCandidate");
        }
    }
}
