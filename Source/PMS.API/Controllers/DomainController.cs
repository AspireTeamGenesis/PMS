using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Net;

namespace PMS_API{
[Authorize]
[ApiController]
[Route("[controller]/[Action]")]
public class DomainController : ControllerBase
{
    private readonly ILogger _logger;
    public DomainController(ILogger<DomainController> logger)
    {
        _logger = logger;
    }
    private readonly IDomainServices DomainService = DomainDataFactory.GetDomainServiceObject();
    //Getting the list of Domains

    
    [HttpGet]
    public IActionResult ViewDomains() 
    {
        try
        {
             _logger.LogInformation("List of Domains......"); 
            return Ok(DomainService.ViewDomains());
           
        }
        catch (Exception exception) 
        {
             _logger.LogError($"DomainController:ViewDomains()-{exception.Message}{exception.StackTrace}");
            return Problem(exception.Message);
           
        }
    }
}
}