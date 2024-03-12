using ArchivexExplorer.Domain.Models;

namespace ArchivexExplorer.Core.Interfaces.Services
{
    public interface IOrderNotificationDeliveryService : ITelegramNotificationDeliveryService<OrderModel> {}
}
