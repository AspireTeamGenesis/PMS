using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
namespace PMS_API
{
    // [Authorize]
    [ApiController]
    [Route("[controller]/[Action]")]
    public class UserController : Controller
    {

        private IUserServices _userServices;
        private ILogger _logger;
        public UserController(IUserServices userServices, ILogger<UserController> logger)
        {
            _userServices = userServices;
            _logger = logger;

        }
        [HttpGet]
        public IActionResult Getallusers(int profilestatusId)
        {
            try
            {
                int currentDesignation = Convert.ToInt32(User.FindFirst("DesignationId").Value);
                return Ok(_userServices.GetallUsers(profilestatusId, currentDesignation));
            }
           
            catch (Exception exception)
            {
                _logger.LogInformation($"UserController :GetAllUsers()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
                return Problem(exception.Message);
            }
        }
        [HttpGet]
        public IActionResult GetUserProfile()
        {

            try
            {

                int currentUser = Convert.ToInt32(User.FindFirst("UserId").Value);

                return Ok(_userServices.GetUser(currentUser));

            }

            catch (Exception exception)
            {

                _logger.LogInformation($"UserController :GetUserProfile()- exception occured while fetching record{exception.Message}{exception.StackTrace}");

                return Problem(exception.Message);

            }

        }
        [HttpGet]
        public IActionResult GetSpecificUserDetails()
        {
            try
            {

                return Ok(_userServices.GetSpecificUserDetails());
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"UserController :GetSpecificUserDetails()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
                return Problem(exception.Message);
            }


        }
        [HttpGet]
        public IActionResult GetUserById(int id)
        {
            try
            {

                return Ok(_userServices.GetUser(id));
            }
            catch (ValidationException exception)
            {
                _logger.LogInformation($"UserController :GetUserById()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"UserController :GetUserById()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
                return Problem(exception.Message);
            }
        }
        [HttpPost]
        public IActionResult AddUser(User userValues)
        {
            if (userValues == null)
            {
                _logger.LogInformation("UserController :AddUser()-user tries to enter null values");
                return BadRequest(new { message = "User values should not be null" });
            }
            try
            {
                int currentUser = Convert.ToInt32(User.FindFirst("UserId").Value);
                return _userServices.AddUser(userValues, currentUser) ? Ok(new { message = "User Added Successfully" }) : Problem("Sorry internal error occured");
            }
            catch (ValidationException exception)
            {
                _logger.LogInformation($"UserController :AddUser()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }
            catch (ArgumentNullException exception)
            {
                _logger.LogInformation($"UserController :AddUser()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"UserController :AddUser()-{exception.Message}{exception.StackTrace}");
                return Problem("Sorry Internal error occured");
            }
        }
        [HttpPut]
        public IActionResult UpdateUser(User user, int id)
        {
            if (user == null)
            {
                _logger.LogInformation("UserController :UpdateUser()-user tries to enter null values");
                return BadRequest("User values not be null");
            }

            //updating user via userservices

            try
            {

                return _userServices.UpdateUser(user) ? Ok(new { message = "User Updated Successfully" }) : BadRequest(new { message = "Sorry internal error occured" });

            }

            catch (Exception exception)
            {
                _logger.LogInformation($"UserController:UpdateUser()-{exception.Message}{exception.StackTrace}");
                return Problem(exception.Message);
            }

        }
        [HttpDelete(Name = "Disable")]
        public IActionResult Disable(int id)
        {
            if (id == 0) return BadRequest(new { message = "User Id is required" });
            try
            {

                return _userServices.Disable(id) ? Ok(new { message = "User Disabled Successfully" }) : BadRequest(new { message = "Sorry internal error occured" });
            }

            catch (Exception exception)
            {
                _logger.LogInformation($"UserController:DisableUser()-{exception.Message}{exception.StackTrace}");
                return Problem(exception.StackTrace);
            }
        }



        [HttpPut("Change Password")]

        public IActionResult ChangePassword(string OldPassword, string NewPassword, string ConfirmPassword)

        {

            if (string.IsNullOrEmpty(OldPassword) && string.IsNullOrEmpty(NewPassword) && string.IsNullOrEmpty(ConfirmPassword))

                BadRequest(new { message = "All the password fiels should be entered" });

            try

            {
                int currentUser = Convert.ToInt32(User.FindFirst("UserId").Value);
                return _userServices.ChangePassword(OldPassword, NewPassword, ConfirmPassword, currentUser) ? Ok(new { message = "Password Changed Successfully" }) : BadRequest(new { message = "Sorry internal error occured" });



            }

            catch (ValidationException exception)

            {

                _logger.LogInformation($"UserController:ChangePassword(string OldPassword,string NewPassword,string ConfirmPassword): {exception.Message}{exception.StackTrace}");

                return BadRequest(exception.Message);

            }



            catch (Exception exception)

            {

                _logger.LogInformation($"UserController:ChangePassword(string OldPassword,string NewPassword,string ConfirmPassword): {exception.Message}{exception.StackTrace}");

                return BadRequest(new { message = "Sorry some internal error occured" });

            }



        }
        [HttpGet]
        public IActionResult GetAllUsersByDesignation()
        {
            try
            {
                int currentDesignation = Convert.ToInt32(User.FindFirst("DesignationId").Value);
                return Ok(_userServices.GetAllUsersByDesignation(currentDesignation));
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"UserController :GetAllUsersByDesignation()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
                return Problem(exception.Message);
            }
        }

    }
}
