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
        public ApplicationDbContext DB { get; set; }

        //FilmServices constructor to establish database connection
        public FilmServices(ApplicationDbContext db)
        {
            DB = db;
        }

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
            }

            return returnList;
        }
    }
}