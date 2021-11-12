#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/BikeShop.API/BikeShop.API.csproj", "src/BikeShop.API/"]
RUN dotnet restore "src/BikeShop.API/BikeShop.API.csproj"
COPY . .
WORKDIR "/src/src/BikeShop.API"
RUN dotnet build "BikeShop.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BikeShop.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BikeShop.API.dll"]