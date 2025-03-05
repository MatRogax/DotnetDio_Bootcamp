using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using minimal_api.domain.dtos;
using minimal_api.domain.entities;
using minimal_api.domain.infrastructure.Database;
using minimal_api.domain.interfaces;
using minimal_api.domain.ModelViews;
using MinimalApi.domain.services;
using Namespace.Domain.Interfaces;

#region builder
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IVehicleService, VehicleService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DatabaseContent>(options =>
{
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("PostgresConnection")
    );
});
var app = builder.Build();
#endregion

#region Home
app.MapGet("/", () => Results.Json(new Home())).WithTags("Home");
#endregion

#region Admin
app.MapPost("/admin/login", ([FromBody] LoginDto loginDto, IAdminService adminService) =>
{
    if (adminService.Login(loginDto) == null)
    {
        return Results.Unauthorized();
    }
    else
    {
        return Results.Ok("Login efetuado com sucesso!");
    }
}).WithTags("Admin");
#endregion

#region Vehicle
app.MapPost("/vehicles", ([FromBody] VehicleDto vehicleDto, IVehicleService vehicleService) =>
{
    Vehicle vehicle = new Vehicle
    {
        Name = vehicleDto.Name,
        Mark = vehicleDto.Mark,
        Year = vehicleDto.Year

    };

    vehicleService.IncludeVehicle(vehicle);

    return Results.Created($"/vehicle/{vehicle.Id}", vehicle);
}).WithTags("Vehicle");

app.MapGet("/vehicles", ([FromQuery] int? page, IVehicleService vehicleService) =>
{
    var vehicles = vehicleService.AllVehicles(page);

    return Results.Ok(vehicles);
}).WithTags("Vehicle");

app.MapGet("/vehicles/{id}", ([FromRoute] int id, IVehicleService vehicleService) =>
{
    var vehicle = vehicleService.GetVehicle(id);

    if (vehicle == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(vehicle);
}).WithTags("Vehicle");

app.MapPut("/vehicles/{id}", ([FromRoute] int id, VehicleDto vehicleDto, IVehicleService vehicleService) =>
{
    var vehicle = vehicleService.GetVehicle(id);

    if (vehicle == null)
    {
        return Results.NotFound();
    }

    vehicle.Name = vehicleDto.Name;
    vehicle.Mark = vehicleDto.Mark;
    vehicle.Year = vehicleDto.Year;

    vehicleService.UpdateVehicle(vehicle);

    return Results.Ok(vehicle);
}).WithTags("Vehicle");

app.MapDelete("/vehicles/{id}", ([FromRoute] int id, IVehicleService vehicleService) =>
{
    var vehicle = vehicleService.GetVehicle(id);

    if (vehicle == null)
    {
        return Results.NotFound();
    }

    vehicleService.DeleteVehicle(vehicle);
    return Results.NoContent();
}).WithTags("Vehicle");

#endregion

#region App
app.UseSwagger();
app.UseSwaggerUI();
app.Run();
#endregion

