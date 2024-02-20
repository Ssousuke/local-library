#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/LocalLibrary.API/LocalLibrary.API.csproj", "src/LocalLibrary.API/"]
COPY ["src/LocalLibrary.Application/LocalLibrary.Application.csproj", "src/LocalLibrary.Application/"]
COPY ["src/LocalLibrary.Domain/LocalLibrary.Domain.csproj", "src/LocalLibrary.Domain/"]
COPY ["src/LocalLibrary.Infra.Data/LocalLibrary.Infra.Data.csproj", "src/LocalLibrary.Infra.Data/"]
COPY ["src/LocalLibrary.IoC/LocalLibrary.IoC.csproj", "src/LocalLibrary.IoC/"]
RUN dotnet restore "./src/LocalLibrary.API/LocalLibrary.API.csproj"
COPY . .
WORKDIR "/src/src/LocalLibrary.API"
RUN dotnet build "./LocalLibrary.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./LocalLibrary.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LocalLibrary.API.dll"]