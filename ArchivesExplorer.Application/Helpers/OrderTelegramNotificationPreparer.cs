using ArchivesExplorer.DataContext.Repositories.Interfaces.ReadRepositores;
using ArchivexExplorer.Core.Interfaces.Helpers;
using ArchivexExplorer.Domain.Models;

namespace ArchivesExplorer.Application.Helpers
{
    public class OrderTelegramNotificationPreparer : IOrderTelegramNotificationPreparer
    {
        private readonly IProductReadRepository _productReadRepository;

        public OrderTelegramNotificationPreparer(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;   
        }

        public async Task<string> GetNotificationMessage(OrderModel order)
        {
            var product = await _productReadRepository.GetUniqueAsync(x => x.Id == order.ProductId);

            return $"{nameof(product.Name)}: {product.Name}\n" +
                $"{nameof(order.FirstName)}: {order.FirstName}\n" +
                $"{nameof(order.LastName)}: {order.LastName}\n" +
                $"{nameof(order.Email)}: {order.Email}\n" +
                $"{nameof(order.Address)}: {order.Address}\n" +
                $"{nameof(order.Phone)}: {order.Phone}\n";
        }
    }
}
