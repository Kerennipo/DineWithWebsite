namespace WebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class openingHours : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Posts", t => t.Post_ID)
                .Index(t => t.Post_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BusinessDays", "Post_ID", "dbo.Posts");
            DropIndex("dbo.BusinessDays", new[] { "Post_ID" });
            DropTable("dbo.BusinessDays");
        }
    }
}
