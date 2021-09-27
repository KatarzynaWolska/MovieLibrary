using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Data;
using MovieLibrary.Dtos;
using MovieLibrary.Models;
using System;

namespace MovieLibrary.Controllers
{
    [ApiController]
    [Route("api/directors")]
    public class DirectorController : Controller
    {
        private IDirectorData _directorData;

        public DirectorController(IDirectorData directorData)
        {
            _directorData = directorData;
        }

        [HttpGet]
        public IActionResult GetDirectors()
        {
            return Ok(_directorData.GetDirectors().ConvertAll(d => DirectorDto.FromDirector(d)));
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetDirector(Guid id)
        {
            var director = _directorData.GetDirectorById(id);

            if (director != null)
            {
                return Ok(DirectorDto.FromDirector(director));
            }

            return NotFound($"Director with id: {id} not found");
        }

        [HttpPost]
        public IActionResult AddDirector(DirectorDto director)
        {
            var newDirector = new Director(name: director.Name, surname: director.Surname);
            var createdDirector  = _directorData.AddDirector(newDirector);

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + createdDirector.DirectorId,
                createdDirector);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteDirector(Guid id)
        {
            var director = _directorData.GetDirectorById(id);

            if (director != null)
            {
                _directorData.DeleteDirector(director);
                return Ok(DirectorDto.FromDirector(director));
            }

            return NotFound($"Director with id: {id} not found");
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult EditDirector(Guid id, DirectorDto director)
        {
            var existingDirector = _directorData.GetDirectorById(id);

            if (existingDirector != null)
            {
                existingDirector.edit(director.Name, director.Surname);
                _directorData.EditDirector(existingDirector);
                return Ok(existingDirector);
            }

            return NotFound($"Director with id: {id} not found");
        }
    }
}
