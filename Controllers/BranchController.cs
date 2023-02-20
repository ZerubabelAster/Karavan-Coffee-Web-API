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
    public class BranchController : BaseController
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
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> GetBranches()
        {
            try
            {
                var branches = await _unitOfWork.Branches.GetAll();
                var results = _mapper.Map<List<BranchDTO>>(branches);
                if (results.Count > 0)
                {
                    return CustomResult("Branch Loaded Successfully", results);
                }
                else
                    return CustomResult("Branch Not Found", System.Net.HttpStatusCode.NotFound);

                //return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetBranches)}");
                return CustomResult("Internal Server Error", System.Net.HttpStatusCode.InternalServerError);
                //return StatusCode(500, "Internal Server Error. Please Try Again Lagter.");
            }
        }

        [Authorize(Roles = "Administrator, Branch Admin")]
        [HttpGet("{id:int}", Name = "GetBranch")]
        public async Task<IActionResult> GetBranch(int id)
        {
            try
            {
                var branch = await _unitOfWork.Branches.Get(q => q.BranchId == id);
                var result = _mapper.Map<BranchDTO>(branch);
                return CustomResult($"The Branch request is OK.", result, System.Net.HttpStatusCode.OK);

                //return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetBranch)}");
                return CustomResult($"Something Went Wrong in the {nameof(GetBranch)}", System.Net.HttpStatusCode.InternalServerError);

                //return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateBranch([FromBody] CreateBranchDTO branchDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST Attempt in {nameof(CreateBranch)}");
                return CustomResult($"Invalid Post Attempt {nameof(CreateBranch)}", System.Net.HttpStatusCode.BadRequest);

                //return BadRequest(ModelState);
            }

            try
            {
                var branch = _mapper.Map<Branch>(branchDTO);
                await _unitOfWork.Branches.Insert(branch);
                await _unitOfWork.Save();
                return CustomResult("Product Created Successfully", System.Net.HttpStatusCode.Created);

                //return StatusCode(201, "Branch Created Successfully");
            }
            catch (Exception)
            {
                _logger.LogError($"Invalid POST Attempt in {nameof(CreateBranch)}");
                return CustomResult($"Something Went Wrong in the {nameof(CreateBranch)}", System.Net.HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateBranch(int id, [FromBody] UpdateBranchDTO updateBranchDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid Update Attempt in {nameof(UpdateBranch)}");
                return BadRequest(ModelState);
            }

            try
            {
                var branch = await _unitOfWork.Branches.Get(q => q.BranchId == id);
                if (branch == null)
                {
                    _logger.LogError($"Invalid Update Attempt in {nameof(UpdateBranch)}");
                    return CustomResult($"Invalid Update Attempt in {nameof(UpdateBranch)}", System.Net.HttpStatusCode.BadRequest);
                }

                _mapper.Map(updateBranchDTO, branch);
                _unitOfWork.Branches.Update(branch);
                await _unitOfWork.Save();
                return CustomResult("Updated Successfully", System.Net.HttpStatusCode.NoContent);

                //return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Someting Went Wrong in the {nameof(UpdateBranch)}");
                return CustomResult($"Something Went Wrong in the {nameof(UpdateBranch)}", System.Net.HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteBranch(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid Delete attemp in {nameof(DeleteBranch)}");
                return CustomResult($"Invalid Delete attempt in {nameof(DeleteBranch)}");
            }

            try
            {
                var branch = await _unitOfWork.Branches.Get(q => q.BranchId == id);
                if (branch == null)
                {
                    _logger.LogError($"Invalid Delete attemp in {nameof(DeleteBranch)}");
                    return CustomResult($"Invlaid Delte attempt in {nameof(DeleteBranch)}", System.Net.HttpStatusCode.BadRequest);
                }

                await _unitOfWork.Branches.Delete(id);
                await _unitOfWork.Save();

                return CustomResult("Deleted Successfully", System.Net.HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something Went Wrong in the {nameof(DeleteBranch)}");
                return CustomResult("Internal Server Error. Please Try Again Later", System.Net.HttpStatusCode.InternalServerError);
            }
        }
    }
}
