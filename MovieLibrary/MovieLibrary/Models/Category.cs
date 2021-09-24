using System;
using System.ComponentModel.DataAnnotations;

namespace MovieLibrary.Models
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Name can only be 50 characters long")]
        public string Name { get; set; }

        public void edit(Category category)
        {
            Name = category.Name;
        }
    }
}
