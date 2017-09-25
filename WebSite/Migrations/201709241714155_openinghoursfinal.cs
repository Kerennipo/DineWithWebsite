namespace WebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class openinghoursfinal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "SundayClosing", c => c.String());
            AddColumn("dbo.Posts", "MondayOpening", c => c.String());
            AddColumn("dbo.Posts", "MondayClosing", c => c.String());
            AddColumn("dbo.Posts", "TuesdayOpening", c => c.String());
            AddColumn("dbo.Posts", "TuesdayClosing", c => c.String());
            AddColumn("dbo.Posts", "WednesdayOpening", c => c.String());
            AddColumn("dbo.Posts", "WednesdayClosing", c => c.String());
            AddColumn("dbo.Posts", "ThursdayOpening", c => c.String());
            AddColumn("dbo.Posts", "ThursdayClosing", c => c.String());
            AddColumn("dbo.Posts", "FridayOpening", c => c.String());
            AddColumn("dbo.Posts", "FridayClosing", c => c.String());
            AddColumn("dbo.Posts", "SaturdayOpening", c => c.String());
            AddColumn("dbo.Posts", "SaturdayClosing", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "SaturdayClosing");
            DropColumn("dbo.Posts", "SaturdayOpening");
            DropColumn("dbo.Posts", "FridayClosing");
            DropColumn("dbo.Posts", "FridayOpening");
            DropColumn("dbo.Posts", "ThursdayClosing");
            DropColumn("dbo.Posts", "ThursdayOpening");
            DropColumn("dbo.Posts", "WednesdayClosing");
            DropColumn("dbo.Posts", "WednesdayOpening");
            DropColumn("dbo.Posts", "TuesdayClosing");
            DropColumn("dbo.Posts", "TuesdayOpening");
            DropColumn("dbo.Posts", "MondayClosing");
            DropColumn("dbo.Posts", "MondayOpening");
            DropColumn("dbo.Posts", "SundayClosing");
        }
    }
}
