using MovieLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieLibrary.Data
{
    public interface ICategoryData
    {
        List<Category> GetCategories();

        Category GetCategoryById(Guid id);

        Category GetCategoryByName(string name);

        Category AddCategory(Category category);

        void DeleteCategory(Category category);

        Category EditCategory(Category category);

        void AddMovie(Category category, Movie movie);
    }
}
