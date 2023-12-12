using Email.API.BLL.Services.IServices;
using Email.API.DAL.Request;
using Email.API.DAL.Response;
using MailKit.Net.Smtp;
using MimeKit;

namespace Email.API.BLL.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailConfiguration _emailConfig;

        public EmailService(EmailConfiguration emailConfig)
        {
            _emailConfig = emailConfig;
        }

        public async Task SendEmailAsync(EmailRequest request)
        {
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("Notify", _emailConfig.From));
            message.To.Add(new MailboxAddress("Recipient Name", request.RecipientEmail));

            message.Subject = request.Subject;

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = request.Body,
                TextBody = request.Body
            };

            message.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.Port, _emailConfig.UseSsl);
                await client.AuthenticateAsync(_emailConfig.UserName, _emailConfig.Password);

                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
    }
}
