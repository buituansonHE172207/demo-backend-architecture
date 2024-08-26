# Use the official .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the dependencies file to the working directory 
COPY ./DemoBackendArchitecture.Application/*.csproj ./DemoBackendArchitecture.Application/
COPY ./DemoBackendArchitecture.Domain/*.csproj ./DemoBackendArchitecture.Domain/
COPY ./DemoBackendArchitecture.Infrastructure/*.csproj ./DemoBackendArchitecture.Infrastructure/

# Restore the dependencies and tools
RUN dotnet restore ./DemoBackendArchitecture.Application/DemoBackendArchitecture.Application.csproj
RUN dotnet restore ./DemoBackendArchitecture.Infrastructure/DemoBackendArchitecture.Infrastructure.csproj

# Copy the remaining project files and build the application
COPY ./DemoBackendArchitecture.API/*.csproj ./DemoBackendArchitecture.API/
RUN dotnet restore ./DemoBackendArchitecture.API/DemoBackendArchitecture.API.csproj

# Copy everything else and build
COPY . ./
RUN dotnet publish ./DemoBackendArchitecture.API/DemoBackendArchitecture.API.csproj -c Release -o out

# Use the official .NET runtime image for the final stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

# Set the entrypoint for the container
ENTRYPOINT ["dotnet", "DemoBackendArchitecture.API.dll"]
