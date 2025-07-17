# Etapa 1: Build da aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia tudo
COPY . .

# Restaura dependências
RUN dotnet restore "src/Unlocker.WebApi/Unlocker.WebApi.csproj"

# Publica a aplicação
RUN dotnet publish "src/Unlocker.WebApi/Unlocker.WebApi.csproj" -c Release -o /app/publish

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 5000
ENTRYPOINT ["dotnet", "Unlocker.WebApi.dll"]