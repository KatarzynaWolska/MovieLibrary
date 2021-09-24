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

        public void edit(Movie movie)
        {
            Title = movie.Title;
            Category = movie.Category;
        }
    }
}
