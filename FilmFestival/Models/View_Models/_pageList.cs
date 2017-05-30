using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmFestival.Models.View_Models
{
    public class _pageList
    {
        public int Previous { get; set; }

        public int Next { get; set; }

        //i.e. Films, News, Showtimes
        public string ContentType { get; set; }
    }
}