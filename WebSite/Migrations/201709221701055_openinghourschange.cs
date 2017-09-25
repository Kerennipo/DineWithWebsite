namespace WebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class openinghourschange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BusinessDays", "Post_ID", "dbo.Posts");
            DropIndex("dbo.BusinessDays", new[] { "Post_ID" });
            DropTable("dbo.BusinessDays");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.BusinessDays",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        open = c.DateTime(nullable: false),
                        close = c.DateTime(nullable: false),
                        Post_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.BusinessDays", "Post_ID");
            AddForeignKey("dbo.BusinessDays", "Post_ID", "dbo.Posts", "ID");
        }
    }
}
