namespace DIneWithWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addrating : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Votes", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Votes");
        }
    }
}
