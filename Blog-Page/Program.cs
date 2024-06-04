using AutoMapper;
using Blog_Page.Models;
using Blog_Page.Persistance.Context;
using Blog_Page.Service.Helpers;
using Blog_Page.Service.Interfaces;
using Blog_Page.Service.Mappings.AutoMappers;
using Blog_Page.Service.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

 static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseContentRoot(Directory.GetCurrentDirectory()); // Bu satırı ekleyin
        });


// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddScoped(typeof(IRepositoryUI<>), typeof(Repository<>));

builder.Services.AddHttpClient();

//Authentication and Authorization 
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddCookie(JwtBearerDefaults.AuthenticationScheme, opt =>
{
    opt.LoginPath = "/Account/Login";
    opt.LogoutPath = "/Account/Logout";
    opt.AccessDeniedPath = "/Account/AccessDenied";
    opt.Cookie.SameSite = SameSiteMode.Strict;
    opt.Cookie.HttpOnly = true;
    opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
    opt.Cookie.Name = "JwtCookie";
});

var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();



builder.Services.AddDbContext<BlogDbContext>(opt =>
{
    opt.UseSqlServer("Server=.\\SQLEXPRESS;Database=blogdb;Trusted_Connection=True;TrustServerCertificate=True");
});

//AutoMapper Configuration
var profiles = ProfileHelper.GetProfiles();
var mapConfiguration = new MapperConfiguration(opt =>
{
    opt.AddProfiles(profiles);
});
var mapper = mapConfiguration.CreateMapper();
builder.Services.AddSingleton(mapper);


//Connection
var config = builder.Configuration;


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
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
