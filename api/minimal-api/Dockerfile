# Usar a imagem base do .NET SDK
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copiar os arquivos do projeto e restaurar dependências
COPY *.csproj .
RUN dotnet restore

# Copiar o restante dos arquivos do projeto
COPY . .
RUN dotnet publish -c Release -o out

# Usar a imagem runtime para executar a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/out .

# Expor a porta
EXPOSE 5000
ENTRYPOINT ["dotnet", "MinhaApi.dll"]
