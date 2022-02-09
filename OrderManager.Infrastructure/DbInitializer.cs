using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using OrderManager.Core.Entities;

namespace OrderManager.Infrastructure
{
    public static class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using var serviceScope = applicationBuilder.ApplicationServices.CreateScope();

            var context = serviceScope.ServiceProvider.GetService<OrderManagerDbContext>();
            context?.Database.EnsureCreated();

            if (context != null)
            {
                if (!context.ProductTypes.Any())
                {
                    context.ProductTypes.Add(new Product { Id = 1, Type = "PhotoBook", Width = 19 });
                    context.ProductTypes.Add(new Product { Id = 2, Type = "Calendar ", Width = 10 });
                    context.ProductTypes.Add(new Product { Id = 3, Type = "Canvas", Width = 16 });
                    context.ProductTypes.Add(new Product { Id = 4, Type = "Cards", Width = 4.7M });
                    context.ProductTypes.Add(new Product { Id = 5, Type = "Mug ", Width = 94 });
                }

                if (!context.Orders.Any())
                {
                    context.Orders.Add(new Order { Id = 1 });
                    context.Orders.Add(new Order { Id = 2 });
                }

                if (!context.OrderProducts.Any())
                {
                    context.OrderProducts.Add(new OrderProduct { OrderId = 1, ProductId = 1, Quantity = 1});
                    context.OrderProducts.Add(new OrderProduct { OrderId = 1, ProductId = 2, Quantity = 1});
                    context.OrderProducts.Add(new OrderProduct { OrderId = 1, ProductId = 3, Quantity = 1});
                    context.OrderProducts.Add(new OrderProduct { OrderId = 1, ProductId = 4, Quantity = 1});
                    context.OrderProducts.Add(new OrderProduct { OrderId = 1, ProductId = 5, Quantity = 1});
                    context.OrderProducts.Add(new OrderProduct { OrderId = 2, ProductId = 1, Quantity = 1});
                    context.OrderProducts.Add(new OrderProduct { OrderId = 2, ProductId = 2, Quantity = 2});
                    context.OrderProducts.Add(new OrderProduct { OrderId = 3, ProductId = 4, Quantity = 3});
                    context.OrderProducts.Add(new OrderProduct { OrderId = 4, ProductId = 5, Quantity = 10});
                }

                context.SaveChanges();
            }
        }
    }
}
