using OrderManager.Core.Models.DTOs;

namespace OrderManager.Infrastructure.Repositories
{
    public interface IOrderRepository
    {
        Task<int> CreateOrderAsync(OrderCreateDto order);

        Task<OrderGetDto> GetOrderAsync(int id);
    }
}
