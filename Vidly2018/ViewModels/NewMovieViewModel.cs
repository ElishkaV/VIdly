using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly2018.Models;

namespace Vidly2018.ViewModels
{
    public class NewMovieViewModel
    {
        public Movie Movie { get; set; }

        public IEnumerable<MembershipType> MembershipTypes { get; set; }
    }
}