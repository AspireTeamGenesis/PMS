using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using System.Net;
using PMS_API;

namespace PMS_API{
 [Authorize]
[Route("api/[controller]")]
[ApiController]
public class MailController : ControllerBase
{
    private readonly ILogger _logger;
    private readonly IMailService _mailService;
    public MailController(IMailService mailService, ILogger<MailController> logger)
    {
        _mailService = mailService;
        _logger = logger;

    }

    //Mail
    [HttpPost("send")]
    public async Task<IActionResult> SendMail([FromForm]MailRequest request)
    {
        try
        {
            await _mailService.SendEmailAsync(request,true);
            return Ok();
        }
        catch(Exception exception)
        {
            _logger.LogError($"MailController:SendMail()-{exception.Message}{exception.StackTrace}");
            return Problem(exception.Message);
        }
            
    }
}
}