using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using minimal_api.domain.dtos;
using minimal_api.domain.infrastructure.Database;
using MinimalApi.domain.services;
using Namespace.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddDbContext<DatabaseContent>(options =>
{
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("PostgresConnection")
    );
});
var app = builder.Build();


// app.MapGet("/", () => "Hello World!");

app.MapPost("/login",([FromBody]LoginDto loginDto,IAdminService adminService) => {
    if(adminService.Login(loginDto) == null) {
        return Results.Unauthorized();
    }else{
        return Results.Ok("Login efetuado com sucesso!");
    }
});

app.Run();
