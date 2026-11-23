# Etapa 1: Compilar
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /src

COPY *.csproj ./
RUN dotnet restore

COPY . .

RUN dotnet publish -c Release -o /app/publish

# Etapa 2: Ejecutar
FROM mcr.microsoft.com/dotnet/aspnet:10.0

WORKDIR /app

ENV ASPNETCORE_HTTP_PORTS=8080

EXPOSE 8080

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "MVCWebASPCore.dll"]