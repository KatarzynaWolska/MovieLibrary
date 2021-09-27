using MovieLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieLibrary.Dtos
{
    public class DirectorDto
    {
        public Guid DirectorId { get; set; }

        public string Name { get; set; }
            
        public string Surname { get; set; }

        public List<MovieDto> Movies { get; set; }

        public DirectorDto()
        {

        }
        public DirectorDto(Guid id, string name, string surname, List<MovieDto> movies)
        {
            this.DirectorId = id;
            this.Name = name;
            this.Surname = surname;
            this.Movies = movies;
        }
        public static DirectorDto FromDirector(Director director)
        {
            return new DirectorDto(id: director.DirectorId, name: director.Name, surname: director.Surname, movies: director.Movies?.ConvertAll(m => MovieDto.FromMovie(m)).ToList());
        }
    }
}
