# =========================
# Stage 1: Build
# =========================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy csproj and restore dependencies
COPY NumberConverter/*.csproj ./NumberConverter/
RUN dotnet restore NumberConverter/NumberConverter.csproj

# Copy everything else and publish
COPY NumberConverter ./NumberConverter/
RUN dotnet publish NumberConverter/NumberConverter.csproj -c Release -o /app/out

# =========================
# Stage 2: Runtime
# =========================
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copy published files from build stage
COPY --from=build /app/out .

# Tell ASP.NET Core to listen on the port Railway provides
ENV ASPNETCORE_URLS=http://+:$PORT

# Run the app
ENTRYPOINT ["dotnet", "NumberConverter.dll"]
