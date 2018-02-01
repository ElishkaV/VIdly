using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly2018.Models;

namespace Vidly2018.ViewModels
{
    public class MovieFormViewModel
    {
        public Movie Movie { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        public string Title { get { if (Movie.Id == 0) return "New Movie"; return "Edit Movie"; } }
    }
}