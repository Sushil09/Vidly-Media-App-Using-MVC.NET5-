using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly_Most_Final.Models;

namespace Vidly_Most_Final.ViewModels
{
    public class NewMovieViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Movies Movies { get; set; }
    }
}