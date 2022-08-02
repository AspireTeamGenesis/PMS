using PMS_API;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace PMS_API
{
    public class LoginService:ILoginService
    {
        private readonly IUserData _userData;
        private readonly ILogger<LoginService> _logger;
        private readonly IConfiguration _configuration;

        public LoginService(ILogger<LoginService> logger, IConfiguration configuration, IUserData userData)
        {
            _logger = logger;
            _configuration = configuration;
            _userData = userData;
        }

        public object AuthLogin(string UserName, string Password)
        {
            try
            {
                var user =_userData.LoginCrendentials(UserName,Password);

                var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("Username",user.UserName!),
                        new Claim("UserId",user.UserId.ToString()),                      
                        new Claim("DesignationId",user.DesignationId.ToString()),
                    };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                        claims,
                    expires: DateTime.UtcNow.AddHours(6),
                    signingCredentials: signIn);

                var Result = new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    ExpiryInMinutes = 360,
                    IsHR = user.DesignationId == 1 ? true : false,
                    IsAdmin = user.DesignationId == 2 ? true : false
                };

                return Result;

            }
            catch (ValidationException loginCredentialsNotValid)
            {
                _logger.LogInformation($"User DAL : LoginCredentails throwed an exception : {loginCredentialsNotValid.Message}");
                throw;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"User DAL : LoginCredentails throwed an exception : {exception.Message}");
                throw;
            }
        }

    }
}
