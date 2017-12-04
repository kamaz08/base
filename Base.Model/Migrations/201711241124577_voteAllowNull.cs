namespace Base.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class voteAllowNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vote", "VoteDate", c => c.DateTime());
            AlterColumn("dbo.Vote", "Note", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vote", "Note", c => c.Int(nullable: false));
            AlterColumn("dbo.Vote", "VoteDate", c => c.DateTime(nullable: false));
        }
    }
}
