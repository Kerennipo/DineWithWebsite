namespace DIneWithWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addlocation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Latitude", c => c.String());
            AddColumn("dbo.Posts", "Longitude", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Longitude");
            DropColumn("dbo.Posts", "Latitude");
        }
    }
}
