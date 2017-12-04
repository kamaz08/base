namespace Base.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class preferences : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Preference",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AppUserId = c.String(nullable: false, maxLength: 128),
                        OrderCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrderCategory", t => t.OrderCategoryId)
                .ForeignKey("dbo.AspNetUsers", t => t.AppUserId)
                .Index(t => t.AppUserId)
                .Index(t => t.OrderCategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Preference", "AppUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Preference", "OrderCategoryId", "dbo.OrderCategory");
            DropIndex("dbo.Preference", new[] { "OrderCategoryId" });
            DropIndex("dbo.Preference", new[] { "AppUserId" });
            DropTable("dbo.Preference");
        }
    }
}
