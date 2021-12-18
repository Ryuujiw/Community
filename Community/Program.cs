using Community.Data;
using Community.Data.Configuration;
using Community.Services.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});

builder.Services.AddControllersWithViews();

builder.Host.ConfigureServices(services =>
{
    ServiceExtensions.AddServices(services);
});

builder.Services.AddDbContext<MapContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("MapDatabase"));
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
