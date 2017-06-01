namespace FilmFestival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class theatrechangedtoint : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Showtimes", "Theatre", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Showtimes", "Theatre", c => c.String());
        }
    }
}
