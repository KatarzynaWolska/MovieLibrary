using MovieLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieLibrary.Dtos
{
    public class CategoryDto
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public List<MovieDto> Movies { get; set; }

        public CategoryDto()
        {

        }

        private CategoryDto(Guid id, string name, List<MovieDto> movies) 
        {
            this.CategoryId = id;
            this.Name = name;
            this.Movies = movies;
        }

        public static CategoryDto FromCategory(Category category)
        {
            return new CategoryDto(id: category.CategoryId, name: category.Name, movies: category.Movies?.ConvertAll(m => MovieDto.FromMovie(m)).ToList());
        }
    }
}
