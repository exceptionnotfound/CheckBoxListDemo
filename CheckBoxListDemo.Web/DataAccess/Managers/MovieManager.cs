using CheckBoxListDemo.Web.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CheckBoxListDemo.Web.DataAccess.Managers
{
    public static class MovieManager
    {
        public static List<Movie> GetAll()
        {
            using (MovieEntities context = new MovieEntities())
            {
                var movies = context.Movies.Include(x => x.Genres).OrderBy(x => x.Title).ToList();
                return movies;
            }
        }

        public static Movie GetByID(int id)
        {
            using (MovieEntities context = new MovieEntities())
            {
                var movie = context.Movies.Include(x => x.Genres).Where(x => x.ID == id).First();
                return movie;
            }
        }

public static void Add(string title, DateTime releaseDate, int runningTime, List<int> genres)
{
    using (MovieEntities context = new MovieEntities())
    {
        var movie = new Movie()
        {
            Title = title,
            ReleaseDate = releaseDate,
            RunningTime = runningTime
        };

        foreach (var genreID in genres)
        {
            var genre = context.Genres.Find(genreID);
            movie.Genres.Add(genre);
        }
        context.Movies.Add(movie);

        context.SaveChanges();
    }
}


        public static void Edit(int id, string title, DateTime releaseDate, decimal price, List<int> genres)
        {
            using (MovieEntities context = new MovieEntities())
            {
                var movie = context.Movies.Where(x => x.ID == id).First();
                movie.Title = title;
                movie.ReleaseDate = releaseDate;
                movie.Genres.Clear();
                foreach (var genreID in genres)
                {
                    var genre = context.Genres.Find(genreID);
                    movie.Genres.Add(genre);
                }

                context.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (MovieEntities context = new MovieEntities())
            {
                var movie = context.Movies.Where(x => x.ID == id).First();
                context.Movies.Remove(movie);
                context.SaveChanges();
            }
        }
    }
}