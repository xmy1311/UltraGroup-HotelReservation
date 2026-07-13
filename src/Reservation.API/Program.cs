using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Reservation.API;
using Reservation.API.Middlewares;
using Reservation.App.Interfaces;
using Reservation.App.Services;
using Reservation.App.Validators;
using Reservation.Domain.Interfaces;
using Reservation.Infrastructure.Clients;
using Reservation.Infrastructure.Persistence;
using Reservation.Infrastructure.Repositories;
using System.Text;
using UltraGroup.Common.Security;
using FluentValidation;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
    

builder.Services.Configure<JwtSettings>(
    builder.Configuration.GetSection("Jwt"));

var jwtSettings = builder.Configuration
    .GetSection("Jwt")
    .Get<JwtSettings>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = jwtSettings!.Issuer,
            ValidAudience = jwtSettings.Audience,

            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtSettings.Key))
        };
    });

builder.Services.AddDbContext<ReservationDbContext>(options =>
                             options.UseSqlServer(builder.Configuration
                             .GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IReservationRepository, ReservationRespository>();
builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<INotificationService, NotificationService>();

// Add FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<ReservationDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<GuestDtoValidator>();


builder.Services.AddHttpClient<IHotelClient, HotelClient>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["Services:HotelService"]!);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
