namespace Base.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Voting : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vote",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AppUserId = c.String(nullable: false, maxLength: 128),
                        RaterId = c.String(nullable: false, maxLength: 128),
                        OrderName = c.String(),
                        VoteDate = c.DateTime(nullable: false),
                        Note = c.Int(nullable: false),
                        Description = c.String(),
                        Type_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vote", t => t.Type_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.RaterId)
                .ForeignKey("dbo.AspNetUsers", t => t.AppUserId, cascadeDelete: true)
                .Index(t => t.AppUserId)
                .Index(t => t.RaterId)
                .Index(t => t.Type_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vote", "AppUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Vote", "RaterId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Vote", "Type_Id", "dbo.Vote");
            DropIndex("dbo.Vote", new[] { "Type_Id" });
            DropIndex("dbo.Vote", new[] { "RaterId" });
            DropIndex("dbo.Vote", new[] { "AppUserId" });
            DropTable("dbo.Vote");
        }
    }
}
