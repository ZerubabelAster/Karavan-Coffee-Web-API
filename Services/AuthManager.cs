using KaravanCoffeeWebAPI.Data;
using KaravanCoffeeWebAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace KaravanCoffeeWebAPI.Services
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<Person> _userManager;
        private readonly IConfiguration _configuration;
        private Person _person;

        public AuthManager(UserManager<Person> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<string> CreateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSetting = _configuration.GetSection("Jwt");
            var expiration = DateTime.Now.AddMinutes(Convert.ToDouble(jwtSetting.GetSection("lifetime").Value));
            
            var token = new JwtSecurityToken(
                    issuer: jwtSetting.GetSection("Issuer").Value,
                    audience: jwtSetting.GetSection("Audience").Value,
                    claims: claims,
                    expires: expiration,
                    signingCredentials: signingCredentials
                );

            return token; 
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, _person.UserName),
            };

            var roles = await _userManager.GetRolesAsync(_person);

            foreach(var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        private SigningCredentials GetSigningCredentials()
        {
            /*var key = Environment.GetEnvironmentVariable("KEY");
            var key2 = "new key is created";*/

            //var key = new SymmetricSecurityKey

            var jwtSettings = _configuration.GetSection("jwt");

            var secret = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtSettings.GetSection("Key").Value));

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        public async Task<bool> ValidateUser(LoginPersonDTO loginPersonDTO)
        {
            _person = await _userManager.FindByNameAsync(loginPersonDTO.Email); 
            return (_person != null && await _userManager.CheckPasswordAsync(_person, loginPersonDTO.Password));
        }
    }
}
