using MovieLibrary.Models;
using System;
using System.Collections.Generic;

namespace MovieLibrary.Data
{
    public interface IMovieData
    {
        List<Movie> GetMovies();

        Movie GetMovie(Guid id);

        Movie AddMovie(Movie movie);

        void DeleteMovie(Movie movie);

        Movie EditMovie(Movie movie);
    }
}
