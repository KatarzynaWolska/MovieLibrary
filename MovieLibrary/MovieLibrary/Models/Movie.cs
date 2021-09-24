using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace MovieLibrary.Models
{
    public class Movie
    {
        [Key]
        public Guid MovieId { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Title can only be 100 characters long")]
        public string Title { get; set; }

        [Required]
        public Category Category { get; set; }

        public Movie()
        {

        }

        public Movie(string title, Category category)
        {
            this.MovieId = Guid.NewGuid();
            this.Title = title;
            this.Category = category;
        }

        public void edit(string title, Category category)
        {
            this.Title = title;
            this.Category = category;
        }
    }
}
