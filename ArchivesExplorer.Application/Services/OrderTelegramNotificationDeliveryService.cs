using ArchivexExplorer.Core.Interfaces.Helpers;
using ArchivexExplorer.Core.Interfaces.Services;
using ArchivexExplorer.Domain.Models;

namespace ArchivesExplorer.Application.Services
{
    public class OrderTelegramNotificationDeliveryService : IOrderNotificationDeliveryService
    {
        private readonly IOrderTelegramNotificationPreparer _notificationPreparer;
        private readonly ITelegramNotificationSender _notificationSender;

        public OrderTelegramNotificationDeliveryService(IOrderTelegramNotificationPreparer notificationPreparer,
            ITelegramNotificationSender notificationSender)
        {
            _notificationPreparer = notificationPreparer;
            _notificationSender = notificationSender;
        }

        public async Task DeliverNotification(OrderModel order)
        {
            var message = await _notificationPreparer.GetNotificationMessage(order);

            await _notificationSender.SendNotification(message);
        }
    }
}
