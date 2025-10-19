# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy and restore
COPY NumberConverter/*.csproj ./NumberConverter/
RUN dotnet restore NumberConverter/NumberConverter.csproj

# Copy the rest and build
COPY NumberConverter ./NumberConverter/
RUN dotnet publish NumberConverter/NumberConverter.csproj -c Release -o /app/out

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

# Railway sets the PORT environment variable automatically
ENV ASPNETCORE_URLS=http://*:$PORT

# ✅ Run the compiled DLL — not `dotnet run`
ENTRYPOINT ["dotnet", "NumberConverter.dll"]
