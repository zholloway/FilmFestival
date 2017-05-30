namespace FilmFestival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class badgestable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Badges",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BadgeLevel = c.String(),
                        UserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.UserID);
            
            AddColumn("dbo.AspNetUsers", "BadgeID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Badges", "UserID", "dbo.AspNetUsers");
            DropIndex("dbo.Badges", new[] { "UserID" });
            DropColumn("dbo.AspNetUsers", "BadgeID");
            DropTable("dbo.Badges");
        }
    }
}
