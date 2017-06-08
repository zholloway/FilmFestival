namespace FilmFestival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Showtimes", "DateAndTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Showtimes", "Date");
            DropColumn("dbo.Showtimes", "Time");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Showtimes", "Time", c => c.DateTime(nullable: false));
            AddColumn("dbo.Showtimes", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Showtimes", "DateAndTime");
        }
    }
}
