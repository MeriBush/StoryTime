namespace StoryTime.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class five : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LocationPrompt", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LocationPrompt", "ModifiedUtc");
        }
    }
}
