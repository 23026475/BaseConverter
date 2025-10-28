# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore
COPY ./NumberConverter/*.csproj ./NumberConverter/
RUN dotnet restore ./NumberConverter/NumberConverter.csproj

# Copy everything and publish
COPY ./NumberConverter ./NumberConverter/
RUN dotnet publish ./NumberConverter/NumberConverter.csproj -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Railway port binding
ENV DOTNET_RUNNING_IN_CONTAINER=true
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

# Run the app
ENTRYPOINT ["dotnet", "NumberConverter.dll"]
