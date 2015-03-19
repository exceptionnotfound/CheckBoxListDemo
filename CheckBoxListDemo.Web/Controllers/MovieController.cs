using CheckBoxListDemo.Web.DataAccess.Managers;
using CheckBoxListDemo.Web.Models;
using CheckBoxListDemo.Web.ViewModels.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CheckBoxListDemo.Web.Controllers
{
    public class MovieController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            MovieIndexVM model = new MovieIndexVM();
            model.Movies = MovieManager.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            AddMovieVM model = new AddMovieVM();
            var allGenres = GenreManager.GetAll();
            var checkBoxListItems = new List<CheckBoxListItem>();
            foreach (var genre in allGenres)
            {
                checkBoxListItems.Add(new CheckBoxListItem()
                {
                    ID = genre.ID,
                    Display = genre.Name,
                    IsChecked = false
                });
            }
            model.Genres = checkBoxListItems;
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(AddMovieVM model)
        {
            var selectedGenres = model.Genres.Where(x => x.IsChecked).Select(x => x.ID).ToList();
            MovieManager.Add(model.Title, model.ReleaseDate, model.RunningTimeMinutes, selectedGenres);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var movie = MovieManager.GetByID(id);
            var model = new EditMovieVM()
            {
                ID = movie.ID,
                ReleaseDate = movie.ReleaseDate,
                RunningTimeMinutes = movie.RunningTime,
                Title = movie.Title
            };
            var movieGenres = GenreManager.GetForMovie(id);
            var allGenres = GenreManager.GetAll();
            var checkBoxListItems = new List<CheckBoxListItem>();
            foreach (var genre in allGenres)
            {
                checkBoxListItems.Add(new CheckBoxListItem()
                {
                    ID = genre.ID,
                    Display = genre.Name,
                    IsChecked = movieGenres.Where(x => x.ID == genre.ID).Any()
                });
            }
            model.Genres = checkBoxListItems;
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditMovieVM model)
        {
            var selectedGenres = model.Genres.Where(x => x.IsChecked).Select(x => x.ID).ToList();
            MovieManager.Edit(model.ID, model.Title, model.ReleaseDate, model.RunningTimeMinutes, selectedGenres);
            return RedirectToAction("Index");
        }
    }
}