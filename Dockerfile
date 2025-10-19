# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY NumberConverter/*.csproj ./NumberConverter/
RUN dotnet restore NumberConverter/NumberConverter.csproj

# Copy everything else and build
COPY NumberConverter ./NumberConverter/
RUN dotnet publish NumberConverter/NumberConverter.csproj -c Release -o /app/out

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

# Railway expects your app to bind to the PORT environment variable
ENV ASPNETCORE_URLS=http://*:$PORT

# 👇 This is the key line (don’t use dotnet run!)
ENTRYPOINT ["dotnet", "NumberConverter.dll"]
