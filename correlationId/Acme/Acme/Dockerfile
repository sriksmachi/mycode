FROM microsoft/aspnetcore:1.1 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:1.1 AS build
WORKDIR /src
COPY Acme/Acme.csproj Acme/
RUN dotnet restore Acme/Acme.csproj
COPY . .
WORKDIR /src/Acme
RUN dotnet build Acme.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Acme.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Acme.dll"]
