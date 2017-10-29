namespace Base.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderCategory2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OrderCategory", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrderCategory", "Name", c => c.String());
        }
    }
}
