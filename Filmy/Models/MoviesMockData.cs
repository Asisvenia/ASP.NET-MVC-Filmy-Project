using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Filmy.Models
{
    public static class MoviesMockData
    {
        public static List<Movie> MovieCollection = new List<Movie>()
        {
            new Movie {Id = 1, Name = "Shrek", ReleaseDate = new DateTime(2001, 06, 22), Genre = Genres.Family,
                NumberInStock = 20, Image = ImagePaths.Shrek},
            new Movie {Id = 2, Name = "Matrix", ReleaseDate = new DateTime(1999, 09, 03), Genre = Genres.Action,
                NumberInStock = 25, Image = ImagePaths.Matrix},
            new Movie {Id = 3, Name = "Die Hard 4.0", ReleaseDate = new DateTime(2007, 09, 03), Genre = Genres.Action,
                NumberInStock = 30, Image = ImagePaths.DieHard},
            new Movie {Id = 4, Name = "Get Out", ReleaseDate = new DateTime(2016, 03, 12), Genre = Genres.Thriller,
                NumberInStock = 25, Image = ImagePaths.GetOut},
            new Movie {Id = 5, Name = "John Wick 3", ReleaseDate = new DateTime(2019, 05, 17), Genre = Genres.Action,
                NumberInStock = 50, Image = ImagePaths.JohnWick_3},
        };

        public static IEnumerable<Movie> GetMovies()
        {
            return MovieCollection;
        }

        public static void AddMovie(Movie newMovie)
        {
            int availableMaxId = MovieCollection.Max(c => c.Id);
            newMovie.Id = availableMaxId + 1;

            MovieCollection.Add(newMovie);
        }
    }
}