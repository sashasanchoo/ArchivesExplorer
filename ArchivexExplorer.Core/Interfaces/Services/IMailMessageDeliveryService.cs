namespace ArchivexExplorer.Core.Interfaces.Services
{
    public interface IMailMessageDeliveryService
    {
        Task DeliverOrderReceiverNotification(string firstName, string productName, Guid orderId, string receiver);
    }
}
