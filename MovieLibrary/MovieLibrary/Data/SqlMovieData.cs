using Microsoft.EntityFrameworkCore;
using MovieLibrary.Models;
using MovieLibrary.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieLibrary.Data
{
    public class SqlMovieData : IMovieData
    {

        private ProjectContext _context;
        public SqlMovieData(ProjectContext context)
        {
            _context = context;
        }

        public Movie AddMovie(Movie movie)
        {
            movie.MovieId = Guid.NewGuid();
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return movie;
        }

        public void DeleteMovie(Movie movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }

        public Movie EditMovie(Movie movie)
        {
            var existingMovie = GetMovie(movie.MovieId);

            if (existingMovie != null)
            {
                _context.Movies.Update(movie);
                _context.SaveChanges();
            }

            return movie;
        }

        public Movie GetMovie(Guid id)
        {
            return _context.Movies
                .Include(m => m.Category)
                .Include(m => m.Director)
                .FirstOrDefault(m => m.MovieId == id);
        }

        public List<Movie> GetMovies()
        {
            return _context.Movies
                .Include(m => m.Category)
                .Include(m => m.Director)
                .ToList();
        }
    }
}
