# Context: .
# Command: docker build -f src/FilterLists.Api/Dockerfile .

# init base
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-alpine as base
WORKDIR /app
EXPOSE 80
ENTRYPOINT ["dotnet", "FilterLists.Api.dll"]

# init build
FROM mcr.microsoft.com/dotnet/core/sdk:2.2-alpine AS build

# restore
WORKDIR /app/src
COPY src/FilterLists.Data/FilterLists.Data.csproj FilterLists.Data/
COPY src/FilterLists.Services/FilterLists.Services.csproj FilterLists.Services/
WORKDIR /app/src/FilterLists.Api
COPY src/FilterLists.Api/FilterLists.Api.csproj .
RUN dotnet restore

# build
WORKDIR /app/src
COPY src/FilterLists.Data/. FilterLists.Data/
COPY src/FilterLists.Services/. FilterLists.Services/
WORKDIR /app/src/FilterLists.Api
COPY src/FilterLists.Api/. .
RUN dotnet build -c Release --no-restore

# init data migration test
FROM build AS migrate-data
COPY data/. data/
WORKDIR /app/src/FilterLists.Data
ENTRYPOINT ["dotnet", "ef", "migrations", "--startup-project", "../FilterLists.Api", "add"]

# init Services.Tests
FROM build AS test-services
ENTRYPOINT ["dotnet", "test"]

# restore Services.Tests
WORKDIR /app/tests/FilterLists.Services.Tests
COPY tests/FilterLists.Services.Tests/FilterLists.Services.Tests.csproj .
RUN dotnet restore

# build Services.Tests
COPY tests/FilterLists.Services.Tests/. .
RUN dotnet build -c Release --no-restore

# publish
FROM migrate-data AS publish
WORKDIR /app/src/FilterLists.Api
RUN dotnet publish -c Release -o out --no-restore --no-build

# final
FROM base as final
COPY --from=publish /app/src/FilterLists.Api/out .
