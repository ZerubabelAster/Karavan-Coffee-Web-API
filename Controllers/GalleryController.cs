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
    public class GalleryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GalleryController> _logger;
        private readonly IMapper _mapper;

        public GalleryController(IUnitOfWork unitOfWork, ILogger<GalleryController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;

        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> GetGalleries()
        {
            try
            {
                var galleries = await _unitOfWork.Galleries.GetAll();
                var results = _mapper.Map<List<GalleryDTO>>(galleries);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetGalleries)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Lagter.");
            }
        }

        [Authorize(Roles = "Administrator, Branch Admin")]
        [HttpGet("{id:int}", Name = "GetGallery")]
        public async Task<IActionResult> GetGallery(int id)
        {
            try
            {
                var gallery = await _unitOfWork.Galleries.Get(q => q.GalleryId == id);
                var result = _mapper.Map<GalleryDTO>(gallery);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetGalleries)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateGallery([FromBody] CreateGalleryDTO  galleryDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST Attempt in {nameof(CreateGallery)}");
                return BadRequest(ModelState);
            }

            try
            {
                var gallery = _mapper.Map<Gallery>(galleryDTO);
                await _unitOfWork.Galleries.Insert(gallery);
                await _unitOfWork.Save();

                return StatusCode(201, "Gallery Created Successfully");
            }
            catch (Exception)
            {
                _logger.LogError($"Invalid POST Attempt in {nameof(CreateGallery)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later");
            }
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateGallery(int id, [FromBody] UpdateGalleryDTO updateGalleryDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid Update Attempt in {nameof(UpdateGallery)}");
                return BadRequest(ModelState);
            }

            try
            {
                var gallery = await _unitOfWork.Galleries.Get(q => q.GalleryId == id);
                if (gallery == null)
                {
                    _logger.LogError($"Invalid Update Attempt in {nameof(UpdateGallery)}");
                    return BadRequest("submitted data is invalid");
                }

                _mapper.Map(updateGalleryDTO, gallery);
                _unitOfWork.Galleries.Update(gallery);
                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Someting Went Wrong in the {nameof(UpdateGallery)}");
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteGallery(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid Delete attemp in {nameof(DeleteGallery)}");
                return BadRequest();
            }

            try
            {
                var gallery = await _unitOfWork.Galleries.Get(q => q.GalleryId == id);
                if (gallery == null)
                {
                    _logger.LogError($"Invalid Delete attemp in {nameof(DeleteGallery)}");
                    return BadRequest("Submitted data is invalid");
                }

                await _unitOfWork.Galleries.Delete(id);
                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something Went Wrong in the {nameof(DeleteGallery)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later");
            }
        }
    }
}
