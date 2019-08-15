using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Filmy.Models
{
    public enum Genres
    {
        Action,
        Thriller,
        Adult,
        Family,
        Romance,
        Horror,
        Comedy
    }
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Movie's name field is required.")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Movie's release date field is required.")]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public Genres Genre { get; set; }

        [Required]
        [Range(1, 30)]
        [Display(Name = "Number In Stock")]
        public int NumberInStock { get; set; }

        public int NumberAvailable { get; set; }
        public string Image { get; set; }
    }
}