#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Refiq6.Api/Refiq6.Api.csproj", "Refiq6.Api/"]
COPY ["Refiq6.Application/Refiq6.Application.csproj", "Refiq6.Application/"]
COPY ["Refiq6.Domain/Refiq6.Domain.csproj", "Refiq6.Domain/"]
COPY ["Refiq6.Infrastructure/Refiq6.Infrastructure.csproj", "Refiq6.Infrastructure/"]
RUN dotnet restore "./Refiq6.Api/Refiq6.Api.csproj"
COPY . .
WORKDIR "/src/Refiq6.Api"
RUN dotnet build "./Refiq6.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Refiq6.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Refiq6.Api.dll"]