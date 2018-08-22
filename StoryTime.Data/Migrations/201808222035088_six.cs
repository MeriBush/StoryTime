namespace StoryTime.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class six : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TwistPrompt", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TwistPrompt", "ModifiedUtc");
        }
    }
}
