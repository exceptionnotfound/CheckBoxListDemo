using CheckBoxListDemo.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CheckBoxListDemo.Web.ViewModels.Movie
{
public class AddMovieVM
{
    [DisplayName("Title: ")]
    public string Title { get; set; }

    [DisplayName("Release Date: ")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime ReleaseDate { get; set; }

    [DisplayName("Running Time (Minutes):")]
    public int RunningTimeMinutes { get; set; }

    public List<CheckBoxListItem> Genres { get; set; }

    public AddMovieVM()
    {
        Genres = new List<CheckBoxListItem>();
    }
}
}