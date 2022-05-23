global using BlazorRpg.Server.Data;
global using BlazorRpg.Server.Repositories.BaseRepository;
global using Microsoft.EntityFrameworkCore;
global using BlazorRpg.Shared.Models;
global using System.Linq.Expressions;
global using BlazorRpg.Server.Services.BaseService;
using Microsoft.AspNetCore.ResponseCompression;
using BlazorRpg.Server.Repositories.TestModelRepository;
using BlazorRpg.Server.Services.TestModelService;
using BlazorRpg.Server.Services.SecondTestModelService;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BlazorRpgConnection")));
builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddTransient(typeof(ITestModelRepository), typeof(TestModelRepository));

builder.Services.AddTransient(typeof(IBaseService<>), typeof(BaseService<>));
builder.Services.AddScoped(typeof(ITestModelService), typeof(TestModelService));
builder.Services.AddScoped(typeof(ISecondTestModelService), typeof(SecondTestModelService));

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");



app.Run();
