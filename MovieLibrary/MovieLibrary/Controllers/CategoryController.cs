using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Data;
using MovieLibrary.Models;
using System;

namespace MovieLibrary.Controllers
{

    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryData _categoryData;

        public CategoryController(ICategoryData categoryData)
        {
            _categoryData = categoryData;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetCategories()
        {
            Console.WriteLine("Ble");
            return Ok(_categoryData.GetCategories());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetCategory(Guid id)
        {
            var category = _categoryData.GetCategory(id);

            if(category != null)
            {
                return Ok(category);
            }

            return NotFound($"Category with id: {id} not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddCategory(Category category)
        {
            var createdCategory = _categoryData.AddCategory(category);

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + createdCategory.Id, 
                createdCategory);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteCategory(Guid id)
        {
            var category = _categoryData.GetCategory(id);

            if (category != null)
            {
                _categoryData.DeleteCategory(category);
                return Ok(category);
            }

            return NotFound($"Category with id: {id} not found");
        }

        [HttpPut]
        [Route("api/[controller]/{id}")]
        public IActionResult EditCategory(Guid id, Category category)
        {
            var existingCategory = _categoryData.GetCategory(id);

            if (existingCategory != null)
            {
                existingCategory.edit(category);
                _categoryData.EditCategory(existingCategory);
                return Ok(existingCategory);
            }

            return NotFound($"Category with id: {id} not found");
        }
    }
}
