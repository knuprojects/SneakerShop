#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/Services/Security/Api/Security.Api/Security.Api.csproj", "src/Services/Security/Api/Security.Api/"]
COPY ["src/Services/Security/Application/Security.Application/Security.Application.csproj", "src/Services/Security/Application/Security.Application/"]
COPY ["src/Services/Security/Domain/Security.Domain/Security.Domain.csproj", "src/Services/Security/Domain/Security.Domain/"]
COPY ["src/Services/Security/Infrastructure/Security.Infrastructure/Security.Infrastructure.csproj", "src/Services/Security/Infrastructure/Security.Infrastructure/"]
RUN dotnet restore "src/Services/Security/Api/Security.Api/Security.Api.csproj"
COPY . .
WORKDIR "/src/src/Services/Security/Api/Security.Api"
RUN dotnet build "Security.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Security.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Security.Api.dll"]
