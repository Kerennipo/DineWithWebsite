namespace DIneWithWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addvotes2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VoteLogs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SectionID = c.Int(nullable: false),
                        VoteForID = c.Int(nullable: false),
                        UserName = c.String(),
                        Vote = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Posts", "voteLog_ID", c => c.Int());
            CreateIndex("dbo.Posts", "voteLog_ID");
            AddForeignKey("dbo.Posts", "voteLog_ID", "dbo.VoteLogs", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "voteLog_ID", "dbo.VoteLogs");
            DropIndex("dbo.Posts", new[] { "voteLog_ID" });
            DropColumn("dbo.Posts", "voteLog_ID");
            DropTable("dbo.VoteLogs");
        }
    }
}
