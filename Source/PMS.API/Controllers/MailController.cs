using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using System.Net;
using PMS_API;

// [Authorize]
[Route("api/[controller]")]
[ApiController]
public class MailController : ControllerBase
{
    private IMailService _mailService;
    public MailController(IMailService mailService)
    {
        _mailService = mailService;
    }
    [HttpPost("send")]
    public async Task<IActionResult> SendMail([FromForm]MailRequest request)
    {
        try
        {
            await _mailService.SendEmailAsync(request,true);
            return Ok();
        }
        catch (Exception exception)
        {
            throw exception;
        }
            
    }
}