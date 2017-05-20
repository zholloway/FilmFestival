using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmFestival.Models
{
    public class Hotel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string StateAbbreviation { get; set; }

        public int ZipCode { get; set; }

        public string PhoneNumber { get; set; }
    }
}