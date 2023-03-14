using Cart.API.Infra.Repositories;
using Cart.API.Services;
using BusinessObjects.Models;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddDbContext<EShopContext>();
builder.Services.AddScoped<ICartRepository, CartRepository>();

var app = builder.Build();

app.MapGrpcService<CartService>();

app.Run();



