using Blog_Page.API.Core.Application.Interfaces;
using Blog_Page.API.Persistance.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using AutoMapper;
using Blog_Page.API.Core.Application.Mappings;
using Blog_Page.API.Persistance.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var config = builder.Configuration;

builder.Services.AddDbContext<ApiDbContext>(opt =>
{
    opt.UseSqlServer(config.GetConnectionString("DefaultConnection"));
});


builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddAutoMapper(opt =>
{
    opt.AddProfiles(new List<Profile>()
    {
        new BlogProfile(),
        new CategoryProfile()
    });
});

    var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
