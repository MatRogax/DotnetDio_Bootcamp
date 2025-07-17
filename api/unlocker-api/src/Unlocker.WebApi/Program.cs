using MediatR;
using Microsoft.EntityFrameworkCore;
using Unlocker.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// ✅ Adiciona Controllers
builder.Services.AddControllers();

// ✅ Adiciona Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(typeof(ApplicationAssemblyMarker));

// ✅ EF Core + PostgreSQL (Infrastructure Layer)
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// ✅ Middleware de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

// ✅ Mapeia os Controllers
app.MapControllers();

app.Run();

public class ApplicationAssemblyMarker
{
}