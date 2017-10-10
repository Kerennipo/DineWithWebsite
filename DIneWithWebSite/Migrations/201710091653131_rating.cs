namespace DIneWithWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rating : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Rating", c => c.Single(nullable: false));
            AddColumn("dbo.Posts", "totalNumberOfVotes", c => c.Single(nullable: false));
            AddColumn("dbo.Posts", "totalVoteCount", c => c.Single(nullable: false));
            DropColumn("dbo.Posts", "AverageRating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "AverageRating", c => c.String());
            DropColumn("dbo.Posts", "totalVoteCount");
            DropColumn("dbo.Posts", "totalNumberOfVotes");
            DropColumn("dbo.Posts", "Rating");
        }
    }
}
