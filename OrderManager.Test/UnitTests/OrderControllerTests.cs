using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OrderManager.API.Controllers;
using OrderManager.Infrastructure.Repositories;
using OrderManager.Test.Helpers;
using Xunit;

namespace OrderManager.Test.UnitTests
{
    public class OrderControllerTests
    {
        private readonly Mock<IOrderRepository> _ordersRepositoryMock;
        private readonly OrdersController _ordersController;

        public OrderControllerTests()
        {
            _ordersRepositoryMock = new Mock<IOrderRepository>();
            _ordersController = new OrdersController(_ordersRepositoryMock.Object);
        }

        [Fact]
        public async Task Create_ValidOrder_ReturnsSuccess()
        {
            // arrange
            var order = CommonTestHelper.CreateValidOrderDto();
            _ordersRepositoryMock.Setup(p => p.CreateOrderAsync(order)).ReturnsAsync(1);

            // act
            var result = (OkObjectResult)await _ordersController.Post(order);

            // assert
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        }
        
    }
}