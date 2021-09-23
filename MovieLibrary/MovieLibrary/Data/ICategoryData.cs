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

        Category GetCategory(Guid id);

        Category AddCategory(Category category);

        void DeleteCategory(Category category);

        Category EditCategory(Category category);
    }
}
