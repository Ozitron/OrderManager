using OrderManager.Core.Entities;

namespace OrderManager.Infrastructure.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductsAsync();
    }
}
