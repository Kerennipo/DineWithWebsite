namespace DIneWithWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CommentPosts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Title = c.String(),
                        Content = c.String(),
                        RelatedPostId = c.Int(nullable: false),
                        PostName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CommentPosts");
        }
    }
}
