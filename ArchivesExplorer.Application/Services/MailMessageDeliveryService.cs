using ArchivexExplorer.Core.Interfaces.Helpers;
using ArchivexExplorer.Core.Interfaces.Services;

namespace ArchivesExplorer.Application.Services
{
    public class MailMessageDeliveryService : IMailMessageDeliveryService
    {
        private readonly IOrderReceivedMailNotificationPreparer _notificationPreparer;
        private readonly IMailNotificationSender _mailNotificationSender;

        public MailMessageDeliveryService(IMailNotificationSender mailNotificationSender, 
            IOrderReceivedMailNotificationPreparer notificationPreparer)
        {
            _mailNotificationSender = mailNotificationSender;
            _notificationPreparer = notificationPreparer;
        }

        public async Task DeliverOrderReceiverNotification(string firstName, string productName, Guid orderId, string receiver)
        {
            var message = _notificationPreparer.GetNotificationMessage(firstName, productName, orderId.ToString());
            var subject = _notificationPreparer.GetNotificationSubject();

            await _mailNotificationSender.SendNotificationAsync(message, subject, receiver);
        }
    }
}
