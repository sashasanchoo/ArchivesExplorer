using ArchivesExplorer.DataContext.Repositories.Interfaces.ReadRepositores;
using ArchivesExplorer.DataContext.UoW;
using ArchivexExplorer.Core.Interfaces.Services;
using ArchivexExplorer.Domain.Models;

namespace ArchivesExplorer.Application.Services
{

    public class OrderService : IOrderService
    {
        private readonly IOrderReadRepository _orderReadRepository;
        private readonly IProductReadRepository _productReadRepository;
        private readonly IArchivexExplorerUnitOfWork _unitOfWork;
        private readonly IOrderNotificationDeliveryService _orderNotificationDeliveryService;
        private readonly IMailMessageDeliveryService _mailMessageDeliveryService;

        public OrderService(IArchivexExplorerUnitOfWork unitOfWork, 
            IOrderReadRepository orderReadRepository,
            IProductReadRepository productReadRepository,
            IOrderNotificationDeliveryService orderNotificationDeliveryService,
            IMailMessageDeliveryService mailMessageDeliveryService)
        {
            _unitOfWork = unitOfWork;
            _orderReadRepository = orderReadRepository;
            _productReadRepository = productReadRepository;
            _orderNotificationDeliveryService = orderNotificationDeliveryService;
            _mailMessageDeliveryService = mailMessageDeliveryService;
        }

        public async Task CreateOrder(OrderModel order)
        {
            var product = await _productReadRepository.GetUniqueAsync(x => x.Id == order.ProductId);
            if (product == null)
            {
                throw new Exception();
            }

            order.Id = Guid.NewGuid();

            await _unitOfWork.Orders.AddEntityAsync(order);
            await _unitOfWork.SaveChangesAsync();

            await _orderNotificationDeliveryService.DeliverNotification(order);

            _mailMessageDeliveryService.DeliverOrderReceiverNotification(
                order.FirstName, 
                product.Name, 
                order.Id, 
                order.Email);
        }

        public async Task<IEnumerable<OrderModel>> GetAllOrders()
        {
            var orders = await _orderReadRepository.GetAsync();

            return orders;
        }
    }
}
