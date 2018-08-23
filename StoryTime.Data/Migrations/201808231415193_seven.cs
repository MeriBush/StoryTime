namespace StoryTime.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seven : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.StorySubmission", "ModifiedUtc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StorySubmission", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
        }
    }
}
