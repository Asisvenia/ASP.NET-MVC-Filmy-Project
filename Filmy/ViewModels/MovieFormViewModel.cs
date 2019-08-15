using Filmy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Filmy.ViewModels
{
    public class MovieFormViewModel
    {
        public Movie Movie { get; set; }
        public List<Genre> AllGenres { get; set; } = new List<Genre>
        {
            new Genre {Id = 0, Name = Genres.Action},
            new Genre {Id = 1, Name = Genres.Thriller},
            new Genre {Id = 2, Name = Genres.Adult},
            new Genre {Id = 3, Name = Genres.Family},
            new Genre {Id = 4, Name = Genres.Romance},
            new Genre {Id = 5, Name = Genres.Horror},
            new Genre {Id = 6, Name = Genres.Comedy},
        };
    }
}