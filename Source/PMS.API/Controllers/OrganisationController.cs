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
    IOrganisationServices organisationService = OrganisationDataFactory.GetOrganisationServiceObject();
    [HttpGet]
    public IActionResult ViewOrganisations() //Getting the list of Organisations
    {
        try
        {
             _logger.LogInformation("List of Organisations......"); //Passing the Information to log
            return Ok(organisationService.ViewOrganisations());
           
        }
        catch (Exception exception) // Handling Exception
        {
            _logger.LogError($"OrganisationController:ViewOrganisations()-{exception.Message}{exception.StackTrace}");
            return Problem(exception.Message);
           
        }
    }

}