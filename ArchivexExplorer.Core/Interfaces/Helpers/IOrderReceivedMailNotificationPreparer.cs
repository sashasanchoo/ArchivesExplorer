namespace ArchivexExplorer.Core.Interfaces.Helpers
{
    public interface IOrderReceivedMailNotificationPreparer
    {
        string GetNotificationMessage(string firstName, string productName, string orderId);
        string GetNotificationSubject();
    }
}
