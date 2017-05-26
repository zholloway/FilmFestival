namespace FilmFestival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateSeat : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Seats", "UserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Seats", "UserID");
            AddForeignKey("dbo.Seats", "UserID", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Seats", "UserID", "dbo.AspNetUsers");
            DropIndex("dbo.Seats", new[] { "UserID" });
            DropColumn("dbo.Seats", "UserID");
        }
    }
}
