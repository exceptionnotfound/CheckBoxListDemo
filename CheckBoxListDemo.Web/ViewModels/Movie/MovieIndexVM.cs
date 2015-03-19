using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckBoxListDemo.Web.ViewModels.Movie
{
    public class MovieIndexVM
    {
        public List<CheckBoxListDemo.Web.DataAccess.Model.Movie> Movies { get; set; }
    }
}