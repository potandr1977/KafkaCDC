#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["KafkaCDC.FillMongoConsole/KafkaCDC.FillMongoConsole.csproj", "KafkaCDC.FillMongoConsole/"]
COPY ["KafkaCDC.Domain.Mongo/KafkaCDC.Domain.Mongo.csproj", "KafkaCDC.Domain.Mongo/"]
COPY ["KafkaCDC.Settings/KafkaCDC.Settings.csproj", "KafkaCDC.Settings/"]
RUN dotnet restore "KafkaCDC.FillMongoConsole/KafkaCDC.FillMongoConsole.csproj"
COPY . .
WORKDIR "/src/KafkaCDC.FillMongoConsole"
RUN dotnet build "KafkaCDC.FillMongoConsole.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KafkaCDC.FillMongoConsole.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KafkaCDC.FillMongoConsole.dll"]