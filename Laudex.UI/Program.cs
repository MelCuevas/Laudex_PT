using Laudex.DataAccess;
using Laudex.Infrastructure;
using Laudex.Models;
using Laudex.Models.Interfaces;
using Laudex.UI.Extensions;
using Laudex.UI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

var appSettings = builder.AddAppConfigurationWithSettings<AppSettings>();

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<TaskService>();
builder.Services.AddScoped<ILaudexTaskProvider, LaudexTaskProvider>();

builder.Services.AddDbContext<LaudexDbContext>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseExceptionHandler(options => { options.Run(GlobalExceptionHandler.HandleExceptionAsync); });

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
