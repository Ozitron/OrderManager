using Microsoft.EntityFrameworkCore;
using OrderManager.Core.Entities;
using OrderManager.Core.Models.DTOs;
using OrderManager.Core.Models.Enums;

namespace OrderManager.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public readonly OrderManagerDbContext Context;

        public OrderRepository(OrderManagerDbContext context)
        {
            Context = context;
        }

        public async Task<int> CreateOrderAsync(OrderCreateDto orderDto)
        {
            try
            {
                var existingOrder = await Context.Orders.FirstOrDefaultAsync(x => x.Id == orderDto.OrderId);
                if (existingOrder == null)
                {
                    await Context.Orders.AddAsync(new Order { Id = orderDto.OrderId });
                }

                var existingOrderProduct = await Context.OrderProducts.Where(x => x.OrderId == orderDto.OrderId
                                                                             && x.ProductId == orderDto.ProductId).FirstOrDefaultAsync();
                if (existingOrderProduct != null)
                {
                    existingOrderProduct.Quantity += orderDto.Quantity;
                }
                else
                {
                    await Context.OrderProducts.AddAsync(new OrderProduct
                    {
                        OrderId = orderDto.OrderId,
                        ProductId = orderDto.ProductId,
                        Quantity = orderDto.Quantity
                    });
                }

                await Context.SaveChangesAsync();
                return orderDto.OrderId;
            }
            catch
            {
                //throw new AppException();
                throw new Exception();
            }
        }

        public async Task<OrderGetDto> GetOrderAsync(int orderId)
        {
            var orderResult = new OrderGetDto();
            var orderProducts = await Context.OrderProducts.Where(x => x.OrderId == orderId).ToListAsync();

            if (orderProducts.Count == 0)
                return orderResult;


            var products = await Context.ProductTypes.ToListAsync();
            var binProducts = new List<ProductDetailDto>();
            foreach (var orderProduct in orderProducts)
            {
                var productModel = new ProductGetDto();
                var binProduct = new ProductDetailDto();
                var selectedProduct = products.FirstOrDefault(x => x.Id == orderProduct.ProductId);
                binProduct.ProductId = orderProduct.ProductId;
                binProduct.Quantity = productModel.Quantity = orderProduct.Quantity;
                binProduct.Width = selectedProduct.Width;
                binProducts.Add(binProduct);
                productModel.ProductType = selectedProduct.Type;
                orderResult.ProductTypes.Add(productModel);
            }

            orderResult.RequiredBinWidth = CalculateRequiredBinWidth(binProducts);
            return orderResult;
        }

        private static decimal CalculateRequiredBinWidth(List<ProductDetailDto> products)
        {
            var width = 0M;

            foreach (var product in products)
            {
                if (product.ProductId == (int)ProductType.Mug)
                    width += Math.Ceiling(Convert.ToDecimal(product.Quantity) / 4) * product.Width;
                else
                    width += product.Width * product.Quantity;
            }

            return width;
        }
    }
}
