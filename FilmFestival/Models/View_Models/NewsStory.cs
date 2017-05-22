using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmFestival.Models.View_Models
{
    public class NewsStory
    {
        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string Author { get; set; }

        public DateTime Date { get; set; }

        public string StoryImgPath { get; set; }

        public string StoryBody { get; set; }
    }
}