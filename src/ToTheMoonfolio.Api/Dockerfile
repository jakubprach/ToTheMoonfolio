# Use the official Microsoft .NET SDK image as the base image for building the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /src

# Copy the main API csproj file and restore as distinct layers
COPY ["ToTheMoonfolio.Api/ToTheMoonfolio.Api.csproj", "ToTheMoonfolio.Api/"]
COPY ["ToTheMoonfolio.Core/ToTheMoonfolio.Core.csproj", "ToTheMoonfolio.Core/"]
COPY ["ToTheMoonfolio.Infrastructure/ToTheMoonfolio.Infrastructure.csproj", "ToTheMoonfolio.Infrastructure/"]
COPY ["ToTheMoonfolio.Persistence/ToTheMoonfolio.Persistence.csproj", "ToTheMoonfolio.Persistence/"]
COPY ["ToTheMoonfolio.ServiceBus/ToTheMoonfolio.ServiceBus.csproj", "ToTheMoonfolio.ServiceBus/"]

WORKDIR "/src/ToTheMoonfolio.Api"
COPY . .
RUN dotnet restore "ToTheMoonfolio.Api/ToTheMoonfolio.Api.csproj"

# Publish the application
FROM build-env AS publish
RUN dotnet publish "ToTheMoonfolio.Api/ToTheMoonfolio.Api.csproj" -c Release -o /app/publish

# Generate the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ToTheMoonfolio.Api.dll"]