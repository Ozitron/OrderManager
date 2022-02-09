using System.Collections.Generic;
using OrderManager.Core.Entities;
using OrderManager.Core.Models.DTOs;

namespace OrderManager.Test.Helpers
{
    internal static class CommonTestHelper
    {
        internal static OrderCreateDto CreateValidOrderDto()
        {
            return new OrderCreateDto
            {
                OrderId = 1,
                ProductId = 1,
                Quantity = 10
            };
        }

        internal static OrderGetDto CreateOrderGetDto()
        {
            var orderGetDto = new OrderGetDto();
            var productGetDto = new ProductGetDto { ProductType = "Mug", Quantity = 1 };

            orderGetDto.ProductTypes = new List<ProductGetDto>();
            orderGetDto.ProductTypes.Add(productGetDto);
            orderGetDto.RequiredBinWidth = 5;

            return orderGetDto;
        }

        internal static List<Order> GetSampleOrderList()
        {
            var orders = new List<Order>
            {
                new()
                {
                    Id = 1
                },
                new()
                {
                    Id = 2
                }
            };

            return orders;
        }
    }
}
