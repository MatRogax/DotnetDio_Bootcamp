# ============================================================
# ETAPA 1: Build da aplicação usando o SDK do .NET 9.0
# ============================================================
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copiar o arquivo de projeto e restaurar as dependências
COPY *.csproj ./
RUN dotnet restore

# Copiar todos os arquivos do projeto
COPY . ./

# Publicar a aplicação em modo Release para a pasta "out"
RUN dotnet publish -c Release -o out

# ============================================================
# ETAPA 2: Imagem final de runtime
# ============================================================
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app

# Copiar os arquivos publicados da etapa de build
COPY --from=build /app/out ./

# Expor a porta que sua aplicação utiliza (verifique se é a 5000 ou a configurada na sua API)
EXPOSE 5000

# Ponto de entrada para a aplicação
ENTRYPOINT ["dotnet", "minimal-api.dll"]
