global using BlazorRpg.Client.ClientServices.TestModelClientService;
global using BlazorRpg.Client.ClientServices.SecondTestModelClientService;
global using BlazorRpg.Client.ClientServices.CombatClientService;
global using BlazorRpg.Shared.Models;
global using System.Net.Http.Json;
using BlazorRpg.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorRpg.Client.ClientServices.CharacterClientService;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<ITestModelClientService, TestModelClientService>();
builder.Services.AddScoped<ISecondTestModelClientService, SecondTestModelClientService>();
builder.Services.AddScoped<ICharacterClientService, CharacterClientService>();
builder.Services.AddScoped<ICombatClientService, CombatClientService>();


await builder.Build().RunAsync();
