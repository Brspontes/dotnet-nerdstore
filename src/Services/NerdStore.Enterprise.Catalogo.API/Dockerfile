#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/Services/NerdStore.Enterprise.Catalogo.API/NerdStore.Enterprise.Catalogo.API.csproj", "src/Services/NerdStore.Enterprise.Catalogo.API/"]
RUN dotnet restore "src/Services/NerdStore.Enterprise.Catalogo.API/NerdStore.Enterprise.Catalogo.API.csproj"
COPY . .
WORKDIR "/src/src/Services/NerdStore.Enterprise.Catalogo.API"
RUN dotnet build "NerdStore.Enterprise.Catalogo.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NerdStore.Enterprise.Catalogo.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NerdStore.Enterprise.Catalogo.API.dll"]