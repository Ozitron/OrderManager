using Microsoft.AspNetCore.Mvc;
using OrderManager.Infrastructure.Repositories;

namespace OrderManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _productRepository.GetProductsAsync());
        }
    }
}
