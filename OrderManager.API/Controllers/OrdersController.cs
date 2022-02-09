using Microsoft.AspNetCore.Mvc;
using OrderManager.Core.Entities;
using OrderManager.Core.Models.DTOs;
using OrderManager.Infrastructure.Repositories;

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

        [HttpPost]
        public async Task<IActionResult> Post(OrderCreateDto orderCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orderId = await _orderRepository.CreateOrderAsync(orderCreateDto);
            return Ok(new { message = $"Records is successfully created for order {orderId}" });
        }
    }
}