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
    public class SubCategoryController : BaseController
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
        public async Task<IActionResult> GetSubCategories()
        {
            try
            {
                var subCategories = await _unitOfWork.SubCategories.GetAll(null, new List<string> { "products" });
                var results = _mapper.Map<List<SubCategoryDTO>>(subCategories);
                return CustomResult("Sub Category Loaded Succssfully", results, System.Net.HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetSubCategories)}");
                return CustomResult($"Something Went Wrong in the {nameof(GetSubCategories)}", System.Net.HttpStatusCode.InternalServerError);
            }
        }

        //[Authorize(Roles = "Administrator, Branch Admin, Customer")]
        [HttpGet("{id:int}", Name = "GetSubCategory")]
        public async Task<IActionResult> GetSubCategory(int id)
        {
            try
            {
                var subCategory = await _unitOfWork.SubCategories.Get(q => q.SubCategoryId == id, include: q => q.Include(x => x.products));
                var result = _mapper.Map<SubCategoryDTO>(subCategory);
                return CustomResult($"Sub Category Loaded Succfully", result, System.Net.HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetSubCategory)}");
                return CustomResult($"Something Went Wrong in the {nameof(GetSubCategory)}", System.Net.HttpStatusCode.InternalServerError);
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
                return CustomResult($"Invalid Post Attempt {nameof(CreateSubCategory)}", System.Net.HttpStatusCode.BadRequest);
            }

            try
            {
                //var path1 = Path.GetFullPath()
                //var path = Path.Combine("C:\\Users\\Administrator\\source\\repos\\Karavan Coffee Web API\\", "Asset/Products/", subCategoryDTO.Image.FileName);
                //subCategoryDTO.ImagePath = path;
                var subCategory = _mapper.Map<SubCategory>(subCategoryDTO);

                if (subCategoryDTO.Image != null)
                    subCategory.ImagePath = Constant.DefalutProductImagepathURL + _unitOfWork.SubCategories.UploadImage(subCategoryDTO.Image, Constant.DefaultProductImage);
                else
                    subCategory.ImagePath = Constant.DefaultProductImage;

                await _unitOfWork.SubCategories.Insert(subCategory);
                //await _unitOfWork.SubCategories.SaveImage(subCategory.Image, path);
                await _unitOfWork.Save();

                return CustomResult("Sub Category Created Successfully", System.Net.HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Invalid POST Attempt in {nameof(CreateSubCategory)}");
                return CustomResult($"Something Went Wrong in the {nameof(CreateSubCategory)}", System.Net.HttpStatusCode.InternalServerError);
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
                return CustomResult($"Invalid Update Attempt in {nameof(UpdateSubCategory)}", System.Net.HttpStatusCode.BadRequest);
            }

            try
            {
                var updateSubCategory = await _unitOfWork.SubCategories.Get(q => q.SubCategoryId == id);
                if (updateSubCategory == null)
                {
                    _logger.LogError($"Invalid Update Attempt in {nameof(UpdateSubCategory)}");
                    return CustomResult("Submitted data is invalid", System.Net.HttpStatusCode.BadRequest);
                }

                _mapper.Map(updateSubCategoryDTO, updateSubCategory);
                _unitOfWork.SubCategories.Update(updateSubCategory);
                await _unitOfWork.Save();

                return CustomResult("Updated Successfully", System.Net.HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Someting Went Wrong in the {nameof(UpdateSubCategory)}");
                return CustomResult($"Something Went Wrong in the {nameof(UpdateSubCategory)}", System.Net.HttpStatusCode.InternalServerError);
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
                return CustomResult($"Invalid Update Attempt in {nameof(DeleteSubCategory)}", System.Net.HttpStatusCode.BadRequest);
            }

            try
            {
                var subCategory = await _unitOfWork.SubCategories.Get(q => q.SubCategoryId == id);
                if (subCategory == null)
                {
                    _logger.LogError($"Invalid Delete attemp in {nameof(DeleteSubCategory)}");
                    return CustomResult($"Invlaid Delete attempt in {nameof(DeleteSubCategory)}", System.Net.HttpStatusCode.BadRequest);
                }

                await _unitOfWork.SubCategories.Delete(id);
                await _unitOfWork.Save();

                return CustomResult("Deleted Successfully", System.Net.HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something Went Wrong in the {nameof(DeleteSubCategory)}");
                return CustomResult($"Something Went Wrong in the {nameof(DeleteSubCategory)}", System.Net.HttpStatusCode.InternalServerError);
            }
        }
    }
}
