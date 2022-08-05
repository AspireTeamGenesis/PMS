using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Net;


namespace PMS_API{
[Authorize]
[ApiController]
[Route("[controller]/[Action]")]
public class CollegeController : ControllerBase
{
    private readonly ILogger _logger;
    public CollegeController(ILogger<CollegeController> logger)
    {
        _logger = logger;
    }
    private readonly ICollegeServices collegeService = CollegeDataFactory.GetCollegeServiceObject(); 
    //Getting The List of Colleges
    
    [HttpGet]
    public IActionResult ViewColleges() 
    {
        try
        {
             _logger.LogInformation("List of Colleges......"); 
            return Ok(collegeService.ViewColleges());
           
        }
        catch (Exception exception) 
        {
             _logger.LogError($"CollegeController:ViewColleges()-{exception.Message}{exception.StackTrace}");
            return Problem(exception.Message);
           
        }
    }
}
}