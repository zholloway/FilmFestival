namespace FilmFestival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingStripeChargestable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StripeCharges",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Token = c.String(nullable: false),
                        Amount = c.Double(nullable: false),
                        CardHolderName = c.String(nullable: false),
                        AddressLine1 = c.String(),
                        AddressLine2 = c.String(),
                        AddressCity = c.String(),
                        AddressPostcode = c.String(),
                        AddressCountry = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StripeCharges");
        }
    }
}
