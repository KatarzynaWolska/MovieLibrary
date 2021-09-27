using MovieLibrary.Models;
using System;

namespace MovieLibrary.Dtos
{
    public class MovieDto
    {
        public Guid MovieId { get; set; }
        
        public string Title { get; set; }

        public string Category { get; set; }

        public string Director { get; set; }

        public MovieDto()
        {
           
        }

        private MovieDto(Guid id, string title, string category, string director)
        {
            this.MovieId = id;
            this.Title = title;
            this.Category = category;
            this.Director = director;
        }

        public static MovieDto FromMovie(Movie movie)
        {
            return new MovieDto(id: movie.MovieId, title: movie.Title, category: movie.Category?.Name, 
                director: movie.Director.Name + " " + movie.Director.Surname);
        }
    }
}
