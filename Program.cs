using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Data;
using ProyectoFinal.Repositories;
using ProyectoFinal.Services;

var builder = WebApplication.CreateBuilder(args);

// 1. Controllers
builder.Services.AddControllers();

// 2. Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 3. BASE DE DATOS (PostgreSQL) – SIN APPSETTINGS, HARD-CODEADO
var connString = "Host=localhost;Port=5432;Database=taxiapp;Username=postgres;Password=postgres";
Console.WriteLine($"CONNECTION STRING => {connString}");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connString));

// 4. REPOSITORIES
builder.Services.AddScoped<IDriverRepository, DriverRepository>();
builder.Services.AddScoped<IPassengerRepository, PassengerRepository>();
builder.Services.AddScoped<ITripRepository, TripRepository>();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();

// 5. SERVICES
builder.Services.AddScoped<IDriverService, DriverService>();
builder.Services.AddScoped<IPassengerService, PassengerService>();
builder.Services.AddScoped<ITripService, TripService>();
builder.Services.AddScoped<IVehicleService, VehicleService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
