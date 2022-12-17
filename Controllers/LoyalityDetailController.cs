using AutoMapper;
using KaravanCoffeeWebAPI.Data;
using KaravanCoffeeWebAPI.IRepository;
using KaravanCoffeeWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KaravanCoffeeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoyalityDetailController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<BranchController> _logger;
        private readonly IMapper _mapper;

        public LoyalityDetailController(IUnitOfWork unitOfWork, ILogger<BranchController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;

        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public async Task<IActionResult> GetLoyaltiesDetail()
        {
            try
            {
                var loyalityDetail = await _unitOfWork.LoyaltiesDetail.GetAll();
                var results = _mapper.Map<List<LoyalityDetailDTO>>(loyalityDetail);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetLoyaltiesDetail)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Lagter.");
            }
        }

        [Authorize(Roles = "Customer")]
        [HttpGet("{id:int}", Name = "GetLoyalityDetail")]
        public async Task<IActionResult> GetLoyalityDetail(int id)
        {
            try
            {
                var loyaltyDetail = await _unitOfWork.LoyaltiesDetail.Get(q => q.LoyalityId == id);
                var result = _mapper.Map<LoyalityDetailDTO>(loyaltyDetail);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetLoyalityDetail)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Lagter.");
            }
        }

        [Authorize(Roles = "Customer")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateLoyalityDetail([FromBody] CreateLoyalityDetailDTO loyalityDetailDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST Attempt in {nameof(CreateLoyalityDetail)}");
                return BadRequest(ModelState);
            }

            try
            {
                var loyalityDetail = _mapper.Map<LoyalityDetail>(loyalityDetailDTO);
                await _unitOfWork.LoyaltiesDetail.Insert(loyalityDetail);
                await _unitOfWork.Save();

                return StatusCode(201, "Reward Created Sussfully");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Invalid POST Attempt in {nameof(CreateLoyalityDetail)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later");
            }
        }

        [Authorize(Roles = "Customer")]
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateLoyalityDetail(int id, [FromBody] CreateLoyalityDetailDTO updateLoyalityDetailDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid Update Attempt in {nameof(UpdateLoyalityDetail)}");
                return BadRequest(ModelState);
            }

            try
            {
                var loyalityDetail = await _unitOfWork.LoyaltiesDetail.Get(q => q.LoyalityId == id);
                if (loyalityDetail == null)
                {
                    _logger.LogError($"Invalid Update Attempt in {nameof(UpdateLoyalityDetail)}");
                    return BadRequest("submitted data is invalid");
                }

                _mapper.Map(updateLoyalityDetailDTO, loyalityDetail);
                _unitOfWork.LoyaltiesDetail.Update(loyalityDetail);
                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception)
            {
                _logger.LogError($"Someting Went Wrong in the {nameof(UpdateLoyalityDetail)}");
                return BadRequest(ModelState);
            }
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteLoyalityDetail(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid Delete attemp in {nameof(DeleteLoyalityDetail)}");
                return BadRequest();
            }

            try
            {
                var loyalityDetail = await _unitOfWork.LoyaltiesDetail.Get(q => q.LoyalityId == id);
                if (loyalityDetail == null)
                {
                    _logger.LogError($"Invalid Delete attemp in {nameof(DeleteLoyalityDetail)}");
                    return BadRequest("Submitted data is invalid");
                }

                await _unitOfWork.LoyaltiesDetail.Delete(id);
                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something Went Wrong in the {nameof(DeleteLoyalityDetail)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later");
            }
        }
    }
}
