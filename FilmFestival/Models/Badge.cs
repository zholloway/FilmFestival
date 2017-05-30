using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FilmFestival.Models
{
    public class Badge
    {
        public int ID { get; set; }

        //"Second Half Badge", "Superfan Badge", etc
        public string BadgeLevel { get; set; }

        public string UserID { get; set; }

        [ForeignKey("UserID")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public ApplicationUser User { get; set; }
    }
}