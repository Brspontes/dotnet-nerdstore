#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["./Web/NerdStore.Enterprise.Web/NerdStore.Enterprise.Web.csproj", "Web/NerdStore.Enterprise.Web/"]
COPY ["./BuildingBlocks/NerdStore.Enterprise.Core/NerdStore.Enterprise.Core.csproj", "BuildingBlocks/NerdStore.Enterprise.Core/"]
COPY ["./BuildingBlocks/NerdStore.Enterprise.WebAPI.Core/NerdStore.Enterprise.WebAPI.Core.csproj", "BuildingBlocks/NerdStore.Enterprise.WebAPI.Core/"]

RUN dotnet restore "./Web/NerdStore.Enterprise.Web/NerdStore.Enterprise.Web.csproj"
COPY . .
WORKDIR "Web/NerdStore.Enterprise.Web"
RUN dotnet build "NerdStore.Enterprise.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NerdStore.Enterprise.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NerdStore.Enterprise.Web.dll"]