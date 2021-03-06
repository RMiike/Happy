using H.Domain.Entities;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace H.Services.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(string toEmail, string subject, string content);
    }
    public class MailService : IMailService
    {
        private readonly AppSettings _configuration;

        public MailService(IOptions<AppSettings> configuration)
        {
            _configuration = configuration.Value;
        }
        public async Task SendEmailAsync(string toEmail, string subject, string content)
        {
            try
            {
                var apiKey = _configuration.MailServiceKey;
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress(_configuration.MailServiceFrom, "Happy");
                var to = new EmailAddress(toEmail);
                var msg = MailHelper.CreateSingleEmail(from, to, subject, content, content);
                await client.SendEmailAsync(msg);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(e.Message);
            }
        }
    }
}
