namespace Base.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 128),
                        Rate = c.String(nullable: false, maxLength: 64),
                        NumberOfEmploye = c.Int(nullable: false),
                        AddressId = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        ResultDate = c.DateTime(nullable: false),
                        WorkDate = c.DateTime(nullable: false),
                        EmployerId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Address", t => t.AddressId)
                .ForeignKey("dbo.AspNetUsers", t => t.EmployerId, cascadeDelete: true)
                .Index(t => t.AddressId)
                .Index(t => t.EmployerId);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Order", "EmployerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Order", "AddressId", "dbo.Address");
            DropIndex("dbo.Order", new[] { "EmployerId" });
            DropIndex("dbo.Order", new[] { "AddressId" });
            DropTable("dbo.Order");
        }
    }
}
