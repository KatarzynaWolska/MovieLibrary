using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Data;
using MovieLibrary.Dtos;
using MovieLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieLibrary.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MovieController : Controller
    {
        private IMovieData _movieData;
        private ICategoryData _categoryData;

        public MovieController(IMovieData movieData, ICategoryData categoryData)
        {
            _movieData = movieData;
            _categoryData = categoryData;
        }

        [HttpGet]
        public IActionResult GetMovies()
        {
            return Ok(_movieData.GetMovies().ConvertAll(m => MovieDto.FromMovie(m)).ToList());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetMovie(Guid id)
        {
            var movie = _movieData.GetMovie(id);

            System.Diagnostics.Debug.WriteLine("Ble");
            System.Diagnostics.Debug.WriteLine(movie.Category.Name);

            if (movie != null)
            {
                return Ok(MovieDto.FromMovie(movie));
            }

            return NotFound($"Movie with id: {id} not found");
        }

        [HttpPost]
        public IActionResult AddMovie(MovieDto movie)
        { 
            var category = _categoryData.GetCategoryByName(movie.Category);
            var newMovie = new Movie(title: movie.Title, category: category);
            var createdMovie = _movieData.AddMovie(newMovie);
            _categoryData.AddMovie(category, newMovie);

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + createdMovie.MovieId,
                createdMovie);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteMovie(Guid id)
        {
            var movie = _movieData.GetMovie(id);

            if (movie != null)
            {
                _movieData.DeleteMovie(movie);
                return Ok(MovieDto.FromMovie(movie));
            }

            return NotFound($"Movie with id: {id} not found");
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult EditMovie(Guid id, MovieDto movie)
        {
            var existingMovie = _movieData.GetMovie(id);

            if (existingMovie != null)
            {
                var category = _categoryData.GetCategoryByName(movie.Category);
                existingMovie.edit(movie.Title, category);
                _movieData.EditMovie(existingMovie);
                return Ok(existingMovie);
            }

            return NotFound($"Movie with id: {id} not found");
        }
    }
}
