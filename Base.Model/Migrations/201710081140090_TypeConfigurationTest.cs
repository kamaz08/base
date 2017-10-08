namespace Base.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TypeConfigurationTest : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PersonalData", "Address_Id", "dbo.Address");
            DropForeignKey("dbo.PersonalData", "AppUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.PersonalProfile", "AppUser_Id", "dbo.AspNetUsers");
            RenameColumn(table: "dbo.Address", name: "City_Id", newName: "CityId");
            RenameColumn(table: "dbo.Address", name: "State_Id", newName: "StateId");
            AddColumn("dbo.AspNetUsers", "PersonalDataId", c =>c.Int());
            AddColumn("dbo.AspNetUsers", "PersonalProfileId", c =>c.Int());
            RenameColumn(table: "dbo.PersonalData", name: "Address_Id", newName: "AddressId");
            RenameColumn(table: "dbo.PersonalData", name: "AppUser_Id", newName: "AppUserId");
            RenameColumn(table: "dbo.PersonalProfile", name: "AppUser_Id", newName: "AppUserId");
            RenameIndex(table: "dbo.Address", name: "IX_City_Id", newName: "IX_CityId");
            RenameIndex(table: "dbo.Address", name: "IX_State_Id", newName: "IX_StateId");
            RenameIndex(table: "dbo.PersonalData", name: "IX_AppUser_Id", newName: "IX_AppUserId");
            RenameIndex(table: "dbo.PersonalData", name: "IX_Address_Id", newName: "IX_AddressId");
            RenameIndex(table: "dbo.PersonalProfile", name: "IX_AppUser_Id", newName: "IX_AppUserId");
            AlterColumn("dbo.Address", "Street", c => c.String(maxLength: 64));
            AlterColumn("dbo.Address", "ZipCode", c => c.String(maxLength: 8));
            AlterColumn("dbo.Address", "HouseNumber", c => c.String(maxLength: 8));
            AlterColumn("dbo.Address", "FlatNumber", c => c.String(maxLength: 8));
            AlterColumn("dbo.City", "Name", c => c.String(nullable: false, maxLength: 64));
            AlterColumn("dbo.AspNetUsers", "Email", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.PersonalData", "PhoneNumber", c => c.String(maxLength: 16));
            AlterColumn("dbo.RefreshToken", "UserName", c => c.String(nullable: false, maxLength: 32));
            CreateIndex("dbo.AspNetUsers", "PersonalDataId");
            CreateIndex("dbo.AspNetUsers", "PersonalProfileId");
            AddForeignKey("dbo.PersonalData", "AddressId", "dbo.Address", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PersonalData", "AppUserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.PersonalProfile", "AppUserId", "dbo.AspNetUsers", "Id");
            DropTable("dbo.TestDb");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TestDb",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(maxLength: 50),
                        Opis = c.String(maxLength: 512),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.PersonalProfile", "AppUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PersonalData", "AppUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PersonalData", "AddressId", "dbo.Address");
            DropIndex("dbo.AspNetUsers", new[] { "PersonalProfileId" });
            DropIndex("dbo.AspNetUsers", new[] { "PersonalDataId" });
            AlterColumn("dbo.RefreshToken", "UserName", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.PersonalData", "PhoneNumber", c => c.String(maxLength: 15));
            AlterColumn("dbo.AspNetUsers", "Email", c => c.String(maxLength: 256));
            AlterColumn("dbo.City", "Name", c => c.String());
            AlterColumn("dbo.Address", "FlatNumber", c => c.String());
            AlterColumn("dbo.Address", "HouseNumber", c => c.String());
            AlterColumn("dbo.Address", "ZipCode", c => c.String());
            AlterColumn("dbo.Address", "Street", c => c.String());
            RenameIndex(table: "dbo.PersonalProfile", name: "IX_AppUserId", newName: "IX_AppUser_Id");
            RenameIndex(table: "dbo.PersonalData", name: "IX_AddressId", newName: "IX_Address_Id");
            RenameIndex(table: "dbo.PersonalData", name: "IX_AppUserId", newName: "IX_AppUser_Id");
            RenameIndex(table: "dbo.Address", name: "IX_StateId", newName: "IX_State_Id");
            RenameIndex(table: "dbo.Address", name: "IX_CityId", newName: "IX_City_Id");
            RenameColumn(table: "dbo.PersonalProfile", name: "AppUserId", newName: "AppUser_Id");
            RenameColumn(table: "dbo.PersonalData", name: "AppUserId", newName: "AppUser_Id");
            RenameColumn(table: "dbo.PersonalData", name: "AddressId", newName: "Address_Id");
            RenameColumn(table: "dbo.AspNetUsers", name: "PersonalProfileId", newName: "AppUser_Id");
            RenameColumn(table: "dbo.AspNetUsers", name: "PersonalDataId", newName: "AppUser_Id");
            RenameColumn(table: "dbo.Address", name: "StateId", newName: "State_Id");
            RenameColumn(table: "dbo.Address", name: "CityId", newName: "City_Id");
            AddForeignKey("dbo.PersonalProfile", "AppUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PersonalData", "AppUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PersonalData", "Address_Id", "dbo.Address", "Id");
        }
    }
}
