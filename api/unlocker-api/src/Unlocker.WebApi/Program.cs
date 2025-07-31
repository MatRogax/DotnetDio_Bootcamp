using MediatR;
using Microsoft.EntityFrameworkCore;
using Unlocker.Application;
using Unlocker.Application.Persistence.Abstractions;
using Unlocker.Infrastructure;
using Unlocker.Infrastructure.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(typeof(ApplicationAssemblyMarker));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

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

app.MapControllers();

app.Run();
