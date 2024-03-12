using System.Net.Mail;

namespace ArchivexExplorer.Core.Interfaces.Helpers
{
    public interface ISmtpClient
    {
        Task SendMailAsync(MailMessage message);
    }
}
