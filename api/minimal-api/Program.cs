using minimal_api.domain.dtos;

var builder = WebApplication.CreateBuilder(args);
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
