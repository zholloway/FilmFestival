namespace FilmFestival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emailaddedtoStripeCharges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StripeCharges", "CardHolderEmail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.StripeCharges", "CardHolderEmail");
        }
    }
}
