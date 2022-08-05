using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Net;

namespace PMS_API{
[Authorize]
[ApiController]
[Route("[controller]/[Action]")]
public class ProfileStatusController : ControllerBase
{
    private readonly ILogger _logger;
   public ProfileStatusController(ILogger<ProfileStatusController> logger)
    {
        _logger = logger;
    }
    private readonly IProfileStatusServices ProfileStatusService = ProfileStatusDataFactory.GetProfileStatusServiceObject();
    //Getting the list of ProfileStatus

    
    [HttpGet]
    public IActionResult ViewProfileStatuss() 
    {
        try
        {
             _logger.LogInformation("List of ProfileStatuss......"); 
            return Ok(ProfileStatusService.ViewProfileStatuss());
           
        }
        catch (Exception exception) 
        {
              _logger.LogError($"ProfileStatusController:ViewProfileStatuss()-{exception.Message}{exception.StackTrace}");
            return Problem(exception.Message);
           
        }
    }
}
}