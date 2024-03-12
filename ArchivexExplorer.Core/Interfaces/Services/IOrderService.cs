using ArchivexExplorer.Domain.Models;

namespace ArchivexExplorer.Core.Interfaces.Services
{
    public interface IOrderService
    {
        Task CreateOrder(OrderModel order);
        Task<IEnumerable<OrderModel>> GetAllOrders();
    }
}
