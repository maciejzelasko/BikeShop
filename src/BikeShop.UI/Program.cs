using BikeShop.App;
using BikeShop.Infrastructure;
using BikeShop.UI;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services
    .AddApp()
    .AddInfrastructure(builder.Configuration);

await builder.Build().RunAsync();
