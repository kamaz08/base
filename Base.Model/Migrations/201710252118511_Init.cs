namespace Base.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street = c.String(maxLength: 64),
                        ZipCode = c.String(maxLength: 8),
                        HouseNumber = c.String(maxLength: 8),
                        FlatNumber = c.String(maxLength: 8),
                        CityId = c.Int(),
                        StateId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.City", t => t.CityId)
                .ForeignKey("dbo.State", t => t.StateId)
                .Index(t => t.CityId)
                .Index(t => t.StateId);
            
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
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(nullable: false, maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        DateCreated = c.DateTime(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        PersonalData_Id = c.Int(),
                        PersonalProfile_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PersonalData", t => t.PersonalData_Id)
                .ForeignKey("dbo.PersonalProfile", t => t.PersonalProfile_Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.PersonalData_Id)
                .Index(t => t.PersonalProfile_Id);
            
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
                .ForeignKey("dbo.Order", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.PrivateMessage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FromAppUserId = c.String(nullable: false, maxLength: 128),
                        ToAppUserId = c.String(nullable: false, maxLength: 128),
                        Date = c.DateTime(nullable: false),
                        OrderId = c.Int(),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Order", t => t.OrderId)
                .ForeignKey("dbo.AspNetUsers", t => t.ToAppUserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.FromAppUserId)
                .Index(t => t.FromAppUserId)
                .Index(t => t.ToAppUserId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.PersonalData",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AppUserId = c.String(nullable: false, maxLength: 128),
                        AddressId = c.Int(),
                        FirstName = c.String(maxLength: 32),
                        LastName = c.String(maxLength: 32),
                        BirthDate = c.DateTime(),
                        Pesel = c.String(maxLength: 11),
                        PhoneNumber = c.String(maxLength: 16),
                        DateCreated = c.DateTime(nullable: false),
                        DateModifield = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Address", t => t.AddressId)
                .ForeignKey("dbo.AspNetUsers", t => t.AppUserId)
                .Index(t => t.AppUserId)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.PersonalProfile",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AppUserId = c.String(nullable: false, maxLength: 128),
                        PhotoUrl = c.String(),
                        ShowFirstName = c.Boolean(nullable: false),
                        ShowLastName = c.Boolean(nullable: false),
                        ShowBirthDate = c.Boolean(nullable: false),
                        ShowPhoneNumber = c.Boolean(nullable: false),
                        ShowEmail = c.Boolean(nullable: false),
                        Education = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AppUserId)
                .Index(t => t.AppUserId);
            
            CreateTable(
                "dbo.Vote",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        AppUserId = c.String(nullable: false, maxLength: 128),
                        RaterId = c.String(nullable: false, maxLength: 128),
                        OrderName = c.String(),
                        VoteDate = c.DateTime(nullable: false),
                        Note = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.RaterId)
                .ForeignKey("dbo.AspNetUsers", t => t.AppUserId, cascadeDelete: true)
                .Index(t => t.AppUserId)
                .Index(t => t.RaterId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.RefreshToken",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(nullable: false, maxLength: 32),
                        IssuedUtc = c.DateTime(nullable: false),
                        ExpiresUtc = c.DateTime(nullable: false),
                        ProtectedTicket = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Vote", "AppUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Order", "EmployerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PrivateMessage", "FromAppUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Vote", "RaterId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PrivateMessage", "ToAppUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "PersonalProfile_Id", "dbo.PersonalProfile");
            DropForeignKey("dbo.PersonalProfile", "AppUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "PersonalData_Id", "dbo.PersonalData");
            DropForeignKey("dbo.PersonalData", "AppUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PersonalData", "AddressId", "dbo.Address");
            DropForeignKey("dbo.AppUserOrderCustomer", "AppUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AppUserOrderCandidate", "AppUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AppUserPublicMessage", "AppUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AppUserPublicMessage", "PublicMessageId", "dbo.PublicMessage");
            DropForeignKey("dbo.PublicMessage", "OrderId", "dbo.Order");
            DropForeignKey("dbo.PrivateMessage", "OrderId", "dbo.Order");
            DropForeignKey("dbo.OrderDetail", "Id", "dbo.Order");
            DropForeignKey("dbo.AppUserOrderCustomer", "OrderId", "dbo.Order");
            DropForeignKey("dbo.AppUserOrderCandidate", "OrderId", "dbo.Order");
            DropForeignKey("dbo.Order", "AddressId", "dbo.Address");
            DropForeignKey("dbo.Message", "PublicMessageId", "dbo.PublicMessage");
            DropForeignKey("dbo.Message", "AppUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Address", "StateId", "dbo.State");
            DropForeignKey("dbo.Address", "CityId", "dbo.City");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.Vote", new[] { "RaterId" });
            DropIndex("dbo.Vote", new[] { "AppUserId" });
            DropIndex("dbo.PersonalProfile", new[] { "AppUserId" });
            DropIndex("dbo.PersonalData", new[] { "AddressId" });
            DropIndex("dbo.PersonalData", new[] { "AppUserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.PrivateMessage", new[] { "OrderId" });
            DropIndex("dbo.PrivateMessage", new[] { "ToAppUserId" });
            DropIndex("dbo.PrivateMessage", new[] { "FromAppUserId" });
            DropIndex("dbo.OrderDetail", new[] { "Id" });
            DropIndex("dbo.AppUserOrderCustomer", new[] { "OrderId" });
            DropIndex("dbo.AppUserOrderCustomer", new[] { "AppUserId" });
            DropIndex("dbo.AppUserOrderCandidate", new[] { "OrderId" });
            DropIndex("dbo.AppUserOrderCandidate", new[] { "AppUserId" });
            DropIndex("dbo.Order", new[] { "EmployerId" });
            DropIndex("dbo.Order", new[] { "AddressId" });
            DropIndex("dbo.Message", new[] { "AppUserId" });
            DropIndex("dbo.Message", new[] { "PublicMessageId" });
            DropIndex("dbo.PublicMessage", new[] { "OrderId" });
            DropIndex("dbo.AppUserPublicMessage", new[] { "PublicMessageId" });
            DropIndex("dbo.AppUserPublicMessage", new[] { "AppUserId" });
            DropIndex("dbo.AspNetUsers", new[] { "PersonalProfile_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "PersonalData_Id" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Address", new[] { "StateId" });
            DropIndex("dbo.Address", new[] { "CityId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.RefreshToken");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Vote");
            DropTable("dbo.PersonalProfile");
            DropTable("dbo.PersonalData");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.PrivateMessage");
            DropTable("dbo.OrderDetail");
            DropTable("dbo.AppUserOrderCustomer");
            DropTable("dbo.AppUserOrderCandidate");
            DropTable("dbo.Order");
            DropTable("dbo.Message");
            DropTable("dbo.PublicMessage");
            DropTable("dbo.AppUserPublicMessage");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.State");
            DropTable("dbo.City");
            DropTable("dbo.Address");
        }
    }
}
