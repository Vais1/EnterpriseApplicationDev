using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using MVCEF.Models;

var builder = WebApplication.CreateBuilder(args);

// Configure services (equivalent to ConfigureServices in Startup.cs)
builder.Services.AddDbContext<EmployeeDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddMvc(options =>
{
    options.EnableEndpointRouting = false;
});

// Configuration is already available through builder.Configuration
// The appsettings.json files are automatically loaded by WebApplication.CreateBuilder

var app = builder.Build();

// Configure the HTTP request pipeline (equivalent to Configure in Startup.cs)
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Add static files support for CSS, JS, images
app.UseStaticFiles();

app.UseMvc(routes =>
{
    routes.MapRoute(
        name: "default",
        template: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
