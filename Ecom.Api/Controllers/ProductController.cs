using AutoMapper;
using Ecom.Api.Helper;
using Ecom.core.DTO;
using Ecom.core.Entities.Product;
using Ecom.core.Interfacies;
using Ecom.core.Sharing;
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
        public async Task<IActionResult> GetAllProducts([FromQuery]ProductParams productParams)
        {
            try
            {
                var products = await _work.ProductRepository.GetAllAsync(productParams);
                var totalCount = await _work.ProductRepository.CountAsync();
                return Ok(new Pagination<ProductDto>(productParams.PageNumber,productParams.pageSize,totalCount,products));
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if needed
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving products.");
            }
        }
        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            try
            {
                var product = await _work.ProductRepository.GetByIdAsync(id, x => x.Category, x => x.Photos);
                if (product == null)
                    return NotFound(new ResponseAPI(404));
                var result = mapper.Map<ProductDto>(product);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if needed
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the product.");
            }
        }
        
        [HttpPost("add-product")]
        public async Task<IActionResult> AddProduct([FromForm] AddProductDto productDto)
        {
            try
            {
                var result = await _work.ProductRepository.AddAsync(productDto);
                if (!result)
                    return BadRequest(new ResponseAPI(400));

                return Ok(new ResponseAPI(200));
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if needed
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while adding the product.");
            }
        }

        [HttpPut("update-product")]
        public async Task<IActionResult> Update([FromForm] UpdateProductDto productDto)
        {

            try
            {
                var result = await _work.ProductRepository.UpdateAsync(productDto);
                if (!result)
                    return NotFound(new ResponseAPI(404));

                return Ok(new ResponseAPI(200));

            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if needed
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating the product.");
            }
        }
    }
}
