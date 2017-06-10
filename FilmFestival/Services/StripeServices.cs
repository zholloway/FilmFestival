using FilmFestival.Models;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace FilmFestival.Services
{
    public class StripeServices
    {
        public ApplicationDbContext DB { get; } = new ApplicationDbContext();

        public async Task<string> ProcessPayment(Models.StripeCharge charge)
        {
            return await Task.Run(() =>
            {
                var myCharge = new StripeChargeCreateOptions
                {
                    // convert the amount of £12.50 to pennies i.e. 1250
                    Amount = (int)(charge.Amount * 100),
                    Currency = "usd",
                    Description = "Description for test charge",
                    SourceTokenOrExistingSourceId = charge.Token
                };

                var chargeService = new StripeChargeService("sk_test_Acj0PF5U4vBfFvUGXGmxNaok");
                var stripeCharge = chargeService.Create(myCharge);

                return stripeCharge.Id;
            });
        }

        public void AddStripeCharge(Models.StripeCharge charge)
        {
            DB.StripeCharges.Add(charge);
            DB.SaveChanges();
        }
    }
}