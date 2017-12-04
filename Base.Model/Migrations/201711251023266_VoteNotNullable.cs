namespace Base.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VoteNotNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vote", "VoteDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vote", "VoteDate", c => c.DateTime());
        }
    }
}
