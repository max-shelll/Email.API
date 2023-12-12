using Email.API.BLL.Services;
using Email.API.BLL.Services.IServices;
using Email.API.DAL.Response;

namespace Email.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            /// Get Email Configuration
            var emailConfig = builder.Configuration.GetSection("EmailConfiguration")
               .Get<EmailConfiguration>();

            builder.Services
                .AddTransient<IEmailService, EmailService>()
                .AddSingleton(emailConfig);

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}