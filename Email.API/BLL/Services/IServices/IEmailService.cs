using Email.API.DAL.Request;

namespace Email.API.BLL.Services.IServices
{
    public interface IEmailService
    {
        Task SendEmailAsync(EmailRequest request);
    }
}
