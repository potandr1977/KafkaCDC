#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["KafkaCDC.ProjectionConsole/KafkaCDC.ProjectionConsole.csproj", "KafkaCDC.ProjectionConsole/"]
COPY ["KafkaCDC.DataAccess.Elastic/KafkaCDC.DataAccess.Elastic.csproj", "KafkaCDC.DataAccess.Elastic/"]
COPY ["KafkaCDC.Domain.Elastic/KafkaCDC.Domain.Elastic.csproj", "KafkaCDC.Domain.Elastic/"]
COPY ["KafkaCDC.Domain.Mongo/KafkaCDC.Domain.Mongo.csproj", "KafkaCDC.Domain.Mongo/"]
COPY ["KafkaCDC.Settings/KafkaCDC.Settings.csproj", "KafkaCDC.Settings/"]
RUN dotnet restore "KafkaCDC.ProjectionConsole/KafkaCDC.ProjectionConsole.csproj"
COPY . .
WORKDIR "/src/KafkaCDC.ProjectionConsole"
RUN dotnet build "KafkaCDC.ProjectionConsole.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KafkaCDC.ProjectionConsole.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KafkaCDC.ProjectionConsole.dll"]