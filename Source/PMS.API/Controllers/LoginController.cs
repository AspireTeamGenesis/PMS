using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.ComponentModel.DataAnnotations;
namespace PMS_API
{
//    [ApiController]
    [Route("[controller]/[Action]")]
    public class LoginController :Controller{
        
        private ILoginService _loginServices;
         private readonly ILogger<LoginController> _logger;
        public LoginController(ILoginService loginServices, ILogger<LoginController> logger)
        {

            _loginServices = loginServices;
            _logger = logger;
        }
        [HttpPost("Login")]
        public IActionResult AuthLogin(string Username, string password)
        {
            try
            {
                
                var Result = _loginServices.AuthLogin(Username, password);                
                return Ok(Result);
            }
            catch (ValidationException validationException)
            {
                _logger.LogInformation($"Login Service : AuthLogin() : {validationException.Message}");
                return BadRequest(new{message=validationException.Message});
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Login Service : AuthLogin() : {exception.Message}");
                return Problem("Sorry some internal error occured");
            }
        }
     
}
}
