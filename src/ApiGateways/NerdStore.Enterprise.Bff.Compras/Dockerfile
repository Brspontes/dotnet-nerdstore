#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["./ApiGateways/NerdStore.Enterprise.Bff.Compras/NerdStore.Enterprise.Bff.Compras.csproj", "ApiGateways/NerdStore.Enterprise.Bff.Compras/"]
COPY ["./BuildingBlocks/NerdStore.Enterprise.Core/NerdStore.Enterprise.Core.csproj", "BuildingBlocks/NerdStore.Enterprise.Core/"]
COPY ["./BuildingBlocks/NerdStore.Enterprise.WebAPI.Core/NerdStore.Enterprise.WebAPI.Core.csproj", "BuildingBlocks/NerdStore.Enterprise.WebAPI.Core/"]
COPY ["./BuildingBlocks/NerdStore.Enterprise.MessageBus/NerdStore.Enterprise.MessageBus.csproj", "BuildingBlocks/NerdStore.Enterprise.MessageBus/"]

RUN dotnet restore "ApiGateways/NerdStore.Enterprise.Bff.Compras/NerdStore.Enterprise.Bff.Compras.csproj"
COPY . .
WORKDIR "ApiGateways/NerdStore.Enterprise.Bff.Compras"
RUN dotnet build "NerdStore.Enterprise.Bff.Compras.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NerdStore.Enterprise.Bff.Compras.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NerdStore.Enterprise.Bff.Compras.dll"]