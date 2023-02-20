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
    public class GalleryController : BaseController
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
        //[Authorize(Roles = "Administrator")]
        public async Task<IActionResult> GetGalleries()
        {
            try
            {
                var galleries = await _unitOfWork.Galleries.GetAll();
                var results = _mapper.Map<List<GalleryDTO>>(galleries);
                return CustomResult("Gallery Loaded Succssfully", results, System.Net.HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetGalleries)}");
                return CustomResult($"Something Went Wrong in the {nameof(GetGalleries)}", System.Net.HttpStatusCode.InternalServerError);
            }
        }

        //[Authorize(Roles = "Administrator, Branch Admin")]
        [HttpGet("{id:int}", Name = "GetGallery")]
        public async Task<IActionResult> GetGallery(int id)
        {
            try
            {
                var gallery = await _unitOfWork.Galleries.Get(q => q.GalleryId == id);
                var result = _mapper.Map<GalleryDTO>(gallery);
                return CustomResult($"Gallery Loaded Succfully", result, System.Net.HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetGallery)}");
                return CustomResult($"Something Went Wrong in the {nameof(GetGallery)}", System.Net.HttpStatusCode.InternalServerError);
            }
        }

        //[Authorize(Roles = "Administrator")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateGallery([FromForm] CreateGalleryDTO galleryDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST Attempt in {nameof(CreateGallery)}");
                return CustomResult($"Invalid Post Attempt {nameof(CreateGallery)}", System.Net.HttpStatusCode.BadRequest);
            }

            try
            {
                var gallery = _mapper.Map<Gallery>(galleryDTO);
                gallery.ImagePath = Constant.DefalutGalleryImagepathURL + _unitOfWork.Galleries.UploadImage(galleryDTO.Image, Constant.DefaultGalleryImagePath);
                await _unitOfWork.Galleries.Insert(gallery);
                await _unitOfWork.Save();

                return CustomResult("Gallery Created Successfully", System.Net.HttpStatusCode.Created);
            }
            catch (Exception)
            {
                _logger.LogError($"Invalid POST Attempt in {nameof(CreateGallery)}");
                return CustomResult($"Something Went Wrong in the {nameof(CreateGallery)}", System.Net.HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateGallery(int id, [FromForm] UpdateGalleryDTO updateGalleryDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid Update Attempt in {nameof(UpdateGallery)}");
                return CustomResult($"Invalid Update Attempt in {nameof(UpdateGallery)}", System.Net.HttpStatusCode.BadRequest);
            }

            try
            {
                var gallery = await _unitOfWork.Galleries.Get(q => q.GalleryId == id);
                if (gallery == null)
                {
                    _logger.LogError($"Invalid Update Attempt in {nameof(UpdateGallery)}");
                    return CustomResult("Submitted data is invalid", System.Net.HttpStatusCode.BadRequest);
                }

                _mapper.Map(updateGalleryDTO, gallery);
                _unitOfWork.Galleries.Update(gallery);
                await _unitOfWork.Save();

                return CustomResult("Updated Successfully", System.Net.HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Someting Went Wrong in the {nameof(UpdateGallery)}");
                return CustomResult($"Something Went Wrong in the {nameof(UpdateGallery)}", System.Net.HttpStatusCode.InternalServerError);
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
                return CustomResult($"Invalid Delete attempt in {nameof(DeleteGallery)}");
            }

            try
            {
                var gallery = await _unitOfWork.Galleries.Get(q => q.GalleryId == id);
                if (gallery == null)
                {
                    _logger.LogError($"Invalid Delete attemp in {nameof(DeleteGallery)}");
                    return CustomResult($"Invlaid Delte attempt in {nameof(DeleteGallery)}", System.Net.HttpStatusCode.BadRequest);
                }

                await _unitOfWork.Galleries.Delete(id);
                await _unitOfWork.Save();

                return CustomResult("Deleted Successfully", System.Net.HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something Went Wrong in the {nameof(DeleteGallery)}");
                return CustomResult("Internal Server Error. Please Try Again Later", System.Net.HttpStatusCode.InternalServerError);
            }
        }
    }
}
