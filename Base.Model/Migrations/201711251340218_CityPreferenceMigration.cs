namespace Base.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CityPreferenceMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CityPreference",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AppUserId = c.String(nullable: false, maxLength: 128),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.City", t => t.CityId)
                .ForeignKey("dbo.AspNetUsers", t => t.AppUserId)
                .Index(t => t.AppUserId)
                .Index(t => t.CityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CityPreference", "AppUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CityPreference", "CityId", "dbo.City");
            DropIndex("dbo.CityPreference", new[] { "CityId" });
            DropIndex("dbo.CityPreference", new[] { "AppUserId" });
            DropTable("dbo.CityPreference");
        }
    }
}
