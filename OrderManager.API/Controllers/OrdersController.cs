using Microsoft.AspNetCore.Mvc;
using OrderManager.Core.Entities;
using OrderManager.Core.Repositories;

namespace OrderManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetAsync(int id)
        {
            var result = await _orderRepository.GetOrderAsync(id);

            return Ok(result);
        }
    }
}