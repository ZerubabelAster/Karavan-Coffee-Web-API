using AutoMapper;
using KaravanCoffeeWebAPI.Data;
using KaravanCoffeeWebAPI.IRepository;
using KaravanCoffeeWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KaravanCoffeeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ProductController> _logger;
        private readonly IMapper _mapper;

        public ProductController(IUnitOfWork unitOfWork, ILogger<ProductController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var products = await _unitOfWork.Products.GetAll();
                var results = _mapper.Map<List<ProductDTO>>(products);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetProducts)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Lagter.");
            }
        }

        [HttpGet("{id:int}", Name = "GetProduct")]
        public async Task<IActionResult> GetProduct(int id)
        {
            try
            {
                var product = await _unitOfWork.Products.Get(q => q.ProductId == id);
                var result = _mapper.Map<ProductDTO>(product);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetProduct)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDTO productDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST Attempt in {nameof(CreateProduct)}");
                return BadRequest(ModelState);
            }

            try
            {
                var product = _mapper.Map<Product>(productDTO);
                await _unitOfWork.Products.Insert(product);
                await _unitOfWork.Save();

                return CreatedAtRoute("GetProduct", new { id = product.ProductId }, product);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Invalid POST Attempt in {nameof(CreateProduct)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later");
            }
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductDTO updateProductDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid Update Attempt in {nameof(UpdateProduct)}");
                return BadRequest(ModelState);
            }

            try
            {
                var updateProduct = await _unitOfWork.Products.Get(q => q.ProductId == id);
                if (updateProduct == null)
                {
                    _logger.LogError($"Invalid Update Attempt in {nameof(UpdateProduct)}");
                    return BadRequest("submitted data is invalid"); 
                }

                _mapper.Map(updateProductDTO, updateProduct);
                _unitOfWork.Products.Update(updateProduct);
                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Someting Went Wrong in the {nameof(UpdateProduct)}");
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid Delete attemp in {nameof(DeleteProduct)}");
                return BadRequest();
            }

            try
            {
                var product = await _unitOfWork.Products.Get(q => q.ProductId == id);
                if (product == null)
                {
                    _logger.LogError($"Invalid Delete attemp in {nameof(DeleteProduct)}");
                    return BadRequest("Submitted data is invalid");
                }

                await _unitOfWork.Products.Delete(id);
                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something Went Wrong in the {nameof(DeleteProduct)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later");
            }
        }
    }
}
