using FilmFestival.Models;
using FilmFestival.Models.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmFestival.Services
{
    public class FilmServices
    {
        public ApplicationDbContext DB { get; } = new ApplicationDbContext();

        //get all films
        public List<FilmIndex> GetAllFilms()
        {
            var filmList = DB.Films;

            var returnList = new List<FilmIndex>();

            foreach (var film in filmList)
            {
                var returnFilm = new FilmIndex {
                    Director = film.Director,
                    ID = film.ID,
                    PreviewImgPath = film.PreviewImgPath,
                    Title = film.Title
                };

                returnList.Add(returnFilm);
            }

            return returnList;
        }

        public FilmInfo GetIndividualFilm(int filmID)
        {
            var film = DB.Films.First(f => f.ID == filmID);

            var returnFilm = new FilmInfo {
                BriefSummary = film.BriefSummary,
                Country = film.Country,
                Director = film.Director,
                FullDescription = film.FullDescription,
                ID = film.ID,
                InfoImgPath = film.InfoImgPath,
                Runtime = film.Runtime,
                Title = film.Title,
                YearReleased = film.YearReleased
            };

            return returnFilm;
        }
    }
}