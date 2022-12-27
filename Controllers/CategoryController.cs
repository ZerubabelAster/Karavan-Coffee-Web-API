using AutoMapper;
using KaravanCoffeeWebAPI.Data;
using KaravanCoffeeWebAPI.IRepository;
using KaravanCoffeeWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace KaravanCoffeeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
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
                var categories = await _unitOfWork.Categories.GetAll();
                var results = _mapper.Map<List<CategoryDTO>>(categories);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetCategories)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Lagter.");
            }
        }

        //[Authorize(Roles = "Administrator, Branch Admin, Customer")]
        [HttpGet("{id:int}", Name = "GetCategory")]
        public async Task<IActionResult> GetCategory(int id)
        {
            try
            {
                var category = await _unitOfWork.Categories.Get(q => q.CategoryId == id, include: q => q.Include(x => x.Products));
                var result = _mapper.Map<CategoryDTO>(category);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetCategory)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
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
                return BadRequest(ModelState);
            }

            try
            {
                //var path1 = Path.GetFullPath()
                //var path = Path.Combine("C:\\Users\\Administrator\\source\\repos\\Karavan Coffee Web API\\", "Asset/Products/", categoryDTO.Image.FileName);
                var category = _mapper.Map<Category>(categoryDTO);

                if (categoryDTO.Image != null)
                    category.ImagePath = _unitOfWork.Categories.UploadImage(category.Image);
                else
                    categoryDTO.ImagePath = Path.Combine(_environment.WebRootPath + Constant.DefaultProductImagePath + Constant.DefaultProductImage);


                await _unitOfWork.Categories.Insert(category);
                //await _unitOfWork.Categories.UploadImage(category.Image);
                await _unitOfWork.Save();

                return StatusCode(201, "Category Created Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Invalid POST Attempt in {nameof(CreateCategory)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later");
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
                return BadRequest(ModelState);
            }

            try
            {
                var updateCategory = await _unitOfWork.Categories.Get(q => q.CategoryId == id);
                if (updateCategory == null)
                {
                    _logger.LogError($"Invalid Update Attempt in {nameof(UpdateCategory)}");
                    return BadRequest("submitted data is invalid");
                }

                _mapper.Map(updateCategoryDTO, updateCategory);
                _unitOfWork.Categories.Update(updateCategory);
                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Someting Went Wrong in the {nameof(UpdateCategory)}");
                return BadRequest(ModelState);
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
                return BadRequest();
            }

            try
            {
                var category = await _unitOfWork.Categories.Get(q => q.CategoryId == id);
                if (category == null)
                {
                    _logger.LogError($"Invalid Delete attemp in {nameof(DeleteCategory)}");
                    return BadRequest("Submitted data is invalid");
                }

                await _unitOfWork.Categories.Delete(id);
                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something Went Wrong in the {nameof(DeleteCategory)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later");
            }
        }
    }
}
