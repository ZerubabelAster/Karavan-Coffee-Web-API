using KaravanCoffeeWebAPI.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
                    //issuer: jwtSetting.GetSection("Issuer").Value,
                    //audience: jwtSetting.GetSection("Audience").Value,
                    claims: claims,
                    expires: expiration,
                    signingCredentials: signingCredentials
                );

            return token;
        }

        private async Task<List<Claim>> GetClaims()
        {
            //string role, userName, Email;
            var claims = new List<Claim>
            {
                //new Claim(ClaimTypes.Name, _person.UserName),
                new Claim(JwtRegisteredClaimNames.Name, _person.FullName),
                new Claim(JwtRegisteredClaimNames.Email, _person.UserName),
                new Claim(JwtRegisteredClaimNames.UniqueName, _person.UserName),
            };

            var roles = await _userManager.GetRolesAsync(_person);

            foreach (var role in roles)
            {
                claims.Add(new Claim("role", role));
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

        public async Task<bool> ValidateUser(string PhoneOREmail, string password)
        {
            var username = PhoneOREmail;
            if (username.Contains("@"))
            {
                _person = await _userManager.FindByEmailAsync(PhoneOREmail);
                return (_person != null && await _userManager.CheckPasswordAsync(_person, password));
            }
            else
            {
                _person = await _userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == PhoneOREmail);
                return (_person != null && await _userManager.CheckPasswordAsync(_person, password));
            }

        }

        public async Task<bool> IsUserRegistered(string PhoneOREmail)
        {
            var username = PhoneOREmail;
            if (username.Contains("@"))
            {
                return await _userManager.FindByEmailAsync(PhoneOREmail) != null;
            }
            else
            {
                return await _userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == PhoneOREmail) != null;
            }

        }
    }
}
