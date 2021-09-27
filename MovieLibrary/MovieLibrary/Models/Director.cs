using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieLibrary.Models
{
    public class Director
    {
        [Key]
        public Guid DirectorId { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Title can only be 50 characters long")]
        public string Name { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Title can only be 50 characters long")]
        public string Surname { get; set; }

        public List<Movie> Movies { get; set; }

        public Director()
        {
            this.Movies = new List<Movie>();
        }

        public Director(string name, string surname)
        {
            this.Movies = new List<Movie>();
            this.Name = name;
            this.Surname = surname;
        }

        public void edit(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }
    }
}
