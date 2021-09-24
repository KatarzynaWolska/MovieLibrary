using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Data;
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

        public MovieController(IMovieData movieData)
        {
            _movieData = movieData;
        }

        [HttpGet]
        public IActionResult GetMovies()
        {
            return Ok(_movieData.GetMovies());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetMovie(Guid id)
        {
            var movie = _movieData.GetMovie(id);

            if (movie != null)
            {
                return Ok(movie);
            }

            return NotFound($"Movie with id: {id} not found");
        }

        [HttpPost]
        public IActionResult AddMovie(Movie movie)
        {
            var createdMovie = _movieData.AddMovie(movie);

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
                return Ok(movie);
            }

            return NotFound($"Movie with id: {id} not found");
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult EditMovie(Guid id, Movie movie)
        {
            var existingMovie = _movieData.GetMovie(id);

            if (existingMovie != null)
            {
                existingMovie.edit(movie);
                _movieData.EditMovie(existingMovie);
                return Ok(existingMovie);
            }

            return NotFound($"Movie with id: {id} not found");
        }
    }
}
