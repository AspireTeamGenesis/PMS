using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Net;

namespace PMS_API;
// [Authorize]
[ApiController]
[Route("[controller]/[Action]")]
public class TechnologyController : ControllerBase
{
    private readonly ILogger _logger;
    public TechnologyController(ILogger<TechnologyController> logger)
    {
        _logger = logger;
    }
    ITechnologyServices technologyService = TechnologyDataFactory.GetTechnologyServiceObject();

    //Getting the list of Technologies
    [HttpGet]
    public IActionResult ViewTechnologies() 
    {
        try
        {
             _logger.LogInformation("List of Technologies......"); 
            return Ok(technologyService.ViewTechnologies());
           
        }
        catch (Exception exception) 
        {
             _logger.LogError($"TechnologyController:ViewTechnologies()-{exception.Message}{exception.StackTrace}");
            return Problem(exception.Message);
           
        }
    }

}