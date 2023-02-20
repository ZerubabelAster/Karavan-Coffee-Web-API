using AutoMapper;
using CoreApiResponse;
using KaravanCoffeeWebAPI.Data;
using KaravanCoffeeWebAPI.IRepository;
using KaravanCoffeeWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace KaravanCoffeeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
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

        //[Authorize(Roles = "Administrator, Branch Admin, Customer")]
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var products = await _unitOfWork.Products.GetAll();
                var results = _mapper.Map<List<ProductDTO>>(products);
                return CustomResult("Product Loaded Succssfully", results, System.Net.HttpStatusCode.OK);
                //return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetProducts)}");
                return CustomResult($"Something Went Wrong in the {nameof(GetProducts)}", System.Net.HttpStatusCode.InternalServerError);
                //return StatusCode(500, "Internal Server Error. Please Try Again Lagter.");
            }
        }

        //[Authorize(Roles = "Administrator, Branch Admin, Customer")]
        [HttpGet("{id:int}", Name = "GetProduct")]
        public async Task<IActionResult> GetProduct(int id)
        {
            try
            {
                var product = await _unitOfWork.Products.Get(q => q.ProductId == id);
                var result = _mapper.Map<ProductDTO>(product);
                return CustomResult($"Product Loaded Succfully", result, System.Net.HttpStatusCode.OK);
                //return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetProduct)}");
                return CustomResult($"Something Went Wrong in the {nameof(GetProduct)}", System.Net.HttpStatusCode.InternalServerError);
                //return StatusCode(500, "Internal Server Error. Please Try Again Later.");
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
                return CustomResult($"Invalid Post Attempt {nameof(CreateProduct)}", System.Net.HttpStatusCode.BadRequest);
                //return BadRequest(ModelState);
            }

            try
            {
                //var path = Path.Combine("C:\\Users\\Administrator\\source\\repos\\Karavan Coffee Web API\\", "Asset/Products/" , productDTO.Image.FileName);
                //productDTO.ImagePath = path;
                var product = _mapper.Map<Product>(productDTO);

                if (productDTO.Image != null)
                    product.ImagePath = Constant.DefalutProductImagepathURL + _unitOfWork.Products.UploadImage(productDTO.Image, Constant.DefaultProductImagePath);
                else
                    product.ImagePath = Constant.DefaultProductImage;

                await _unitOfWork.Products.Insert(product);
                await _unitOfWork.Save();
                return CustomResult("Product Created Successfully", System.Net.HttpStatusCode.Created);
                //return StatusCode(201, "Product Created Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Invalid POST Attempt in {nameof(CreateProduct)}");
                return CustomResult($"Something Went Wrong in the {nameof(CreateProduct)}", System.Net.HttpStatusCode.InternalServerError);
                //return StatusCode(500, "Internal Server Error. Please Try Again Later");
            }
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateProduct(int id, [FromForm] UpdateProductDTO updateProductDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid Update Attempt in {nameof(UpdateProduct)}");
                return CustomResult($"Invalid Update Attempt in {nameof(UpdateProduct)}",System.Net.HttpStatusCode.BadRequest);

                //return BadRequest(ModelState);
            }

            try
            {

                var updateProduct = await _unitOfWork.Products.Get(q => q.ProductId == id);

        
                if (updateProduct == null)
                {
                    _logger.LogError($"Invalid Update Attempt in {nameof(UpdateProduct)}");
                    return CustomResult("Submitted data is invalid", System.Net.HttpStatusCode.BadRequest);
                    //return BadRequest("submitted data is invalid");
                }
                if (updateProduct.ImagePath != null)
                    updateProductDTO.ImagePath = updateProduct.ImagePath;

                _mapper.Map(updateProductDTO, updateProduct);
                if (updateProductDTO.Image != null)
                    updateProduct.ImagePath = Constant.DefalutProductImagepathURL + _unitOfWork.Products.UploadImage(updateProductDTO.Image, Constant.DefaultProductImagePath);
                
                _unitOfWork.Products.Update(updateProduct);
                await _unitOfWork.Save();

                return CustomResult("Updated Successfully", System.Net.HttpStatusCode.NoContent);
                //return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Someting Went Wrong in the {nameof(UpdateProduct)}");
                return CustomResult($"Something Went Wrong in the {nameof(UpdateProduct)}", System.Net.HttpStatusCode.InternalServerError);
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
                _logger.LogError($"Invalid Delete attempt in {nameof(DeleteProduct)}");
                return CustomResult($"Invalid Delete attempt in {nameof(DeleteProduct)}");
                //return BadRequest();
            }

            try
            {
                var product = await _unitOfWork.Products.Get(q => q.ProductId == id);
                if (product == null)
                {
                    _logger.LogError($"Invalid Delete attemp in {nameof(DeleteProduct)}");
                    return CustomResult($"Invlaid Delete attempt in {nameof(DeleteProduct)}",System.Net.HttpStatusCode.BadRequest);
                    //return BadRequest("Submitted data is invalid");
                }

                await _unitOfWork.Products.Delete(id);
                await _unitOfWork.Save();

                return CustomResult("Deleted Successfully", System.Net.HttpStatusCode.NoContent);
                //return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something Went Wrong in the {nameof(DeleteProduct)}");
                return CustomResult("Internal Server Error. Please Try Again Later", System.Net.HttpStatusCode.InternalServerError);
                //return StatusCode(500, "Internal Server Error. Please Try Again Later");
            }
        }
    }
}
