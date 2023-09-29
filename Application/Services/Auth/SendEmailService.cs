using Application.Interfaces;
using Core.Entities.Auth;
using Core.Interfaces.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using SendGrid;
using SendGrid.Helpers.Errors.Model;
using SendGrid.Helpers.Mail;

namespace Application.Services.Auth
{
    public class SendEmailService : ISendEmailService
    {
        private readonly IUnitOfWork _unit;
        private readonly IServiceProvider _serviceProvider;
        private const string defaultLink = "https://digiapi2023-u7m5-dev.fl0.io/auth/user/confirm-email";

        public SendEmailService(IUnitOfWork unit, IServiceProvider serviceProvider)
        {
            _unit = unit;
            _serviceProvider = serviceProvider;
        }

        public async Task<string> SendConfirmationEmail(string email)
        {
            try
            {
                var apiKey = "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";
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress("lokeje9431@ipniel.com", "DigiService");
                var to = new EmailAddress(email, "Tamer");

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

                string confirmationLink = $"{defaultLink}?email={email}&token={emailConfirmation.Token}";
                string htmlContent = $"<p><a href='{confirmationLink}'>LINK AQUI !!!</a></p>";

                var dynamicTemplateData = new
                {
                    Confirmation_Link = htmlContent
                };

                var msg = MailHelper.CreateSingleTemplateEmail(from, to, "d-47ae1d37cf694cfb93f6d4ba31955b00", dynamicTemplateData);
                var response = await client.SendEmailAsync(msg);
                return response.IsSuccessStatusCode ? "Email enviado com sucesso!" : throw new Exception("Ocorreu um erro ao enviar o email, tente novamente.");
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

                // var passwordReset

                return "continue...";
            }
            catch
            { throw; }
        }
    }
}
