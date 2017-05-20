using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmFestival.Models
{
    public class NewsStory
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string Author { get; set; }

        public DateTime Date { get; set; }

        public string PreviewImgPath { get; set; }

        public string StoryImgPath { get; set; }

        public string StoryBody { get; set; }
    }
}