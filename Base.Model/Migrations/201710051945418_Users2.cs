namespace Base.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Users2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Address", "Id", "dbo.PersonalData");
            DropForeignKey("dbo.PersonalData", "Address_Id", "dbo.Address");
            DropIndex("dbo.Address", new[] { "Id" });
            DropPrimaryKey("dbo.Address");
            CreateTable(
                "dbo.City",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 64),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.State",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 64),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Address", "City_Id", c => c.Int());
            AddColumn("dbo.Address", "State_Id", c => c.Int());
            AlterColumn("dbo.Address", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Address", "Id");
            CreateIndex("dbo.Address", "City_Id");
            CreateIndex("dbo.Address", "State_Id");
            AddForeignKey("dbo.Address", "City_Id", "dbo.City", "Id");
            AddForeignKey("dbo.Address", "State_Id", "dbo.State", "Id");
            AddForeignKey("dbo.PersonalData", "Address_Id", "dbo.Address", "Id");
            DropColumn("dbo.Address", "City");
            DropColumn("dbo.Address", "State");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Address", "State", c => c.String(maxLength: 64));
            AddColumn("dbo.Address", "City", c => c.String(maxLength: 64));
            DropForeignKey("dbo.PersonalData", "Address_Id", "dbo.Address");
            DropForeignKey("dbo.Address", "State_Id", "dbo.State");
            DropForeignKey("dbo.Address", "City_Id", "dbo.City");
            DropIndex("dbo.Address", new[] { "State_Id" });
            DropIndex("dbo.Address", new[] { "City_Id" });
            DropPrimaryKey("dbo.Address");
            AlterColumn("dbo.Address", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.Address", "State_Id");
            DropColumn("dbo.Address", "City_Id");
            DropTable("dbo.State");
            DropTable("dbo.City");
            AddPrimaryKey("dbo.Address", "Id");
            CreateIndex("dbo.Address", "Id");
            AddForeignKey("dbo.PersonalData", "Address_Id", "dbo.Address", "Id");
            AddForeignKey("dbo.Address", "Id", "dbo.PersonalData", "Id", cascadeDelete: true);
        }
    }
}
