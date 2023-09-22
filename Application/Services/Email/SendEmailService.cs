using Application.Interfaces;

using SendGrid;
using SendGrid.Helpers.Mail;

namespace Application.Services.Email
{
    public class SendEmailService : ISendEmailService
    {
        public SendEmailService()
        { }

        public async Task Confirmation(string email, string subject, string message)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("acjsdughkhtvnggsfe@cazlq.com", "DigiService");
            var to = new EmailAddress("acjsdughkhtvnggsfe@cazlq.com", "Tamer");

            var dynamicTemplateData = new
            {
                variavel1 = "Valor1",
                variavel2 = "Valor2"
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
