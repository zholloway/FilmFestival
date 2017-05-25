using FilmFestival.Models;
using FilmFestival.Models.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmFestival.Services
{
    public class NewsServices
    {
        public ApplicationDbContext DB { get; } = new ApplicationDbContext();

        //get all news
        public List<NewsIndex> GetAllNews()
        {
            var newsList = DB.NewsStories;

            var returnList = new List<NewsIndex>();

            foreach (var story in newsList)
            {
                var returnStory = new NewsIndex
                {
                    Author = story.Author,
                    Date = story.Date,
                    ID = story.ID,
                    StoryImgPath = story.StoryImgPath,
                    SubTitle = story.SubTitle,
                    Title = story.Title
                };

                returnList.Add(returnStory);
            }

            return returnList;
        }

        public Models.View_Models.NewsStory GetIndividualStory(int storyID)
        {
            var story = DB.NewsStories.First(f => f.ID == storyID);

            var returnStory = new Models.View_Models.NewsStory
            {
                Author = story.Author,
                Date = story.Date,
                StoryBody = story.StoryBody,
                StoryImgPath = story.StoryImgPath,
                SubTitle = story.SubTitle,
                Title = story.Title
            };

            return returnStory;
        }
    }
}