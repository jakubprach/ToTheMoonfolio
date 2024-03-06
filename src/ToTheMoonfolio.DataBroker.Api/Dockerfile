# Use the official Microsoft .NET SDK image as the base image for building the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /src

# Copy the main API csproj file and restore as distinct layers
COPY ["ToTheMoonfolio.DataBroker.Api/ToTheMoonfolio.DataBroker.Api.csproj", "ToTheMoonfolio.DataBroker.Api/"]
COPY ["ToTheMoonfolio.DataBroker.Core/ToTheMoonfolio.DataBroker.Core.csproj", "ToTheMoonfolio.DataBroker.Core/"]
COPY ["ToTheMoonfolio.DataBroker.Infrastructure/ToTheMoonfolio.DataBroker.Infrastructure.csproj", "ToTheMoonfolio.DataBroker.Infrastructure/"]
COPY ["ToTheMoonfolio.DataBroker.Publisher/ToTheMoonfolio.DataBroker.Publisher.csproj", "ToTheMoonfolio.DataBroker.Publisher/"]
COPY ["ToTheMoonfolio.ServiceBus/ToTheMoonfolio.ServiceBus.csproj", "ToTheMoonfolio.ServiceBus/"]

WORKDIR "/src/ToTheMoonfolio.DataBroker.Api"
COPY . .
RUN dotnet restore "ToTheMoonfolio.DataBroker.Api/ToTheMoonfolio.DataBroker.Api.csproj"

# Publish the application
FROM build-env AS publish
RUN dotnet publish "ToTheMoonfolio.DataBroker.Api/ToTheMoonfolio.DataBroker.Api.csproj" -c Release -o /app/publish

# Generate the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ToTheMoonfolio.DataBroker.Api.dll"]