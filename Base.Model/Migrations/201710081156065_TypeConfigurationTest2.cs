namespace Base.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TypeConfigurationTest2 : DbMigration
    {
        public override void Up()
        {
            AddForeignKey("dbo.AspNetUsers", "PersonalDataId", "dbo.PersonalData", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUsers", "PersonalProfileId", "dbo.PersonalProfile", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "PersonalDataId", "dbo.PersonalData");
            DropForeignKey("dbo.AspNetUsers", "PersonalProfileId", "dbo.PersonalProfile");
        }
    }
}
