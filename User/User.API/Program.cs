using BusinessObjects.Models;
using User.API.Infra.Repositories;
using User.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();

builder.Services.AddDbContext<EShopContext>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

app.MapGrpcService<CustomerService>();

app.Run();

