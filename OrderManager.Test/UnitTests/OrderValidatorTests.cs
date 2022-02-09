using OrderManager.Core.Validators;
using OrderManager.Test.Helpers;
using Xunit;

namespace OrderManager.Test.UnitTests
{
    public class OrderValidatorTests
    {
        private readonly OrderValidator _orderValidator;

        public OrderValidatorTests()
        {
            _orderValidator = new OrderValidator();
        }

        [Fact]
        public void Order_InvalidOrderId_ReturnsValidationError()
        {
            // Arrange
            var order = CommonTestHelper.CreateValidOrderDto();
            order.OrderId *= -1;

            // Act
            var result = _orderValidator.Validate(order);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Order_InvalidProductId_ReturnsValidationError()
        {
            // Arrange
            var order = CommonTestHelper.CreateValidOrderDto();
            order.ProductId = -1;

            // Act
            var result = _orderValidator.Validate(order);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Order_InvalidQuantity_ReturnsValidationError()
        {
            // Arrange
            var order = CommonTestHelper.CreateValidOrderDto();
            order.Quantity = -1;

            // Act
            var result = _orderValidator.Validate(order);

            // Assert
            Assert.False(result.IsValid);
        }
    }
}
