using AutoMapper;
using CoreApiResponse;
using KaravanCoffeeWebAPI.Data;
using KaravanCoffeeWebAPI.IRepository;
using KaravanCoffeeWebAPI.Models;
using KaravanCoffeeWebAPI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace KaravanCoffeeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {

        private readonly UserManager<Person> _userManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IMapper _mapper;
        private readonly IAuthManager _authManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _environment;

        public AccountController(UserManager<Person> userManager,
            ILogger<AccountController> logger,
            IMapper mapper,
            IAuthManager authManager, IUnitOfWork unitOfWork, IWebHostEnvironment environment)
        {
            _userManager = userManager;
            _logger = logger;
            _mapper = mapper;
            _authManager = authManager;
            _unitOfWork = unitOfWork;
            _environment = environment;
        }

        [HttpPost]
        [Route("Register")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register([FromBody] PersonDTO personDTO)
        {
            _logger.LogInformation($"Registration Attempt for {personDTO.Email}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_userManager.Users.Any(user => user.PhoneNumber == personDTO.PhoneNumber))
            {
                return CustomResult("This phone number already exists. Try to Login.", System.Net.HttpStatusCode.Conflict);
            }

            try
            {
                var person = _mapper.Map<Person>(personDTO);

                person.ImagePath = Constant.DefaultAvatarImage;

                person.UserName = personDTO.Email;
                var result = await _userManager.CreateAsync(person, personDTO.Password);

                /*if (personDTO.BirthDate == null)
                    person.BirthDate = null;*/

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);
                }

                if (personDTO.Role == null)
                    await _userManager.AddToRoleAsync(person, "CUSTOMER");
                else
                    await _userManager.AddToRoleAsync(person, personDTO.Role);


                if (!await _authManager.ValidateUser(personDTO.PhoneNumber, personDTO.Password))
                {
                    return Unauthorized();
                }

                return CustomResult("Registered Successfully", new { Token = await _authManager.CreateToken() }, System.Net.HttpStatusCode.Accepted);
                
                //return Accepted(new { Token = await _authManager.CreateToken() });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(Register)}");
                return CustomResult($"Something Went Wrong in the {nameof(Register)}", System.Net.HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginByPhonePersonDTO personDTO)
        {
            _logger.LogInformation($"Login Attempt for {personDTO.PhoneOREmail}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                if(!await _authManager.IsUserRegistered(personDTO.PhoneOREmail))
                {
                    return CustomResult("This User does not exist", System.Net.HttpStatusCode.NotFound);
                }

                if (!await _authManager.ValidateUser(personDTO.PhoneOREmail, personDTO.Password))
                {
                    return CustomResult("You are not Authorized!", System.Net.HttpStatusCode.Unauthorized);
                }
                else
                    return CustomResult("Loged in Successfully", new { Token = await _authManager.CreateToken() }, System.Net.HttpStatusCode.Accepted);
                //return Accepted(new { Token = await _authManager.CreateToken()});
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(Login)}");
                return CustomResult($"Something Went Wrong in the {nameof(Login)}", System.Net.HttpStatusCode.InternalServerError);
                //return Problem($"Something Went Wrong in the {nameof(Login)}", statusCode: 500);
            }
        }



        [HttpPut]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateUser(string id, [FromForm] UpdatePersonDTO updatePersonDTO)
        {
            _logger.LogInformation($"Update user Attempt for {updatePersonDTO.Email}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user != null)
                {
                    var person = _mapper.Map<Person>(updatePersonDTO);
                    var result = await _userManager.UpdateAsync(person);

                    if (!result.Succeeded)
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(error.Code, error.Description);
                        }
                        return BadRequest(ModelState);
                    }
                }

                return CustomResult("Update Person Successfully", System.Net.HttpStatusCode.Accepted);

                //return Accepted(new { Token = await _authManager.CreateToken() });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(Register)}");
                return CustomResult($"Something Went Wrong in the {nameof(Login)}", System.Net.HttpStatusCode.InternalServerError);
            }
            
        }

    }
}
