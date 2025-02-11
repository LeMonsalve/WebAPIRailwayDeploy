FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
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

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebAPIRailwayDeploy.dll"]
