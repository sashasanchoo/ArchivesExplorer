using ArchivexExplorer.Core.Interfaces.Helpers;
using System.Net.Mail;

namespace ArchivesExplorer.Application.Helpers
{
    public class SmtpClientWrapper : SmtpClient, ISmtpClient
    {
        public SmtpClientWrapper(string host, int port) : base(host, port)
        {

        }
    }
}
