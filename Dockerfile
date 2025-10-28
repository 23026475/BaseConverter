# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy and restore dependencies
COPY NumberConverter/*.csproj ./NumberConverter/
RUN dotnet restore NumberConverter/NumberConverter.csproj

# Copy the rest of the files and publish the app
COPY NumberConverter ./NumberConverter/
RUN dotnet publish NumberConverter/NumberConverter.csproj -c Release -o /app/out

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copy published files
COPY --from=build /app/out .

# Listen on Railway PORT dynamically
ENV DOTNET_RUNNING_IN_CONTAINER=true
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

# Use Railway PORT environment variable in command
ENTRYPOINT ["dotnet", "NumberConverter.dll"]
