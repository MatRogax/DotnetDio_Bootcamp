using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using minimal_api.domain.dtos;
using minimal_api.domain.entities;
using minimal_api.domain.Enuns;
using minimal_api.domain.infrastructure.Database;
using minimal_api.domain.interfaces;
using minimal_api.domain.ModelViews;
using MinimalApi.domain.services;
using Namespace.Domain.Interfaces;
using System.Text;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authorization;

#region builder
var builder = WebApplication.CreateBuilder(args);
var key = builder.Configuration["Jwt:Key"];
if (string.IsNullOrEmpty(key))
{
    key = "this_is_my_custom_Secret_key_for_authentication";
}


builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(option =>
{
    option.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateLifetime = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
        ValidateIssuer = false,
        ValidateAudience = false,

    };
});

builder.Services.AddAuthorization();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IVehicleService, VehicleService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Insira o token JWT no formato: Bearer {seu token}"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});


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

string GenerateJwtToken(Admin admin)
{

    var tokenHandler = new JwtSecurityTokenHandler();
    var keyBytes = Encoding.UTF8.GetBytes(key);

    var tokenDescriptor = new SecurityTokenDescriptor
    {
        Subject = new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.Name, admin.Email),
            new Claim(ClaimTypes.Role, admin.Profile)
        }),
        Expires = DateTime.UtcNow.AddHours(1),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
    };

    var token = tokenHandler.CreateToken(tokenDescriptor);
    return tokenHandler.WriteToken(token);
}


app.MapPost("/admin/login", ([FromBody] LoginDto loginDto, IAdminService adminService) =>
{
    var admin = adminService.Login(loginDto);
    string token = "";

    Console.WriteLine(admin);

    if (admin == null)
    {
        return Results.Unauthorized();
    }

    token = GenerateJwtToken(admin);
    return Results.Ok(new adminLogged()
    {
        Email = admin.Email,
        Profile = admin.Profile,
        Token = token
    });

}).WithTags("Admin");

app.MapPost("/admin/create", ([FromBody] AdminDto adminDto, IAdminService adminService) =>
{
    var validation = new ErrorValidations
    {
        Message = new List<string>()
    };

    if (String.IsNullOrEmpty(adminDto.Email))
    {
        validation.Message.Add("Preencha o campo de Email");
    }

    if (String.IsNullOrEmpty(adminDto.Password))
    {
        validation.Message.Add("Preencha o campo de Senha");
    }

    if (String.IsNullOrEmpty(adminDto.Profile.ToString()))
    {
        validation.Message.Add("Perfil não pode ser vazio");
    }

    var admin = new Admin
    {
        Email = adminDto.Email,
        Password = adminDto.Password,
        Profile = adminDto.Profile.ToString() ?? Profile.Editor.ToString(),
    };

    adminService.Create(admin);


}).WithTags("Admin");

app.MapGet("/admins", (int? page, IAdminService adminService) =>
{
    var admins = adminService.AllAdmins(page);

    var adminViews = admins.Select(adm => new AdminModelView
    {
        Id = adm.Id,
        Email = adm.Email,
        Profile = adm.Profile,
    }).ToList();

    return Results.Ok(adminViews);

})
.RequireAuthorization()
.RequireAuthorization(new AuthorizeAttribute { Roles = "Admin" })
.WithTags("Admin");

app.MapGet("/admins/{id}", ([FromRoute] int id, IAdminService adminService) =>
{
    var admin = adminService.FindById(id);

    if (admin == null)
    {
        return Results.NotFound();
    }
    else
    {

        var getAdmin = new AdminModelView
        {
            Id = admin.Id,
            Email = admin.Email,
            Profile = admin.Profile,
        };

        return Results.Ok(getAdmin);
    }


})
.RequireAuthorization()
.RequireAuthorization(new AuthorizeAttribute { Roles = "Admin" })
.WithTags("Admin");

#endregion

#region Vehicle

ErrorValidations validateDtoObj(VehicleDto vehicleDto)
{
    var validations = new ErrorValidations(
        Message: new List<string>()
    );

    if (string.IsNullOrWhiteSpace(vehicleDto.Name))
    {
        validations.Message.Add("Preencha corretamente o campo Name");
    }
    if (string.IsNullOrWhiteSpace(vehicleDto.Mark))
    {
        validations.Message.Add("Preencha corretamente o campo Marca");
    }
    if (vehicleDto.Year < 1950)
    {
        validations.Message.Add("Veículo não pode ter ano menor que 1950");
    }

    return validations;
}

app.MapPost("/vehicles", ([FromBody] VehicleDto vehicleDto, IVehicleService vehicleService) =>
{

    var validations = validateDtoObj(vehicleDto);

    if (validations.Message.Count > 0)
    {
        return Results.BadRequest(validations);
    }

    Vehicle vehicle = new Vehicle
    {
        Name = vehicleDto.Name,
        Mark = vehicleDto.Mark,
        Year = vehicleDto.Year

    };

    vehicleService.IncludeVehicle(vehicle);

    return Results.Created($"/vehicle/{vehicle.Id}", vehicle);
})
.RequireAuthorization()
.RequireAuthorization(new AuthorizeAttribute { Roles = "Admin,Editor", })
.WithTags("Vehicle");

app.MapGet("/vehicles", ([FromQuery] int? page, IVehicleService vehicleService) =>
{
    var vehicles = vehicleService.AllVehicles(page);

    return Results.Ok(vehicles);
}).RequireAuthorization().WithTags("Vehicle");

app.MapGet("/vehicles/{id}", ([FromRoute] int id, IVehicleService vehicleService) =>
{
    var vehicle = vehicleService.GetVehicle(id);

    if (vehicle == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(vehicle);
})
.RequireAuthorization()
.RequireAuthorization(new AuthorizeAttribute { Roles = "Admin,Editor" })
.WithTags("Vehicle");

app.MapPut("/vehicles/{id}", ([FromRoute] int id, VehicleDto vehicleDto, IVehicleService vehicleService) =>
{
    var vehicle = vehicleService.GetVehicle(id);

    if (vehicle == null)
    {
        return Results.NotFound();
    }

    ErrorValidations validations = validateDtoObj(vehicleDto);

    if (validations.Message.Count > 0)
    {
        return Results.BadRequest(validations);
    }

    vehicle.Name = vehicleDto.Name;
    vehicle.Mark = vehicleDto.Mark;
    vehicle.Year = vehicleDto.Year;

    vehicleService.UpdateVehicle(vehicle);

    return Results.Ok(vehicle);
})
.RequireAuthorization()
.RequireAuthorization(new AuthorizeAttribute { Roles = "Admin" })
.WithTags("Vehicle");

app.MapDelete("/vehicles/{id}", ([FromRoute] int id, IVehicleService vehicleService) =>
{
    var vehicle = vehicleService.GetVehicle(id);

    if (vehicle == null)
    {
        return Results.NotFound();
    }

    vehicleService.DeleteVehicle(vehicle);
    return Results.NoContent();
})
.RequireAuthorization()
.RequireAuthorization(new AuthorizeAttribute { Roles = "Admin" })
.WithTags("Vehicle");

#endregion

#region App
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();

app.Run();
#endregion

