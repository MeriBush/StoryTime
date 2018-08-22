namespace StoryTime.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class three : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StorySubmission",
                c => new
                    {
                        StoryId = c.Int(nullable: false, identity: true),
                        StudentId = c.Guid(nullable: false),
                        StoryTitle = c.String(nullable: false),
                        StoryText = c.String(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.StoryId);
            
            AddColumn("dbo.CharacterPrompt", "ModifiedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CharacterPrompt", "ModifiedUtc");
            DropTable("dbo.StorySubmission");
        }
    }
}
