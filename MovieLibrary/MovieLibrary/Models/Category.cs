using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieLibrary.Models
{
    public class Category
    {
        [Key]
        public Guid CategoryId { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Name can only be 50 characters long")]
        public string Name { get; set; }

        public List<Movie> Movies { get; set; } = new List<Movie>();

        public Category()
        {
          
        }

        public Category(string name)
        {
            this.CategoryId = Guid.NewGuid();
            this.Name = name;
            this.Movies = new List<Movie>();
        }

        public void edit(string name)
        {
            this.Name = name;
        }
    }
}
