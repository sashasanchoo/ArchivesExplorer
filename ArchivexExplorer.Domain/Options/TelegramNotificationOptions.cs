namespace ArchivexExplorer.Domain.Options
{
    public class TelegramNotificationOptions
    {
        public const string SectionName = "TelegramNotification";

        public string Token { get; set; }
        public long ChatId { get; set; }
    }
}
