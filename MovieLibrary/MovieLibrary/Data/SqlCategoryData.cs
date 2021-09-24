using MovieLibrary.Models;
using MovieLibrary.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieLibrary.Data
{
    public class SqlCategoryData : ICategoryData
    {
        private ProjectContext _context;
        public SqlCategoryData(ProjectContext context)
        {
            _context = context;
        }

        public Category AddCategory(Category category)
        {
            category.CategoryId = Guid.NewGuid();
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category;
        }

        public void DeleteCategory(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

        public Category EditCategory(Category category)
        {
            var existingCategory = GetCategory(category.CategoryId);
            
            if(existingCategory != null)
            {
                _context.Categories.Update(category);
                _context.SaveChanges();
            }

            return category;
        }

        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategory(Guid id)
        {
            return _context.Categories.Find(id);
        }
    }
}
