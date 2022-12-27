using AutoMapper;
using KaravanCoffeeWebAPI.Data;
using KaravanCoffeeWebAPI.IRepository;
using KaravanCoffeeWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace KaravanCoffeeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<SubCategoryController> _logger;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;


        public SubCategoryController(IUnitOfWork unitOfWork, ILogger<SubCategoryController> logger, IMapper mapper, IWebHostEnvironment environment)
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
                var subCategories = await _unitOfWork.SubCategories.GetAll();
                var results = _mapper.Map<List<SubCategoryDTO>>(subCategories);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetCategories)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Lagter.");
            }
        }

        //[Authorize(Roles = "Administrator, Branch Admin, Customer")]
        [HttpGet("{id:int}", Name = "GetSubCategory")]
        public async Task<IActionResult> GetSubCategory(int id)
        {
            try
            {
                var subCategory = await _unitOfWork.SubCategories.Get(q => q.SubCategoryId == id);
                var result = _mapper.Map<SubCategoryDTO>(subCategory);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetSubCategory)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }

        //[Authorize(Roles = "Administrator")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateSubCategory([FromForm] CreateSubCategoryDTO subCategoryDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST Attempt in {nameof(CreateSubCategory)}");
                return BadRequest(ModelState);
            }

            try
            {
                //var path1 = Path.GetFullPath()
                //var path = Path.Combine("C:\\Users\\Administrator\\source\\repos\\Karavan Coffee Web API\\", "Asset/Products/", subCategoryDTO.Image.FileName);
                //subCategoryDTO.ImagePath = path;
                var subCategory = _mapper.Map<SubCategory>(subCategoryDTO);

                if (subCategoryDTO.Image != null)
                    subCategory.ImagePath = _unitOfWork.SubCategories.UploadImage(subCategory.Image);
                else
                    subCategoryDTO.ImagePath = Path.Combine(_environment.WebRootPath + Constant.DefaultProductImagePath + Constant.DefaultProductImage);

                await _unitOfWork.SubCategories.Insert(subCategory);
               //await _unitOfWork.SubCategories.SaveImage(subCategory.Image, path);
                await _unitOfWork.Save();

                return StatusCode(201, "SubCategory Created Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Invalid POST Attempt in {nameof(CreateSubCategory)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later");
            }
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateSubCategory(int id, [FromBody] UpdateSubCategoryDTO updateSubCategoryDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid Update Attempt in {nameof(UpdateSubCategory)}");
                return BadRequest(ModelState);
            }

            try
            {
                var updateSubCategory = await _unitOfWork.SubCategories.Get(q => q.SubCategoryId == id);
                if (updateSubCategory == null)
                {
                    _logger.LogError($"Invalid Update Attempt in {nameof(UpdateSubCategory)}");
                    return BadRequest("submitted data is invalid");
                }

                _mapper.Map(updateSubCategoryDTO, updateSubCategory);
                _unitOfWork.SubCategories.Update(updateSubCategory);
                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Someting Went Wrong in the {nameof(UpdateSubCategory)}");
                return BadRequest(ModelState);
            }
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteSubCategory(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid Delete attemp in {nameof(DeleteSubCategory)}");
                return BadRequest();
            }

            try
            {
                var subCategory = await _unitOfWork.SubCategories.Get(q => q.SubCategoryId == id);
                if (subCategory == null)
                {
                    _logger.LogError($"Invalid Delete attemp in {nameof(DeleteSubCategory)}");
                    return BadRequest("Submitted data is invalid");
                }

                await _unitOfWork.SubCategories.Delete(id);
                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something Went Wrong in the {nameof(DeleteSubCategory)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later");
            }
        }
    }
}
