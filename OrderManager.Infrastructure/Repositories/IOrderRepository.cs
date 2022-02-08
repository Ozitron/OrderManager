using OrderManager.Core.Entities;
using OrderManager.Core.Models;

namespace OrderManager.Core.Repositories
{
    public interface IOrderRepository
    {
        Task<long> CreateOrderAsync(OrderCreateDto order);

        Task<Order?> GetOrderAsync(long id);
    }
}
