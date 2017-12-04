namespace Base.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class voteWorkDateTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vote", "WorkDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vote", "WorkDate");
        }
    }
}
