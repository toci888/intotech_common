# Wybór obrazu bazowego z .NET SDK
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Ustawienie katalogu roboczego wewnątrz kontenera
WORKDIR /app

# Skopiowanie projektu do kontenera
COPY . .

# Przygotowanie projektu VSIX
    RUN dotnet restore
RUN dotnet build --configuration Release

# Wykorzystaj drugi etap do utrzymania tylko wymaganych plików
FROM mcr.microsoft.com/dotnet/runtime:6.0
WORKDIR /app
COPY --from=build /app .

    ENTRYPOINT ["dotnet", "build"]