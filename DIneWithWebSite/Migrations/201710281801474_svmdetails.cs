namespace DIneWithWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class svmdetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fans", "IsVegeterian", c => c.Boolean(nullable: false));
            AddColumn("dbo.Fans", "FanOfWinning", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Fans", "FanOfWinning");
            DropColumn("dbo.Fans", "IsVegeterian");
        }
    }
}
