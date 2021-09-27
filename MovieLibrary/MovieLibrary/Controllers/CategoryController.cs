using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Data;
using MovieLibrary.Dtos;
using MovieLibrary.Models;
using System;

namespace MovieLibrary.Controllers
{

    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private ICategoryData _categoryData;

        public CategoryController(ICategoryData categoryData)
        {
            _categoryData = categoryData;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            return Ok(_categoryData.GetCategories().ConvertAll(c => CategoryDto.FromCategory(c)));
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetCategory(Guid id)
        {
            var category = _categoryData.GetCategoryById(id);

            if(category != null)
            {
                return Ok(CategoryDto.FromCategory(category));
            }

            return NotFound($"Category with id: {id} not found");
        }

        [HttpPost]
        public IActionResult AddCategory(CategoryDto category)
        {
            var createdCategory = _categoryData.AddCategory(new Category(category.Name));

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + createdCategory.CategoryId, 
                createdCategory);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteCategory(Guid id)
        {
            var category = _categoryData.GetCategoryById(id);

            if (category != null)
            {
                _categoryData.DeleteCategory(category);
                return Ok(CategoryDto.FromCategory(category));
            }

            return NotFound($"Category with id: {id} not found");
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult EditCategory(Guid id, CategoryDto category)
        {
            var existingCategory = _categoryData.GetCategoryById(id);

            if (existingCategory != null)
            {
                existingCategory.edit(category.Name);
                _categoryData.EditCategory(existingCategory);
                return Ok(CategoryDto.FromCategory(existingCategory));
            }

            return NotFound($"Category with id: {id} not found");
        }
    }
}
