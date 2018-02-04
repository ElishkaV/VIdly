using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly2018.Models;

namespace Vidly2018.ViewModels
{
    public class MovieFormViewModel
    {
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }


        [Required, Display(Name = "Number in Stock"), Range(1,20)]
        public int? NumbersInStock { get; set; }


        [Display(Name = "Genre")]
        public int? GenreId { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        public string Title { get { if (Id == 0) return "New Movie"; return "Edit Movie"; } }

        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumbersInStock = movie.NumbersInStock;
            GenreId = movie.GenreId;
        }
    }
}