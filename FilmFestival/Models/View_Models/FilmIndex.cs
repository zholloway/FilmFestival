using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmFestival.Models.View_Models
{
    public class FilmIndex
    {
        public string PreviewImgPath { get; set; }

        public int ID { get; set; }

        public string Title { get; set; }

        public string Director { get; set; }
    }
}