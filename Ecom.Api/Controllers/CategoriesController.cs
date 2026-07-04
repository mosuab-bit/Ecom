using Ecom.core.DTO;
using Ecom.core.Entities.Product;
using Ecom.core.Interfacies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.Api.Controllers
{

    public class CategoriesController : BaseController
    {
        public CategoriesController(IUnitOfWork work) : base(work)
        {
        }
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                var categories = await _work.CategoryRepository.GetAllAsync();
                if (categories == null)
                    return BadRequest();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if needed
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving categories.");
            }
        }
        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            try
            {
                var category = await _work.CategoryRepository.GetByIdAsync(id);
                if (category == null)
                    return NotFound();
                return Ok(category);
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if needed
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the category.");
            }
        }
        [HttpPost("add-category")]
        public async Task<IActionResult> AddCategory(CategoryDto categoryDto)
        {
            try
            {
                var category = new Category
                {
                    Name = categoryDto.Name,
                    Description = categoryDto.Description
                };

               await _work.CategoryRepository.AddAsync(category);
                return Ok(new {message = "Item has benn Added"});
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if needed
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while adding the category.");
            }
        }
    }
}
