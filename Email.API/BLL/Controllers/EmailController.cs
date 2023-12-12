using Email.API.BLL.Services.IServices;
using Email.API.DAL.Request;
using Microsoft.AspNetCore.Mvc;

namespace Email.API.BLL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly ILogger<EmailController> _logger;

        private readonly IEmailService _emailService;

        public EmailController(
            ILogger<EmailController> logger,
            IEmailService emailService)
        {
            _logger = logger;
            _emailService = emailService;
        }

        [HttpPost(Name = "Send")]
        public async Task<IActionResult> SendEmailAsync([FromBody] EmailRequest request)
        {
            try
            {
                await _emailService.SendEmailAsync(request);

                _logger.LogInformation($"A new email has been sent to {request.RecipientEmail}");
                return Ok(new { Message = "Email sent successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to send email. {ex}");
                return StatusCode(500, new { Message = "Failed to send email.", Error = ex.Message });
            }
        }
    }
}
