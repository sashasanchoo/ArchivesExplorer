namespace ArchivexExplorer.Core.Interfaces.Services
{
    public interface ITelegramNotificationDeliveryService<T>
    {
        Task DeliverNotification(T order);
    }
}
