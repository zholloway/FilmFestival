namespace FilmFestival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newsStorybodysettonvarchar : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.NewsStories", "StoryBody", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.NewsStories", "StoryBody", c => c.String(unicode: false));
        }
    }
}
