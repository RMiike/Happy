FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["./src/api/H.API/H.API.csproj", "src/api/H.API/"]
COPY ["./src/data/H.Data/H.Data.csproj", "src/data/H.Data/"]
COPY ["./src/building blocks/H.BuildingBlocks/H.BuildingBlocks.csproj", "src/building blocks/H.BuildingBlocks/"]
COPY ["./src/domain/H.Domain/H.Domain.csproj", "src/domain/H.Domain/"]
COPY ["./src/services/H.Services/H.Services.csproj", "src/services/H.Services/"]

RUN dotnet restore "src/api/H.API/H.API.csproj"
COPY . .
WORKDIR "src/api/H.API"
RUN dotnet build "H.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "H.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# ENTRYPOINT ["dotnet", "H.API.dll"]

CMD ASPNETCORE_URLS=http://*:$PORT dotnet "H.API.dll"

RUN mkdir -p /app/Images