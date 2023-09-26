using Application.Interfaces;

using SendGrid;
using SendGrid.Helpers.Mail;

namespace Application.Services.Auth
{
    public class SendEmailService : ISendEmailService
    {
        public SendEmailService()
        { }

        public async Task Confirmation(string email)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("lokeje9431@ipniel.com", "DigiService");
            var to = new EmailAddress(email, "Tamer");

            string confirmationLink = "youtube.com.br";
            string htmlContent = $"<p><a href='{confirmationLink}'>LINK AQUI !!!</a></p>";

            var dynamicTemplateData = new
            {
                Confirmation_Link = htmlContent
            };

            var msg = MailHelper.CreateSingleTemplateEmail(from, to, "d-47ae1d37cf694cfb93f6d4ba31955b00", dynamicTemplateData);
            await client.SendEmailAsync(msg);
        }

        public async Task<bool> ResetPassword()
        {
            throw new NotImplementedException();
        }
    }
}
