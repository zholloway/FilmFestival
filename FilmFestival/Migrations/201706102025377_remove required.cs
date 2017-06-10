namespace FilmFestival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removerequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StripeCharges", "StripeTransactionID", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StripeCharges", "StripeTransactionID", c => c.String(nullable: false));
        }
    }
}
