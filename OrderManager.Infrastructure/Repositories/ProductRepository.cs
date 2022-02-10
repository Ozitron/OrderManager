using Microsoft.EntityFrameworkCore;
using OrderManager.Core.Entities;

namespace OrderManager.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly OrderManagerDbContext _context;
        public ProductRepository(OrderManagerDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }
    }
}
