using FluentValidation;
using HotelService.API.Middlewares;
using HotelService.App.Interfaces;
using HotelService.App.Services;
using HotelService.App.Validators;
using HotelService.Domain.Interfaces;
using HotelService.Infrastructure.Persistence;
using HotelService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext
builder.Services.AddDbContext<HotelDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

//repository
builder.Services.AddScoped<IHotelRespository, HotelRepository>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();

//Services
builder.Services.AddScoped<IHotelServices, HotelServices>();
builder.Services.AddScoped<IRoomServices, RoomServices>();

// Add FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<HotelDtoValidator>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
