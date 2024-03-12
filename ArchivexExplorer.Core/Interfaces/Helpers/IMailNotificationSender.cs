namespace ArchivexExplorer.Core.Interfaces.Helpers
{
    public interface IMailNotificationSender
    {
        Task SendNotificationAsync(string message, string subject, string receiver);
    }
}
