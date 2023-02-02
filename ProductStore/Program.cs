using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductStore.Data;
using ProductStore.Services.ProductService;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ProductStoreContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProductStoreContext") ?? throw new InvalidOperationException("Connection string 'ProductStoreContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
