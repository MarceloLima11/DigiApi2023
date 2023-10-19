using SendGrid;
using Core.Entities.Auth;
using SendGrid.Helpers.Mail;
using Application.Interfaces;
using Core.Interfaces.UnitOfWork;
using SendGrid.Helpers.Errors.Model;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Services.Auth
{
    public class SendEmailService : ISendEmailService
    {
        private readonly IUnitOfWork _unit;
        private readonly IServiceProvider _serviceProvider;
        private const string _defaultLink = "https://digiapi2023-u7m5-dev.fl0.io/auth/user";
        private readonly string _apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");

        public SendEmailService(IUnitOfWork unit, IServiceProvider serviceProvider)
        {
            _unit = unit;
            _serviceProvider = serviceProvider;
        }

        public async Task<string> SendConfirmationEmail(string email)
        {
            try
            {
                var user = await _unit.UserRepository.GetUserByEmail(email);
                var emailConfirmation = await _unit
                    .EmailConfirmationRepository.GetEmailConfirmationByUser(user.Id);

                using var scope = _serviceProvider.CreateScope();
                IJwtService jwtService = scope.ServiceProvider.GetRequiredService<IJwtService>();

                if (emailConfirmation.Expiration < DateTime.UtcNow)
                {
                    emailConfirmation.Token = jwtService.GenerateEmailConfirmationToken();
                    emailConfirmation.Expiration = DateTime.UtcNow.AddHours(2);
                    _unit.EmailConfirmationRepository.Update(emailConfirmation);
                }

                string confirmationLink = $"{_defaultLink}/confirm-email?email={email}&token={emailConfirmation.Token}";
                string htmlContent = $"<p><a href='{confirmationLink}'>LINK AQUI !!!</a></p>";

                var data = new { Confirmation_Link = htmlContent };
                return await SendEmail(email, data);
            }
            catch
            { throw; }
        }

        public async Task<string> SendPasswordResetEmail(string email)
        {
            try
            {
                if (string.IsNullOrEmpty(email)) throw new BadRequestException("Email inválido.");

                User user = await _unit.UserRepository.GetUserByEmail(email)
                    ?? throw new NotFoundException("Usuário não cadastrado.");

                var passwordReset = await _unit.PasswordResetRepository.GetByUserId(user.Id);

                if (passwordReset.Expiration < DateTime.UtcNow)
                {
                    _unit.PasswordResetRepository.Delete(passwordReset);
                    await _unit.Commit();
                }

                if (passwordReset == null)
                {
                    using var scope = _serviceProvider.CreateScope();
                    IJwtService jwtService = scope.ServiceProvider.GetRequiredService<IJwtService>();

                    string token = jwtService.GenerateEmailConfirmationToken();
                    passwordReset = new PasswordReset(token, user.Id);
                    _unit.PasswordResetRepository.Add(passwordReset);
                    await _unit.Commit();
                }

                string confirmationLink = $"{_defaultLink}/reset-password?email={email}&token={passwordReset.Token}";
                string htmlContent = $"<p><a href='{confirmationLink}'>LINK AQUI !!!</a></p>";

                var data = new { Confirmation_Link = htmlContent };
                return await SendEmail(email, data);
            }
            catch
            { throw; }
        }

        private async Task<string> SendEmail(string toEmail, dynamic data)
        {
            try
            {
                var client = new SendGridClient(_apiKey);
                var from = new EmailAddress("lokeje9431@ipniel.com", "DigiService");
                var to = new EmailAddress(toEmail, "Tamer");

                var msg = MailHelper.CreateSingleTemplateEmail(from, to, "d-47ae1d37cf694cfb93f6d4ba31955b00", data);
                var response = await client.SendEmailAsync(msg);
                return response.IsSuccessStatusCode ? "Email enviado com sucesso!" : throw new Exception("Ocorreu um erro ao enviar o email, tente novamente.");
            }
            catch
            { throw; }
        }
    }
}
