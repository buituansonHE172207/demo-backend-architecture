# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set environment variables
ENV DOCKER_WORKDIR="/app"
ENV DOTNET_ENV="Release"

WORKDIR ${DOCKER_WORKDIR}

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
RUN dotnet publish ./DemoBackendArchitecture.API/DemoBackendArchitecture.API.csproj -c ${DOTNET_ENV} -o out

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Set environment variables
ENV DOCKER_WORKDIR="/app"

WORKDIR ${DOCKER_WORKDIR}

# Create non-root user
RUN addgroup --system appgroup && adduser --system appuser --ingroup appgroup
USER appuser

# Copy the built application from the build stage
COPY --from=build ${DOCKER_WORKDIR}/out .

EXPOSE 8080

# Set the entrypoint for the container
ENTRYPOINT ["dotnet", "DemoBackendArchitecture.API.dll"]
