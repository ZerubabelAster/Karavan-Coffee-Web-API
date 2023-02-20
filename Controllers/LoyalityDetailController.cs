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
    public class LoyalityDetailController : BaseController
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
                return CustomResult("Loyalities Loaded Succssfully", results, System.Net.HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetLoyaltiesDetail)}");
                return CustomResult($"Something Went Wrong in the {nameof(GetLoyaltiesDetail)}", System.Net.HttpStatusCode.InternalServerError);
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
                return CustomResult($"Loyality Loaded Succfully", result, System.Net.HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetLoyalityDetail)}");
                return CustomResult($"Something Went Wrong in the {nameof(GetLoyalityDetail)}", System.Net.HttpStatusCode.InternalServerError);
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
                return CustomResult($"Invalid Post Attempt {nameof(CreateLoyalityDetail)}", System.Net.HttpStatusCode.BadRequest);
            }

            try
            {
                var loyalityDetail = _mapper.Map<LoyalityDetail>(loyalityDetailDTO);
                await _unitOfWork.LoyaltiesDetail.Insert(loyalityDetail);
                await _unitOfWork.Save();

                return CustomResult("Reward Created Successfully", System.Net.HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Invalid POST Attempt in {nameof(CreateLoyalityDetail)}");
                return CustomResult($"Something Went Wrong in the {nameof(CreateLoyalityDetail)}", System.Net.HttpStatusCode.InternalServerError);
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
                return CustomResult($"Invalid Update Attempt in {nameof(UpdateLoyalityDetail)}", System.Net.HttpStatusCode.BadRequest);
            }

            try
            {
                var loyalityDetail = await _unitOfWork.LoyaltiesDetail.Get(q => q.LoyalityId == id);
                if (loyalityDetail == null)
                {
                    _logger.LogError($"Invalid Update Attempt in {nameof(UpdateLoyalityDetail)}");
                    return CustomResult("Submitted data is invalid", System.Net.HttpStatusCode.BadRequest);
                }

                _mapper.Map(updateLoyalityDetailDTO, loyalityDetail);
                _unitOfWork.LoyaltiesDetail.Update(loyalityDetail);
                await _unitOfWork.Save();

                return CustomResult("Updated Successfully", System.Net.HttpStatusCode.NoContent);
            }
            catch (Exception)
            {
                _logger.LogError($"Someting Went Wrong in the {nameof(UpdateLoyalityDetail)}");
                return CustomResult($"Something Went Wrong in the {nameof(UpdateLoyalityDetail)}", System.Net.HttpStatusCode.InternalServerError);
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
                return CustomResult($"Invalid Delete attempt in {nameof(DeleteLoyalityDetail)}");
            }

            try
            {
                var loyalityDetail = await _unitOfWork.LoyaltiesDetail.Get(q => q.LoyalityId == id);
                if (loyalityDetail == null)
                {
                    _logger.LogError($"Invalid Delete attemp in {nameof(DeleteLoyalityDetail)}");
                    return CustomResult($"Invlaid Delete attempt in {nameof(DeleteLoyalityDetail)}", System.Net.HttpStatusCode.BadRequest);
                }

                await _unitOfWork.LoyaltiesDetail.Delete(id);
                await _unitOfWork.Save();

                return CustomResult("Deleted Successfully", System.Net.HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something Went Wrong in the {nameof(DeleteLoyalityDetail)}");
                return CustomResult("Internal Server Error. Please Try Again Later", System.Net.HttpStatusCode.InternalServerError);
            }
        }
    }
}
