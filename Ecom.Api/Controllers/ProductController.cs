using AutoMapper;
using Ecom.Api.Helper;
using Ecom.core.DTO;
using Ecom.core.Interfacies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {
        public ProductController(IUnitOfWork work, IMapper mapper) : base(work, mapper)
        {
        }
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var products = await _work.ProductRepository.GetAllAsync(
                    x=>x.Category ,x=>x.Photos);
                if (products == null)
                    return BadRequest(new ResponseAPI(400));

                var result = mapper.Map<List<ProductDto>>(products);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if needed
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving products.");
            }
        } 
    }
}
