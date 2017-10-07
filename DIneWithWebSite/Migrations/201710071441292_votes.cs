namespace DIneWithWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class votes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "voteLog_ID", "dbo.VoteLogs");
            DropIndex("dbo.Posts", new[] { "voteLog_ID" });
            AddColumn("dbo.VoteLogs", "Post_ID", c => c.Int());
            CreateIndex("dbo.VoteLogs", "Post_ID");
            AddForeignKey("dbo.VoteLogs", "Post_ID", "dbo.Posts", "ID");
            DropColumn("dbo.Posts", "voteLog_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "voteLog_ID", c => c.Int());
            DropForeignKey("dbo.VoteLogs", "Post_ID", "dbo.Posts");
            DropIndex("dbo.VoteLogs", new[] { "Post_ID" });
            DropColumn("dbo.VoteLogs", "Post_ID");
            CreateIndex("dbo.Posts", "voteLog_ID");
            AddForeignKey("dbo.Posts", "voteLog_ID", "dbo.VoteLogs", "ID");
        }
    }
}
