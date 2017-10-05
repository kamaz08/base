namespace Base.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Users : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        City = c.String(maxLength: 64),
                        State = c.String(maxLength: 64),
                        Street = c.String(maxLength: 64),
                        ZipCode = c.String(maxLength: 8),
                        HouseNumber = c.String(maxLength: 8),
                        FlatNumber = c.String(maxLength: 8),
                        DateCreated = c.DateTime(nullable: false),
                        DateModifield = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PersonalData", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.PersonalData",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 32),
                        LastName = c.String(maxLength: 32),
                        BirthDate = c.DateTime(nullable: false),
                        Pesel = c.String(maxLength: 11),
                        PhoneNumber = c.String(maxLength: 15),
                        DateCreated = c.DateTime(nullable: false),
                        DateModifield = c.DateTime(nullable: false),
                        Address_Id = c.Int(),
                        AppUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Address", t => t.Address_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AppUser_Id, cascadeDelete: true)
                .Index(t => t.Address_Id)
                .Index(t => t.AppUser_Id);
            
            CreateTable(
                "dbo.PersonalProfile",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhotoUrl = c.String(),
                        ShowFirstName = c.Boolean(nullable: false),
                        ShowLastName = c.Boolean(nullable: false),
                        ShowBirthDate = c.Boolean(nullable: false),
                        ShowPhoneNumber = c.Boolean(nullable: false),
                        ShowEmail = c.Boolean(nullable: false),
                        Education = c.String(),
                        Description = c.String(),
                        AppUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AppUser_Id, cascadeDelete: true)
                .Index(t => t.AppUser_Id);
            
            DropColumn("dbo.AspNetUsers", "ForeName");
            DropColumn("dbo.AspNetUsers", "SurName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "SurName", c => c.String(maxLength: 256));
            AddColumn("dbo.AspNetUsers", "ForeName", c => c.String(maxLength: 256));
            DropForeignKey("dbo.Address", "Id", "dbo.PersonalData");
            DropForeignKey("dbo.PersonalData", "AppUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.PersonalProfile", "AppUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.PersonalData", "Address_Id", "dbo.Address");
            DropIndex("dbo.PersonalProfile", new[] { "AppUser_Id" });
            DropIndex("dbo.PersonalData", new[] { "AppUser_Id" });
            DropIndex("dbo.PersonalData", new[] { "Address_Id" });
            DropIndex("dbo.Address", new[] { "Id" });
            DropTable("dbo.PersonalProfile");
            DropTable("dbo.PersonalData");
            DropTable("dbo.Address");
        }
    }
}
