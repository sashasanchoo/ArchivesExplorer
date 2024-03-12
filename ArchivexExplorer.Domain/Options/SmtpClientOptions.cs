namespace ArchivexExplorer.Domain.Options
{
    public class SmtpClientOptions
    {
        public const string SectionName = "SmtpClient";
        public string Host { get; set; }
        public int Port { get; set; }
        public bool EnableSSL { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
