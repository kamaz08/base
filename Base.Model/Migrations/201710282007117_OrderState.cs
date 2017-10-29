namespace Base.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderState : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order", "IsOpen", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Order", "IsOpen");
        }
    }
}
