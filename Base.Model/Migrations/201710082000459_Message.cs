namespace Base.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Message : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppUserPublicMessage",
                c => new
                    {
                        AppUserId = c.String(nullable: false, maxLength: 128),
                        PublicMessageId = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AppUserId, t.PublicMessageId })
                .ForeignKey("dbo.PublicMessage", t => t.PublicMessageId)
                .ForeignKey("dbo.AspNetUsers", t => t.AppUserId)
                .Index(t => t.AppUserId)
                .Index(t => t.PublicMessageId);
            
            CreateTable(
                "dbo.PublicMessage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        OrderId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Order", t => t.OrderId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Message",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PublicMessageId = c.Int(nullable: false),
                        AppUserId = c.String(nullable: false, maxLength: 128),
                        Date = c.DateTime(nullable: false),
                        Mess = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AppUserId)
                .ForeignKey("dbo.PublicMessage", t => t.PublicMessageId)
                .Index(t => t.PublicMessageId)
                .Index(t => t.AppUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AppUserPublicMessage", "AppUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AppUserPublicMessage", "PublicMessageId", "dbo.PublicMessage");
            DropForeignKey("dbo.PublicMessage", "OrderId", "dbo.Order");
            DropForeignKey("dbo.Message", "PublicMessageId", "dbo.PublicMessage");
            DropForeignKey("dbo.Message", "AppUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Message", new[] { "AppUserId" });
            DropIndex("dbo.Message", new[] { "PublicMessageId" });
            DropIndex("dbo.PublicMessage", new[] { "OrderId" });
            DropIndex("dbo.AppUserPublicMessage", new[] { "PublicMessageId" });
            DropIndex("dbo.AppUserPublicMessage", new[] { "AppUserId" });
            DropTable("dbo.Message");
            DropTable("dbo.PublicMessage");
            DropTable("dbo.AppUserPublicMessage");
        }
    }
}
