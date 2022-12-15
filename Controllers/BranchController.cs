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
    public class BranchController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<BranchController> _logger;
        private readonly IMapper _mapper;

        public BranchController(IUnitOfWork unitOfWork, ILogger<BranchController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;   
            _mapper = mapper;

        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetBranches()
        {
            try
            {
                var branches = await _unitOfWork.Branches.GetAll();
                var results = _mapper.Map<List<BranchDTO>>(branches);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetBranches)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Lagter.");
            }
        }

        [Authorize]
        [HttpGet("{id:int}", Name = "GetBranch")]
        public async Task<IActionResult> GetBranch(int id)
        {
            try
            {
                var branch = await _unitOfWork.Branches.Get(q => q.BranchId == id);
                var result = _mapper.Map<BranchDTO>(branch);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetBranch)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateBranch([FromBody] CreateBranchDTO branchDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST Attempt in {nameof(CreateBranch)}");
                return BadRequest(ModelState);
            }

            try
            {
                var branch = _mapper.Map<Branch>(branchDTO);
                await _unitOfWork.Branches.Insert(branch);
                await _unitOfWork.Save();

                return (IActionResult)Results.Created($"/Branchs/{branch.BranchId}", branch);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Invalid POST Attempt in {nameof(CreateBranch)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later");
            }
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateBranch(int id, [FromBody] UpdateBranchDTO updateBranchDTO)
        {
            if(!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid Update Attempt in {nameof(UpdateBranch)}");
                return BadRequest(ModelState);
            }

            try
            {
                var branch = await _unitOfWork.Branches.Get(q => q.BranchId == id);
                if( branch == null)
                {
                    _logger.LogError($"Invalid Update Attempt in {nameof(UpdateBranch)}");
                    return BadRequest("submitted data is invalid");
                }

                _mapper.Map(updateBranchDTO, branch);
                _unitOfWork.Branches.Update(branch);
                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Someting Went Wrong in the {nameof(UpdateBranch)}");
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteBranch(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid Delete attemp in {nameof(DeleteBranch)}");
                return BadRequest();
            }

            try
            {
                var branch = await _unitOfWork.Branches.Get(q => q.BranchId == id);
                if (branch == null)
                {
                    _logger.LogError($"Invalid Delete attemp in {nameof(DeleteBranch)}");
                    return BadRequest("Submitted data is invalid");
                }

                await _unitOfWork.Branches.Delete(id);
                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something Went Wrong in the {nameof(DeleteBranch)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later");
            }
        }
    }
}
