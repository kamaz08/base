namespace Base.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Order", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Order", "CategoryId");
            AddForeignKey("dbo.Order", "CategoryId", "dbo.OrderCategory", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Order", "CategoryId", "dbo.OrderCategory");
            DropIndex("dbo.Order", new[] { "CategoryId" });
            DropColumn("dbo.Order", "CategoryId");
            DropTable("dbo.OrderCategory");
        }
    }
}
