namespace FilmFestival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stripeTransactionIDaddedtoStripeCharges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StripeCharges", "StripeTransactionID", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StripeCharges", "StripeTransactionID");
        }
    }
}
