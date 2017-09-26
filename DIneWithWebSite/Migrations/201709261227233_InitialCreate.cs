namespace DIneWithWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RelatedPost = c.Int(nullable: false),
                        Title = c.String(),
                        Writer = c.String(),
                        WebSite = c.String(),
                        Content = c.String(),
                        Post_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Posts", t => t.Post_ID)
                .Index(t => t.Post_ID);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Writer = c.String(),
                        WebSite = c.String(),
                        PublishDate = c.DateTime(nullable: false),
                        Content = c.String(),
                        Cuisine = c.String(),
                        Meals = c.String(),
                        RFeatures = c.String(),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                        Image = c.String(),
                        Video = c.String(),
                        SundayOpening = c.String(),
                        SundayClosing = c.String(),
                        MondayOpening = c.String(),
                        MondayClosing = c.String(),
                        TuesdayOpening = c.String(),
                        TuesdayClosing = c.String(),
                        WednesdayOpening = c.String(),
                        WednesdayClosing = c.String(),
                        ThursdayOpening = c.String(),
                        ThursdayClosing = c.String(),
                        FridayOpening = c.String(),
                        FridayClosing = c.String(),
                        SaturdayOpening = c.String(),
                        SaturdayClosing = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Post_ID", "dbo.Posts");
            DropIndex("dbo.Comments", new[] { "Post_ID" });
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
        }
    }
}
