#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["KafkaCDC.FillDataConsole/KafkaCDC.FillDataConsole.csproj", "KafkaCDC.FillDataConsole/"]
COPY ["KafkaCDC.Domain.FillData/KafkaCDC.Domain.PostgreSQL.csproj", "KafkaCDC.Domain.FillData/"]
COPY ["KafkaCDC.DataAccess.PostgreSQL/KafkaCDC.DataAccess.PostgreSQL.csproj", "KafkaCDC.DataAccess.PostgreSQL/"]
COPY ["KafkaCDC.Settings/KafkaCDC.Settings.csproj", "KafkaCDC.Settings/"]
RUN dotnet restore "KafkaCDC.FillDataConsole/KafkaCDC.FillDataConsole.csproj"
COPY . .
WORKDIR "/src/KafkaCDC.FillDataConsole"
RUN dotnet build "KafkaCDC.FillDataConsole.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KafkaCDC.FillDataConsole.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KafkaCDC.FillDataConsole.dll"]