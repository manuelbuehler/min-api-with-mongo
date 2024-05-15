# 1. Build compile image

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /build
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o out

# 2. Build runtime image
#    mcr.microsoft.com/dotnet/runtime:8.0 für Konsolen-Anwendung (etwas kleiner)
#    mcr.microsoft.com/dotnet/aspnet:8.0 für Web-Anwendung

FROM mcr.microsoft.com/dotnet/aspnet:8.0
LABEL school="GBS"
LABEL module="347"
LABEL author="Manuel Bühler"
WORKDIR /app
COPY --from=build-env /build/out .
ENV  ASPNETCORE_URLS=http://*:5001
EXPOSE 5001
ENTRYPOINT ["dotnet", "WebApi.dll"]