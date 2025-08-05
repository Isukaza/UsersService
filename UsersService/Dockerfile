FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY UsersService/UsersService.csproj UsersService/
COPY DAL/DAL.csproj DAL/
RUN dotnet restore "UsersService/UsersService.csproj"

COPY . .
WORKDIR /src/UsersService
RUN dotnet publish "UsersService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

ENV DOTNET_RUNNING_IN_CONTAINER=true \
    ASPNETCORE_URLS="https://+:8443;http://+:8080" \
    ASPNETCORE_Kestrel__Certificates__Default__Path=/app/certs/cert.pfx

EXPOSE 8080
EXPOSE 8443

ENTRYPOINT ["dotnet", "UsersService.dll"]