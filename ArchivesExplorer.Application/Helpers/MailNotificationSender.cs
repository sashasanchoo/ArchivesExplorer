using ArchivexExplorer.Core.Interfaces.Helpers;
using ArchivexExplorer.Domain.Options;
using Microsoft.Extensions.Options;
using System.Net.Mail;

namespace ArchivesExplorer.Application.Helpers
{
    public class MailNotificationSender : IMailNotificationSender
    {
        private readonly ISmtpClient _client;
        private readonly SmtpClientOptions _clientOptions;

        public MailNotificationSender(IOptions<SmtpClientOptions> clientOptions,
            ISmtpClient client)
        {
            _clientOptions = clientOptions.Value;
            _client = client;
        }

        public async Task SendNotificationAsync(string message, string subject, string receiver)
        {
            await _client.SendMailAsync(new MailMessage(_clientOptions.Username, receiver, subject, message)
            {
                IsBodyHtml = true
            });
        }
    }
}
