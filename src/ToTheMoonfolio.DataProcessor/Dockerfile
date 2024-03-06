# Use the official Microsoft .NET SDK image as the base image for building the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /src

# Copy the main API csproj file and restore as distinct layers
COPY ["ToTheMoonfolio.DataProcessor/ToTheMoonfolio.DataProcessor.csproj", "ToTheMoonfolio.DataProcessor/"]
COPY ["ToTheMoonfolio.ServiceBus/ToTheMoonfolio.ServiceBus.csproj", "ToTheMoonfolio.ServiceBus/"]

WORKDIR "/src/ToTheMoonfolio.DataProcessor"
COPY . .
RUN dotnet restore "ToTheMoonfolio.DataProcessor/ToTheMoonfolio.DataProcessor.csproj"

# Publish the application
FROM build-env AS publish
RUN dotnet publish "ToTheMoonfolio.DataProcessor/ToTheMoonfolio.DataProcessor.csproj" -c Release -o /app/publish

# Generate the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ToTheMoonfolio.DataProcessor.dll"]