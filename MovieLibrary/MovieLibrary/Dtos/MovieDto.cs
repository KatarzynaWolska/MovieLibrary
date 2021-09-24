using MovieLibrary.Models;
using System;

namespace MovieLibrary.Dtos
{
    public class MovieDto
    {
        public Guid MovieId { get; set; }
        
        public string Title { get; set; }

        public string Category { get; set; }

        public MovieDto()
        {
           
        }

        private MovieDto(Guid id, string title, string category)
        {
            this.MovieId = id;
            this.Title = title;
            this.Category = category;
        }

        public static MovieDto FromMovie(Movie movie)
        {
            return new MovieDto(id: movie.MovieId, title: movie.Title, category: movie.Category?.Name);
        }
    }
}
