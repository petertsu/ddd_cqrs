FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk-nanoserver-1709 AS build
WORKDIR /src
COPY CqrsDemo.Host/CqrsDemo.Host.csproj CqrsDemo.Host/
RUN dotnet restore CqrsDemo.Host/CqrsDemo.Host.csproj
COPY . .
WORKDIR /src/CqrsDemo.Host
RUN dotnet build CqrsDemo.Host.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish CqrsDemo.Host.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CqrsDemo.Host.dll"]
