using Blog_Page.AppServices.Services;
using Blog_Page.DBContext;
using Blog_Page.Models;
using Blog_Page.Repositories.Base;
using Blog_Page.Repositories.Interfaces;
using Blog_Page.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IRepository<AppUser>, Repository<AppUser>>();
builder.Services.AddScoped<IRepository<Category>, Repository<Category>>();
builder.Services.AddScoped<IRepository<Blog>, Repository<Blog>>();
builder.Services.AddScoped<IImageService, ImageService>();

//Authentication and Authorization 
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Admin/LogIn/LogIn";
        options.Cookie.Name = "UserDetail";
        options.AccessDeniedPath = "/Admin/LogIn/Error";
    });

var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();


//AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

//Connection

var config = builder.Configuration;

builder.Services.AddDbContext<AddDbContext>(options =>
{
    options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
});


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


// Migrate latest database changes during startup
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider
        .GetRequiredService<AddDbContext>();

    // Here is the migration executed
    dbContext.Database.Migrate();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "AreasRoute",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
