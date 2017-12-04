namespace Base.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class publicMessage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PublicMessage", "IsGroup", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PublicMessage", "IsGroup");
        }
    }
}
