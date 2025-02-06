using Microsoft.EntityFrameworkCore;
using minimal_api.domain.dtos;
using minimal_api.domain.infrastructure.Database;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DatabaseContent>(options =>
{
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("PostgresConnection")
    );
});
var app = builder.Build();


// app.MapGet("/", () => "Hello World!");

app.MapPost("/login",(LoginDto loginDto) => {
    if(loginDto.Email != "adm@teste.com" && loginDto.Password != "123456"){
        return Results.Unauthorized();
    }else{
        return Results.Ok("Login efetuado com sucesso!");
    }
});

app.Run();
