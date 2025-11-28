using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

// --- AQUÍ ESTÁ EL TRUCO: Creamos un "apodo" para evitar choques ---
using OpenApi = Microsoft.OpenApi.Models;

using ProyectoFinal.Data;
using ProyectoFinal.Repositories;
using ProyectoFinal.Services;

var builder = WebApplication.CreateBuilder(args);

// --- 1. CONFIGURACIÓN DE SERVICIOS ---

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Configuración de Swagger usando el apodo "OpenApi"
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApi.OpenApiInfo
    {
        Title = "Transport API",
        Version = "v1",
        Description = "API de Transporte con Autenticación JWT"
    });

    // Configuración del botón "Authorize"
    c.AddSecurityDefinition("Bearer", new OpenApi.OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Enter 'Bearer' [space] and then your token.",
        Name = "Authorization",
        In = OpenApi.ParameterLocation.Header,
        Type = OpenApi.SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApi.OpenApiSecurityRequirement
    {
        {
            new OpenApi.OpenApiSecurityScheme
            {
                Reference = new OpenApi.OpenApiReference
                {
                    Type = OpenApi.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = OpenApi.ParameterLocation.Header
            },
            new List<string>()
        }
    });
});

// Base de Datos
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositorios
builder.Services.AddScoped<IPassengerRepository, PassengerRepository>();
builder.Services.AddScoped<IDriverRepository, DriverRepository>();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
builder.Services.AddScoped<ITripRepository, TripRepository>();

// Servicios
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IPassengerService, PassengerService>();
builder.Services.AddScoped<IDriverService, DriverService>();
builder.Services.AddScoped<IVehicleService, VehicleService>();
builder.Services.AddScoped<ITripService, TripService>();

// --- 2. CONFIGURACIÓN DE SEGURIDAD (JWT) ---

var key = builder.Configuration["Jwt:Key"] ?? "super_secret_key_12345_must_be_long_enough";

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

var app = builder.Build();

// --- 3. PIPELINE HTTP ---

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();