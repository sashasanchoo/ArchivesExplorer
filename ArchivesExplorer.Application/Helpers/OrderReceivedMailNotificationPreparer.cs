using ArchivexExplorer.Core.Interfaces.Helpers;
using ArchivexExplorer.Domain.Extensions;
using ArchivexExplorer.Domain.Options;
using HtmlAgilityPack;
using Microsoft.Extensions.Options;
using System.Reflection;
using System.Resources;
using System.Text;

namespace ArchivesExplorer.Application.Helpers
{
    public class OrderReceivedMailNotificationPreparer : IOrderReceivedMailNotificationPreparer
    {
        private readonly ResourceManager _resourceManager;

        private readonly string _htmlNotificationFullPath;
        private readonly string _callingAssemblyName;

        private readonly NotificationPreparerOptions _notificationPreparerOptions;

        private readonly string? _notificationMessage;
        private readonly string? _firstNameToReplace;
        private readonly string? _productNameToReplace;
        private readonly string? _orderIdToReplace;

        private string? _notificationSubject;


        public OrderReceivedMailNotificationPreparer(IOptions<NotificationPreparerOptions> options)
        {
            _notificationPreparerOptions = options.Value;

            _htmlNotificationFullPath = Path.Combine(Directory.GetCurrentDirectory(),
                _notificationPreparerOptions.HtmlPagesDirectoryName,
                _notificationPreparerOptions.NotificationHtmlFileName);

            _callingAssemblyName = Assembly.GetExecutingAssembly().GetName().Name!;

            _resourceManager = new ResourceManagerBuilder()
                .WithBaseName(_callingAssemblyName + _notificationPreparerOptions.ResourceFileRelativePath)
                .WithAssembly(typeof(OrderReceivedMailNotificationPreparer).Assembly)
                .Build();

            _firstNameToReplace = _resourceManager.GetString("FirstName");
            _productNameToReplace = _resourceManager.GetString("ProductName");
            _orderIdToReplace = _resourceManager.GetString("OrderId");

            _notificationMessage = _resourceManager.GetString("NotificationMessage");
        }

        public string GetNotificationSubject()
        {
            return _notificationSubject!;
        }

        public string GetNotificationMessage(string firstName, string productName, string orderId)
        {
            var messagePartsBuilder = new StringBuilder();

            messagePartsBuilder.Append(_resourceManager.GetString("NotificationSubject"));
            messagePartsBuilder.Replace(_orderIdToReplace!, orderId);
            _notificationSubject = messagePartsBuilder.ToString();

            messagePartsBuilder.Clear();

            messagePartsBuilder.Append(_notificationMessage);
            messagePartsBuilder.Replace(_orderIdToReplace!, orderId);
            messagePartsBuilder.Replace(_firstNameToReplace!, firstName);
            messagePartsBuilder.Replace(_productNameToReplace!, productName);

            var message = messagePartsBuilder.ToString();

            string html = ModifyHTML(message);

            return html;
        }

        private string ModifyHTML(string message)
        {
            var bytes = File.ReadAllBytes(_htmlNotificationFullPath);
            string html = Encoding.UTF8.GetString(bytes);

            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            var messageElement = doc.GetElementbyId(_notificationPreparerOptions.NotificationMessageHtmlElementId);
            messageElement.InnerHtml = message;

            using (var stream = new MemoryStream())
            {
                doc.Save(stream);
                bytes = stream.ToArray();
            };

            return Encoding.UTF8.GetString(bytes);
        }
    }
}
