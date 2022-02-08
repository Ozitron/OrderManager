using Microsoft.EntityFrameworkCore;
using OrderManager.Core.Entities;
using OrderManager.Core.Models;
using OrderManager.Infrastructure;

namespace OrderManager.Core.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public readonly OrderManagerDbContext _context;

        public OrderRepository(OrderManagerDbContext context)
        {
            _context = context;
        }

        public async Task<long> CreateOrderAsync(OrderCreateDto order)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> GetOrderAsync(long id)
        {
            return await _context.Orders.FirstOrDefaultAsync();
        }
    }
}
