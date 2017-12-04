namespace Base.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PublicKey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "PublicKey", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "PublicKey");
        }
    }
}
