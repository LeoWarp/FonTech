FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["FonTech.Api/FonTech.Api.csproj", "FonTech.Api/"]
RUN dotnet restore "FonTech.Api/FonTech.Api.csproj"
COPY . .
WORKDIR "/src/FonTech.Api"
RUN dotnet build "FonTech.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FonTech.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FonTech.Api.dll"]
