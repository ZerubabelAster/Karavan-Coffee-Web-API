using AutoMapper;
using CoreApiResponse;
using KaravanCoffeeWebAPI.Data;
using KaravanCoffeeWebAPI.IRepository;
using KaravanCoffeeWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace KaravanCoffeeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAvailabilityController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ProductAvailabilityController> _logger;
        private readonly IMapper _mapper;

        public ProductAvailabilityController(IUnitOfWork unitOfWork, ILogger<ProductAvailabilityController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<IActionResult> GetProductsAvailability()
        {
            try
            {
                var productAvailabilities = await _unitOfWork.ProductAvailabilities.GetAll();
                var results = _mapper.Map<List<ProductAvailabilityDTO>>(productAvailabilities);
                return CustomResult("Product Availability Loaded Succssfully", results, System.Net.HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetProductsAvailability)}");
                return CustomResult($"Something Went Wrong in the {nameof(GetProductsAvailability)}", System.Net.HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet("{branchId:int}/{productId:int}", Name = "GetProductsAvailability")]
        public async Task<IActionResult> GetProductAvailability(int branchId, int productId)
        {
            try
            {
                var productAvailability = await _unitOfWork.ProductAvailabilities.Get(q => q.BranchId == branchId/* && q.ProductId == productId*/ );
                var result = _mapper.Map<ProductAvailabilityDTO>(productAvailability);
                return CustomResult($"Product Availability Loaded Succfully", result, System.Net.HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetProductAvailability)}");
                return CustomResult($"Something Went Wrong in the {nameof(CreateProductAvailability)}", System.Net.HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateProductAvailability([FromBody] CreateProductAvailabilityDTO productAvailabilityDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST Attempt in {nameof(CreateProductAvailability)}");
                return CustomResult($"Invalid Post Attempt {nameof(CreateProductAvailability)}", System.Net.HttpStatusCode.BadRequest);
            }

            try
            {
                var productAvailability = _mapper.Map<ProductAvailability>(productAvailabilityDTO);
                await _unitOfWork.ProductAvailabilities.Insert(productAvailability);
                await _unitOfWork.Save();

                return CustomResult("Product Availability Created Successfully", System.Net.HttpStatusCode.Created);

                //return CreatedAtRoute("GetOrder", new { id = productAvailability.BranchId/*, productAvailability.ProductId*/ }, productAvailability);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Invalid POST Attempt in {nameof(CreateProductAvailability)}");
                return CustomResult($"Something Went Wrong in the {nameof(CreateProductAvailability)}", System.Net.HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut("{branchId:int}/{productId:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateProductAvailability(int id, [FromBody] UpdateProductAvailabilityDTO updateProductAvailabilityDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid Update Attempt in {nameof(UpdateProductAvailability)}");
                return CustomResult($"Invalid Update Attempt in {nameof(UpdateProductAvailability)}", System.Net.HttpStatusCode.BadRequest);
            }

            try
            {
                var productAvailability = await _unitOfWork.ProductAvailabilities.Get(q => q.ProductAvailabilityId == id);
                if (productAvailability == null)
                {
                    _logger.LogError($"Invalid Update Attempt in {nameof(UpdateProductAvailability)}");
                    return CustomResult("Submitted data is invalid", System.Net.HttpStatusCode.BadRequest);
                }

                _mapper.Map(updateProductAvailabilityDTO, productAvailability);
                _unitOfWork.ProductAvailabilities.Update(productAvailability);
                await _unitOfWork.Save();

                return CustomResult("Updated Successfully", System.Net.HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Someting Went Wrong in the {nameof(UpdateProductAvailability)}");
                return CustomResult("Internal Server Error. Please Try Again Later", System.Net.HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete("{branchId:int}/{productId:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteProductAvailability(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid Delete attemp in {nameof(DeleteProductAvailability)}");
                return CustomResult($"Invlaid Delete attempt in {nameof(DeleteProductAvailability)}", System.Net.HttpStatusCode.BadRequest);
            }

            try
            {
                var prodctAvailabilityies = await _unitOfWork.ProductAvailabilities.Get(q => q.ProductAvailabilityId == id);
                if (prodctAvailabilityies == null)
                {
                    _logger.LogError($"Invalid Delete attemp in {nameof(DeleteProductAvailability)}");
                    return CustomResult($"Invlaid Delete attempt in {nameof(DeleteProductAvailability)}", System.Net.HttpStatusCode.BadRequest);
                }

                await _unitOfWork.ProductAvailabilities.Delete(id);
                await _unitOfWork.Save();

                return CustomResult("Deleted Successfully", System.Net.HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something Went Wrong in the {nameof(DeleteProductAvailability)}");
                return CustomResult("Internal Server Error. Please Try Again Later", System.Net.HttpStatusCode.InternalServerError);
            }
        }
    }
}
