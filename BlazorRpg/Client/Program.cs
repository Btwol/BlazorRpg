global using BlazorRpg.Client.ClientServices.TestModelClientService;
global using BlazorRpg.Client.ClientServices.SecondTestModelClientService;
global using BlazorRpg.Shared.Models;
using BlazorRpg.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<ITestModelClientService, TestModelClientService>();
builder.Services.AddScoped<ISecondTestModelClientService, SecondTestModelClientService>();

await builder.Build().RunAsync();
