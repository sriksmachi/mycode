FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 56876
EXPOSE 44311

FROM microsoft/dotnet:2.1-sdk-nanoserver-1709 AS build
WORKDIR /src
COPY MusicStore/MusicStore.csproj MusicStore/
RUN dotnet restore MusicStore/MusicStore.csproj
COPY . .
WORKDIR /src/MusicStore
RUN dotnet build MusicStore.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish MusicStore.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MusicStore.dll"]
