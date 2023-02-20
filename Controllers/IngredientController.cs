using AutoMapper;
using CoreApiResponse;
using KaravanCoffeeWebAPI.Data;
using KaravanCoffeeWebAPI.IRepository;
using KaravanCoffeeWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KaravanCoffeeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<IngredientController> _logger;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;


        public IngredientController(IUnitOfWork unitOfWork, ILogger<IngredientController> logger, IMapper mapper, IWebHostEnvironment environment)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _environment = environment;
        }

        //[Authorize(Roles = "Administrator, Branch Admin, Customer")]
        [HttpGet]
        public async Task<IActionResult> GetIngredients()
        {
            try
            {
                var ingredinets = await _unitOfWork.Ingredients.GetAll();
                var results = _mapper.Map<List<IngredientDTO>>(ingredinets);
                return CustomResult("Ingredient Loaded Succssfully", results, System.Net.HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetIngredients)}");
                return CustomResult($"Something Went Wrong in the {nameof(GetIngredients)}", System.Net.HttpStatusCode.InternalServerError);
            }
        }

        //[Authorize(Roles = "Administrator, Branch Admin, Customer")]
        [HttpGet("{id:int}", Name = "GetIngredient")]
        public async Task<IActionResult> GetIngredient(int id)
        {
            try
            {
                var ingredinet = await _unitOfWork.Ingredients.Get(q => q.IngredientId == id);
                var result = _mapper.Map<IngredientDTO>(ingredinet);
                return CustomResult($"Gallery Loaded Succfully", result, System.Net.HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetIngredient)}");
                return CustomResult($"Something Went Wrong in the {nameof(GetIngredient)}", System.Net.HttpStatusCode.InternalServerError);
            }
        }

        //[Authorize(Roles = "Administrator")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateIngredient([FromForm] CreateIngredientDTO ingredinetDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST Attempt in {nameof(CreateIngredient)}");
                return CustomResult($"Invalid Post Attempt {nameof(CreateIngredient)}", System.Net.HttpStatusCode.BadRequest);
            }

            try
            {
                //var path = Path.Combine("C:\\Users\\Administrator\\source\\repos\\Karavan Coffee Web API\\", "Asset/Ingredinets/" , ingredinetDTO.Image.FileName);
                //ingredinetDTO.ImagePath = path;
                var ingredinet = _mapper.Map<Ingredient>(ingredinetDTO);

                if (ingredinetDTO.Image != null)
                    ingredinet.ImagePath = Constant.DefalutProductImagepathURL + _unitOfWork.Ingredients.UploadImage(ingredinetDTO.Image, Constant.DefaultProductImagePath);
                else
                    ingredinet.ImagePath = Constant.DefaultProductImage;

                await _unitOfWork.Ingredients.Insert(ingredinet);
                await _unitOfWork.Save();

                return CustomResult("Ingredient Created Successfully", System.Net.HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Invalid POST Attempt in {nameof(CreateIngredient)}");
                return CustomResult($"Something Went Wrong in the {nameof(CreateIngredient)}", System.Net.HttpStatusCode.InternalServerError);
            }
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateIngredient(int id, [FromBody] UpdateIngredientDTO updateIngredientDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid Update Attempt in {nameof(UpdateIngredient)}");
                return CustomResult($"Invalid Update Attempt in {nameof(UpdateIngredient)}", System.Net.HttpStatusCode.BadRequest);
            }

            try
            {
                var updateProduct = await _unitOfWork.Ingredients.Get(q => q.IngredientId == id);
                if (updateProduct == null)
                {
                    _logger.LogError($"Invalid Update Attempt in {nameof(UpdateIngredient)}");
                    return CustomResult("Submitted data is invalid", System.Net.HttpStatusCode.BadRequest);
                }

                _mapper.Map(updateIngredientDTO, updateProduct);
                _unitOfWork.Ingredients.Update(updateProduct);
                await _unitOfWork.Save();

                return CustomResult("Updated Successfully", System.Net.HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Someting Went Wrong in the {nameof(UpdateIngredient)}");
                return CustomResult($"Something Went Wrong in the {nameof(UpdateIngredient)}", System.Net.HttpStatusCode.InternalServerError);
            }
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteIngredient(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid Delete attemp in {nameof(DeleteIngredient)}");
                return CustomResult($"Invalid Delete attempt in {nameof(DeleteIngredient)}");
            }

            try
            {
                var ingredinet = await _unitOfWork.Ingredients.Get(q => q.IngredientId == id);
                if (ingredinet == null)
                {
                    _logger.LogError($"Invalid Delete attemp in {nameof(DeleteIngredient)}");
                    return CustomResult($"Invalid Delete attempt in {nameof(DeleteIngredient)}");
                }

                await _unitOfWork.Ingredients.Delete(id);
                await _unitOfWork.Save();

                return CustomResult("Deleted Successfully", System.Net.HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something Went Wrong in the {nameof(DeleteIngredient)}");
                return CustomResult("Internal Server Error. Please Try Again Later", System.Net.HttpStatusCode.InternalServerError);
            }
        }
    }
}
