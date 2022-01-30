using BikeShop.API.UseCases.Errors;
using BikeShop.API.UseCases.Products;
using BikeShop.App;
using BikeShop.Infrastructure;
using BikeShop.Infrastructure.Persistence.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;

services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddApp()
        .AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.UseExceptionHandler("/errors");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapProducts();
app.MapErrors(app.Logger);

await using (var scope = app.Services.CreateAsyncScope()) 
{
    var database = scope.ServiceProvider.GetRequiredService<BikeShopContext>().Database;
    await database.EnsureCreatedAsync();
}

app.Run();

namespace BikeShop.API
{
    public partial class Program
    {
        // Expose the Program class for use with WebApplicationFactory<T>
    }
}