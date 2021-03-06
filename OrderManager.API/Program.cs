using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using OrderManager.Core.Validators;
using OrderManager.Infrastructure;
using OrderManager.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddFluentValidation(fv =>
{
    fv.RegisterValidatorsFromAssemblyContaining<OrderValidator>();
});


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<OrderManagerDbContext>(options =>
{
    options.UseInMemoryDatabase("OrderManagerDb");
});

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

DbInitializer.Seed(app);
app.Run();
