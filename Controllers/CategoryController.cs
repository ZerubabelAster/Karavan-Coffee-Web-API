using AutoMapper;
using CoreApiResponse;
using KaravanCoffeeWebAPI.Data;
using KaravanCoffeeWebAPI.IRepository;
using KaravanCoffeeWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KaravanCoffeeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CategoryController> _logger;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;


        public CategoryController(IUnitOfWork unitOfWork, ILogger<CategoryController> logger, IMapper mapper, IWebHostEnvironment environment)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _environment = environment;
        }

        //[Authorize(Roles = "Administrator, Branch Admin, Customer")]
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                var categories = await _unitOfWork.Categories.GetAll(null, new List<string> {"subCategories", "products"});
                var results = _mapper.Map<List<CategoryDTO>>(categories);
                return CustomResult("Category Loaded Succssfully", results, System.Net.HttpStatusCode.OK);

                //return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetCategories)}");
                return CustomResult($"Something Went Wrong in the {nameof(GetCategories)}", System.Net.HttpStatusCode.InternalServerError);
                //return StatusCode(500, "Internal Server Error. Please Try Again Lagter.");
            }
        }

        //[Authorize(Roles = "Administrator, Branch Admin, Customer")]
        [HttpGet("{id:int}", Name = "GetCategory")]
        public async Task<IActionResult> GetCategory(int id)
        {
            try
            {
                var category = await _unitOfWork.Categories.Get(q => q.CategoryId == id, include: q => q.Include(x => x.products));
                var result = _mapper.Map<CategoryDTO>(category);
                return CustomResult($"Category Loaded Succfully", result, System.Net.HttpStatusCode.OK);
                //return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetCategory)}");
                return CustomResult($"Something Went Wrong in the {nameof(GetCategory)}", System.Net.HttpStatusCode.InternalServerError);

                //return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }

        //[Authorize(Roles = "Administrator")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateCategory([FromForm] CreateCategoryDTO categoryDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST Attempt in {nameof(CreateCategory)}");
                return CustomResult($"Invalid Post Attempt {nameof(CreateCategory)}", System.Net.HttpStatusCode.BadRequest);
            }

            try
            {
                //var path1 = Path.GetFullPath()
                //var path = Path.Combine("C:\\Users\\Administrator\\source\\repos\\Karavan Coffee Web API\\", "Asset/Products/", categoryDTO.Image.FileName);
                var category = _mapper.Map<Category>(categoryDTO);

                if (categoryDTO.Image != null)
                    category.ImagePath = Constant.DefalutProductImagepathURL + _unitOfWork.Categories.UploadImage(categoryDTO.Image, Constant.DefaultProductImage);
                else
                    category.ImagePath = Constant.DefaultProductImage;


                await _unitOfWork.Categories.Insert(category);
                //await _unitOfWork.Categories.UploadImage(category.Image);
                await _unitOfWork.Save();

                return CustomResult("Category Created Successfully", System.Net.HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Invalid POST Attempt in {nameof(CreateCategory)}");
                return CustomResult($"Something Went Wrong in the {nameof(CreateCategory)}", System.Net.HttpStatusCode.InternalServerError);
            }
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] UpdateCategoryDTO updateCategoryDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid Update Attempt in {nameof(UpdateCategory)}");
                return CustomResult($"Invalid Update Attempt in {nameof(UpdateCategory)}", System.Net.HttpStatusCode.BadRequest);
            }

            try
            {
                var updateCategory = await _unitOfWork.Categories.Get(q => q.CategoryId == id);
                if (updateCategory == null)
                {
                    _logger.LogError($"Invalid Update Attempt in {nameof(UpdateCategory)}");
                    return CustomResult("Submitted data is invalid", System.Net.HttpStatusCode.BadRequest);
                }

                _mapper.Map(updateCategoryDTO, updateCategory);
                _unitOfWork.Categories.Update(updateCategory);
                await _unitOfWork.Save();

                return CustomResult("Updated Successfully", System.Net.HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Someting Went Wrong in the {nameof(UpdateCategory)}");
                return CustomResult($"Something Went Wrong in the {nameof(UpdateCategory)}", System.Net.HttpStatusCode.InternalServerError);
            }
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid Delete attemp in {nameof(DeleteCategory)}");
                return CustomResult($"Invalid Delete attempt in {nameof(DeleteCategory)}");
            }

            try
            {
                var category = await _unitOfWork.Categories.Get(q => q.CategoryId == id);
                if (category == null)
                {
                    _logger.LogError($"Invalid Delete attemp in {nameof(DeleteCategory)}");
                    return CustomResult($"Invlaid Delte attempt in {nameof(DeleteCategory)}", System.Net.HttpStatusCode.BadRequest);
                }

                await _unitOfWork.Categories.Delete(id);
                await _unitOfWork.Save();

                return CustomResult("Deleted Successfully", System.Net.HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something Went Wrong in the {nameof(DeleteCategory)}");
                return CustomResult("Internal Server Error. Please Try Again Later", System.Net.HttpStatusCode.InternalServerError);
            }
        }
    }
}
