#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["KafkaCDC.KafkaConnectConfigureConsole/KafkaCDC.KafkaConnectConfigureConsole.csproj", "KafkaCDC.KafkaConnectConfigureConsole/"]
RUN dotnet restore "KafkaCDC.KafkaConnectConfigureConsole/KafkaCDC.KafkaConnectConfigureConsole.csproj"
COPY . .
WORKDIR "/src/KafkaCDC.KafkaConnectConfigureConsole"
RUN dotnet build "KafkaCDC.KafkaConnectConfigureConsole.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KafkaCDC.KafkaConnectConfigureConsole.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KafkaCDC.KafkaConnectConfigureConsole.dll"]