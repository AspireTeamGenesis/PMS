using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Net;

namespace PMS_API;
// [Authorize]
[ApiController]
[Route("[controller]/[Action]")]
public class OrganisationController : ControllerBase
{
    private readonly ILogger _logger;
    public OrganisationController(ILogger<OrganisationController> logger)
    {
        _logger = logger;
    }
    private readonly IOrganisationServices organisationService = OrganisationDataFactory.GetOrganisationServiceObject();
    //Getting the list of Organisations

    
    [HttpGet]
    public IActionResult ViewOrganisations() 
    {
        try
        {
             _logger.LogInformation("List of Organisations......"); 
            return Ok(organisationService.ViewOrganisations());
           
        }
        catch (Exception exception) 
        {
            _logger.LogError($"OrganisationController:ViewOrganisations()-{exception.Message}{exception.StackTrace}");
            return Problem(exception.Message);
           
        }
    }

}