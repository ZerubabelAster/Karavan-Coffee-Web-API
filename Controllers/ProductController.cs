using AutoMapper;
using KaravanCoffeeWebAPI.Data;
using KaravanCoffeeWebAPI.IRepository;
using KaravanCoffeeWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace KaravanCoffeeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ProductController> _logger;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;


        public ProductController(IUnitOfWork unitOfWork, ILogger<ProductController> logger, IMapper mapper, IWebHostEnvironment environment)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _environment = environment;
        }

        [Authorize(Roles = "Administrator, Branch Admin, Customer")]
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

        [Authorize(Roles = "Administrator, Branch Admin, Customer")]
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

        //[Authorize(Roles = "Administrator")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateProduct([FromForm] CreateProductDTO productDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST Attempt in {nameof(CreateProduct)}");
                return BadRequest(ModelState);
            }

            try
            {
                //var path1 = Path.GetFullPath()
                var path = Path.Combine("C:\\Users\\Administrator\\source\\repos\\Karavan Coffee Web API\\", "Asset/Products/" , productDTO.Image.FileName);
                productDTO.ImagePath = path;
                var product = _mapper.Map<Product>(productDTO);
                await _unitOfWork.Products.Insert(product);
                await _unitOfWork.Products.SaveImage(product.Image, path);
                await _unitOfWork.Save();

                return StatusCode(201, "Product Created Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Invalid POST Attempt in {nameof(CreateProduct)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later");
            }
        }

        [Authorize(Roles = "Administrator")]
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

        [Authorize(Roles = "Administrator")]
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
