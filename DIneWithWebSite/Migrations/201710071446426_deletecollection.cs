namespace DIneWithWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletecollection : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VoteLogs", "Post_ID", "dbo.Posts");
            DropIndex("dbo.VoteLogs", new[] { "Post_ID" });
            DropColumn("dbo.VoteLogs", "Post_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VoteLogs", "Post_ID", c => c.Int());
            CreateIndex("dbo.VoteLogs", "Post_ID");
            AddForeignKey("dbo.VoteLogs", "Post_ID", "dbo.Posts", "ID");
        }
    }
}
