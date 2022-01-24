#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Recepticon.Api/Recepticon.Api.csproj", "Recepticon.Api/"]
COPY ["Recepticon.Persistence/Recepticon.Persistence.csproj", "Recepticon.Persistence/"]
COPY ["Recepticon.Domain/Recepticon.Domain.csproj", "Recepticon.Domain/"]
COPY ["Recepticon.Core/Recepticon.Core.csproj", "Recepticon.Core/"]
RUN dotnet restore "Recepticon.Api/Recepticon.Api.csproj"
COPY . .
WORKDIR "/src/Recepticon.Api"
RUN dotnet build "Recepticon.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Recepticon.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Recepticon.Api.dll"]