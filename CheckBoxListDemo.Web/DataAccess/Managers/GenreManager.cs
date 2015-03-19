using CheckBoxListDemo.Web.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckBoxListDemo.Web.DataAccess.Managers
{
    public static class GenreManager
    {
        public static List<Genre> GetAll()
        {
            using (MovieEntities context = new MovieEntities())
            {
                return context.Genres.OrderBy(x => x.Name).ToList();
            }
        }

        public static Genre GetByID(int id)
        {
            using (MovieEntities context = new MovieEntities())
            {
                return context.Genres.Where(x => x.ID == id).First();
            }
        }

        public static List<Genre> GetForMovie(int id)
        {
            using (MovieEntities context = new MovieEntities())
            {
                return context.Movies.Where(x => x.ID == id).First().Genres.ToList();
            }
        }
    }
}