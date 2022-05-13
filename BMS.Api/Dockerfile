#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["BMS.Api/BMS.Api.csproj", "BMS.Api/"]
COPY ["BMS.Application/BMS.Application.csproj", "BMS.Application/"]
COPY ["BMS.Infra/BMS.Infra.csproj", "BMS.Infra/"]
COPY ["BMS.Domain/BMS.Domain.csproj", "BMS.Domain/"]
RUN dotnet restore "BMS.Api/BMS.Api.csproj"
COPY . .
WORKDIR "/src/BMS.Api"
RUN dotnet build "BMS.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BMS.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BMS.Api.dll"]
