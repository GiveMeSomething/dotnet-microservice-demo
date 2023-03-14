using BusinessObjects.Models;
using Product.API.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSwaggerGen();

builder.Services.AddGrpc();
builder.Services.AddControllers();
builder.Services.AddDbContext<EShopContext>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();

