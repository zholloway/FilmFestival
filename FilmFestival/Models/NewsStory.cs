using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilmFestival.Models
{
    public class NewsStory
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string Author { get; set; }

        public DateTime Date { get; set; }

        public string StoryImgPath { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        [AllowHtml]
        public string StoryBody { get; set; }
    }
}