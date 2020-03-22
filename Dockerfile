#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ONKDelprojekt1Frontend/ONKDelprojekt1Frontend.csproj", "ONKDelprojekt1Frontend/"]
RUN dotnet restore "ONKDelprojekt1Frontend/ONKDelprojekt1Frontend.csproj"
COPY . .
WORKDIR "/src/ONKDelprojekt1Frontend"
RUN dotnet build "ONKDelprojekt1Frontend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ONKDelprojekt1Frontend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ONKDelprojekt1Frontend.dll"]