FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
RUN apt-get update && apt-get install -y --no-install-recommends apt-utils clang zlib1g-dev
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["WebAPIRailwayDeploy/WebAPIRailwayDeploy.csproj", "WebAPIRailwayDeploy/"]
RUN dotnet restore "WebAPIRailwayDeploy/WebAPIRailwayDeploy.csproj"
COPY . .
WORKDIR "/src/WebAPIRailwayDeploy"
RUN dotnet build "WebAPIRailwayDeploy.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "WebAPIRailwayDeploy.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/runtime-deps:9.0 AS final
WORKDIR /app
EXPOSE 8080
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebAPIRailwayDeploy.dll"]
