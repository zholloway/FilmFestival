using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FilmFestival.Models
{
    public class StripeCharge
    {
        public int ID { get; set; }

        [Required]
        public string Token { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public string CardHolderName { get; set; }

        // These fields are optional and are not 
        // required for the creation of the token
        public string CardHolderEmail { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressCity { get; set; }
        public string AddressPostcode { get; set; }
        public string AddressCountry { get; set; }
    }
}