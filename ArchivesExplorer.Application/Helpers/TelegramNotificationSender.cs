using ArchivexExplorer.Core.Interfaces.Helpers;
using ArchivexExplorer.Domain.Options;
using Microsoft.Extensions.Options;
using Telegram.Bot;

namespace ArchivesExplorer.Application.Helpers
{
    public class TelegramNotificationSender : ITelegramNotificationSender
    {
        private readonly ITelegramBotClient _bot;
        private readonly long _chatId;
        private readonly TelegramNotificationOptions _notificationOptions;

        public TelegramNotificationSender(IOptions<TelegramNotificationOptions> options)
        {
            _notificationOptions = options.Value;

            _bot = new TelegramBotClient(_notificationOptions.Token);
            _chatId = _notificationOptions.ChatId;
        }

        public async Task SendNotification(string message)
        {
            await _bot.SendTextMessageAsync(_chatId, message);
        }
    }
}
