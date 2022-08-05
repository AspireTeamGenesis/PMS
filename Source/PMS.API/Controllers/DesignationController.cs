using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace PMS_API{
 [Authorize]
[ApiController]
    [Route("[controller]/[Action]")]
public class DesignationController : ControllerBase
{
    private readonly ILogger _logger;
    public DesignationController(ILogger<DesignationController> logger)
    {
        _logger = logger;
    }
    private readonly IDesignationServices DesignationService = DesignationDataFactory.GetDesignationServiceObject();
    //Getting the list of Designations


    [HttpGet]
    public IActionResult ViewDesignations() 
    {
        try
        {
             _logger.LogInformation("List of Designations......"); 
            return Ok(DesignationService.ViewDesignations());
           
        }
         catch (Exception exception) 
        {
             _logger.LogError($"DesignationController:ViewDesignations()-{exception.Message}{exception.StackTrace}");
            return Problem(exception.Message);
           
        }
    }
}
}