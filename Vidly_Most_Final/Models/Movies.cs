using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly_Most_Final.Models
{
    public class Movies
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        [Display(Name="Genre")]
        public byte GenreId { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public  DateTime ReleaseDate { get; set; }
    }
}