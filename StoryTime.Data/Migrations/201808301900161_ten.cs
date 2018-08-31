namespace StoryTime.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ten : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StorySubmission", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.StorySubmission", "User_Id");
            AddForeignKey("dbo.StorySubmission", "User_Id", "dbo.ApplicationUser", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StorySubmission", "User_Id", "dbo.ApplicationUser");
            DropIndex("dbo.StorySubmission", new[] { "User_Id" });
            DropColumn("dbo.StorySubmission", "User_Id");
        }
    }
}
