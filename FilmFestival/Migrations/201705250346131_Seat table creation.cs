namespace FilmFestival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seattablecreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Seats",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Row = c.String(),
                        SeatNumber = c.Int(nullable: false),
                        Reserved = c.Boolean(nullable: false),
                        ShowtimeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Showtimes", t => t.ShowtimeID, cascadeDelete: true)
                .Index(t => t.ShowtimeID);
            
            DropColumn("dbo.Showtimes", "AvailableSeats");
            DropColumn("dbo.Showtimes", "ReservedSeats");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Showtimes", "ReservedSeats", c => c.Int(nullable: false));
            AddColumn("dbo.Showtimes", "AvailableSeats", c => c.Int(nullable: false));
            DropForeignKey("dbo.Seats", "ShowtimeID", "dbo.Showtimes");
            DropIndex("dbo.Seats", new[] { "ShowtimeID" });
            DropTable("dbo.Seats");
        }
    }
}
