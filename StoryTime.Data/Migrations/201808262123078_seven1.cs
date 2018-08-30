namespace StoryTime.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seven1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StorySubmission", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StorySubmission", "ModifiedUtc");
        }
    }
}
