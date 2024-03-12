namespace ArchivexExplorer.Core.Interfaces.Helpers
{
    public interface ITelegramNotificationSender
    {
        Task SendNotification(string message);
    }
}
