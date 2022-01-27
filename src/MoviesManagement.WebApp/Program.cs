using Microsoft.EntityFrameworkCore;
using MoviesManagement.WebApp.Data;
using MoviesManagement.WebApp.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MoviesManagementWebAppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MoviesManagementWebAppContext")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    ServiceProviderExtensions.MigrateDatabase(services, app.Environment.IsDevelopment());
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Movie/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Movies}/{action=Index}/{id?}");

app.Run();
