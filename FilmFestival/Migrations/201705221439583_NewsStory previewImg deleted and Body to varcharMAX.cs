namespace FilmFestival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewsStorypreviewImgdeletedandBodytovarcharMAX : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.NewsStories", "StoryBody", c => c.String(unicode: false));
            DropColumn("dbo.NewsStories", "PreviewImgPath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NewsStories", "PreviewImgPath", c => c.String());
            AlterColumn("dbo.NewsStories", "StoryBody", c => c.String());
        }
    }
}
